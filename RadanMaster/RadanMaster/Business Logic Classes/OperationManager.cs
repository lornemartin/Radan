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
            associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.operationID == OrderItemOp.operationID).ToList();

            opsPerformed = Globals.dbContext.OperationPerformeds.Where(op => op.OrderItemOperations.FirstOrDefault().operationID == OrderItemOp.operationID).ToList();

            //List<Models.OperationPerformed> filteredOpsPerformed = new List<Models.OperationPerformed>();

            //foreach (Models.OperationPerformed opPerformed in opsPerformed)
            //{
            //    if (associatedOrderItemOps.Contains(opPerformed.OrderItemOperations.First()))   // should be using user filtered list here....
            //    {
            //        filteredOpsPerformed.Add(opPerformed);
            //    }
            //}

            //opsPerformed = filteredOpsPerformed;
            overBatchQty = associatedOrderItemOps.Sum(x => x.qtyDone) - associatedOrderItemOps.Sum(x => x.qtyRequired);

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

        public Stream GetPDFStream()
        {
            Models.Part p = OrderItemOp.operation.Part;
            if (p.Files.Count > 0)
                return new MemoryStream(p.Files.FirstOrDefault().Content);
            else
                return null;
        }

        public bool HasUnassignedOperationsPerformed()
        {
            // get a list of all associated order items that are not linked to an order item
            List<Models.OrderItemOperation> overBatchItemOps = associatedOrderItemOps.Where(o => o.operationID == OrderItemOp.operationID)
                                                                                     .Where(o => o.qtyRequired == 0).ToList();

            List<Models.OrderItemOperation> inCompleteBatchItemOps = associatedOrderItemOps.Where(o => o.operationID == OrderItemOp.operationID)
                                                                                           .Where(o => o.qtyDone < o.qtyRequired).ToList();

            int qtyExtra = overBatchItemOps.Sum(x => x.qtyDone);

            if (qtyExtra > 0 && inCompleteBatchItemOps.Count > 0) return true;
            else return false;
        }

        public void AssignUnAssignedOperations()
        {

            // get a list of all associated order items that are not complete
            List<Models.OrderItemOperation> overBatchItemOps = associatedOrderItemOps.Where(o => o.operationID == OrderItemOp.operationID)
                                                                                     .Where(o => o.qtyRequired == 0).ToList();

            List<Models.OrderItemOperation> inCompleteBatchItemOps = associatedOrderItemOps.Where(o => o.operationID == OrderItemOp.operationID)
                                                                                           .Where(o => o.qtyDone < o.qtyRequired).ToList();

            foreach (Models.OrderItemOperation overBatchItemOp in overBatchItemOps)
            {
                foreach (Models.OrderItemOperation inCompleteBatchItemOp in inCompleteBatchItemOps)
                {
                    if (overBatchItemOp.qtyDone <= inCompleteBatchItemOp.qtyRequired - inCompleteBatchItemOp.qtyDone)
                    {
                        // we can get rid of overBatchItemOp and move it all into the inCompleteBatchItem

                        inCompleteBatchItemOp.qtyDone += overBatchItemOp.qtyDone;
                        if (!inCompleteBatchItemOp.operationsPerformed.Contains(overBatchItemOp.operationsPerformed.FirstOrDefault()))
                            inCompleteBatchItemOp.operationsPerformed.Add(overBatchItemOp.operationsPerformed.FirstOrDefault());
                        Globals.dbContext.OrderItemOperations.Remove(overBatchItemOp);

                        break;  // no further work needed on this overBatchItem
                    }
                    else if (overBatchItemOp.qtyDone > inCompleteBatchItemOp.qtyRequired - inCompleteBatchItemOp.qtyDone)
                    {
                        // reduce the quantity of the overBatchItemOp quantityDone
                        overBatchItemOp.qtyDone -= (inCompleteBatchItemOp.qtyRequired - inCompleteBatchItemOp.qtyDone);
                        // and this inCompleteBatchItem will now be complete...
                        inCompleteBatchItemOp.qtyDone = inCompleteBatchItemOp.qtyRequired;

                        if (!inCompleteBatchItemOp.operationsPerformed.Contains(overBatchItemOp.operationsPerformed.FirstOrDefault()))
                            inCompleteBatchItemOp.operationsPerformed.Add(overBatchItemOp.operationsPerformed.FirstOrDefault());

                        continue;   // continue on with next iteration of this loop to fill up all the incompleteOpItems

                    }
                }
            }

            Globals.dbContext.SaveChanges();
            RefreshDataStructures();
        }

        public void RecordOperationCompleted(int count)
        {
            int qtyLeftToRecord = count;

            // first create the opPerformed record.
            Models.OperationPerformed opPerformed = new Models.OperationPerformed();
            opPerformed.qtyDone = count;
            opPerformed.timePerformed = DateTime.Now;
            opPerformed.usr = currentUser;
            opPerformed.Notes = "";
            opPerformed.OrderItemOperations = new List<Models.OrderItemOperation>();

            // then fill out the quantities done of the orderItemOps 
            foreach (Models.OrderItemOperation op in associatedOrderItemOps)
            {
                if (op.qtyDone < op.qtyRequired)
                {
                    opPerformed.OrderItemOperations.Add(op);    //link the operation to the operationPerformed

                    if (qtyLeftToRecord >= op.qtyRequired - op.qtyDone)  // if we have enough left to record to fill remaining orderItemOp...
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
            {
                overBatchQty = 0;
                overBatchQty += qtyLeftToRecord;
                Models.OrderItemOperation overBatchItem = new Models.OrderItemOperation();
                overBatchItem.operation = OrderItemOp.operation;
                overBatchItem.operationsPerformed.Add(opPerformed);
                overBatchItem.orderItem = null;
                overBatchItem.qtyRequired = 0;
                overBatchItem.qtyDone = overBatchQty;
                Globals.dbContext.OrderItemOperations.Add(overBatchItem);
            }
            else
                overBatchQty = 0;

            Globals.dbContext.OperationPerformeds.Add(opPerformed);
            Globals.dbContext.SaveChanges();
        }

        public void RemoveOperationCompleted(int operationPerformedID)
        {
            Models.OperationPerformed opToRemove = Globals.dbContext.OperationPerformeds.Where(o => o.ID == operationPerformedID).FirstOrDefault();
            List<Models.OrderItemOperation> orderItemOpsToModify = associatedOrderItemOps.OrderByDescending(o => o.ID).ToList();

            int numToRemove = opToRemove.qtyDone;
            int index = 0;
            foreach (Models.OrderItemOperation itemOpToCheck in orderItemOpsToModify.ToList())
            {
                if (numToRemove < itemOpToCheck.qtyDone)
                {
                    // if operationPerformed to remove fits inside the first itemOperation
                    //  but does not completely fill it,
                    //  we only have to adjust the quantity done on the itemOperation, and 
                    //  remove the link to the itemOperation
                    //  and remove the operationPerformed
                    itemOpToCheck.qtyDone -= numToRemove;
                    numToRemove = 0;

                    // remove the operationPerformed record
                    itemOpToCheck.operationsPerformed.Remove(opToRemove);
                    Globals.dbContext.OperationPerformeds.Remove(opToRemove);

                    break; // all done
                }

                else
                {
                    // if operationPerformed to remove fits exactly, or is bigger than
                    //  the itemOpToCheck qtyDone,
                    //  
                    numToRemove -= itemOpToCheck.qtyDone;
                    itemOpToCheck.qtyDone = 0;

                    // remove orderItemOp if it's not linked to any orders.
                    if (itemOpToCheck.orderItem == null)
                    {
                        // if itemOpToCheck has a link to an operation performed, we need to copy this link over to a different itemOp that won't be removed
                        if (itemOpToCheck.operationsPerformed.Count > 0)
                        {
                            //orderItemOpsToModify.ElementAtOrDefault(index + 1).operationsPerformed
                            List<Models.OperationPerformed> associatedOps = itemOpToCheck.operationsPerformed.ToList();

                            foreach(Models.OperationPerformed associatedOp in associatedOps)
                            {
                                if(!orderItemOpsToModify.ElementAt(index +1).operationsPerformed.Contains(associatedOp))
                                    orderItemOpsToModify.ElementAt(index + 1).operationsPerformed.Add(associatedOp);
                            }
                        }

                        Globals.dbContext.OrderItemOperations.Remove(itemOpToCheck);
                    }

                    if (numToRemove == 0)
                    {
                        // remove the operationPerformed record
                        itemOpToCheck.operationsPerformed.Remove(opToRemove);
                        Globals.dbContext.OperationPerformeds.Remove(opToRemove);
                    }

                    index++;
                    continue;   // continue to next iteration of loop
                }
            }

            Globals.dbContext.SaveChanges();
        }
    }
}
