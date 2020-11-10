using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;

using IMAPI2.Interop;

namespace BurnFormat
{
    public partial class Informasi : Form
    {
        private string pesan = "Program ini menjelaskan :";

        public Informasi()
        {
            InitializeComponent();
        }

        #region Load & Close

        private void Informasi_Load(object sender, EventArgs e)
        {
            cekIMAPI();
            cekDrive();
        }

        private void Informasi_Close(object sender, FormClosingEventArgs e)
        {
            releaseCOM();
            kembaliKeFormUtama();
        }

        #endregion

        #region ComboBox Drive

        private void comboBoxDrive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDrive.SelectedIndex == -1)
            {
                return;
            }

            cekDrive();
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
            foreach (MsftDiscRecorder2 discRecorder2 in comboBoxDrive.Items)
            {
                if (discRecorder2 != null)
                {
                    Marshal.ReleaseComObject(discRecorder2);
                }
            }
        }

        public void suaraGalat(bool enable)
        {
            SoundPlayer memainkan = new SoundPlayer(BurnFormat.Properties.Resources.GALAT);
            memainkan.Play();
        }

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

                MessageBox.Show(this, "IMAPI2 tidak ditemukan dalam Sistem Operasi ini.",
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
            richTextBox.Text = string.Empty;

            try
            {
                StringBuilder tipeMedia = new StringBuilder();
                foreach (IMAPI_PROFILE_TYPE profileType in Recorder.SupportedProfiles)
                {
                    string profileName = jenisDrive(profileType);

                    if (string.IsNullOrEmpty(profileName))
                        continue;

                    if (tipeMedia.Length > 0)
                        tipeMedia.Append("\n");
                    tipeMedia.Append(profileName);
                }
                richTextBox.Text = tipeMedia.ToString();
            }

            catch
            {
                richTextBox.Text = "KESALAHAN MENDETEKSI DRIVE !@#$%";
            }

            finally
            {
                if (FormatData != null)
                {
                    Marshal.ReleaseComObject(FormatData);
                }
            }
        }

        static string jenisDrive(IMAPI_PROFILE_TYPE drive)
        {
            switch (drive)
            {
                default:
                    return string.Empty;

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_CD_RECORDABLE:
                    return "Compact Disc - Recordable (CD-R)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_CD_REWRITABLE:
                    return "Compact Disc - Rewriteable (CD-RW)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVDROM:
                    return "Digital Versatile Disc - Read Only Memory (DVD-ROM)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_RECORDABLE:
                    return "Digital Versatile Disc - Recordable (DVD-R)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_RAM:
                    return "Digital Versatile Disc - Random Access Memory (DVD-RAM)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_R:
                    return "Digital Versatile Disc + Recordable (DVD+R)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_RW:
                    return "Digital Versatile Disc + Rewriteable (DVD+RW)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_R_DUAL:
                    return "Digital Versatile Disc + Recordable Dual Layer (DVD+R DL)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_REWRITABLE:
                    return "Digital Versatile Disc - Rewriteable (DVD-RW)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_RW_SEQUENTIAL:
                    return "Digital Versatile Disc - Rewriteable Sequential (DVD-RW SEQ)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_SEQUENTIAL:
                    return "Digital Versatile Disc - Dual Layer Sequential (DVD-R DL SEQ)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_LAYER_JUMP:
                    return "Digital Versatile Disc - Recordable Dual Layer (DVD-R DL)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_DVD_PLUS_RW_DUAL:
                    return "Digital Versatile Disc + Rewriteable Dual Layer (DVD+RW DL)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_HD_DVD_ROM:
                    return "High Density Digital Versatile Disc - Read Only Memory (HD DVD-ROM)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_HD_DVD_RECORDABLE:
                    return "High Density Digital Versatile Disc - Recordable (HD DVD-R)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_HD_DVD_RAM:
                    return "High Density Digital Versatile Disc - Random Access Memory (HD DVD-RAM)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_ROM:
                    return "Blu-ray - Read Only Memory (BD-ROM)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_R_SEQUENTIAL:
                    return "Blu-ray - Recordable Sequential (BD-R SEW)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_R_RANDOM_RECORDING:
                    return "Blu-ray - Recordable (BD-R)";

                case IMAPI_PROFILE_TYPE.IMAPI_PROFILE_TYPE_BD_REWRITABLE:
                    return "Blu-ray - Rewriteable (BD-RW)";
            }
        }

        #endregion   
    }
}
