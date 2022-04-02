using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IceCreamManage.DAO;
using IceCreamManage.DTO;

namespace IceCreamManage
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassWord.Text;
            if (Login(username, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(username);
                fTableManager f = new fTableManager(loginAccount);
                if(loginAccount.Type == "Guest")
                {
                    MessageBox.Show("You should contact Admin(Huong) to active your Account", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
               
            }
            else
            {
                MessageBox.Show("The account or password you have entered is incorrect.", "Announcement", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        bool Login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        private void fLogin_Load(object sender, EventArgs e)
        {

        }
        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void llabekSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fSignUp signUp = new fSignUp();
            signUp.Show();
        }

        private void pbUnHide_Click(object sender, EventArgs e)
        {
            if(txtPassWord.UseSystemPasswordChar == true)
            {
                pbHide.BringToFront();
                txtPassWord.UseSystemPasswordChar = false;
            }
        }

        private void pbHide_Click(object sender, EventArgs e)
        {
            if (txtPassWord.UseSystemPasswordChar == false)
            {
                pbUnHide.BringToFront();
                txtPassWord.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fForgotPassword f = new fForgotPassword();
            f.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            fFacebook f = new fFacebook();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
