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
using System.IO;
using DevExpress.XtraPdfViewer;
using DevExpress.XtraBars;

namespace RadanMaster
{
    public partial class OperationCompleted : Form
    {
        OperationManager opManager { get; set; }
        Models.User currentUser { get; set; }

        public OperationCompleted(Models.OrderItemOperation orderItemOp, Models.User curUser)
        {
            InitializeComponent();

            switch(orderItemOp.operation.Name)
            {
                case "Bandsaw":
                    BackColor = Color.Aqua;
                    break;
                case "BrakePress":
                    BackColor = Color.BlanchedAlmond;
                    break;
                case "Machine Shop":
                    BackColor = Color.LightGreen;
                    break;
                case "Laser":
                    BackColor = Color.LightPink;
                    break;
                default:
                    BackColor = Color.RosyBrown;
                    break;
            }

            opManager = new OperationManager(orderItemOp, curUser);

            currentUser = curUser;

            RefreshGridViews();

        }

        private void RefreshGridViews()
        {
            textBoxQtyExtra.Text = opManager.RefreshDataStructures().ToString();

            Globals.dbContext.Parts.Load();
            Globals.dbContext.Operations.Load();
            Globals.dbContext.OrderItemOperations.Load();
            Globals.dbContext.Orders.Load();

            gridControlAssociatedOrderItems.DataSource = opManager.GetAssociatedOrderItemOperations();
            gridControlOpsPerformed.DataSource = opManager.GetOperationsPerformed();
        }

        private void OperationCompleted_Load(object sender, EventArgs e)
        {
            btnRecordOp.Enabled = false;

            Stream stream = opManager.GetPDFStream();
            pdfViewer1.LoadDocument(stream);
            pdfViewer1.CurrentPageNumber = 1;
            pdfViewer1.ZoomMode = PdfZoomMode.FitToVisible;

            // check for extra items recorded previously
            if (opManager.HasUnassignedOperationsPerformed())
            {
                DialogResult result = MessageBox.Show("There have been some of these items recorded previously that couldn't be matched up with a batch.  Should we assign them to a batch now?.", "Confirm", MessageBoxButtons.YesNoCancel);
                
                if(result == DialogResult.Yes)
                {
                    opManager.AssignUnAssignedOperations();
                }
            }

            opManager.RefreshDataStructures();
            gridControlAssociatedOrderItems.DataSource = opManager.GetAssociatedOrderItemOperations();
            gridControlOpsPerformed.DataSource = opManager.GetOperationsPerformed();
        }

        private void gridViewAssociatedOrderItems_RowClick(object sender, RowClickEventArgs e)
        {
            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;
            Models.OrderItemOperation orderItemOp = new Models.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewAssociatedOrderItems.GetRow(rowHandle);
                orderItemOp = (Models.OrderItemOperation)o;
            }
        }

        private void btnRecordOp_Click(object sender, EventArgs e)
        {
            int qtyDone = 0;
            int.TryParse(TextEditQty.Text, out qtyDone);

            opManager.RecordOperationCompleted(qtyDone);
            
            RefreshGridViews();

            btnRecordOp.Enabled = false;
        }

        private void TextEditQty_EditValueChanged(object sender, EventArgs e)
        {
            btnRecordOp.Enabled = true;
        }

        private void textBoxQtyExtra_TextChanged(object sender, EventArgs e)
        {
            if (int.Parse(textBoxQtyExtra.Text) < 0)
            {
                textBoxQtyExtra.BackColor = Color.Red;
                textBoxQtyExtra.ForeColor = Color.White;
            }
            else
            {
                textBoxQtyExtra.BackColor = Color.Green;
                textBoxQtyExtra.ForeColor = Color.White;
            }
        }

        private void gridViewOpsPerformed_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (BarItemLink itm in popupMenu1.ItemLinks)
            {
                itm.Item.Enabled = currentUser.HasPermission("RemoveOp");
                //itm.Item.Enabled = false;
            }

            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Right && view.CalcHitInfo(e.Location).HitTest == DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell)
                popupMenu1.ShowPopup(gridControlOpsPerformed.PointToScreen(e.Location));
        }

        private void barManager1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            

            if (e.Item.Caption == "Delete")
            {
                DialogResult result;
                result = MessageBox.Show("Are you sure you want to remove this operation from the database?  This operation cannot be reversed!", "Warning!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if(result==DialogResult.Yes)
                {
                    object selectedRowData = gridViewOpsPerformed.GetRow(gridViewOpsPerformed.FocusedRowHandle);
                    Models.OperationPerformed opToRemove = (Models.OperationPerformed)selectedRowData;

                    opManager.RemoveOperationCompleted(opToRemove.ID);
                }
            }
            opManager.RefreshDataStructures();
            RefreshGridViews();
        }

        private void gridViewAssociatedOrderItems_ColumnFilterChanged(object sender, EventArgs e)
        {
            RefreshGridViews();
        }
    }
}
