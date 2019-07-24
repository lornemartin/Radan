using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPdfViewer;
using System.IO;

namespace RadanMaster
{
    public class OperationManager
    {
        Models.OrderItemOperation OrderItemOp { get; set; }
        bool updateAll { get; set; }
        Models.User currentUser { get; set; }
        List<Models.OrderItemOperation> associatedOrderItemOps { get; set; }
        List<Models.OrderItemOperationPerformed> itemOpsPerformed { get; set; }
        List<Models.OperationPerformed> opsPerformed { get; set; }
        List<Models.OrderItemOperation> unFinishedOrderItemOps { get; set; }
        List<Models.OrderItemOperation> overBatchOrderItemOps { get; set; }

        public OperationManager(Models.OrderItemOperation orderItemOp, Models.User usr)
        {
            currentUser = usr;
            OrderItemOp = orderItemOp;
        }

        public void RefreshDataStructures()
        {
            associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
                                                                         .Where(o => o.operationID == OrderItemOp.operationID).ToList();

            // then find all the associated orderItemOperations that have not been applied to an order item yet
            overBatchOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItemID == null)
                                                                         .Where(o => o.operation.PartID == OrderItemOp.operation.PartID).ToList();
            // now combine the two lists into one.
            associatedOrderItemOps.AddRange(overBatchOrderItemOps);

            // find all the unfinishedOrderItemOps
            unFinishedOrderItemOps = associatedOrderItemOps.Where(o => o.qtyDone < o.qtyRequired).ToList();

            opsPerformed = Globals.dbContext.OperationPerformeds.Where(op => op.OrderItemOperationsPerformed.FirstOrDefault().orderItemOperation.operationID == OrderItemOp.operationID).ToList();
        }

        public List<Models.OrderItemOperation> GetAssociatedOrderItemOperations()
        {
            return associatedOrderItemOps;
        }

        public List<Models.OperationPerformed> GetOperationsPerformed()
        {
            return opsPerformed;
        }

        public List<Models.OrderItemOperationPerformed> GetAssociatedOrderItemOperationPerformeds(Models.OrderItemOperation op)
        {
            List<Models.OrderItemOperationPerformed> opsPerformed = Globals.dbContext.OrderItemOperationPerformeds.Where(o => o.orderItemOperation.ID == op.ID).ToList();
            return opsPerformed;
        }

        public Stream GetPDFStream()
        {
            Models.Part p = OrderItemOp.operation.Part;
            return new MemoryStream(p.Files.FirstOrDefault().Content);
        }


        public bool HasUnassignedOperationsPerformed(out int qtyOverBatchItemOps, out int qtyUnAssignedBatchItemOps, out string opName, out string partName)
        {
            qtyOverBatchItemOps = 0;
            qtyUnAssignedBatchItemOps = 0;
            opName = "";
            partName = "";
            
            if (overBatchOrderItemOps != null)
                qtyOverBatchItemOps = overBatchOrderItemOps.Sum(x => x.qtyDone);

            if (unFinishedOrderItemOps != null)
                qtyUnAssignedBatchItemOps = unFinishedOrderItemOps.Sum(x => x.qtyRequired);

            if (qtyOverBatchItemOps > 0 && qtyUnAssignedBatchItemOps > 0)
            {
                opName = overBatchOrderItemOps.FirstOrDefault().operation.Name;
                partName = overBatchOrderItemOps.FirstOrDefault().operation.Part.FileName;
                return true;
            }
            else
                return false;
        }

