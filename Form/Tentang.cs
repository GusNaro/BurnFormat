using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace BurnFormat
{
    public partial class Tentang : Form
    {
        public Tentang()
        {
            InitializeComponent();
        }

        private void Tentang_Close(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            MainForm buka = new MainForm();
            buka.Show();
        }

        private void linkLabelFacebook_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("Iexplore.exe", @"http://www.facebook.com/gus.naro?v=wall");
        }
    }
}
