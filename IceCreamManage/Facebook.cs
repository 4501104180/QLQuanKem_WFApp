﻿using System;
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
    public partial class Facebook : Form
    {
        public Facebook()
        {
            InitializeComponent();
        }

        private void Facebook_Load(object sender, EventArgs e)
        {
            Text = Program.X;
            webBrowser1.Navigate(Program.X);
            webBrowser1.Update();
        }
    }
}
