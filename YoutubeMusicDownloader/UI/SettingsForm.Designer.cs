namespace UI
{
    partial class SettingsForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileOutputPath = new System.Windows.Forms.TextBox();
            this.chkDeleteMp4FilesAfterConversion = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 68);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "File output path";
            // 
            // txtFileOutputPath
            // 
            this.txtFileOutputPath.Location = new System.Drawing.Point(109, 9);
            this.txtFileOutputPath.Name = "txtFileOutputPath";
            this.txtFileOutputPath.Size = new System.Drawing.Size(406, 23);
            this.txtFileOutputPath.TabIndex = 2;
            // 
            // chkDeleteMp4FilesAfterConversion
            // 
            this.chkDeleteMp4FilesAfterConversion.AutoSize = true;
            this.chkDeleteMp4FilesAfterConversion.Location = new System.Drawing.Point(12, 39);
            this.chkDeleteMp4FilesAfterConversion.Name = "chkDeleteMp4FilesAfterConversion";
            this.chkDeleteMp4FilesAfterConversion.Size = new System.Drawing.Size(198, 19);
            this.chkDeleteMp4FilesAfterConversion.TabIndex = 3;
            this.chkDeleteMp4FilesAfterConversion.Text = "Delete mp4 files after conversion";
            this.chkDeleteMp4FilesAfterConversion.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 103);
            this.Controls.Add(this.chkDeleteMp4FilesAfterConversion);
            this.Controls.Add(this.txtFileOutputPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileOutputPath;
        private System.Windows.Forms.CheckBox chkDeleteMp4FilesAfterConversion;
    }
}