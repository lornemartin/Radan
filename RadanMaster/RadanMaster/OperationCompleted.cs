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

namespace RadanMaster
{
    public partial class OperationCompleted : Form
    {
        OperationManager opManager { get; set; }

        public OperationCompleted(Models.OrderItemOperation orderItemOp, Models.User curUser)
        {
            InitializeComponent();

            opManager = new OperationManager(orderItemOp, curUser);

            RefreshGridViews();
        }

        private void RefreshGridViews()
        {
            textBoxQtyExtra.Text = opManager.RefreshDataStructures().ToString();

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

            List<Models.OrderItemOperationPerformed> orderItemOperationPerformeds = opManager.GetAssociatedOrderItemOperationPerformeds(orderItemOp);
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
    }
}
