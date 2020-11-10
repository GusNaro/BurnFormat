namespace BurnFormat
{
    partial class Format
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Format));
            this.groupBoxDrive = new System.Windows.Forms.GroupBox();
            this.checkBoxFormatCepat = new System.Windows.Forms.CheckBox();
            this.labelPenjelasan = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.pictureBoxDisc = new System.Windows.Forms.PictureBox();
            this.labelPemberitahuan = new System.Windows.Forms.Label();
            this.labelMethod = new System.Windows.Forms.Label();
            this.checkBoxMainkanSuara = new System.Windows.Forms.CheckBox();
            this.checkBoxKeluarkanTray = new System.Windows.Forms.CheckBox();
            this.comboBoxDrive = new System.Windows.Forms.ComboBox();
            this.labelDrive = new System.Windows.Forms.Label();
            this.groupBoxProses = new System.Windows.Forms.GroupBox();
            this.buttonFormat = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.buttonSelanjutnya = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBoxDrive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisc)).BeginInit();
            this.groupBoxProses.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDrive
            // 
            this.groupBoxDrive.Controls.Add(this.checkBoxFormatCepat);
            this.groupBoxDrive.Controls.Add(this.labelPenjelasan);
            this.groupBoxDrive.Controls.Add(this.buttonRefresh);
            this.groupBoxDrive.Controls.Add(this.pictureBoxDisc);
            this.groupBoxDrive.Controls.Add(this.labelPemberitahuan);
            this.groupBoxDrive.Controls.Add(this.labelMethod);
            this.groupBoxDrive.Controls.Add(this.checkBoxMainkanSuara);
            this.groupBoxDrive.Controls.Add(this.checkBoxKeluarkanTray);
            this.groupBoxDrive.Controls.Add(this.comboBoxDrive);
            this.groupBoxDrive.Controls.Add(this.labelDrive);
            this.groupBoxDrive.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDrive.Location = new System.Drawing.Point(12, 2);
            this.groupBoxDrive.Name = "groupBoxDrive";
            this.groupBoxDrive.Size = new System.Drawing.Size(701, 192);
            this.groupBoxDrive.TabIndex = 11;
            this.groupBoxDrive.TabStop = false;
            this.groupBoxDrive.Text = "Drive dan parameter";
            // 
            // checkBoxFormatCepat
            // 
            this.checkBoxFormatCepat.AutoSize = true;
            this.checkBoxFormatCepat.Checked = true;
            this.checkBoxFormatCepat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFormatCepat.Location = new System.Drawing.Point(175, 65);
            this.checkBoxFormatCepat.Name = "checkBoxFormatCepat";
            this.checkBoxFormatCepat.Size = new System.Drawing.Size(112, 23);
            this.checkBoxFormatCepat.TabIndex = 23;
            this.checkBoxFormatCepat.Text = "Format cepat";
            this.checkBoxFormatCepat.UseVisualStyleBackColor = true;
            // 
            // labelPenjelasan
            // 
            this.labelPenjelasan.Font = new System.Drawing.Font("Tempus Sans ITC", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPenjelasan.Location = new System.Drawing.Point(91, 92);
            this.labelPenjelasan.Name = "labelPenjelasan";
            this.labelPenjelasan.Size = new System.Drawing.Size(204, 87);
            this.labelPenjelasan.TabIndex = 20;
            this.labelPenjelasan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Image = global::BurnFormat.Properties.Resources.REFRESH;
            this.buttonRefresh.Location = new System.Drawing.Point(328, 25);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(32, 33);
            this.buttonRefresh.TabIndex = 19;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // pictureBoxDisc
            // 
            this.pictureBoxDisc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxDisc.Location = new System.Drawing.Point(460, 20);
            this.pictureBoxDisc.Name = "pictureBoxDisc";
            this.pictureBoxDisc.Size = new System.Drawing.Size(47, 45);
            this.pictureBoxDisc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxDisc.TabIndex = 18;
            this.pictureBoxDisc.TabStop = false;
            // 
            // labelPemberitahuan
            // 
            this.labelPemberitahuan.AutoSize = true;
            this.labelPemberitahuan.Location = new System.Drawing.Point(359, 33);
            this.labelPemberitahuan.Name = "labelPemberitahuan";
            this.labelPemberitahuan.Size = new System.Drawing.Size(109, 19);
            this.labelPemberitahuan.TabIndex = 17;
            this.labelPemberitahuan.Text = "Dalam tray ada ";
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(9, 66);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(59, 19);
            this.labelMethod.TabIndex = 15;
            this.labelMethod.Text = "Method";
            // 
            // checkBoxMainkanSuara
            // 
            this.checkBoxMainkanSuara.AutoSize = true;
            this.checkBoxMainkanSuara.Checked = true;
            this.checkBoxMainkanSuara.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMainkanSuara.Location = new System.Drawing.Point(353, 133);
            this.checkBoxMainkanSuara.Name = "checkBoxMainkanSuara";
            this.checkBoxMainkanSuara.Size = new System.Drawing.Size(152, 23);
            this.checkBoxMainkanSuara.TabIndex = 6;
            this.checkBoxMainkanSuara.Text = "Mainkan efek suara";
            this.checkBoxMainkanSuara.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeluarkanTray
            // 
            this.checkBoxKeluarkanTray.AutoSize = true;
            this.checkBoxKeluarkanTray.Checked = true;
            this.checkBoxKeluarkanTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeluarkanTray.Location = new System.Drawing.Point(353, 104);
            this.checkBoxKeluarkanTray.Name = "checkBoxKeluarkanTray";
            this.checkBoxKeluarkanTray.Size = new System.Drawing.Size(270, 23);
            this.checkBoxKeluarkanTray.TabIndex = 4;
            this.checkBoxKeluarkanTray.Text = "Keluarkan tray jika proses telah selesai";
            this.checkBoxKeluarkanTray.UseVisualStyleBackColor = true;
            // 
            // comboBoxDrive
            // 
            this.comboBoxDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrive.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDrive.FormattingEnabled = true;
            this.comboBoxDrive.Location = new System.Drawing.Point(81, 30);
            this.comboBoxDrive.Name = "comboBoxDrive";
            this.comboBoxDrive.Size = new System.Drawing.Size(214, 25);
            this.comboBoxDrive.TabIndex = 1;
            this.comboBoxDrive.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrive_SelectedIndexChanged);
            this.comboBoxDrive.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBoxDrive_Format);
            // 
            // labelDrive
            // 
            this.labelDrive.AutoSize = true;
            this.labelDrive.Location = new System.Drawing.Point(9, 33);
            this.labelDrive.Name = "labelDrive";
            this.labelDrive.Size = new System.Drawing.Size(42, 19);
            this.labelDrive.TabIndex = 0;
            this.labelDrive.Text = "Drive";
            // 
            // groupBoxProses
            // 
            this.groupBoxProses.Controls.Add(this.buttonFormat);
            this.groupBoxProses.Controls.Add(this.labelStatus);
            this.groupBoxProses.Controls.Add(this.progressBarStatus);
            this.groupBoxProses.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxProses.Location = new System.Drawing.Point(12, 195);
            this.groupBoxProses.Name = "groupBoxProses";
            this.groupBoxProses.Size = new System.Drawing.Size(701, 160);
            this.groupBoxProses.TabIndex = 13;
            this.groupBoxProses.TabStop = false;
            this.groupBoxProses.Text = "Proses berjalan";
            // 
            // buttonFormat
            // 
            this.buttonFormat.Enabled = false;
            this.buttonFormat.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormat.Image = global::BurnFormat.Properties.Resources.FORMAT;
            this.buttonFormat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFormat.Location = new System.Drawing.Point(248, 100);
            this.buttonFormat.Name = "buttonFormat";
            this.buttonFormat.Size = new System.Drawing.Size(219, 49);
            this.buttonFormat.TabIndex = 5;
            this.buttonFormat.Text = "FORMAT";
            this.buttonFormat.UseVisualStyleBackColor = true;
            this.buttonFormat.Click += new System.EventHandler(this.buttonFormat_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Font = new System.Drawing.Font("Tempus Sans ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(6, 16);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(689, 28);
            this.labelStatus.TabIndex = 2;
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
            // buttonSelanjutnya
            // 
            this.buttonSelanjutnya.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelanjutnya.Image = global::BurnFormat.Properties.Resources.NEXT;
            this.buttonSelanjutnya.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSelanjutnya.Location = new System.Drawing.Point(553, 361);
            this.buttonSelanjutnya.Name = "buttonSelanjutnya";
            this.buttonSelanjutnya.Size = new System.Drawing.Size(160, 24);
            this.buttonSelanjutnya.TabIndex = 14;
            this.buttonSelanjutnya.Text = "Selanjutnya";
            this.buttonSelanjutnya.UseVisualStyleBackColor = true;
            this.buttonSelanjutnya.Click += new System.EventHandler(this.buttonSelanjutnya_Click);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // Format
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 394);
            this.Controls.Add(this.buttonSelanjutnya);
            this.Controls.Add(this.groupBoxProses);
            this.Controls.Add(this.groupBoxDrive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Format";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[AGNI] Format Media";
            this.Load += new System.EventHandler(this.Format_Load);
            this.groupBoxDrive.ResumeLayout(false);
            this.groupBoxDrive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDisc)).EndInit();
            this.groupBoxProses.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDrive;
        private System.Windows.Forms.CheckBox checkBoxMainkanSuara;
        private System.Windows.Forms.CheckBox checkBoxKeluarkanTray;
        private System.Windows.Forms.ComboBox comboBoxDrive;
        private System.Windows.Forms.Label labelDrive;
        private System.Windows.Forms.GroupBox groupBoxProses;
        private System.Windows.Forms.Button buttonFormat;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Button buttonSelanjutnya;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.PictureBox pictureBoxDisc;
        private System.Windows.Forms.Label labelPemberitahuan;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelPenjelasan;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox checkBoxFormatCepat;
    }
}