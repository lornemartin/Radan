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
        int overBatchQty { get; set; }
        bool updateAll { get; set; }
        Models.User currentUser { get; set; }
        List<Models.OrderItemOperation> associatedOrderItemOps { get; set; }
        List<Models.OperationPerformed> opsPerformed { get; set; }

        public OperationManager(Models.OrderItemOperation orderItemOp, Models.User usr)
        {
            currentUser = usr;
            OrderItemOp = orderItemOp;
        }

        public int RefreshDataStructures()
        {
            associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
                                                                         .Where(o => o.operationID == OrderItemOp.operationID).ToList();

            opsPerformed = Globals.dbContext.OperationPerformeds.Where(op => op.OrderItemOperationsPerformed.FirstOrDefault().orderItemOperation.operationID == OrderItemOp.operationID).ToList();

            overBatchQty = associatedOrderItemOps.Sum(x => x.qtyDone) - opsPerformed.Sum(x => x.qtyDone);

            return overBatchQty;

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


        //public bool HasUnassignedOperationsPerformed(out int qtyOverBatchItemOps, out int qtyUnAssignedBatchItemOps, out string opName, out string partName)
        //{
        //    qtyOverBatchItemOps = 0;
        //    qtyUnAssignedBatchItemOps = 0;
        //    opName = "";
        //    partName = "";
            
        //    if (overBatchOrderItemOps != null)
        //        qtyOverBatchItemOps = overBatchOrderItemOps.Sum(x => x.qtyDone);

        //    if (unFinishedOrderItemOps != null)
        //        qtyUnAssignedBatchItemOps = unFinishedOrderItemOps.Sum(x => x.qtyRequired);

        //    if (qtyOverBatchItemOps > 0 && qtyUnAssignedBatchItemOps > 0)
        //    {
        //        opName = overBatchOrderItemOps.FirstOrDefault().operation.Name;
        //        partName = overBatchOrderItemOps.FirstOrDefault().operation.Part.FileName;
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public void AssignUnAssignedOperations()
        //{

        //    foreach (Models.OrderItemOperation unFinishedItemOperation in unFinishedOrderItemOps.ToList())
        //    {
        //        foreach (Models.OrderItemOperation overBatchItemOperation in overBatchOrderItemOps.ToList())
        //        {
        //            Models.OrderItemOperationPerformed oiOpPerformed = overBatchItemOperation.OrderItemOperationPerformeds.FirstOrDefault();

        //            int qtyRemaining = unFinishedItemOperation.qtyRequired - unFinishedItemOperation.qtyDone;
        //            if (qtyRemaining >= overBatchItemOperation.qtyRequired) // if overBatchItemOp fits inside of unFinishedItemOp, things will be easy.
        //            {
        //                overBatchItemOperation.OrderItemOperationPerformeds.Clear();        // clear the orderItemOperationPerformed from the overBatchOrderItem
        //                Globals.dbContext.OrderItemOperations.Remove(overBatchItemOperation);       // remove the overBatchItem from the DB

        //                unFinishedItemOperation.OrderItemOperationPerformeds.Add(oiOpPerformed);    // add the orderItemOperationPerformed to the unFinishedOrderItem now
        //                unFinishedItemOperation.qtyDone += overBatchItemOperation.qtyDone;          // increment the qty done on the unFinishedItemOp
        //            }
        //            else        // if overBatchItemOp doesn't all fit inside of unFinishedItemOp, we'll have to split up the OrderItemOperationPerformed
        //            {
        //                // we'll modify the original opPerformed and keep it attached to the original unFinishedOp
        //                // modify the original 'over' orderItemOpPerformed
        //                oiOpPerformed.qtyDone = qtyRemaining;

        //                // modify the original 'over' orderItem
        //                overBatchItemOperation.qtyDone = qtyRemaining;

        //                //// create a new orderItemOpPerformed
        //                //Models.OrderItemOperationPerformed newOrderItemOpPerformed = new Models.OrderItemOperationPerformed();
        //                //newOrderItemOpPerformed.qtyDone = unFinishedItemOperation.qtyRemaining;
        //                //newOrderItemOpPerformed.orderItemOperation = remainingOrderItemOp;

        //                //// add the itemOpPerformed to the itemOp
        //                //remainingOrderItemOp.OrderItemOperationPerformeds.Add(newOrderItemOpPerformed);
        //            }
        //        }
        //    }

        //    Globals.dbContext.SaveChanges();
        //}

        public void RecordOperationCompleted(int count)
        {
            int qtyLeftToRecord = count;

            // first create the opPerformed record.
            Models.OperationPerformed opPerformed = new Models.OperationPerformed();
            opPerformed.qtyDone = count;
            opPerformed.timePerformed = DateTime.Now;
            opPerformed.usr = currentUser;
            opPerformed.Notes = "";

            // then fill out the quantities done of the orderItemOps 
            foreach(Models.OrderItemOperation op in associatedOrderItemOps)
            {
                if(op.qtyDone < op.qtyRequired)
                {
                    if(qtyLeftToRecord >= op.qtyRequired - op.qtyDone)  // if we have enough left to record to fill remaining orderItemOp...
                    {
                        qtyLeftToRecord -= op.qtyRequired - op.qtyDone;
                        op.qtyDone = op.qtyRequired;
                    }
                    else              // we can only partially fill operation
                    {
                        op.qtyDone += qtyLeftToRecord;
                        qtyLeftToRecord = 0;
                        break;  // exit foreach loop, we don't have any more to record
                    }
                }
            }

            // if we have completed more than we have order items to record against, we need to track this.
            if (qtyLeftToRecord > 0)
                overBatchQty += qtyLeftToRecord;
            else
                overBatchQty = 0;

            Globals.dbContext.OperationPerformeds.Add(opPerformed);
            Globals.dbContext.SaveChanges();
        }
    }
}
