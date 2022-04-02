namespace IceCreamManage
{
    partial class fApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fApp));
            this.btApp = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btApp
            // 
            this.btApp.BackColor = System.Drawing.Color.LightGray;
            this.btApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btApp.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btApp.ForeColor = System.Drawing.Color.Crimson;
            this.btApp.Image = global::IceCreamManage.Properties.Resources.admin;
            this.btApp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btApp.Location = new System.Drawing.Point(104, 480);
            this.btApp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btApp.Name = "btApp";
            this.btApp.Size = new System.Drawing.Size(153, 56);
            this.btApp.TabIndex = 0;
            this.btApp.Text = "LOGIN";
            this.btApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btApp.UseVisualStyleBackColor = false;
            this.btApp.Click += new System.EventHandler(this.btApp_Click);
            // 
            // btThoat
            // 
            this.btThoat.BackColor = System.Drawing.Color.LightGray;
            this.btThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btThoat.Font = new System.Drawing.Font("Cooper Black", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThoat.ForeColor = System.Drawing.Color.Crimson;
            this.btThoat.Image = global::IceCreamManage.Properties.Resources.thoát_2;
            this.btThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btThoat.Location = new System.Drawing.Point(281, 480);
            this.btThoat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(137, 56);
            this.btThoat.TabIndex = 0;
            this.btThoat.Text = "EXIT";
            this.btThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btThoat.UseVisualStyleBackColor = false;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(67, 47);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(386, 379);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // fApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightPink;
            this.ClientSize = new System.Drawing.Size(533, 606);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btApp);
            this.Controls.Add(this.btThoat);
            this.ForeColor = System.Drawing.Color.Firebrick;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý cửa hàng Cream HKPP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fApp_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btApp;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}