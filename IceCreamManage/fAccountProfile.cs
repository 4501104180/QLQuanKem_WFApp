using IceCreamManage.DAO;
using IceCreamManage.DTO;
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
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
            nupSex.Text = LoginAccount.Sex;
            nupAge.Value = LoginAccount.Age;
            txbNumber.Text = LoginAccount.Number;
            txbEmail.Text = LoginAccount.Email;
            txbAddress.Text = LoginAccount.Address;
        }

        void UpdateAccountInfo()
        {
            string displayName = txbDisplayName.Text;
            string userName = txbUserName.Text;
            string sex = nupSex.Text;
            int age = (int)nupAge.Value;
            string number = txbNumber.Text;
            string email = txbEmail.Text;
            string address = txbAddress.Text;
            string password = txbPassword.Text;
   

           if (AccountDAO.Instance.UpdateAccount2(userName, displayName, sex, age, number,email,address, password))
           {
                MessageBox.Show("Update successful", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Information);
              if (updateAccount != null)
                {
                     updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                     this.Hide();
                }
           }
           else if(password == "")
           {
                MessageBox.Show("Password must not be empty", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           }
           else
           {
                MessageBox.Show("Please enter the correct password", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error);
           }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();

        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {

        }

        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txbPassword.UseSystemPasswordChar = false;
            }
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txbPassword.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txbPassword.UseSystemPasswordChar = true;
            }
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ExitInfor_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
