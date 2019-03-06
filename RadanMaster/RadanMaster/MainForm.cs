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

namespace RadanMaster
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNesting_Click(object sender, EventArgs e)
        {
            Nesting nestingForm = new Nesting();
            nestingForm.ShowDialog();
        }

        private void buttonAllItems_Click(object sender, EventArgs e)
        {
            AllItems allitemsForm = new AllItems();
            allitemsForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllProduction testForm = new AllProduction();
            testForm.ShowDialog();
        }
    }
}