﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }


        private void ButtonLoadImage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
