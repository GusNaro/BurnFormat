using System;
using System.IO;
using System.Data;
using System.Text;
using System.Media;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

using IMAPI2.Interop;

namespace BurnFormat
{
    public partial class Format : Form
    {
        /// <summary>
        /// Managed code untuk mematikan tombol close
        /// </summary>
        const int MF_BYPOSITION = 0x400;
        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        private bool sedangMenghapus = false;

        private string namaProgram = "BurnFormat";
        private string pesan = "Program ini menjelaskan :";

        public Format()
        {
            InitializeComponent();
        }

        private void Format_Load(object sender, EventArgs e)
        {
            scanMedia();
            cekIMAPI();
            matikanTombolClose();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            penjelasanMethod();

            if (sedangMenghapus == true)
                buttonSelanjutnya.Enabled = false;
            else
                buttonSelanjutnya.Enabled = true;
        }

        private void buttonSelanjutnya_Click(object sender, EventArgs e)
        {
            releaseCOM();
            kembaliKeFormUtama();
        }

        #region Method

        public void kembaliKeFormUtama()
        {
            this.Hide();
            MainForm buka = new MainForm();
            buka.Show();
        }

        public void releaseCOM()
        {
            foreach (MsftDiscRecorder2 discRecorder in comboBoxDrive.Items)
            {
                if (discRecorder != null)
                {
                    Marshal.ReleaseComObject(discRecorder);
                }
            }
        }

        public void matikanTombolClose()
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
        }

        #region Efek Suara

        public void suaraSukses(bool enable)
        {
            SoundPlayer memainkan = new SoundPlayer(BurnFormat.Properties.Resources.SUKSES);
            memainkan.Play();
        }

        public void suaraGagal(bool enable)
        {
            SoundPlayer memainkan = new SoundPlayer(BurnFormat.Properties.Resources.GAGAL);
            memainkan.Play();
        }

        public void suaraGalat(bool enable)
        {
            SoundPlayer memainkan = new SoundPlayer(BurnFormat.Properties.Resources.GALAT);
            memainkan.Play();
        }

        public void suaraTanya(bool enable)
        {
            SoundPlayer memainkan = new SoundPlayer(BurnFormat.Properties.Resources.QUESTION);
            memainkan.Play();
        }

        #endregion

        #region cekIMAPI, cekDrive dan scanMedia

