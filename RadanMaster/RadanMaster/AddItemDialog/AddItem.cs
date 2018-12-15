using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RadanMaster.Models;

namespace RadanMaster.AddItemDialog
{
    public partial class AddItem : Form
    {
        public static string qty { get; set; }
        public static string lastOrderNumber { get; set; }
        public static string lastSchedName { get; set; }
        public static string lastBatchName { get; set; }
        public static string lastBatchProduct { get; set; }
        public static bool isBatch { get; set; }

        public AddItem(RadanMaster.DAL.RadanMasterContext ctx)
        {
            InitializeComponent();
            List<RadanMaster.Models.Order> activeOrders = ctx.Orders.Where(o => o.IsComplete == false).ToList();
            txtBoxQty.Text = qty;
            comboBoxOrderNum.Text = lastOrderNumber;
            foreach (Order o in activeOrders)
            {
                if (o.OrderNumber != null && o.OrderNumber != "")
                {
                    if (!comboBoxOrderNum.Items.Contains(o.OrderNumber))
                        comboBoxOrderNum.Items.Add(o.OrderNumber);
                }
            }

            comboBoxSchedName.Text = lastSchedName;
            foreach (Order o in activeOrders)
            {
                if (o.ScheduleName != null && o.ScheduleName != "")
                {
                    if (!comboBoxSchedName.Items.Contains(o.ScheduleName))
                        comboBoxSchedName.Items.Add(o.ScheduleName);
                }
            }


            comboBoxBatchName.Text = lastBatchName;
            foreach(Order o in activeOrders)
            {
                if (o.BatchName != null && o.BatchName != "")
                {
                    if(!comboBoxBatchName.Items.Contains(o.BatchName))
                        comboBoxBatchName.Items.Add(o.BatchName);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            qty = txtBoxQty.Text;
            lastOrderNumber = comboBoxOrderNum.Text;
            lastSchedName = comboBoxSchedName.Text;
            lastBatchName = comboBoxBatchName.Text;
            if (comboBoxBatchName.Text != "") isBatch = true;
            else isBatch = false;

            if (txtBoxQty.Text == "")
            {
                MessageBox.Show("Please fill in quantity field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
            {
                int result;
                if(!int.TryParse(qty, out result))
                {
                    MessageBox.Show("Please fill in quantity field with a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
            }

            if(comboBoxBatchName.Text != "" && comboBoxSchedName.Text != "")
            {
                MessageBox.Show("Please fill in either batch name or schedule name, but not both.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (comboBoxBatchName.Text == "" && comboBoxSchedName.Text == "")
            {
                MessageBox.Show("Please fill in either a batch name or a schedule name, but not both.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }


            this.Close();
            this.DialogResult = DialogResult.OK;
            
        }
    }
}
