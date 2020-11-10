using System;
using System.IO;
using System.Data;
using System.Text;
using System.Media;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Resources;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

using Data.MediaItem;
using IMAPI2.Interop;

namespace BurnFormat
{
    public partial class Burner : Form
    {
        /// <summary>
        /// Managed code untuk stream file *.ISO
        /// </summary>
        /// <param name="pszFile"></param>
        /// <param name="grfMode"></param>
        /// <param name="ppstm"></param>
        /// <returns></returns>
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        static extern int SHCreateStreamOnFile(string pszFile, uint grfMode, out IMAPI2.Interop.FsiStream ppstm);

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

        private string namaProgram = "BurnFormat";
        private string pesan = "Program ini menjelaskan :";

        private bool sedangMembakar = false;

        private BURN_INTERFACE burnMedia = new BURN_INTERFACE();

        Int64 ukuranDiscTotal = 0;

        private IMAPI_BURN_VERIFICATION_LEVEL verificationLevel = IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_QUICK;

        public Burner()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Burner_Load(object sender, EventArgs e)
        {
            scanMedia();
            cekIMAPI();
            matikanTombolClose();

            updateUIData();
            comboBoxVerifikasi.SelectedIndex = 1;
            DateTime sekarang = DateTime.Now;
            textBoxNamaDisc.Text = sekarang.Day + "-" + sekarang.Month + "-" + sekarang.Year;
        }
        
        #region Pilihan Selanjutnya

        /// <summary>
        /// Cek parameter tiap waktu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (sedangMembakar == true)
                buttonSelanjutnya.Enabled = false;
            else
                buttonSelanjutnya.Enabled = true;
        }

        /// <summary>
        /// Kembali ke form utama
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelanjutnya_Click(object sender, EventArgs e)
        {
            releaseCOM();
            kembaliKeFormUtama();
        }