        public void cekIMAPI()
        {
            MsftDiscMaster2 Master = null;

            try
            {
                Master = new MsftDiscMaster2();

                if (!Master.IsSupportedEnvironment)
                    return;
                foreach (string uniqueRecorderID in Master)
                {
                    MsftDiscRecorder2 Recorder = new MsftDiscRecorder2();
                    Recorder.InitializeDiscRecorder(uniqueRecorderID);
                    comboBoxDrive.Items.Add(Recorder);
                }
                if (comboBoxDrive.Items.Count > 0)
                {
                    comboBoxDrive.SelectedIndex = 0;
                }
            }

            catch
            {
                suaraGalat(true);

                MessageBox.Show(this, "Sepertinya IMAPI2 tidak ditemukan dalam Sistem Operasi ini.",
                                pesan, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                kembaliKeFormUtama();
            }

            finally
            {
                if (Master != null)
                {
                    Marshal.ReleaseComObject(Master);
                }
            }
        }

        public void cekDrive()
        {
            IDiscRecorder2 Recorder = (IDiscRecorder2)comboBoxDrive.Items[comboBoxDrive.SelectedIndex];
            IDiscFormat2Data FormatData = null;

            try
            {
                FormatData = new MsftDiscFormat2Data();
                if (!FormatData.IsRecorderSupported(Recorder))
                {
                    aktifkanUIFormat(false);
                }
                else
                {
                    aktifkanUIFormat(true);
                }
            }

            catch
            {
                suaraGalat(true);

                MessageBox.Show(this, "Drive ini tidak mendukung Formatting. \nSilakan pilih drive lainnya atau hubungi manufaktur komputer ini.",
                pesan, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            finally
            {
                if (FormatData != null)
                {
                    Marshal.ReleaseComObject(FormatData);
                }
            }
        }

        public void scanMedia()
        {
            if (comboBoxDrive.SelectedIndex == -1)
            {
                return;
            }

            IDiscRecorder2 Recorder = (IDiscRecorder2)comboBoxDrive.Items[comboBoxDrive.SelectedIndex];
            MsftDiscFormat2Erase FormatErase = null;

            try
            {
                FormatErase = new MsftDiscFormat2Erase();
                if (!FormatErase.IsCurrentMediaSupported(Recorder))
                {
                    pictureBoxDisc.Image = BurnFormat.Properties.Resources.CAUTION;
                    suaraGalat(true);
                    buttonFormat.Enabled = false;
                    return;
                }
                else
                {
                    FormatErase.Recorder = Recorder;
                    IMAPI_MEDIA_PHYSICAL_TYPE mediaType = FormatErase.CurrentPhysicalMediaType;
                    pictureBoxDisc.Image = jenisDisc(mediaType);
                    buttonFormat.Enabled = true;
                }             
            }

            catch
            {
                suaraGalat(true);
                buttonFormat.Enabled = false;
            }

            finally
            {
                if (FormatErase != null)
                {
                    Marshal.ReleaseComObject(FormatErase);
                    FormatErase = null;
                }
            }
        }

        #endregion

        #region User Interface On-Off

        void aktifkanUIFormat(bool enable)
        {
            buttonFormat.Text = enable ? "FORMAT" : "BATALKAN";

            checkBoxKeluarkanTray.Enabled = enable;
            checkBoxMainkanSuara.Enabled = enable;
            checkBoxFormatCepat.Enabled = enable;

            buttonRefresh.Enabled = enable;

            comboBoxDrive.Enabled = enable;
        }

        public void penjelasanMethod()
        {
            if (checkBoxFormatCepat.Checked)
            {
                labelPenjelasan.Text = "Pilihan method ini hanya untuk menghapus TOC (Table of Contents) Hilangkan centang untuk memilih method *Menyeluruh* jika ada data sensitif dalam disc.";
            }
            else
            {
                labelPenjelasan.Text = "Pilihan method ini akan menghapus semua data dalam disc, tapi tentunya akan memakan waktu yang lebih lama dari method *Format Cepat*";
            }
        }

        #endregion

        #endregion

        #region Drive dan Parameter

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            scanMedia();
        }

        private void comboBoxDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrive.SelectedIndex == -1)
            {
                return;
            }

            cekDrive();
            scanMedia();
        }

        private void comboBoxDrive_Format(object sender, ListControlConvertEventArgs e)
        {
            IDiscRecorder2 Recorder = (IDiscRecorder2)e.ListItem;
            string device = string.Empty;
            string volume = (string)Recorder.VolumePathNames.GetValue(0);
            foreach (string volPath in Recorder.VolumePathNames)
            {
                if (!string.IsNullOrEmpty(device))
                {
                    device += ",";
                }
                device += volume;
            }

            e.Value = string.Format("{0} [{1}]", device, Recorder.ProductId);
        }

        Image jenisDisc(IMAPI_MEDIA_PHYSICAL_TYPE disc)
        {
            switch (disc)
            {
                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_UNKNOWN:
                default:
                    return BurnFormat.Properties.Resources.CAUTION;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDROM:
                    return BurnFormat.Properties.Resources.CDROM;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDR:
                    return BurnFormat.Properties.Resources.CDminR;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_CDRW:
                    return BurnFormat.Properties.Resources.CDminRW;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDROM:
                    return BurnFormat.Properties.Resources.DVDROM;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDRAM:
                    return BurnFormat.Properties.Resources.DVDminRAM;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR:
                    return BurnFormat.Properties.Resources.DVDplusR;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW:
                    return BurnFormat.Properties.Resources.DVDplusRW;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER:
                    return BurnFormat.Properties.Resources.DVDplusRDL;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR:
                    return BurnFormat.Properties.Resources.DVDminR;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHRW:
                    return BurnFormat.Properties.Resources.DVDminRW;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER:
                    return BurnFormat.Properties.Resources.DVDminRDL;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK:
                    return BurnFormat.Properties.Resources.RAM;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER:
                    return BurnFormat.Properties.Resources.HDDVDDL;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDROM:
                    return BurnFormat.Properties.Resources.HDDVD;

                /*case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDR:
                    return BurnFormat.Properties.Resources.HDDVDminR;*/

                /*case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_HDDVDRAM:
                    return BurnFormat.Properties.Resources.HDDVDminRAM;*/

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDROM:
                    return BurnFormat.Properties.Resources.BD;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDR:
                    return BurnFormat.Properties.Resources.BD;

                case IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_BDRE:
                    return BurnFormat.Properties.Resources.BDminRE;
            }
        }

