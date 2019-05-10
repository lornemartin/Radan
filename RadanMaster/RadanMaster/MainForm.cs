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
        Models.User currentUser { get; set; }

        public MainForm()
        {
            InitializeComponent();
            btnAllProduction.Enabled = false;
            btnNesting.Enabled = false;
        }

        private void RefreshForm()
        {
            btnAllProduction.Enabled = currentUser.hasAccess(btnAllProduction.Name);
            btnNesting.Enabled = currentUser.hasAccess(btnNesting.Name);
        }

        private void btnNesting_Click(object sender, EventArgs e)
        {
            Nesting nestingForm = new Nesting();
            nestingForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AllProduction testForm = new AllProduction(currentUser);
                testForm.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void barButtonItemLogin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Login loginForm = new Login();
            var result = loginForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                currentUser = loginForm.currentUser;
                RefreshForm();
            }
        }
    }
}