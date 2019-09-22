//Started 9/15/2019 by Landon Hise
//Use: To back up files utilizing a GUI and persistently store location of previously backed up files
//GUI displays to user the source files for backup, and any error messages

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BackUpSave {

    public partial class Form1 : Form {



        public Form1() {
            InitializeComponent();
            this.btnFileRelease.DragDrop += new DragEventHandler(this.btnFileRelease_DragDrop);
            this.btnFileRelease.DragEnter += new DragEventHandler(this.btnFileRelease_DragEnter);
        }




        //Generate file name with semi-unique key

        public string GenerateKey() {
            return ("[" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "_" +DateTime.Now.Hour + DateTime.Now.Millisecond + "]");
        }
        //capture current users name (used to create Backup directory in appropriate place)
        static String currentUser = Environment.UserName;





        //method that convers a string array to a normal string via StringBuilder
        static string ConvertStringArray(string[] array) {

            StringBuilder storage = new StringBuilder();

            foreach (string value in array) {
                storage.Append(value);
            }//end foreach

            return (storage.ToString());
        }//end convert method



        //On Form Load
        private void Form1_Load(object sender, EventArgs e) {
            btnFileRelease.AllowDrop = true;

            string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
            string logFilePath = Path.Combine(pathToBackups, "filesToBackup.txt");


            //On form load, create a directory titled "Backups" in current user's home directory
            //will be ignored automatically if directory already exists
            Directory.CreateDirectory(pathToBackups);


            if (!File.Exists(logFilePath)) {
                File.Create(logFilePath).Close();
            }//end if



            long logFileLength = new FileInfo(logFilePath).Length;

            if (logFileLength == 0) {
                //do nothing 
            }//end if
            else {
                StreamReader readFilePaths = new StreamReader(logFilePath);

                string temp = "";

                while ((temp = readFilePaths.ReadLine()) != null) {
                    listBox1.Items.Add(temp);
                }//end while

                readFilePaths.Close();
            }//end else


        }//end Form1_Load



        private void btnFileRelease_DragDrop(object sender, DragEventArgs e) {

            string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
            string logFilePath = Path.Combine(pathToBackups, "filesToBackup.txt");

            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string sourceFile = ConvertStringArray(s);



            string successfulSchedMsg = "New file scheduled to be backed up!";
            string duplicateMsg = "ERROR: File is already scheduled to backed up!";

            if (File.ReadAllText(logFilePath).Contains(sourceFile)) {
                listBox2.Items.Add(duplicateMsg);
            }
            else {

                File.AppendAllText(logFilePath, sourceFile + Environment.NewLine);
                listBox1.Items.Add(sourceFile);
                listBox2.Items.Add(successfulSchedMsg);

            }

        }//end textBoxFile_DragDrop handler



        private void BtnBackup_Click(object sender, EventArgs e) {

            string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
            string logFilePath = Path.Combine(pathToBackups, "filesToBackup.txt");

            string backupDirName = "Backup" + GenerateKey();
            string pathToNewBackupDir = Path.Combine(pathToBackups, backupDirName);
            

            string successfulCopyMsg = "Files successfully backed up!";
            string emptyPathsMsg = "ERROR: There are no files scheduled to be backed up";
            string line = "";
            

            StreamReader readFilePaths = new StreamReader(logFilePath);

            //if there are no files in filesToBackup.txt: break out of method and inform user
            if ((line = readFilePaths.ReadLine()) == null) {
                listBox2.Items.Add(emptyPathsMsg);
            }//end if

            //else: create directory and prepare files to populate it
            else {

                //while filesToBackup.txt has another line, continue looping
                while (line != null) {

                    Directory.CreateDirectory(pathToNewBackupDir);

                    string sourceFile = line;

                    FileAttributes dirCheck = File.GetAttributes(sourceFile);

                    if ((dirCheck & FileAttributes.Directory) == FileAttributes.Directory) {
                        listBox2.Items.Add("FATAL ERROR: CANNOT PROCESS DIRECTORIES YET");
                        return;
                    }
                 

                    //Build file name of newly created file by extracting info from source file
                    string copyFileName = Path.GetFileName(sourceFile);

                  


                    //combine path to backups directory with semi-unique file name
                    string completeFileName = Path.Combine(pathToNewBackupDir, copyFileName);


                    File.Copy(sourceFile, completeFileName);


                }//end while

                listBox2.Items.Add(successfulCopyMsg);

                
            }//end else

            readFilePaths.Close();

        }//end Backup Button Click


        private void btnFileRelease_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }//end textBoxFile_DragEnter

        private void BtnEraseFilePaths_Click(object sender, EventArgs e) {
            string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
            string logFilePath = Path.Combine(pathToBackups, "filesToBackup.txt");
            string dumpFilePathsMsg = "IMPORTANT: Files to be backed up has been dumped";

            File.Create(logFilePath).Close();
            listBox1.Items.Clear();
            listBox2.Items.Add(dumpFilePathsMsg);

        }//end Erase Paths button click
    }
}

