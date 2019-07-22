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

        public Stream GetPDFStream()
        {
            Models.Part p = OrderItemOp.operation.Part;
            return new MemoryStream(p.Files.FirstOrDefault().Content);
        }


        public bool HasUnassignedOperationsPerformed(out int qtyOverBatchItemOps, out int qtyUnAssignedBatchItemOps, out string opName, out string partName)
        {
            qtyOverBatchItemOps = 0;
            qtyUnAssignedBatchItemOps = 0;
            opName = "test";
            partName = "test";

            return false;
        }

        public void AssignUnfinishedOperations()
        {

        }

        public void RecordOperationCompleted(int count)
        {

        }

        public List<Models.OrderItemOperationPerformed> GetAssociatedOrderItemOperationPerformeds(Models.OrderItemOperation op)
        {
            return null;
        }

    }
}
