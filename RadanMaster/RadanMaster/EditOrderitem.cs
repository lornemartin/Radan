using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ComponentModel.DataAnnotations;
using System.IO;
using DevExpress.XtraLayout.Helpers;
using DevExpress.XtraLayout;
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace RadanMaster
{
    public partial class EditOrderitem : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Models.OrderItem itemToEdit { get; set; }
        DAL.RadanMasterContext dbContext { get; set; }
        bool updateAll { get; set; }
        Models.User currentUser { get; set; }


        public EditOrderitem(Models.OrderItem oItem, DAL.RadanMasterContext ctx,Models.User curUser)
        {
            currentUser = curUser;
            //dbContext = new DAL.RadanMasterContext();
            dbContext = ctx;
            itemToEdit = oItem;
            InitializeComponent();
            textEditQtyReqd.Text = itemToEdit.QtyRequired.ToString();
            textEditQtyDone.Text = itemToEdit.QtyNested.ToString();
            textEditNotes.Text = itemToEdit.Notes;

            dbContext.Parts.Load();
            dbContext.Operations.Load();
            dbContext.OrderItemOperations.Load();

            gridControlOperations.DataSource = itemToEdit.orderItemOps.ToList();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            itemToEdit.QtyRequired = int.Parse(textEditQtyReqd.Text);
            itemToEdit.QtyNested = int.Parse(textEditQtyDone.Text);
            itemToEdit.Notes = textEditNotes.Text;

            textEditQtyDone.Focus();        // take focus away from operations grid to force data update if needed


            if (updateAll)
            {
                // find other open order items that should be updated...
                List<Models.OrderItem> openOrderItems = new List<Models.OrderItem>();
                openOrderItems = dbContext.OrderItems.Where(o => o.PartID == itemToEdit.PartID)
                                                     .Where(o => o.IsComplete == false).ToList();

                List<Models.Operation> itemOps = new List<Models.Operation>();


                foreach (Models.OrderItemOperation itemOp in itemToEdit.orderItemOps.ToList())
                {
                    foreach (Models.OrderItem item in openOrderItems.ToList())
                    {
                        Models.OrderItemOperation newItemOp = new Models.OrderItemOperation();
                        newItemOp.qtyRequired = item.QtyRequired;
                        newItemOp.qtyDone = 0;
                        newItemOp.operation = itemOp.operation;

                        Models.OrderItemOperation testOp = item.orderItemOps.Where(o => o.operation.Name == itemOp.operation.Name).FirstOrDefault();
                        if (testOp == null)
                            item.orderItemOps.Add(newItemOp);
                    }
                }
            }

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = itemToEdit.orderItemOps.ToList();

            dbContext.SaveChanges();

            this.Close();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void EditOrderitem_Load(object sender, EventArgs e)
        {

        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Did you want to add this operation to all open order items or only to this item?", "Apply To All?", MessageBoxButtons.YesNoCancel);

            if (result != DialogResult.Cancel)
            {
                Models.Operation newOp = new Models.Operation();
                newOp.Part = itemToEdit.Part;
                newOp.PartID = itemToEdit.PartID;
                newOp.Location = "";
                newOp.isFinalOp = false;
                newOp.Name = "";

                dbContext.Operations.Add(newOp);
                itemToEdit.Part.Operations.Add(newOp);

                Models.OrderItemOperation itemOp = new Models.OrderItemOperation();


                dbContext.OrderItemOperations.Add(itemOp);

                itemOp.operation = newOp;
                itemOp.qtyRequired = itemToEdit.QtyRequired;
                itemOp.qtyDone = 0;
                itemToEdit.orderItemOps.Add(itemOp);

                if (result == DialogResult.No)
                {
                    updateAll = true;

                }
                else
                {
                    updateAll = true;

                }

                gridControlOperations.DataSource = null;
                gridControlOperations.DataSource = itemToEdit.orderItemOps.ToList();
            }
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            int selectedRow = gridViewOperations.GetSelectedRows().FirstOrDefault();

            Models.OrderItemOperation opToRemove = gridViewOperations.GetRow(selectedRow) as Models.OrderItemOperation;

            dbContext.OrderItemOperations.Remove(opToRemove);

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = itemToEdit.orderItemOps.ToList();

        }

        private void gridViewOperations_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;
            Models.OrderItemOperation opToEdit = new Models.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewOperations.GetRow(rowHandle);
                opToEdit = (Models.OrderItemOperation)o;
            }

            //EditOrderitem editForm = new EditOrderitem(itemToEdit, dbContext, currentUser);
            AddOperationCompleted addOperationCompletedDialog = new AddOperationCompleted(currentUser,opToEdit,itemToEdit.Part,dbContext);
            addOperationCompletedDialog.ShowDialog();
        }
    }
}
