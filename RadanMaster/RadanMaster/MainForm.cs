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
        ProductionMasterModel.User currentUser { get; set; }

        public MainForm()
        {
            InitializeComponent();
            btnAllProduction.Enabled = false;
            btnNesting.Enabled = false;
            barButtonItemLogin.Enabled = true;
            barButtonLogout.Enabled = false;
        }

        private void RefreshForm()
        {
            ProductionMasterModel.Privilege p = currentUser.Privileges.Where(p1 => p1.buttonName == "btnAllProduction").FirstOrDefault();
            if (p != null)
            {
                if (p.HasAccess)
                    btnAllProduction.Enabled = true;
            }

            p = currentUser.Privileges.Where(p1 => p1.buttonName == "btnNesting").FirstOrDefault();
            if (p != null)
            {
                if (p.HasAccess)
                    btnNesting.Enabled = true;
            }


        }

        private void btnNesting_Click(object sender, EventArgs e)
        {
            Nesting2 nestingForm = new Nesting2(currentUser);
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
                barButtonItemLogin.Enabled = false;
                barButtonLogout.Enabled = true;
                RefreshForm();
            }
        }

        private void barButtonLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnAllProduction.Enabled = false;
            btnNesting.Enabled = false;
            barButtonItemLogin.Enabled = true;
            barButtonLogout.Enabled = false;
        }
    }
}