        public void AssignUnAssignedOperations()
        {

            foreach (Models.OrderItemOperation unFinishedItemOperation in unFinishedOrderItemOps.ToList())
            {
                foreach (Models.OrderItemOperation overBatchItemOperation in overBatchOrderItemOps.ToList())
                {
                    Models.OrderItemOperationPerformed oiOpPerformed = overBatchItemOperation.OrderItemOperationPerformeds.FirstOrDefault();

                    int qtyRemaining = unFinishedItemOperation.qtyRequired - unFinishedItemOperation.qtyDone;
                    if (qtyRemaining >= overBatchItemOperation.qtyRequired) // if overBatchItemOp fits inside of unFinishedItemOp, things will be easy.
                    {
                        overBatchItemOperation.OrderItemOperationPerformeds.Clear();        // clear the orderItemOperationPerformed from the overBatchOrderItem
                        Globals.dbContext.OrderItemOperations.Remove(overBatchItemOperation);       // remove the overBatchItem from the DB

                        unFinishedItemOperation.OrderItemOperationPerformeds.Add(oiOpPerformed);    // add the orderItemOperationPerformed to the unFinishedOrderItem now
                        unFinishedItemOperation.qtyDone += overBatchItemOperation.qtyDone;          // increment the qty done on the unFinishedItemOp
                    }
                    else        // if overBatchItemOp doesn't all fit inside of unFinishedItemOp, we'll have to split up the OrderItemOperationPerformed
                    {
                        // we'll modify the original opPerformed and keep it attached to the original unFinishedOp
                        // modify the original 'over' orderItemOpPerformed
                        oiOpPerformed.qtyDone = qtyRemaining;

                        // modify the original 'over' orderItem
                        overBatchItemOperation.qtyDone = qtyRemaining;

                        //// create a new orderItemOpPerformed
                        //Models.OrderItemOperationPerformed newOrderItemOpPerformed = new Models.OrderItemOperationPerformed();
                        //newOrderItemOpPerformed.qtyDone = unFinishedItemOperation.qtyRemaining;
                        //newOrderItemOpPerformed.orderItemOperation = remainingOrderItemOp;

                        //// add the itemOpPerformed to the itemOp
                        //remainingOrderItemOp.OrderItemOperationPerformeds.Add(newOrderItemOpPerformed);
                    }
                }
            }

            Globals.dbContext.SaveChanges();
        }

        public void RecordOperationCompleted(int count)
        {
            List<Models.OrderItem> unassignedOrderItems = Globals.dbContext.OrderItems.Where(o => o.IsComplete == false)
                                                                        .Where(o => o.Part.ID == OrderItemOp.orderItem.PartID).ToList();
            int qtyToAllocate = count;
            int qtyAllocatedRunningTotal = 0;

            Models.OperationPerformed opPerformed = new Models.OperationPerformed();
            opPerformed.qtyDone = qtyToAllocate;
            opPerformed.timePerformed = DateTime.Now;
            opPerformed.usr = currentUser;
            opPerformed.Notes = "";
            opPerformed.OrderItemOperationsPerformed = new List<Models.OrderItemOperationPerformed>();

            foreach (Models.OrderItem orderItem in unassignedOrderItems.ToList())
            {
                if (orderItem.QtyRequired <= qtyToAllocate - qtyAllocatedRunningTotal)
                {
                    orderItem.QtyNested = orderItem.QtyRequired;
                    qtyAllocatedRunningTotal += orderItem.QtyRequired;

                    Models.OrderItemOperationPerformed orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                    orderItemOpPerformed.qtyDone = orderItem.QtyRequired;
                    orderItemOpPerformed.orderItemOperation = OrderItemOp;
                    orderItemOpPerformed.opPerformed = opPerformed;
                    Globals.dbContext.OrderItemOperationPerformeds.Add(orderItemOpPerformed);

                    opPerformed.OrderItemOperationsPerformed.Add(orderItemOpPerformed);
                }
            }

            // if we still have some left to allocate after all open batches have been filled, we'll have to 
            //  create a new opPerformed without linking it to an orderItem
            if(qtyAllocatedRunningTotal < qtyToAllocate)
            {
                Models.OrderItemOperationPerformed orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                orderItemOpPerformed.qtyDone = qtyToAllocate - qtyAllocatedRunningTotal;
                orderItemOpPerformed.orderItemOperation = null;
                orderItemOpPerformed.opPerformed = opPerformed;
                Globals.dbContext.OrderItemOperationPerformeds.Add(orderItemOpPerformed);

                opPerformed.OrderItemOperationsPerformed.Add(orderItemOpPerformed);
            }

            Globals.dbContext.OperationPerformeds.Add(opPerformed);
            Globals.dbContext.SaveChanges();
        }
    }
}
