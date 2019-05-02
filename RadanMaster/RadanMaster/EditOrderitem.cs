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
            gridControlOperations.DataSource = dbContext.Operations.Local.ToBindingList().Where(p => p.PartID == itemToEdit.PartID);
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            itemToEdit.QtyRequired = int.Parse(textEditQtyReqd.Text);
            itemToEdit.QtyNested = int.Parse(textEditQtyDone.Text);
            itemToEdit.Notes = textEditNotes.Text;

            //int dataRowCount = gridViewOperations.DataRowCount;
            DevExpress.XtraGrid.Columns.GridColumn col = gridViewOperations.Columns.ColumnByFieldName("isFinalOp");

            int i = 0;
            foreach(Models.Operation op in itemToEdit.Part.Operations)
            {
                //Models.Operation oper = dbContext.Operations.Where(o => o.ID == op.ID).FirstOrDefault();
                op.isFinalOp = (bool) gridViewOperations.GetRowCellValue(i, col);
                i++;
            }

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = dbContext.Operations.Local.ToBindingList().Where(p => p.PartID == itemToEdit.PartID);

            dbContext.SaveChanges();

            this.Close();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void EditOrderitem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'radanMaster2DataSet.Operations' table. You can move, or remove it, as needed.
            //this.operationsTableAdapter.Fill(this.radanMaster2DataSet.Operations);
           
            //this.operationsTableAdapter.Fill(this.radanMaster2DataSet.Operations);
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            Models.Operation newOp = new Models.Operation();
            newOp.qtyRequired = itemToEdit.QtyRequired;
            newOp.qtyDone = 0;
            newOp.Part = itemToEdit.Part;
            newOp.PartID = itemToEdit.PartID;
            newOp.Location = "";
            newOp.isFinalOp = false;
            newOp.Name = "";

            dbContext.Operations.Add(newOp);

            Models.Part prt = dbContext.Parts.Where(p => p.ID == itemToEdit.PartID).FirstOrDefault();
            prt.Operations.Add(newOp);

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = dbContext.Operations.Local.ToBindingList().Where(p => p.PartID == itemToEdit.PartID);
        }

        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            int selectedRow = gridViewOperations.GetSelectedRows().FirstOrDefault();

            Models.Operation opToRemove = gridViewOperations.GetRow(selectedRow) as Models.Operation;

            dbContext.Operations.Remove(opToRemove);

            gridControlOperations.DataSource = null;
            gridControlOperations.DataSource = dbContext.Operations.Local.ToBindingList().Where(p => p.PartID == itemToEdit.PartID);

        }
    }
}
