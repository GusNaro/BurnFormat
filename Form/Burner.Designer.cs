namespace BurnFormat
{
    partial class Burner
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Burner));
            this.radioButtonImage = new System.Windows.Forms.RadioButton();
            this.groupBoxSumberData = new System.Windows.Forms.GroupBox();
            this.buttonHapusImage = new System.Windows.Forms.Button();
            this.groupBoxPilihanSumber = new System.Windows.Forms.GroupBox();
            this.radioButtonData = new System.Windows.Forms.RadioButton();
            this.textBoxNamaDisc = new System.Windows.Forms.TextBox();
            this.buttonFolder = new System.Windows.Forms.Button();
            this.labelNamaDisc = new System.Windows.Forms.Label();
            this.buttonImage = new System.Windows.Forms.Button();
            this.buttonHapus = new System.Windows.Forms.Button();
            this.textBoxImage = new System.Windows.Forms.TextBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.groupBoxDrive = new System.Windows.Forms.GroupBox();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.pictureBoxDisc = new System.Windows.Forms.PictureBox();
            this.labelPemberitahuan = new System.Windows.Forms.Label();
            this.comboBoxVerifikasi = new System.Windows.Forms.ComboBox();
            this.labelVerifikasi = new System.Windows.Forms.Label();
            this.checkBoxMainkanSuara = new System.Windows.Forms.CheckBox();
            this.checkBoxSekaliPakai = new System.Windows.Forms.CheckBox();
            this.checkBoxKeluarkanTray = new System.Windows.Forms.CheckBox();
            this.comboBoxDrive = new System.Windows.Forms.ComboBox();
            this.labelDrive = new System.Windows.Forms.Label();
            this.groupBoxUkuranData = new System.Windows.Forms.GroupBox();
            this.labelUkuranTotal = new System.Windows.Forms.Label();
            this.labelNol = new System.Windows.Forms.Label();
            this.progressBarKapasitas = new System.Windows.Forms.ProgressBar();
            this.groupBoxProses = new System.Windows.Forms.GroupBox();
            this.buttonBurn = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.openFileData = new System.Windows.Forms.OpenFileDialog();
            this.openFileImage = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonSelanjutnya = new System.Windows.Forms.Button();
            this.groupBoxSumberData.SuspendLayout();
            this.groupBoxPilihanSumber.SuspendLayout();
            this.groupBoxDrive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisc)).BeginInit();
            this.groupBoxUkuranData.SuspendLayout();
            this.groupBoxProses.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonImage
            // 
            this.radioButtonImage.AutoSize = true;
            this.radioButtonImage.Location = new System.Drawing.Point(6, 34);
            this.radioButtonImage.Name = "radioButtonImage";
            this.radioButtonImage.Size = new System.Drawing.Size(95, 23);
            this.radioButtonImage.TabIndex = 0;
            this.radioButtonImage.Text = "Disc image";
            this.radioButtonImage.UseVisualStyleBackColor = true;
            this.radioButtonImage.CheckedChanged += new System.EventHandler(this.radioButtonImage_CheckedChanged);
            // 
            // groupBoxSumberData
            // 
            this.groupBoxSumberData.Controls.Add(this.buttonHapusImage);
            this.groupBoxSumberData.Controls.Add(this.groupBoxPilihanSumber);
            this.groupBoxSumberData.Controls.Add(this.textBoxNamaDisc);
            this.groupBoxSumberData.Controls.Add(this.buttonFolder);
            this.groupBoxSumberData.Controls.Add(this.labelNamaDisc);
            this.groupBoxSumberData.Controls.Add(this.buttonImage);
            this.groupBoxSumberData.Controls.Add(this.buttonHapus);
            this.groupBoxSumberData.Controls.Add(this.textBoxImage);
            this.groupBoxSumberData.Controls.Add(this.listBox);
            this.groupBoxSumberData.Controls.Add(this.buttonFile);
            this.groupBoxSumberData.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSumberData.Location = new System.Drawing.Point(12, 161);
            this.groupBoxSumberData.Name = "groupBoxSumberData";
            this.groupBoxSumberData.Size = new System.Drawing.Size(701, 214);
            this.groupBoxSumberData.TabIndex = 0;
            this.groupBoxSumberData.TabStop = false;
            this.groupBoxSumberData.Text = "Sumber data";
            // 
            // buttonHapusImage
            // 
            this.buttonHapusImage.Enabled = false;
            this.buttonHapusImage.Image = global::BurnFormat.Properties.Resources.HAPUS;
            this.buttonHapusImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHapusImage.Location = new System.Drawing.Point(530, 118);
            this.buttonHapusImage.Name = "buttonHapusImage";
            this.buttonHapusImage.Size = new System.Drawing.Size(165, 44);
            this.buttonHapusImage.TabIndex = 0;
            this.buttonHapusImage.Text = "Hapus pilihan";
            this.buttonHapusImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHapusImage.UseVisualStyleBackColor = true;
            this.buttonHapusImage.Visible = false;
            this.buttonHapusImage.Click += new System.EventHandler(this.buttonHapusImage_Click);
            // 
            // groupBoxPilihanSumber
            // 
            this.groupBoxPilihanSumber.Controls.Add(this.radioButtonImage);
            this.groupBoxPilihanSumber.Controls.Add(this.radioButtonData);
            this.groupBoxPilihanSumber.Location = new System.Drawing.Point(6, 63);
            this.groupBoxPilihanSumber.Name = "groupBoxPilihanSumber";
            this.groupBoxPilihanSumber.Size = new System.Drawing.Size(113, 100);
            this.groupBoxPilihanSumber.TabIndex = 0;
            this.groupBoxPilihanSumber.TabStop = false;
            this.groupBoxPilihanSumber.Text = "Pilihan";
            // 
            // radioButtonData
            // 
            this.radioButtonData.AutoSize = true;
            this.radioButtonData.Checked = true;
            this.radioButtonData.Location = new System.Drawing.Point(6, 60);
            this.radioButtonData.Name = "radioButtonData";
            this.radioButtonData.Size = new System.Drawing.Size(56, 23);
            this.radioButtonData.TabIndex = 0;
            this.radioButtonData.TabStop = true;
            this.radioButtonData.Text = "Data";
            this.radioButtonData.UseVisualStyleBackColor = true;
            this.radioButtonData.CheckedChanged += new System.EventHandler(this.radioButtonData_CheckedChanged);
            // 
            // textBoxNamaDisc
            // 
            this.textBoxNamaDisc.Location = new System.Drawing.Point(210, 21);
            this.textBoxNamaDisc.MaxLength = 12;
            this.textBoxNamaDisc.Name = "textBoxNamaDisc";
            this.textBoxNamaDisc.Size = new System.Drawing.Size(172, 27);
            this.textBoxNamaDisc.TabIndex = 0;
            this.textBoxNamaDisc.Visible = false;
            // 
            // buttonFolder
            // 
            this.buttonFolder.Image = global::BurnFormat.Properties.Resources.FOLDER;
            this.buttonFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFolder.Location = new System.Drawing.Point(530, 107);
            this.buttonFolder.Name = "buttonFolder";
            this.buttonFolder.Size = new System.Drawing.Size(165, 44);
            this.buttonFolder.TabIndex = 0;
            this.buttonFolder.Text = "Tambahkan folder";
            this.buttonFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFolder.UseVisualStyleBackColor = true;
            this.buttonFolder.Visible = false;
            this.buttonFolder.Click += new System.EventHandler(this.buttonFolder_Click);
            // 
            // labelNamaDisc
            // 
            this.labelNamaDisc.AutoSize = true;
            this.labelNamaDisc.Location = new System.Drawing.Point(129, 25);
            this.labelNamaDisc.Name = "labelNamaDisc";
            this.labelNamaDisc.Size = new System.Drawing.Size(75, 19);
            this.labelNamaDisc.TabIndex = 0;
            this.labelNamaDisc.Text = "Nama disc";
            this.labelNamaDisc.Visible = false;
            // 
            // buttonImage
            // 
            this.buttonImage.Image = global::BurnFormat.Properties.Resources.ISO;
            this.buttonImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImage.Location = new System.Drawing.Point(530, 71);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(165, 44);
            this.buttonImage.TabIndex = 0;
            this.buttonImage.Text = "Pilih image";
            this.buttonImage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Visible = false;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // buttonHapus
            // 
            this.buttonHapus.Enabled = false;
            this.buttonHapus.Image = global::BurnFormat.Properties.Resources.HAPUS;
            this.buttonHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHapus.Location = new System.Drawing.Point(530, 159);
            this.buttonHapus.Name = "buttonHapus";
            this.buttonHapus.Size = new System.Drawing.Size(165, 44);
            this.buttonHapus.TabIndex = 0;
            this.buttonHapus.Text = "Hapus pilihan";
            this.buttonHapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHapus.UseVisualStyleBackColor = true;
            this.buttonHapus.Visible = false;
            this.buttonHapus.Click += new System.EventHandler(this.buttonHapus_Click);
            // 
            // textBoxImage
            // 
            this.textBoxImage.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxImage.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImage.Location = new System.Drawing.Point(125, 104);
            this.textBoxImage.Name = "textBoxImage";
            this.textBoxImage.ReadOnly = true;
            this.textBoxImage.Size = new System.Drawing.Size(399, 27);
            this.textBoxImage.TabIndex = 0;
            this.textBoxImage.Visible = false;
            this.textBoxImage.TextChanged += new System.EventHandler(this.textBoxImage_TextChanged);
            // 
            // listBox
            // 
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 34;
            this.listBox.Location = new System.Drawing.Point(125, 59);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(399, 140);
            this.listBox.TabIndex = 0;
            this.listBox.Visible = false;
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // buttonFile
            // 
            this.buttonFile.Image = global::BurnFormat.Properties.Resources.FILE;
            this.buttonFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFile.Location = new System.Drawing.Point(530, 56);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(165, 44);
            this.buttonFile.TabIndex = 0;
            this.buttonFile.Text = "Tambahkan file";
            this.buttonFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Visible = false;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // groupBoxDrive
            // 
            this.groupBoxDrive.Controls.Add(this.buttonRefresh);
            this.groupBoxDrive.Controls.Add(this.pictureBoxDisc);
            this.groupBoxDrive.Controls.Add(this.labelPemberitahuan);
            this.groupBoxDrive.Controls.Add(this.comboBoxVerifikasi);
            this.groupBoxDrive.Controls.Add(this.labelVerifikasi);
            this.groupBoxDrive.Controls.Add(this.checkBoxMainkanSuara);
            this.groupBoxDrive.Controls.Add(this.checkBoxSekaliPakai);
            this.groupBoxDrive.Controls.Add(this.checkBoxKeluarkanTray);
            this.groupBoxDrive.Controls.Add(this.comboBoxDrive);
            this.groupBoxDrive.Controls.Add(this.labelDrive);
            this.groupBoxDrive.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDrive.Location = new System.Drawing.Point(12, 2);
            this.groupBoxDrive.Name = "groupBoxDrive";
            this.groupBoxDrive.Size = new System.Drawing.Size(701, 158);
            this.groupBoxDrive.TabIndex = 0;
            this.groupBoxDrive.TabStop = false;
            this.groupBoxDrive.Text = "Drive dan parameter";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Image = global::BurnFormat.Properties.Resources.REFRESH;
            this.buttonRefresh.Location = new System.Drawing.Point(296, 22);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(32, 33);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // pictureBoxDisc
            // 
            this.pictureBoxDisc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxDisc.Location = new System.Drawing.Point(428, 17);
            this.pictureBoxDisc.Name = "pictureBoxDisc";
            this.pictureBoxDisc.Size = new System.Drawing.Size(47, 45);
            this.pictureBoxDisc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxDisc.TabIndex = 10;
            this.pictureBoxDisc.TabStop = false;
            // 
            // labelPemberitahuan
            // 
            this.labelPemberitahuan.AutoSize = true;
            this.labelPemberitahuan.Location = new System.Drawing.Point(327, 30);
            this.labelPemberitahuan.Name = "labelPemberitahuan";
            this.labelPemberitahuan.Size = new System.Drawing.Size(109, 19);
            this.labelPemberitahuan.TabIndex = 0;
            this.labelPemberitahuan.Text = "Dalam tray ada ";
            // 
            // comboBoxVerifikasi
            // 
            this.comboBoxVerifikasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVerifikasi.FormattingEnabled = true;
            this.comboBoxVerifikasi.Items.AddRange(new object[] {
            "Tidak ada",
            "Cepat",
            "Menyeluruh"});
            this.comboBoxVerifikasi.Location = new System.Drawing.Point(133, 68);
            this.comboBoxVerifikasi.Name = "comboBoxVerifikasi";
            this.comboBoxVerifikasi.Size = new System.Drawing.Size(144, 27);
            this.comboBoxVerifikasi.TabIndex = 0;
            this.comboBoxVerifikasi.SelectedIndexChanged += new System.EventHandler(this.comboBoxVerifikasi_SelectedIndexChanged);
            // 
            // labelVerifikasi
            // 
            this.labelVerifikasi.AutoSize = true;
            this.labelVerifikasi.Location = new System.Drawing.Point(9, 71);
            this.labelVerifikasi.Name = "labelVerifikasi";
            this.labelVerifikasi.Size = new System.Drawing.Size(68, 19);
            this.labelVerifikasi.TabIndex = 0;
            this.labelVerifikasi.Text = "Verifikasi";
            // 
            // checkBoxMainkanSuara
            // 
            this.checkBoxMainkanSuara.AutoSize = true;
            this.checkBoxMainkanSuara.Checked = true;
            this.checkBoxMainkanSuara.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMainkanSuara.Location = new System.Drawing.Point(353, 124);
            this.checkBoxMainkanSuara.Name = "checkBoxMainkanSuara";
            this.checkBoxMainkanSuara.Size = new System.Drawing.Size(152, 23);
            this.checkBoxMainkanSuara.TabIndex = 0;
            this.checkBoxMainkanSuara.Text = "Mainkan efek suara";
            this.checkBoxMainkanSuara.UseVisualStyleBackColor = true;
            // 
            // checkBoxSekaliPakai
            // 
            this.checkBoxSekaliPakai.AutoSize = true;
            this.checkBoxSekaliPakai.Checked = true;
            this.checkBoxSekaliPakai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSekaliPakai.Location = new System.Drawing.Point(353, 99);
            this.checkBoxSekaliPakai.Name = "checkBoxSekaliPakai";
            this.checkBoxSekaliPakai.Size = new System.Drawing.Size(324, 23);
            this.checkBoxSekaliPakai.TabIndex = 0;
            this.checkBoxSekaliPakai.Text = "Sekali pakai *disc akan dapat digunakan sekali*";
            this.checkBoxSekaliPakai.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeluarkanTray
            // 
            this.checkBoxKeluarkanTray.AutoSize = true;
            this.checkBoxKeluarkanTray.Checked = true;
            this.checkBoxKeluarkanTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeluarkanTray.Location = new System.Drawing.Point(353, 74);
            this.checkBoxKeluarkanTray.Name = "checkBoxKeluarkanTray";
            this.checkBoxKeluarkanTray.Size = new System.Drawing.Size(270, 23);
            this.checkBoxKeluarkanTray.TabIndex = 0;
            this.checkBoxKeluarkanTray.Text = "Keluarkan tray jika proses telah selesai";
            this.checkBoxKeluarkanTray.UseVisualStyleBackColor = true;
            // 
            // comboBoxDrive
            // 
            this.comboBoxDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrive.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDrive.FormattingEnabled = true;
            this.comboBoxDrive.Location = new System.Drawing.Point(63, 28);
            this.comboBoxDrive.Name = "comboBoxDrive";
            this.comboBoxDrive.Size = new System.Drawing.Size(214, 25);
            this.comboBoxDrive.TabIndex = 0;
            this.comboBoxDrive.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrive_SelectedIndexChanged);
            this.comboBoxDrive.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBoxDrive_Format);
            // 
            // labelDrive
            // 
            this.labelDrive.AutoSize = true;
            this.labelDrive.Location = new System.Drawing.Point(9, 31);
            this.labelDrive.Name = "labelDrive";
            this.labelDrive.Size = new System.Drawing.Size(42, 19);
            this.labelDrive.TabIndex = 0;
            this.labelDrive.Text = "Drive";
            // 
            // groupBoxUkuranData
            // 
            this.groupBoxUkuranData.Controls.Add(this.labelUkuranTotal);
            this.groupBoxUkuranData.Controls.Add(this.labelNol);
            this.groupBoxUkuranData.Controls.Add(this.progressBarKapasitas);
            this.groupBoxUkuranData.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxUkuranData.Location = new System.Drawing.Point(12, 376);
            this.groupBoxUkuranData.Name = "groupBoxUkuranData";
            this.groupBoxUkuranData.Size = new System.Drawing.Size(701, 80);
            this.groupBoxUkuranData.TabIndex = 0;
            this.groupBoxUkuranData.TabStop = false;
            this.groupBoxUkuranData.Text = "Ukuran data";
            // 
            // labelUkuranTotal
            // 
            this.labelUkuranTotal.AutoSize = true;
            this.labelUkuranTotal.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUkuranTotal.Location = new System.Drawing.Point(629, 23);
            this.labelUkuranTotal.Name = "labelUkuranTotal";
            this.labelUkuranTotal.Size = new System.Drawing.Size(67, 19);
            this.labelUkuranTotal.TabIndex = 0;
            this.labelUkuranTotal.Text = "????? MB";
            this.labelUkuranTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNol
            // 
            this.labelNol.AutoSize = true;
            this.labelNol.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNol.Location = new System.Drawing.Point(1, 23);
            this.labelNol.Name = "labelNol";
            this.labelNol.Size = new System.Drawing.Size(48, 19);
            this.labelNol.TabIndex = 0;
            this.labelNol.Text = "0 MB";
            // 
            // progressBarKapasitas
            // 
            this.progressBarKapasitas.Location = new System.Drawing.Point(6, 43);
            this.progressBarKapasitas.MarqueeAnimationSpeed = 10;
            this.progressBarKapasitas.Name = "progressBarKapasitas";
            this.progressBarKapasitas.Size = new System.Drawing.Size(689, 23);
            this.progressBarKapasitas.TabIndex = 0;
            // 
            // groupBoxProses
            // 
            this.groupBoxProses.Controls.Add(this.buttonBurn);
            this.groupBoxProses.Controls.Add(this.labelStatus);
            this.groupBoxProses.Controls.Add(this.progressBarStatus);
            this.groupBoxProses.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProses.Location = new System.Drawing.Point(12, 457);
            this.groupBoxProses.Name = "groupBoxProses";
            this.groupBoxProses.Size = new System.Drawing.Size(701, 160);
            this.groupBoxProses.TabIndex = 0;
            this.groupBoxProses.TabStop = false;
            this.groupBoxProses.Text = "Proses berjalan";
            // 
            // buttonBurn
            // 
            this.buttonBurn.Enabled = false;
            this.buttonBurn.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBurn.Image = global::BurnFormat.Properties.Resources.BURN;
            this.buttonBurn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBurn.Location = new System.Drawing.Point(248, 100);
            this.buttonBurn.Name = "buttonBurn";
            this.buttonBurn.Size = new System.Drawing.Size(219, 49);
            this.buttonBurn.TabIndex = 0;
            this.buttonBurn.Text = "BAKAR";
            this.buttonBurn.UseVisualStyleBackColor = true;
            this.buttonBurn.Click += new System.EventHandler(this.buttonBurn_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(6, 16);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(689, 28);
            this.labelStatus.TabIndex = 0;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(6, 47);
            this.progressBarStatus.MarqueeAnimationSpeed = 10;
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(689, 47);
            this.progressBarStatus.TabIndex = 1;
            // 
            // openFileData
            // 
            this.openFileData.Filter = "Semua jenis file (*.*)|*.*";
            this.openFileData.InitialDirectory = "C:\\";
            this.openFileData.RestoreDirectory = true;
            this.openFileData.ShowReadOnly = true;
            this.openFileData.Title = "Tambahkan file...";
            // 
            // openFileImage
            // 
            this.openFileImage.Filter = "Berkas ISO (*.iso)|*.iso";
            this.openFileImage.InitialDirectory = "C:\\";
            this.openFileImage.ReadOnlyChecked = true;
            this.openFileImage.RestoreDirectory = true;
            this.openFileImage.ShowReadOnly = true;
            this.openFileImage.Title = "Pilih file image disc....";
            // 
            // folderBrowser
            // 
            this.folderBrowser.Description = "Tambahkan folder...";
            this.folderBrowser.ShowNewFolderButton = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // buttonSelanjutnya
            // 
            this.buttonSelanjutnya.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelanjutnya.Image = global::BurnFormat.Properties.Resources.NEXT;
            this.buttonSelanjutnya.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSelanjutnya.Location = new System.Drawing.Point(553, 624);
            this.buttonSelanjutnya.Name = "buttonSelanjutnya";
            this.buttonSelanjutnya.Size = new System.Drawing.Size(160, 24);
            this.buttonSelanjutnya.TabIndex = 0;
            this.buttonSelanjutnya.Text = "Selanjutnya";
            this.buttonSelanjutnya.UseVisualStyleBackColor = true;
            this.buttonSelanjutnya.Click += new System.EventHandler(this.buttonSelanjutnya_Click);
            // 
            // Burner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 656);
            this.Controls.Add(this.buttonSelanjutnya);
            this.Controls.Add(this.groupBoxProses);
            this.Controls.Add(this.groupBoxUkuranData);
            this.Controls.Add(this.groupBoxDrive);
            this.Controls.Add(this.groupBoxSumberData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Burner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[AGNI] Burning Media";
            this.Load += new System.EventHandler(this.Burner_Load);
            this.groupBoxSumberData.ResumeLayout(false);
            this.groupBoxSumberData.PerformLayout();
            this.groupBoxPilihanSumber.ResumeLayout(false);
            this.groupBoxPilihanSumber.PerformLayout();
            this.groupBoxDrive.ResumeLayout(false);
            this.groupBoxDrive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisc)).EndInit();
            this.groupBoxUkuranData.ResumeLayout(false);
            this.groupBoxUkuranData.PerformLayout();
            this.groupBoxProses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonImage;
        private System.Windows.Forms.GroupBox groupBoxSumberData;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonImage;
        private System.Windows.Forms.TextBox textBoxImage;
        private System.Windows.Forms.RadioButton radioButtonData;
        private System.Windows.Forms.Button buttonFolder;
        private System.Windows.Forms.Button buttonHapus;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.GroupBox groupBoxDrive;
        private System.Windows.Forms.CheckBox checkBoxMainkanSuara;
        private System.Windows.Forms.CheckBox checkBoxSekaliPakai;
        private System.Windows.Forms.CheckBox checkBoxKeluarkanTray;
        private System.Windows.Forms.ComboBox comboBoxDrive;
        private System.Windows.Forms.Label labelDrive;
        private System.Windows.Forms.GroupBox groupBoxUkuranData;
        private System.Windows.Forms.Label labelUkuranTotal;
        private System.Windows.Forms.Label labelNol;
        private System.Windows.Forms.ProgressBar progressBarKapasitas;
        private System.Windows.Forms.GroupBox groupBoxProses;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Button buttonBurn;
        private System.Windows.Forms.Button buttonSelanjutnya;
        private System.Windows.Forms.TextBox textBoxNamaDisc;
        private System.Windows.Forms.Label labelNamaDisc;
        private System.Windows.Forms.ComboBox comboBoxVerifikasi;
        private System.Windows.Forms.Label labelVerifikasi;
        private System.Windows.Forms.GroupBox groupBoxPilihanSumber;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.PictureBox pictureBoxDisc;
        private System.Windows.Forms.Label labelPemberitahuan;
        private System.Windows.Forms.OpenFileDialog openFileData;
        private System.Windows.Forms.OpenFileDialog openFileImage;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button buttonHapusImage;
    }
}

