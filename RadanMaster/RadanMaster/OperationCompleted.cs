using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace RadanMaster
{
    public partial class OperationCompleted : Form
    {
        Models.OrderItemOperation OrderItemOp { get; set; }
        bool updateAll { get; set; }
        Models.User currentUser { get; set; }
        List<Models.OrderItemOperation> associatedOrderItemOps { get; set; }
        List<Models.OrderItemOperationPerformed> itemOpsPerformed { get; set; }
        List<Models.OperationPerformed> opsPerformed { get; set; }

        public OperationCompleted(Models.OrderItemOperation orderItemOp, Models.User curUser)
        {
            InitializeComponent();

            currentUser = curUser;
            OrderItemOp = orderItemOp;
        }

        private void OperationCompleted_Load(object sender, EventArgs e)
        {
            Globals.dbContext.Parts.Load();
            Globals.dbContext.Operations.Load();
            Globals.dbContext.OrderItemOperations.Load();
            Globals.dbContext.Orders.Load();
            Globals.dbContext.OrderItems.Load();
            Globals.dbContext.Parts.Load();
            Globals.dbContext.OrderItemOperationPerformeds.Load();
            Globals.dbContext.OperationPerformeds.Load();

            associatedOrderItemOps = new List<Models.OrderItemOperation>();
            associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
                                                                          .Where(o => o.operationID == OrderItemOp.operationID).ToList();
            gridControlAssociatedOrderItems.DataSource = associatedOrderItemOps;

        }

        private void gridViewAssociatedOrderItems_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;
            itemOpsPerformed = new List<Models.OrderItemOperationPerformed>();
            Models.OrderItemOperation orderItemOp = new Models.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewAssociatedOrderItems.GetRow(rowHandle);
                orderItemOp = (Models.OrderItemOperation)o;
            }

            itemOpsPerformed = orderItemOp.OrderItemOperationPerformeds.ToList();
            gridControlOrderItemOpsPerformed.DataSource = itemOpsPerformed;
        }

        private void btnRecordOp_Click(object sender, EventArgs e)
        {
            Models.OrderItemOperation orderItemOp = Globals.dbContext.OrderItemOperations.Where(o => o.ID == OrderItemOp.ID).FirstOrDefault();

            int qtyDone = 0;
            int.TryParse(TextEditQty.Text, out qtyDone);

            Models.OrderItemOperationPerformed itemOpPerformed = new Models.OrderItemOperationPerformed();
            itemOpPerformed.qtyDone = qtyDone;

            orderItemOp.OrderItemOperationPerformeds.Add(itemOpPerformed);

            Models.OperationPerformed opPerformed = new Models.OperationPerformed();
            opPerformed.qtyDone = qtyDone;
            opPerformed.timePerformed = DateTime.Now;
            opPerformed.usr = currentUser;
            opPerformed.OrderItemOperationsPerformed = new List<Models.OrderItemOperationPerformed>();
            opPerformed.OrderItemOperationsPerformed.Add(itemOpPerformed);

            Globals.dbContext.OperationPerformeds.Add(opPerformed);
            Globals.dbContext.SaveChanges();

        }


    }
}
