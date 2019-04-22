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
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        bool loggedIn = false;

        RadanMaster.DAL.RadanMasterContext dbContext { get; set; }
        public Login()
        {
            InitializeComponent();
            dbContext = new RadanMaster.DAL.RadanMasterContext();
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Models.User usr = dbContext.Users.Where(u => u.UserName == textEditUserName.Text).FirstOrDefault();

            bool success = evaluateLogin();

            if (success)
                this.Close();
        }

        private bool evaluateLogin()
        {
            Models.User usr = dbContext.Users.Where(u => u.UserName == textEditUserName.Text).FirstOrDefault();

            if (usr != null)
            {
                if (usr.Password != textEditPassword.Text)
                {
                    MessageBox.Show("Invalid Password");
                    return false;
                }
                else
                {
                    loggedIn = true;
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Invalid User Name");
                return false;
                
            }
        }

    }
}