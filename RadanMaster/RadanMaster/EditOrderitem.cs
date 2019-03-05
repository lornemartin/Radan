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
           
        }

        private void bbiSaveAndClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            itemToEdit.QtyRequired = int.Parse(textEditQtyReqd.Text);
            itemToEdit.QtyNested = int.Parse(textEditQtyDone.Text);
            itemToEdit.Notes = textEditNotes.Text;

            dbContext.SaveChanges();

            this.Close();
        }

        private void bbiReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
