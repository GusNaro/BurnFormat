namespace BurnFormat
{
    partial class Informasi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Informasi));
            this.groupBoxDrive = new System.Windows.Forms.GroupBox();
            this.comboBoxDrive = new System.Windows.Forms.ComboBox();
            this.labelDrive = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBoxDrive.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDrive
            // 
            this.groupBoxDrive.Controls.Add(this.comboBoxDrive);
            this.groupBoxDrive.Controls.Add(this.labelDrive);
            this.groupBoxDrive.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDrive.Location = new System.Drawing.Point(12, 2);
            this.groupBoxDrive.Name = "groupBoxDrive";
            this.groupBoxDrive.Size = new System.Drawing.Size(550, 100);
            this.groupBoxDrive.TabIndex = 0;
            this.groupBoxDrive.TabStop = false;
            this.groupBoxDrive.Text = "Drive";
            // 
            // comboBoxDrive
            // 
            this.comboBoxDrive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDrive.Font = new System.Drawing.Font("Tempus Sans ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDrive.FormattingEnabled = true;
            this.comboBoxDrive.Location = new System.Drawing.Point(202, 40);
            this.comboBoxDrive.Name = "comboBoxDrive";
            this.comboBoxDrive.Size = new System.Drawing.Size(214, 25);
            this.comboBoxDrive.TabIndex = 3;
            this.comboBoxDrive.SelectedIndexChanged += new System.EventHandler(this.comboBoxDrive_SelectedIndexChanged);
            this.comboBoxDrive.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.comboBoxDrive_Format);
            // 
            // labelDrive
            // 
            this.labelDrive.AutoSize = true;
            this.labelDrive.Location = new System.Drawing.Point(130, 43);
            this.labelDrive.Name = "labelDrive";
            this.labelDrive.Size = new System.Drawing.Size(42, 19);
            this.labelDrive.TabIndex = 2;
            this.labelDrive.Text = "Drive";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 216);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kemampuan yang didukung";
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Tempus Sans ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(19, 28);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(510, 173);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // Informasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 330);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxDrive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Informasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[AGNI] Sistem Informasi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Informasi_Close);
            this.Load += new System.EventHandler(this.Informasi_Load);
            this.groupBoxDrive.ResumeLayout(false);
            this.groupBoxDrive.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxDrive;
        private System.Windows.Forms.ComboBox comboBoxDrive;
        private System.Windows.Forms.Label labelDrive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}