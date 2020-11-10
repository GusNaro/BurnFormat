namespace BurnFormat
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelPertanyaan = new System.Windows.Forms.Label();
            this.linkLabelDownload = new System.Windows.Forms.LinkLabel();
            this.linkLabelSistemInformasi = new System.Windows.Forms.LinkLabel();
            this.buttonTentang = new System.Windows.Forms.Button();
            this.buttonKeluar = new System.Windows.Forms.Button();
            this.buttonFormatter = new System.Windows.Forms.Button();
            this.buttonBurner = new System.Windows.Forms.Button();
            this.labelBuildNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPertanyaan
            // 
            this.labelPertanyaan.AutoSize = true;
            this.labelPertanyaan.Font = new System.Drawing.Font("Tempus Sans ITC", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPertanyaan.Location = new System.Drawing.Point(24, 14);
            this.labelPertanyaan.Name = "labelPertanyaan";
            this.labelPertanyaan.Size = new System.Drawing.Size(310, 27);
            this.labelPertanyaan.TabIndex = 9;
            this.labelPertanyaan.Text = "Apa yang akan anda lakukan ??";
            // 
            // linkLabelDownload
            // 
            this.linkLabelDownload.AutoSize = true;
            this.linkLabelDownload.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDownload.Location = new System.Drawing.Point(4, 154);
            this.linkLabelDownload.Name = "linkLabelDownload";
            this.linkLabelDownload.Size = new System.Drawing.Size(119, 19);
            this.linkLabelDownload.TabIndex = 10;
            this.linkLabelDownload.TabStop = true;
            this.linkLabelDownload.Text = "Download IMAPI";
            this.linkLabelDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDownload_LinkClicked);
            // 
            // linkLabelSistemInformasi
            // 
            this.linkLabelSistemInformasi.AutoSize = true;
            this.linkLabelSistemInformasi.Location = new System.Drawing.Point(481, -1);
            this.linkLabelSistemInformasi.Name = "linkLabelSistemInformasi";
            this.linkLabelSistemInformasi.Size = new System.Drawing.Size(85, 15);
            this.linkLabelSistemInformasi.TabIndex = 11;
            this.linkLabelSistemInformasi.TabStop = true;
            this.linkLabelSistemInformasi.Text = "Sistem informasi";
            this.linkLabelSistemInformasi.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSistemInformasi_LinkClicked);
            // 
            // buttonTentang
            // 
            this.buttonTentang.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTentang.Image = global::BurnFormat.Properties.Resources.TANYA;
            this.buttonTentang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTentang.Location = new System.Drawing.Point(478, 137);
            this.buttonTentang.Name = "buttonTentang";
            this.buttonTentang.Size = new System.Drawing.Size(88, 41);
            this.buttonTentang.TabIndex = 8;
            this.buttonTentang.Text = "Tentang";
            this.buttonTentang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTentang.UseVisualStyleBackColor = true;
            this.buttonTentang.Click += new System.EventHandler(this.buttonTentang_Click);
            // 
            // buttonKeluar
            // 
            this.buttonKeluar.Font = new System.Drawing.Font("Tempus Sans ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKeluar.Image = global::BurnFormat.Properties.Resources.EXIT;
            this.buttonKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKeluar.Location = new System.Drawing.Point(371, 57);
            this.buttonKeluar.Name = "buttonKeluar";
            this.buttonKeluar.Size = new System.Drawing.Size(182, 70);
            this.buttonKeluar.TabIndex = 2;
            this.buttonKeluar.Text = "KELUAR";
            this.buttonKeluar.UseVisualStyleBackColor = true;
            this.buttonKeluar.Click += new System.EventHandler(this.buttonKeluar_Click);
            // 
            // buttonFormatter
            // 
            this.buttonFormatter.Font = new System.Drawing.Font("Tempus Sans ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFormatter.Image = global::BurnFormat.Properties.Resources.FORMAT;
            this.buttonFormatter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFormatter.Location = new System.Drawing.Point(204, 57);
            this.buttonFormatter.Name = "buttonFormatter";
            this.buttonFormatter.Size = new System.Drawing.Size(161, 70);
            this.buttonFormatter.TabIndex = 1;
            this.buttonFormatter.Text = "FORMAT";
            this.buttonFormatter.UseVisualStyleBackColor = true;
            this.buttonFormatter.Click += new System.EventHandler(this.buttonFormatter_Click);
            // 
            // buttonBurner
            // 
            this.buttonBurner.Font = new System.Drawing.Font("Tempus Sans ITC", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBurner.Image = global::BurnFormat.Properties.Resources.BURN;
            this.buttonBurner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBurner.Location = new System.Drawing.Point(12, 57);
            this.buttonBurner.Name = "buttonBurner";
            this.buttonBurner.Size = new System.Drawing.Size(186, 70);
            this.buttonBurner.TabIndex = 0;
            this.buttonBurner.Text = "BURN";
            this.buttonBurner.UseVisualStyleBackColor = true;
            this.buttonBurner.Click += new System.EventHandler(this.buttonBurner_Click);
            // 
            // labelBuildNumber
            // 
            this.labelBuildNumber.AutoSize = true;
            this.labelBuildNumber.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuildNumber.Location = new System.Drawing.Point(451, 14);
            this.labelBuildNumber.Name = "labelBuildNumber";
            this.labelBuildNumber.Size = new System.Drawing.Size(115, 15);
            this.labelBuildNumber.TabIndex = 12;
            this.labelBuildNumber.Text = "Versi Ciptaan 1.2.0002";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 177);
            this.ControlBox = false;
            this.Controls.Add(this.labelBuildNumber);
            this.Controls.Add(this.linkLabelSistemInformasi);
            this.Controls.Add(this.linkLabelDownload);
            this.Controls.Add(this.labelPertanyaan);
            this.Controls.Add(this.buttonTentang);
            this.Controls.Add(this.buttonKeluar);
            this.Controls.Add(this.buttonFormatter);
            this.Controls.Add(this.buttonBurner);
            this.Font = new System.Drawing.Font("Tempus Sans ITC", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[AGNI] Burn & Format Media";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBurner;
        private System.Windows.Forms.Button buttonFormatter;
        private System.Windows.Forms.Button buttonKeluar;
        private System.Windows.Forms.Button buttonTentang;
        private System.Windows.Forms.Label labelPertanyaan;
        private System.Windows.Forms.LinkLabel linkLabelDownload;
        private System.Windows.Forms.LinkLabel linkLabelSistemInformasi;
        private System.Windows.Forms.Label labelBuildNumber;
    }
}