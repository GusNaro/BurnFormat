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
    public partial class MainForm : Form
    {
        private string pesan = "Program ini menjelaskan :";

        public MainForm()
        {
            InitializeComponent();
        }

        // ini akan membuat program tertutup dan didispatch dari memory
        private void buttonKeluar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // memanggil form format
        private void buttonFormatter_Click(object sender, EventArgs e)
        {
            this.Hide();
            Format buka = new Format();
            buka.Show();
        }

        // memanggil form burner
        private void buttonBurner_Click(object sender, EventArgs e)
        {
            this.Hide();
            Burner buka = new Burner();
            buka.Show();
        }

        // memanggil form informasi program
        private void buttonTentang_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tentang buka = new Tentang();
            buka.Show();
        }

        // melakukan unduhan IMAPI jika tidak ada di sistem komputer bersangkutan
        private void linkLabelDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show(this, "Anda akan dibawa ke halaman *Download Center Microsoft* untuk mendownload IMAPI. \n\nLanjutkan?? [Memerlukan koneksi ke internet]",
                                pesan, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                try
                {
                    Process.Start("firefox.exe", @"http://support.microsoft.com/kb/KB932716");
                }
                catch
                {
                    Process.Start("Iexplore.exe", @"http://support.microsoft.com/kb/KB932716");
                }
            else
                return;
        }

        // memanggil form sistem informasi
        private void linkLabelSistemInformasi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Informasi buka = new Informasi();
            buka.Show();
        }
    }
}
