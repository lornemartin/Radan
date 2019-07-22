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
        public OperationManager(Models.OrderItemOperation orderItemOp, Models.User usr)
        {

        }

        public void RefreshDataStructures()
        {

        }

        public List<Models.OrderItem> GetAssociatedOrderItems()
        {
            return null;
        }

        public List<Models.OperationPerformed> GetOperationsPerformed()
        {
            return null;
        }

        public Stream GetPDFStream()
        {
            return null;
        }


        public bool HasUnassignedOperationsPerformed(out int qtyOverBatchItemOps, out int qtyUnAssignedBatchItemOps, out string opName, out string partName)
        {
            return false;
        }

        public void AssignUnfinishedOperations()
        {

        }

        public void RecordOperationCompleted(int count)
        {

        }

        public List<Models.OrderItemOperation> GetAssociatedOrderItemOperationPerformeds()
        {
            return null;
        }

    }
}
