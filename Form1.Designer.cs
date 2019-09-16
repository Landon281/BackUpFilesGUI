namespace BackUpSave {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnFileRelease = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnEraseFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 185);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(606, 303);
            this.listBox1.TabIndex = 1;
            // 
            // btnFileRelease
            // 
            this.btnFileRelease.AllowDrop = true;
            this.btnFileRelease.Location = new System.Drawing.Point(110, 34);
            this.btnFileRelease.Name = "btnFileRelease";
            this.btnFileRelease.Size = new System.Drawing.Size(310, 101);
            this.btnFileRelease.TabIndex = 2;
            this.btnFileRelease.Text = "Drag New Files Here";
            this.btnFileRelease.UseVisualStyleBackColor = true;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(624, 185);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(395, 303);
            this.listBox2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Files That Will Be Backed Up:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(797, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Console:";
            // 
            // btnBackup
            // 
            this.btnBackup.AllowDrop = true;
            this.btnBackup.Location = new System.Drawing.Point(610, 34);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(310, 101);
            this.btnBackup.TabIndex = 6;
            this.btnBackup.Text = "Back Up Files";
            this.btnBackup.UseVisualStyleBackColor = true;
            // 
            // btnEraseFile
            // 
            this.btnEraseFile.Location = new System.Drawing.Point(998, 496);
            this.btnEraseFile.Name = "btnEraseFile";
            this.btnEraseFile.Size = new System.Drawing.Size(21, 23);
            this.btnEraseFile.TabIndex = 7;
            this.btnEraseFile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(855, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Reset files to be backed up";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 531);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEraseFile);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnFileRelease);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Back Up Your Files!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnFileRelease;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnEraseFile;
        private System.Windows.Forms.Label label3;
    }
}

