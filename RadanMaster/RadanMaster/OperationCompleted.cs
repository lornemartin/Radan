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
            btnRecordOp.Enabled = false;

            associatedOrderItemOps = Globals.dbContext.OrderItemOperations.Where(o => o.orderItem.PartID == OrderItemOp.orderItem.PartID)
                                                                          .Where(o => o.operationID == OrderItemOp.operationID).ToList();
                                                                          //.Where(o => o.qtyDone < o.qtyRequired).ToList();
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

            Models.OperationPerformed opPerformed = new Models.OperationPerformed();
            opPerformed.qtyDone = qtyDone;
            opPerformed.timePerformed = DateTime.Now;
            opPerformed.usr = currentUser;
            opPerformed.OrderItemOperationsPerformed = new List<Models.OrderItemOperationPerformed>();

            int totalQtyLeftToDo = qtyDone;
            foreach(Models.OrderItemOperation associatedOrderItemOp in associatedOrderItemOps)
            {
                if (associatedOrderItemOp.qtyDone < associatedOrderItemOp.qtyRequired)
                {
                    int itemQtyLeftToDo = associatedOrderItemOp.qtyRequired - associatedOrderItemOp.qtyDone;
                    Models.OrderItemOperationPerformed orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                    if (totalQtyLeftToDo <= itemQtyLeftToDo)
                    {
                        orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                        orderItemOpPerformed.qtyDone = totalQtyLeftToDo;
                        associatedOrderItemOp.qtyDone += totalQtyLeftToDo;
                        associatedOrderItemOp.OrderItemOperationPerformeds.Add(orderItemOpPerformed);
                        opPerformed.OrderItemOperationsPerformed.Add(orderItemOpPerformed);
                        totalQtyLeftToDo -= totalQtyLeftToDo;
                        break;
                    }
                    else
                    {
                        orderItemOpPerformed = new Models.OrderItemOperationPerformed();
                        orderItemOpPerformed.qtyDone = itemQtyLeftToDo;
                        associatedOrderItemOp.qtyDone = associatedOrderItemOp.qtyRequired;
                        associatedOrderItemOp.OrderItemOperationPerformeds.Add(orderItemOpPerformed);
                        opPerformed.OrderItemOperationsPerformed.Add(orderItemOpPerformed);
                        totalQtyLeftToDo -= itemQtyLeftToDo;
                    }
                }
            }

            // if we've filled all the orders, we need to do something with the rest...
            if(totalQtyLeftToDo > 0)
            {
                MessageBox.Show(totalQtyLeftToDo + " of these items could not be applied to a batch");
            }

            Globals.dbContext.OperationPerformeds.Add(opPerformed);
            Globals.dbContext.SaveChanges();

            btnRecordOp.Enabled = false;

        }

        private void TextEditQty_EditValueChanged(object sender, EventArgs e)
        {
            btnRecordOp.Enabled = true;
        }
    }
}