        #endregion

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
                    aktifkanUIData(false);
                    aktifkanUIImage(false);
                }
            }

            catch
            {
                suaraGalat(true);

                MessageBox.Show(this, "Drive ini tidak mendukung Burning. \nSilakan pilih drive lainnya atau hubungi manufaktur komputer ini.",
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
            MsftFileSystemImage SystemImage = null;
            MsftDiscFormat2Data FormatData = null;

            try
            {
                FormatData = new MsftDiscFormat2Data();
                if (!FormatData.IsCurrentMediaSupported(Recorder))
                {
                    ukuranDiscTotal = 0;
                    pictureBoxDisc.Image = BurnFormat.Properties.Resources.CAUTION;
                    suaraGalat(true);
                    return;
                }
                else
                {
                    FormatData.Recorder = Recorder;
                    IMAPI_MEDIA_PHYSICAL_TYPE mediaType = FormatData.CurrentPhysicalMediaType;
                    pictureBoxDisc.Image = jenisDisc(mediaType);

                    SystemImage = new MsftFileSystemImage();
                    SystemImage.ChooseImageDefaultsForMediaType(mediaType);

                    if (!FormatData.MediaHeuristicallyBlank)
                    {
                        SystemImage.MultisessionInterfaces = FormatData.MultisessionInterfaces;
                        SystemImage.ImportFileSystem();
                    }

                    Int64 spaceBebas = SystemImage.FreeMediaBlocks;
                    ukuranDiscTotal = 2048 * spaceBebas;

                    buttonBurn.Enabled = true;
                }
            }

            catch (COMException exception)
            {
                suaraGalat(true);
                pictureBoxDisc.Image = BurnFormat.Properties.Resources.CAUTION;

                MessageBox.Show(this, exception.Message, pesan,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (FormatData != null)
                {
                    Marshal.ReleaseComObject(FormatData);
                    FormatData = null;
                }

                if (SystemImage != null)
                {
                    Marshal.ReleaseComObject(SystemImage);
                    SystemImage = null;
                }
            }
            kapasitasData();
        }

        #endregion

        #region User Interface On-Off

        void aktifkanUIData(bool enable)
        {
            buttonBurn.Text = enable ? "BAKAR" : "BATALKAN";
            radioButtonImage.Enabled = enable;

            textBoxNamaDisc.Enabled = enable;
            listBox.Enabled = enable;

            buttonFile.Enabled = enable;
            buttonFolder.Enabled = enable;
            buttonHapus.Enabled = enable;

            checkBoxKeluarkanTray.Enabled = enable;
            checkBoxSekaliPakai.Enabled = enable;          
            checkBoxMainkanSuara.Enabled = enable;
            
            buttonRefresh.Enabled = enable;

            comboBoxDrive.Enabled = enable;
            comboBoxVerifikasi.Enabled = enable;
        }

        void aktifkanUIImage(bool enable)
        {
            buttonBurn.Text = enable ? "BAKAR" : "BATALKAN";
            radioButtonData.Enabled = enable;

            buttonImage.Enabled = enable;
            buttonHapusImage.Enabled = enable;

            checkBoxKeluarkanTray.Enabled = enable;
            checkBoxMainkanSuara.Enabled = enable;

            buttonRefresh.Enabled = enable;

            comboBoxDrive.Enabled = enable;
            comboBoxVerifikasi.Enabled = enable;
        }

        #endregion

        #region buttonBurn

        private void burnData()
        {
            if (comboBoxDrive.SelectedIndex == -1)
            {
                return;
            }

            if (sedangMembakar)
            {
                buttonBurn.Enabled = false;
                backgroundWorker.CancelAsync();
            }
            else
            {
                sedangMembakar = true;
                aktifkanUIData(false);
                IDiscRecorder2 discRecorder = (IDiscRecorder2)comboBoxDrive.Items[comboBoxDrive.SelectedIndex];
                burnMedia.uniqueRecorderId = discRecorder.ActiveDiscRecorder;
                backgroundWorker.RunWorkerAsync(burnMedia);
            }
        }

        private void burnImage()
        {
            if (comboBoxDrive.SelectedIndex == -1)
            {
                return;
            }

            if (string.IsNullOrEmpty(textBoxImage.Text))
            {
                if (openFileImage.ShowDialog(this) == DialogResult.OK)
                {
                    textBoxImage.Text = openFileImage.FileName;
                }
            }

            if (sedangMembakar)
            {
                buttonBurn.Enabled = false;
                backgroundWorker.CancelAsync();
            }
            else
            {
                sedangMembakar = true;
                aktifkanUIImage(false);
                IDiscRecorder2 discRecorder = (IDiscRecorder2)comboBoxDrive.Items[comboBoxDrive.SelectedIndex];
                burnMedia.uniqueRecorderId = discRecorder.ActiveDiscRecorder;
                backgroundWorker.RunWorkerAsync(burnMedia);
            }
        }

        #endregion

        #endregion

        #region Drive dan Parameter

        private void comboBoxVerifikasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            verificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)comboBoxVerifikasi.SelectedIndex;
        }

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

        #region Sumber Data

        #region radioButton

        private void radioButtonImage_CheckedChanged(object sender, EventArgs e)
        {
            updateUIImage();
            listBox.Items.Clear();
            groupBoxUkuranData.Visible = false;
        }

        private void radioButtonData_CheckedChanged(object sender, EventArgs e)
        {
            updateUIData();
            textBoxImage.Text = "";
            groupBoxUkuranData.Visible = true;
        }

        public void updateUIData()
        {
            listBox.Visible = true;
            buttonFile.Visible = true;
            buttonFolder.Visible = true;
            buttonHapus.Visible = true;
            labelNamaDisc.Visible = true;
            textBoxNamaDisc.Visible = true;
            checkBoxSekaliPakai.Visible = true;
            checkBoxSekaliPakai.Enabled = true;
            textBoxImage.Visible = false;
            buttonImage.Visible = false;
            buttonHapusImage.Visible = false;
        }

        public void updateUIImage()
        {
            listBox.Visible = false;
            buttonFile.Visible = false;
            buttonFolder.Visible = false;
            buttonHapus.Visible = false;
            labelNamaDisc.Visible = false;
            textBoxNamaDisc.Visible = false;
            checkBoxSekaliPakai.Enabled = false;
            textBoxImage.Visible = true;
            buttonImage.Visible = true;
            buttonHapusImage.Visible = true;
        }

        #endregion

        #region buttonData

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (openFileData.ShowDialog(this) == DialogResult.OK)
            {
                FileItem fileItem = new FileItem(openFileData.FileName);
                listBox.Items.Add(fileItem);
                kapasitasData();
            }
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowser.ShowDialog(this) == DialogResult.OK)
            {
                DirectoryItem direktoriItem = new DirectoryItem(folderBrowser.SelectedPath);
                listBox.Items.Add(direktoriItem);
                kapasitasData();
            }
        }

        private void buttonHapus_Click(object sender, EventArgs e)
        {
            suaraTanya(true);

            IMediaItem mediaItem = (IMediaItem)listBox.SelectedItem;

            if (mediaItem == null)
                return;

            if (MessageBox.Show("Yakin ingin menghapus \"" + mediaItem + "\"?", pesan,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listBox.Items.Remove(mediaItem);
                kapasitasData();
            }
        }

        #endregion

        #region buttonImage

        private void buttonImage_Click(object sender, EventArgs e)
        {
            if (openFileImage.ShowDialog(this) == DialogResult.OK)
            {
                    textBoxImage.Text = openFileImage.FileName;        
            }
        }

        private void buttonHapusImage_Click(object sender, EventArgs e)
        {
            suaraTanya(true);

            if (MessageBox.Show("Yakin ingin menghapus \"" + textBoxImage.Text + "\"?", pesan,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                textBoxImage.Text = "";
            }
        }

        private void textBoxImage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxImage.Text))
            {
                buttonImage.Enabled = true;
                buttonHapusImage.Enabled = false;
            }
            else
            {
                buttonImage.Enabled = false;
                buttonHapusImage.Enabled = true;
            }
        }

        #endregion

        #region ListBox

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonHapus.Enabled = (listBox.SelectedIndex != -1);
        }

        private void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            IMediaItem mediaItem = (IMediaItem)listBox.Items[e.Index];
            if (mediaItem == null)
            {
                return;
            }

            e.DrawBackground();

            if ((e.State & DrawItemState.Focus) != 0)
            {
                e.DrawFocusRectangle();
            }

            if (mediaItem.FileIconImage != null)
            {
                e.Graphics.DrawImage(mediaItem.FileIconImage, new Rectangle(4, e.Bounds.Y + 10, 16, 16));
            }

            RectangleF rectF = new RectangleF(e.Bounds.X + 24, e.Bounds.Y, e.Bounds.Width - 24, e.Bounds.Height);
            Font font = new Font(FontFamily.GenericSansSerif, 11);
            StringFormat stringFormat = new StringFormat();
            stringFormat.LineAlignment = StringAlignment.Center;
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(mediaItem.ToString(), font, new SolidBrush(e.ForeColor), rectF, stringFormat);
        }

        #endregion

        #endregion

        #region Ukuran Data

        private void kapasitasData()
        {
            if (ukuranDiscTotal == 0)
            {
                labelUkuranTotal.Text = "?? MB";
                return;
            }
            else if (ukuranDiscTotal < 1000000000)
            {
                labelUkuranTotal.Text = string.Format("{0} MB", ukuranDiscTotal / 1000000);
            }
            else
            {
                labelUkuranTotal.Text = string.Format("{0:F2} GB", (float)ukuranDiscTotal / 1000000000.0);
            }

            Int64 ukuranMediaTotal = 0;
            foreach (IMediaItem mediaItem in listBox.Items)
            {
                ukuranMediaTotal += mediaItem.ukuranDiDisc;
            }

            if (ukuranMediaTotal == 0)
            {
                progressBarKapasitas.Value = 0;
                progressBarKapasitas.ForeColor = SystemColors.Highlight;
                buttonFile.Enabled = true;
                buttonFolder.Enabled = true;
                buttonBurn.Enabled = true;
            }
            else
            {
                int kapasitas = (int)((ukuranMediaTotal * 100) / ukuranDiscTotal);
                if (kapasitas > 100)
                {
                    progressBarKapasitas.Value = 100;
                    progressBarKapasitas.ForeColor = Color.Red;
                    buttonFile.Enabled = false;
                    buttonFolder.Enabled = false;
                    buttonBurn.Enabled = false;
                }
                else if(kapasitas < 100)
                {
                    progressBarKapasitas.Value = kapasitas;
                    progressBarKapasitas.ForeColor = SystemColors.Highlight;
                    buttonFile.Enabled = true;
                    buttonFolder.Enabled = true;
                    buttonBurn.Enabled = true;
                }
            }
        }

        #endregion

        #region Proses

        void burningUpdate([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.IDispatch)] object progress)
        {
            if (backgroundWorker.CancellationPending)
            {
                IDiscFormat2Data Data = (IDiscFormat2Data)sender;
                Data.CancelWrite();
                return;
            }

            IDiscFormat2DataEventArgs kejadian = (IDiscFormat2DataEventArgs)progress;
            burnMedia.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING;

            burnMedia.elapsedTime = kejadian.ElapsedTime;
            burnMedia.remainingTime = kejadian.RemainingTime;
            burnMedia.totalTime = kejadian.TotalTime;

            burnMedia.currentAction = kejadian.CurrentAction;
            burnMedia.startLba = kejadian.StartLba;
            burnMedia.sectorCount = kejadian.SectorCount;
            burnMedia.lastReadLba = kejadian.LastReadLba;
            burnMedia.lastWrittenLba = kejadian.LastWrittenLba;
            burnMedia.totalSystemBuffer = kejadian.TotalSystemBuffer;
            burnMedia.usedSystemBuffer = kejadian.UsedSystemBuffer;
            burnMedia.freeSystemBuffer = kejadian.FreeSystemBuffer;

            backgroundWorker.ReportProgress(0, burnMedia);
        }

        private bool membuatFileSystem(IDiscRecorder2 Recorder, object[] multiSesi, out IStream streamData)
        {
            MsftFileSystemImage fileSystem = null;

            try
            {
                fileSystem = new MsftFileSystemImage();
                fileSystem.ChooseImageDefaults(Recorder);
                fileSystem.FileSystemsToCreate = FsiFileSystems.FsiFileSystemJoliet | FsiFileSystems.FsiFileSystemISO9660;
                fileSystem.VolumeName = textBoxNamaDisc.Text;

                fileSystem.Update += new DFileSystemImage_EventHandler(fileSystemHandler);

                if (multiSesi != null)
                {
                    fileSystem.MultisessionInterfaces = multiSesi;
                    fileSystem.ImportFileSystem();
                }

                IFsiDirectoryItem rootItem = fileSystem.Root;

                foreach (IMediaItem mediaItem in listBox.Items)
                {
                    if (backgroundWorker.CancellationPending)
                    {
                        break;
                    }
                    mediaItem.tambahkanKeFileSystem(rootItem);
                }

                fileSystem.Update -= new DFileSystemImage_EventHandler(fileSystemHandler);

                if (backgroundWorker.CancellationPending)
                {
                    streamData = null;
                    return false;
                }
                streamData = fileSystem.CreateResultImage().ImageStream;
            }

            catch (COMException exception)
            {
                MessageBox.Show(this, exception.Message, "Kesalahan File System dengan kode :",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                streamData = null;
                return false;
            }

            finally
            {
                if (fileSystem != null)
                {
                    Marshal.ReleaseComObject(fileSystem);
                }
            }
            return true;
        }

        void fileSystemHandler([In, MarshalAs(UnmanagedType.IDispatch)] object sender, [In, MarshalAs(UnmanagedType.BStr)]string fileDisimpan, [In] int sektorDisimpan, [In] int totalSektor)
        {
            int proses = 0;
            if (sektorDisimpan > 0 && totalSektor > 0)
            {
                proses = (sektorDisimpan * 100) / totalSektor;
            }

            if (!string.IsNullOrEmpty(fileDisimpan))
            {
                FileInfo fileInfo = new FileInfo(fileDisimpan);
                burnMedia.statusMessage = "Menambahkan \"" + fileInfo.Name + "\" ke...";
                burnMedia.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM;
                backgroundWorker.ReportProgress(proses, burnMedia);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (radioButtonData.Checked)
            {
                MsftDiscRecorder2 Recorder = null;
                MsftDiscFormat2Data Data = null;

                try
                {
                    Recorder = new MsftDiscRecorder2();
                    BURN_INTERFACE burnMedia = (BURN_INTERFACE)e.Argument;
                    Recorder.InitializeDiscRecorder(burnMedia.uniqueRecorderId);
                    Recorder.AcquireExclusiveAccess(true, namaProgram);

                    Data = new MsftDiscFormat2Data();
                    Data.Recorder = Recorder;
                    Data.ClientName = namaProgram;
                    Data.ForceMediaToBeClosed = checkBoxSekaliPakai.Checked;

                    IBurnVerification burnVerification = (IBurnVerification)Data;
                    burnVerification.BurnVerificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)verificationLevel;

                    object[] multisessionInterfaces = null;
                    if (!Data.MediaHeuristicallyBlank)
                    {
                        multisessionInterfaces = Data.MultisessionInterfaces;
                    }

                    IStream fileSystem = null;
                    if (!membuatFileSystem(Recorder, multisessionInterfaces, out fileSystem))
                    {
                        e.Result = -1;
                        return;
                    }

                    Data.Update += new DiscFormat2Data_EventHandler(burningUpdate);

                    try
                    {
                        Data.Write(fileSystem);
                        e.Result = 0;
                    }

                    catch (COMException ex)
                    {
                        e.Result = ex.ErrorCode;
                        MessageBox.Show("Sepertinya terjadi masalah dalam I/O stream. \nTidak perlu panik, coba cek parameter...", pesan,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                    finally
                    {
                        if (fileSystem != null)
                        {
                            Marshal.FinalReleaseComObject(fileSystem);
                        }
                    }

                    Data.Update -= new DiscFormat2Data_EventHandler(burningUpdate);

                    if (this.checkBoxKeluarkanTray.Checked)
                    {
                        Recorder.EjectMedia();
                    }
                }

                catch (COMException exception)
                {
                    MessageBox.Show("Okay, ini mungkin masalah...\nCoba cek semua parameter dan lakukan ulang semua langkah dari awal.", pesan);
                    e.Result = exception.ErrorCode;
                    if (this.checkBoxKeluarkanTray.Checked)
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

                    if (Data != null)
                    {
                        Marshal.ReleaseComObject(Data);
                    }
                }
            }

            else if (radioButtonImage.Checked)
            {
                MsftDiscRecorder2 Recorder = null;
                MsftDiscFormat2Data Data = null;

                IMAPI2.Interop.FsiStream streamData = null;
                int imageStream = SHCreateStreamOnFile(textBoxImage.Text, 0x20, out streamData);

                if (imageStream < 0)
                    return;

                try
                {
                    Recorder = new MsftDiscRecorder2();
                    BURN_INTERFACE burnMedia = (BURN_INTERFACE)e.Argument;
                    Recorder.InitializeDiscRecorder(burnMedia.uniqueRecorderId);
                    Recorder.AcquireExclusiveAccess(true, namaProgram);

                    Data = new MsftDiscFormat2Data();
                    Data.Recorder = Recorder;
                    Data.ClientName = namaProgram;

                    IBurnVerification burnVerification = (IBurnVerification)Data;
                    burnVerification.BurnVerificationLevel = (IMAPI_BURN_VERIFICATION_LEVEL)verificationLevel;

                    Data.Update += new DiscFormat2Data_EventHandler(burningUpdate);

                    try
                    {
                        Data.Write(streamData);
                        e.Result = 0;
                    }
                    catch (COMException ex)
                    {
                        e.Result = ex.ErrorCode;
                        MessageBox.Show("Ups, terjadi kesalahan...\nHal ini karena ukuran *ISO yang tidak sesuai dengan ukuran media.", pesan,
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    finally
                    {
                        if (streamData != null)
                        {
                            Marshal.FinalReleaseComObject(streamData);
                        }
                    }

                    Data.Update -= new DiscFormat2Data_EventHandler(burningUpdate);

                    if (this.checkBoxKeluarkanTray.Checked)
                    {
                        Recorder.EjectMedia();
                    }
                }

                catch (COMException exception)
                {
                    MessageBox.Show("Okay, ini mungkin masalah...\nCoba cek semua parameter dan lakukan ulang semua langkah dari awal.", pesan);
                    e.Result = exception.ErrorCode;
                    if (this.checkBoxKeluarkanTray.Checked)
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

                    if (Data != null)
                    {
                        Marshal.ReleaseComObject(Data);
                    }
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BURN_INTERFACE proses = (BURN_INTERFACE)e.UserState;

            if (proses.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM)
            {
                labelStatus.Text = proses.statusMessage;
            }

            else if (proses.task == BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING)
            {
                switch (proses.currentAction)
                {
                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA:
                        labelStatus.Text = "Validasi media disc...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA:
                        labelStatus.Text = "Format media disc...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE:
                        labelStatus.Text = "Mempersiapkan drive...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER:
                        labelStatus.Text = "Optimasi kekuatan laser...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA:
                        long sektorDitulis = proses.lastWrittenLba - proses.startLba;

                        if (sektorDitulis > 0 && proses.sectorCount > 0)
                        {
                            int prosesPersen = (int)((100 * sektorDitulis) / proses.sectorCount);
                            labelStatus.Text = string.Format("Proses sedang berjalan : {0}%", prosesPersen);
                            progressBarStatus.Value = prosesPersen;
                        }
                        else
                        {
                            labelStatus.Text = "Proses masih 0%";
                            progressBarStatus.Value = 0;
                        }
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION:
                        labelStatus.Text = "Menyelesaikan proses pembakaran...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED:
                        labelStatus.Text = "Yaph! proses pembakaran data selesai...";
                        break;

                    case IMAPI_FORMAT2_DATA_WRITE_ACTION.IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING:
                        labelStatus.Text = "Sedang melakukan verifikasi...";
                        break;
                }
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 0)
            {
                labelStatus.Text = "Proses pembakaran data selesai dengan sempurna...";
                if (checkBoxMainkanSuara.Checked)
                {
                    suaraSukses(true);
                }
            }

            else
            {
                labelStatus.Text = "Uups! Terjadi kesalahan dalam proses pembakaran...";
                if (checkBoxMainkanSuara.Checked)
                {
                    suaraGagal(true);
                }
            }

            sedangMembakar = false;
            progressBarStatus.Value = 0;
            aktifkanUIData(true);
            aktifkanUIImage(true);
        }

        private void buttonBurn_Click(object sender, EventArgs e)
        {
            if (radioButtonData.Checked)
            {
                burnData();
            }
            else if (radioButtonImage.Checked)
            {
                burnImage();
            }
        }

        #endregion
    }
}