        #endregion

        #region Proses

        void eraseUpdate([In, MarshalAs(UnmanagedType.IDispatch)] object sender, int waktuBerjalan, int waktuTotal)
        {
            IDiscFormat2Erase Format = (IDiscFormat2Erase)sender;
            int persenProses = waktuBerjalan * 100 / waktuTotal;
            backgroundWorker.ReportProgress(persenProses);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 Recorder = null;
            MsftDiscFormat2Erase Format = null;
            MsftFileSystemImage fileSystem = null;

            try
            {
                Recorder = new MsftDiscRecorder2();
                string activeDiscRecorder = (string)e.Argument;
                Recorder.InitializeDiscRecorder(activeDiscRecorder);
                Recorder.AcquireExclusiveAccess(true, namaProgram);

                fileSystem = new MsftFileSystemImage();
                fileSystem.VolumeName = "";

                Format = new MsftDiscFormat2Erase();
                Format.Recorder = Recorder;
                Format.ClientName = namaProgram;
                Format.FullErase = checkBoxFormatCepat.Checked;

                Format.Update += new DiscFormat2Erase_EventHandler(eraseUpdate);

                try
                {
                    Format.EraseMedia();
                    e.Result = 0;
                }

                catch (COMException ex)
                {
                    e.Result = ex.ErrorCode;
                    MessageBox.Show("Sepertinya media ini tidak bisa dihapus...\nKemungkinan media terkunci, diproteksi atau sudah rusak.", pesan,
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

                Format.Update -= new DiscFormat2Erase_EventHandler(eraseUpdate);

                if (checkBoxKeluarkanTray.Checked)
                {
                    Recorder.EjectMedia();
                }
            }

            catch (COMException exception)
            {
                MessageBox.Show(exception.Message, pesan);
                if (checkBoxKeluarkanTray.Checked)
                {
                    Recorder.EjectMedia();
                }
            }

            finally
            {
                if (Recorder != null)
                {
                    Recorder.ReleaseExclusiveAccess();
                    Marshal.ReleaseComObject(Recorder);
                }

                if (Format != null)
                {
                    Marshal.ReleaseComObject(Format);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelStatus.Text = string.Format("Menghapus media, proses berlangsung {0}%", e.ProgressPercentage);
            progressBarStatus.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                labelStatus.Text = "Proses penghapusan media telah selesai...";
                if (checkBoxMainkanSuara.Checked)
                {
                    suaraSukses(true);
                }
            }

            else
            {
                labelStatus.Text = "Upss!! Terjadi kesalahan dalam proses penghapusan...";
                if (checkBoxMainkanSuara.Checked)
                {
                    suaraGagal(true);
                }
            }

            sedangMenghapus = false;
            progressBarStatus.Value = 0;
            aktifkanUIFormat(true);
        }

        private void buttonFormat_Click(object sender, EventArgs e)
        {
            if (comboBoxDrive.SelectedIndex == -1)
            {
                return;
            }

            if (sedangMenghapus)
            {
                buttonFormat.Enabled = false;
                backgroundWorker.CancelAsync();
            }
            else
            {
                sedangMenghapus = true;
                aktifkanUIFormat(false);
                IDiscRecorder2 discRecorder = (IDiscRecorder2)comboBoxDrive.Items[comboBoxDrive.SelectedIndex];
                backgroundWorker.RunWorkerAsync(discRecorder.ActiveDiscRecorder);
            }
        }

        #endregion
    }
}
