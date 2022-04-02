using IceCreamManage.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamManage
{
    public partial class fSignUp : Form
    {
        BindingSource accountList = new BindingSource();
        public fSignUp()
        {
            InitializeComponent();
        }

        private void fSignUp_Load(object sender, EventArgs e)
        {
        
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string userName = txbAccountName.Text;
            string displayName = txbDisplayName.Text;
            string password = txbPassword.Text;
            string password2 = txbPassword2.Text;
            string sex = nupSex.Text;
            int age = (int)nupAge.Value;
            string number = txbNumber.Text;
            string email = txbEmail.Text;
            string address = txbAddress.Text;

            SignupAccount(userName, displayName, password,password2, sex, age, number, email, address);
        }

        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == true || txbPassword2.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txbPassword.UseSystemPasswordChar = false;
                txbPassword2.UseSystemPasswordChar = false;
            }
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == false || txbPassword2.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txbPassword.UseSystemPasswordChar = true;
                txbPassword2.UseSystemPasswordChar = true;
            }
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void SignupAccount(string userName, string displayName, string password,string password2, string sex, int age, string number, string email, string address)
        {
            if (txbAccountName.Text == "")
            {
                MessageBox.Show("Username must not be empty !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(txbPassword.Text == null || txbPassword.Text == "" ||txbPassword2.Text == null || txbPassword2.Text =="")
            {
                MessageBox.Show("Password must not be empty !", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (AccountDAO.Instance.SignUPAccount(userName, displayName, password,password2, sex, age, number, email, address))
            {
                MessageBox.Show("Account registration is successful", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("This account has already existed", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            LoadAccount();
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
