namespace BackUpSave {
    partial class FormMain {
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
            this.listbox_filePaths = new System.Windows.Forms.ListBox();
            this.btn_fileRelease = new System.Windows.Forms.Button();
            this.listBox_console = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_backup = new System.Windows.Forms.Button();
            this.btn_eraseFilePaths = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_clearConsole = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listbox_filePaths
            // 
            this.listbox_filePaths.FormattingEnabled = true;
            this.listbox_filePaths.Location = new System.Drawing.Point(12, 185);
            this.listbox_filePaths.Name = "listbox_filePaths";
            this.listbox_filePaths.Size = new System.Drawing.Size(606, 303);
            this.listbox_filePaths.TabIndex = 1;
            // 
            // btn_fileRelease
            // 
            this.btn_fileRelease.AllowDrop = true;
            this.btn_fileRelease.Location = new System.Drawing.Point(110, 34);
            this.btn_fileRelease.Name = "btn_fileRelease";
            this.btn_fileRelease.Size = new System.Drawing.Size(310, 101);
            this.btn_fileRelease.TabIndex = 2;
            this.btn_fileRelease.Text = "Drag New Files Here";
            this.btn_fileRelease.UseVisualStyleBackColor = true;
            // 
            // listBox_console
            // 
            this.listBox_console.FormattingEnabled = true;
            this.listBox_console.Location = new System.Drawing.Point(624, 185);
            this.listBox_console.Name = "listBox_console";
            this.listBox_console.Size = new System.Drawing.Size(395, 303);
            this.listBox_console.TabIndex = 3;
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
            // btn_backup
            // 
            this.btn_backup.AllowDrop = true;
            this.btn_backup.Location = new System.Drawing.Point(610, 34);
            this.btn_backup.Name = "btn_backup";
            this.btn_backup.Size = new System.Drawing.Size(310, 101);
            this.btn_backup.TabIndex = 6;
            this.btn_backup.Text = "Back Up Files";
            this.btn_backup.UseVisualStyleBackColor = true;
            this.btn_backup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // btn_eraseFilePaths
            // 
            this.btn_eraseFilePaths.Location = new System.Drawing.Point(998, 496);
            this.btn_eraseFilePaths.Name = "btn_eraseFilePaths";
            this.btn_eraseFilePaths.Size = new System.Drawing.Size(21, 23);
            this.btn_eraseFilePaths.TabIndex = 7;
            this.btn_eraseFilePaths.UseVisualStyleBackColor = true;
            this.btn_eraseFilePaths.Click += new System.EventHandler(this.BtnEraseFilePaths_Click);
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
            // btn_clearConsole
            // 
            this.btn_clearConsole.Location = new System.Drawing.Point(657, 499);
            this.btn_clearConsole.Name = "btn_clearConsole";
            this.btn_clearConsole.Size = new System.Drawing.Size(10, 10);
            this.btn_clearConsole.TabIndex = 9;
            this.btn_clearConsole.Text = "button1";
            this.btn_clearConsole.UseVisualStyleBackColor = true;
            this.btn_clearConsole.Click += new System.EventHandler(this.Btn_clearConsole_Click);
            // 
            // clear
            // 
            this.clear.AutoSize = true;
            this.clear.Location = new System.Drawing.Point(621, 496);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(30, 13);
            this.clear.TabIndex = 10;
            this.clear.Text = "clear";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 531);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.btn_clearConsole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_eraseFilePaths);
            this.Controls.Add(this.btn_backup);
            this.Controls.Add(this.btn_fileRelease);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_console);
            this.Controls.Add(this.listbox_filePaths);
            this.Name = "FormMain";
            this.Text = "Back Up Your Files!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listbox_filePaths;
        private System.Windows.Forms.Button btn_fileRelease;
        private System.Windows.Forms.ListBox listBox_console;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_backup;
        private System.Windows.Forms.Button btn_eraseFilePaths;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_clearConsole;
        private System.Windows.Forms.Label clear;
    }
}

