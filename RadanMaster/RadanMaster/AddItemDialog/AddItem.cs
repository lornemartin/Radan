using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RadanMaster.AddItemDialog
{
    public partial class AddItem : Form
    {
        public static string qty { get; set; }
        public static string lastOrderNumber { get; set; }
        public static bool isBatch { get; set; }

        public AddItem()
        {
            InitializeComponent();
            txtBoxQty.Text = qty;
            comboBoxOrderNum.Text = lastOrderNumber;
            checkBox1.Checked = isBatch;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            qty = txtBoxQty.Text;
            lastOrderNumber = comboBoxOrderNum.Text;
            isBatch = checkBox1.Checked;

            this.Close();
            this.DialogResult = DialogResult.OK;
            
        }
    }
}
