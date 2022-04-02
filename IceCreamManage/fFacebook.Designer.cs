namespace IceCreamManage
{
    partial class fFacebook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFacebook));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAccountName = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.llabelForgotpassword = new System.Windows.Forms.LinkLabel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcbClose = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbUnHide = new System.Windows.Forms.PictureBox();
            this.pbHide = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email or phone number: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(140, 212);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // txbAccountName
            // 
            this.txbAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbAccountName.Location = new System.Drawing.Point(144, 149);
            this.txbAccountName.Margin = new System.Windows.Forms.Padding(4);
            this.txbAccountName.Name = "txbAccountName";
            this.txbAccountName.Size = new System.Drawing.Size(263, 30);
            this.txbAccountName.TabIndex = 0;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(144, 243);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(263, 30);
            this.txbPassword.TabIndex = 1;
            this.txbPassword.UseSystemPasswordChar = true;
            this.txbPassword.TextChanged += new System.EventHandler(this.txbPassword_TextChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(101, 294);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(171, 54);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // llabelForgotpassword
            // 
            this.llabelForgotpassword.AutoSize = true;
            this.llabelForgotpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llabelForgotpassword.ForeColor = System.Drawing.Color.Black;
            this.llabelForgotpassword.LinkColor = System.Drawing.Color.Red;
            this.llabelForgotpassword.Location = new System.Drawing.Point(153, 376);
            this.llabelForgotpassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.llabelForgotpassword.Name = "llabelForgotpassword";
            this.llabelForgotpassword.Size = new System.Drawing.Size(162, 24);
            this.llabelForgotpassword.TabIndex = 4;
            this.llabelForgotpassword.TabStop = true;
            this.llabelForgotpassword.Text = "Forgot Password?";
            this.llabelForgotpassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llabelForgotpassword_LinkClicked);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(331, 294);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(171, 54);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.pcbClose);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbAccountName);
            this.panel1.Controls.Add(this.pbUnHide);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pbHide);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.txbPassword);
            this.panel1.Controls.Add(this.llabelForgotpassword);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 419);
            this.panel1.TabIndex = 21;
            // 
            // pcbClose
            // 
            this.pcbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbClose.Image = global::IceCreamManage.Properties.Resources.Closeicon;
            this.pcbClose.Location = new System.Drawing.Point(548, 0);
            this.pcbClose.Margin = new System.Windows.Forms.Padding(4);
            this.pcbClose.Name = "pcbClose";
            this.pcbClose.Size = new System.Drawing.Size(40, 40);
            this.pcbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbClose.TabIndex = 22;
            this.pcbClose.TabStop = false;
            this.pcbClose.Click += new System.EventHandler(this.pcbClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(87, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(415, 58);
            this.label3.TabIndex = 22;
            this.label3.Text = "Login Facebook ";
            // 
            // pbUnHide
            // 
            this.pbUnHide.BackColor = System.Drawing.Color.Transparent;
            this.pbUnHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbUnHide.Image = ((System.Drawing.Image)(resources.GetObject("pbUnHide.Image")));
            this.pbUnHide.Location = new System.Drawing.Point(429, 243);
            this.pbUnHide.Margin = new System.Windows.Forms.Padding(4);
            this.pbUnHide.Name = "pbUnHide";
            this.pbUnHide.Size = new System.Drawing.Size(36, 28);
            this.pbUnHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbUnHide.TabIndex = 20;
            this.pbUnHide.TabStop = false;
            this.pbUnHide.Click += new System.EventHandler(this.pbUnHide_Click);
            // 
            // pbHide
            // 
            this.pbHide.BackColor = System.Drawing.Color.Transparent;
            this.pbHide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHide.Image = ((System.Drawing.Image)(resources.GetObject("pbHide.Image")));
            this.pbHide.Location = new System.Drawing.Point(429, 243);
            this.pbHide.Margin = new System.Windows.Forms.Padding(4);
            this.pbHide.Name = "pbHide";
            this.pbHide.Size = new System.Drawing.Size(36, 28);
            this.pbHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHide.TabIndex = 19;
            this.pbHide.TabStop = false;
            this.pbHide.Click += new System.EventHandler(this.pbHide_Click);
            // 
            // fFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(586, 418);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fFacebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUnHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAccountName;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel llabelForgotpassword;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbUnHide;
        private System.Windows.Forms.PictureBox pbHide;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pcbClose;
    }
}