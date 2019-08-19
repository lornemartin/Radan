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
using ProductionMasterModel;

namespace RadanMaster
{
    public partial class EditOrderitem : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ProductionMasterModel.OrderItem ItemToEdit { get; set; }
        bool updateAll { get; set; }
        ProductionMasterModel.User currentUser { get; set; }


        public EditOrderitem(ProductionMasterModel.OrderItem item, ProductionMasterModel.User curUser)
        {
            currentUser = curUser;
            ItemToEdit = item;

            InitializeComponent();
        }

        private void EditOrderitem_Load(object sender, EventArgs e)
        {
            textEditQtyReqd.Text = ItemToEdit.QtyRequired.ToString();
            textEditQtyDone.Text = ItemToEdit.QtyNested.ToString();
            textEditNotes.Text = ItemToEdit.Notes;

            Globals.dbContext.Parts.Load();
            Globals.dbContext.Operations.Load();
            Globals.dbContext.OrderItemOperations.Load();
            Globals.dbContext.Orders.Load();

            btnAddOperation.Enabled = currentUser.HasPermission(btnAddOperation.Name);
            btnRemoveOperation.Enabled = currentUser.HasPermission(btnRemoveOperation.Name);
            // add code here to enable/disable operations buttons in gridview?

            gridControlOperations.DataSource = ItemToEdit.OrderItemOperations.ToList();

        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ItemToEdit.QtyRequired = int.Parse(textEditQtyReqd.Text);
            ItemToEdit.QtyNested = int.Parse(textEditQtyDone.Text);
            ItemToEdit.Notes = textEditNotes.Text;

            textEditQtyDone.Focus();        // take focus away from operations grid to force data update if needed

            SaveChanges();
        }
        

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ItemToEdit.QtyRequired = int.Parse(textEditQtyReqd.Text);
            ItemToEdit.QtyNested = int.Parse(textEditQtyDone.Text);
            ItemToEdit.Notes = textEditNotes.Text;

            textEditQtyDone.Focus();        // take focus away from operations grid to force data update if needed

            this.Close();
        }



        private void btnAddOperation_Click(object sender, EventArgs e)
        {


            DialogResult result = MessageBox.Show("Did you want to add this operation to all open order items or only to this item?", "Apply To All?", MessageBoxButtons.YesNoCancel);

            if (result != DialogResult.Cancel)
            {
                ProductionMasterModel.OrderItem itemToEdit = Globals.dbContext.OrderItems.Where(i => i.ID == ItemToEdit.ID).FirstOrDefault();

                ProductionMasterModel.Operation newOp = new ProductionMasterModel.Operation();
                newOp.Part = itemToEdit.Part;
                newOp.PartID = itemToEdit.PartID;
                newOp.Location = "";
                newOp.isFinalOp = false;
                newOp.Name = "";

                Globals.dbContext.Operations.Add(newOp);
                itemToEdit.Part.Operations.Add(newOp);

                ProductionMasterModel.OrderItemOperation itemOp = new ProductionMasterModel.OrderItemOperation();


                Globals.dbContext.OrderItemOperations.Add(itemOp);

                itemOp.Operation = newOp;
                itemOp.qtyRequired = itemToEdit.QtyRequired;
                itemOp.qtyDone = 0;
                itemToEdit.OrderItemOperations.Add(itemOp);

                if (result == DialogResult.No)
                {
                    updateAll = true;

                }
                else
                {
                    updateAll = true;

                }

                gridControlOperations.DataSource = null;
                gridControlOperations.DataSource = itemToEdit.OrderItemOperations.ToList();
            }

        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            ProductionMasterModel.OrderItem itemToEdit = Globals.dbContext.OrderItems.Where(i => i.ID == ItemToEdit.ID).FirstOrDefault();

            int selectedRow = gridViewOperations.GetSelectedRows().FirstOrDefault();

            ProductionMasterModel.OrderItemOperation opToRemove = gridViewOperations.GetRow(selectedRow) as ProductionMasterModel.OrderItemOperation;

            Globals.dbContext.OrderItemOperations.Remove(opToRemove);

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = itemToEdit.OrderItemOperations.ToList();
        }

        private void gridViewOperations_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            int numRows = view.SelectedRowsCount;
            ProductionMasterModel.OrderItemOperation opToEdit = new ProductionMasterModel.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewOperations.GetRow(rowHandle);
                opToEdit = (ProductionMasterModel.OrderItemOperation)o;
            }

            OperationCompleted opForm = new OperationCompleted(opToEdit, currentUser);
            opForm.Text = this.Text + "--->" + opToEdit.Operation.Name;
            opForm.Show();
        }

        private void btnRecordOp_Click(object sender, EventArgs e)
        {
            GridView view = gridViewOperations;
            int numRows = view.SelectedRowsCount;
            ProductionMasterModel.OrderItemOperation opToEdit = new ProductionMasterModel.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewOperations.GetRow(rowHandle);
                opToEdit = (ProductionMasterModel.OrderItemOperation)o;
            }

            OperationCompleted opForm = new OperationCompleted(opToEdit, currentUser);
            opForm.Text = this.Text + "--->" + opToEdit.Operation.Name;
            opForm.ShowDialog();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridView view = gridViewOperations;
            int numRows = view.SelectedRowsCount;
            ProductionMasterModel.OrderItemOperation opToEdit = new ProductionMasterModel.OrderItemOperation();

            List<int> rowHandleList = view.GetSelectedRows().ToList();
            foreach (int rowHandle in rowHandleList)
            {
                object o = gridViewOperations.GetRow(rowHandle);
                opToEdit = (ProductionMasterModel.OrderItemOperation)o;
            }

            OperationCompleted opForm = new OperationCompleted(opToEdit, currentUser);
            opForm.Text = this.Text + "--->" + opToEdit.Operation.Name;
            opForm.ShowDialog();
        }

        private void SaveChanges()
        {
            


            if (updateAll)
            {
                // find other open order items that should be updated...
                List<ProductionMasterModel.OrderItem> openOrderItems = new List<ProductionMasterModel.OrderItem>();
                openOrderItems = Globals.dbContext.OrderItems.Where(o => o.PartID == ItemToEdit.PartID)
                                                     .Where(o => o.IsComplete == false).ToList();

                List<ProductionMasterModel.Operation> itemOps = new List<ProductionMasterModel.Operation>();


                foreach (ProductionMasterModel.OrderItemOperation itemOp in ItemToEdit.OrderItemOperations.ToList())
                {
                    foreach (ProductionMasterModel.OrderItem item in openOrderItems.ToList())
                    {
                        ProductionMasterModel.OrderItemOperation newItemOp = new ProductionMasterModel.OrderItemOperation();
                        newItemOp.qtyRequired = item.QtyRequired;
                        newItemOp.qtyDone = 0;
                        newItemOp.Operation = itemOp.Operation;

                        ProductionMasterModel.OrderItemOperation testOp = item.OrderItemOperations.Where(o => o.Operation.Name == itemOp.Operation.Name).FirstOrDefault();
                        if (testOp == null)
                            item.OrderItemOperations.Add(newItemOp);
                    }
                }
            }

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = ItemToEdit.OrderItemOperations.ToList();

            Globals.dbContext.SaveChanges();

            this.Close();
        }

        private void EditOrderitem_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveChanges();
        }
    }
}
