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

namespace RadanMaster
{
    public partial class EditOrderitem : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Models.OrderItem itemToEdit { get; set; }
        DAL.RadanMasterContext dbContext { get; set; }

        public EditOrderitem(Models.OrderItem oItem, DAL.RadanMasterContext ctx)
        {
            dbContext = ctx;
            itemToEdit = oItem;
            InitializeComponent();
            textEditQtyReqd.Text = itemToEdit.QtyRequired.ToString();
            textEditQtyDone.Text = itemToEdit.QtyNested.ToString();
            textEditNotes.Text = itemToEdit.Notes;

            dbContext.Parts.Load();
            dbContext.Operations.Load();
            gridControlOperations.DataSource = dbContext.OrderItemOperations.Local.ToBindingList().Where(p => p.operation.PartID == itemToEdit.PartID).ToList();
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            itemToEdit.QtyRequired = int.Parse(textEditQtyReqd.Text);
            itemToEdit.QtyNested = int.Parse(textEditQtyDone.Text);
            itemToEdit.Notes = textEditNotes.Text;

            textEditQtyDone.Focus();        // take focus away from operations grid to force data update if needed

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = dbContext.OrderItemOperations.Local.ToBindingList().Where(p => p.operation.PartID == itemToEdit.PartID).ToList();

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
            Models.Operation newOp = new Models.Operation();
            newOp.Part = itemToEdit.Part;
            newOp.PartID = itemToEdit.PartID;
            newOp.Location = "";
            newOp.isFinalOp = false;
            newOp.Name = "";

            dbContext.Operations.Add(newOp);
            itemToEdit.Part.Operations.Add(newOp);

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = dbContext.OrderItemOperations.Local.ToBindingList().Where(p => p.operation.PartID == itemToEdit.PartID).ToList();
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            int selectedRow = gridViewOperations.GetSelectedRows().FirstOrDefault();

            Models.Operation opToRemove = gridViewOperations.GetRow(selectedRow) as Models.Operation;

            dbContext.Operations.Remove(opToRemove);

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = dbContext.OrderItemOperations.Local.ToBindingList().Where(p => p.operation.PartID == itemToEdit.PartID).ToList();

        }
    }
}
