namespace BurnFormat
{
    partial class Tentang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tentang));
            this.linkLabelFacebook = new System.Windows.Forms.LinkLabel();
            this.labelTentang = new System.Windows.Forms.Label();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.labelHakCipta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabelFacebook
            // 
            this.linkLabelFacebook.AutoSize = true;
            this.linkLabelFacebook.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelFacebook.Location = new System.Drawing.Point(284, 152);
            this.linkLabelFacebook.Name = "linkLabelFacebook";
            this.linkLabelFacebook.Size = new System.Drawing.Size(190, 19);
            this.linkLabelFacebook.TabIndex = 4;
            this.linkLabelFacebook.TabStop = true;
            this.linkLabelFacebook.Text = "Kirim saran, bug atau ide...";
            this.linkLabelFacebook.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFacebook_LinkClicked);
            // 
            // labelTentang
            // 
            this.labelTentang.BackColor = System.Drawing.Color.White;
            this.labelTentang.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTentang.ForeColor = System.Drawing.Color.Black;
            this.labelTentang.Location = new System.Drawing.Point(252, 85);
            this.labelTentang.Name = "labelTentang";
            this.labelTentang.Size = new System.Drawing.Size(257, 61);
            this.labelTentang.TabIndex = 7;
            this.labelTentang.Text = "Terima kasih untuk semua orang yang telah berperan penting dalam pembuatan softwa" +
                "re ini.";
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.Image = global::BurnFormat.Properties.Resources.LogoSTIKOM;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(232, 223);
            this.pictureBoxAvatar.TabIndex = 0;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // labelHakCipta
            // 
            this.labelHakCipta.BackColor = System.Drawing.Color.White;
            this.labelHakCipta.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHakCipta.ForeColor = System.Drawing.Color.Black;
            this.labelHakCipta.Location = new System.Drawing.Point(12, 241);
            this.labelHakCipta.Name = "labelHakCipta";
            this.labelHakCipta.Size = new System.Drawing.Size(492, 38);
            this.labelHakCipta.TabIndex = 8;
            this.labelHakCipta.Text = "Produk ini ada sebagaimana yang pernah dipresentasikan oleh salah satu Mahasiswa " +
                "STIKOM Bali pada saat Seminar Skrispsi Tahun 2011";
            this.labelHakCipta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tentang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 285);
            this.Controls.Add(this.labelHakCipta);
            this.Controls.Add(this.labelTentang);
            this.Controls.Add(this.linkLabelFacebook);
            this.Controls.Add(this.pictureBoxAvatar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tentang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tentang";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tentang_Close);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.LinkLabel linkLabelFacebook;
        private System.Windows.Forms.Label labelTentang;
        private System.Windows.Forms.Label labelHakCipta;
    }
}