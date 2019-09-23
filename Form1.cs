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
using System.IO.Compression;

namespace BackUpSave {

    public partial class FormMain : Form {

        public FormMain() {
            InitializeComponent();
            this.btn_fileRelease.DragDrop += new DragEventHandler(this.btnFileRelease_DragDrop);
            this.btn_fileRelease.DragEnter += new DragEventHandler(this.btnFileRelease_DragEnter);    
        }//end Form init


        //Generate semi-unique key to append to file name
        public string GenerateKey() {
            return ("[" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "_" +DateTime.Now.Hour + DateTime.Now.Millisecond + "]");
        }//end GenerateKey


        //capture current users name (used to create Backup directory in appropriate place)
        static String currentUser = Environment.UserName;


        //create static variables to store paths to "Backup" directory and .txt file that stores files paths so
        //it is persistent across multiple program runs
        static string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
        static string logFilePath = Path.Combine(pathToBackups, "filesToBackup.txt");

        //messages to be displayed to user via console listbox
        //successful 
        static string msgSuccessSched = "SUCCESS: New file(s) scheduled to be backed up!";
        static string msgSuccessBackup = "SUCCESS: File(s) successfully backed up!";

        //errors
        static string msgErrorDuplicate = "ERROR: File is already scheduled to backed up!";
        static string msgErrorNoPaths = "ERROR: There are no files scheduled to be backed up";

        //information
        static string msgInfoDumpTxt = "IMPORTANT: All files scheduled to be backed up reset";


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
            btn_fileRelease.AllowDrop = true;

            //On form load, create a directory titled "Backups" in current user's home directory
            //will be ignored automatically if directory already exists
            Directory.CreateDirectory(pathToBackups);

            //if "Backups" does not exist, create it and close it
            if (!File.Exists(logFilePath)) {
                File.Create(logFilePath).Close();
                return;
            }//end if

           
           StreamReader readFilePaths = new StreamReader(logFilePath);

           string temp = "";

           while ((temp = readFilePaths.ReadLine()) != null) {
                listbox_filePaths.Items.Add(temp);
                listbox_filePaths.TopIndex = listbox_filePaths.Items.Count - 1;
            }//end while

            readFilePaths.Close();
           

        }//end Form1_Load


        //dragdrop event to handle released files and directories
        private void btnFileRelease_DragDrop(object sender, DragEventArgs e) {

            //handle drag drop to string array
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //turn stringarray value to string
            string sourceFile = ConvertStringArray(s);

           
            //if file already exists in log file, display duplicate error and exit
            if (File.ReadAllText(logFilePath).Contains(sourceFile)) {
                listBox_console.Items.Add(msgErrorDuplicate);
                listBox_console.TopIndex = listBox_console.Items.Count - 1;
            }
            //if not, add dropped file to logfile 
            else {

                File.AppendAllText(logFilePath, sourceFile + Environment.NewLine);
                listbox_filePaths.Items.Add(sourceFile);
                listbox_filePaths.TopIndex = listbox_filePaths.Items.Count - 1;

                listBox_console.Items.Add(msgSuccessSched);
                listBox_console.TopIndex = listBox_console.Items.Count - 1;

            }

        }//end textBoxFile_DragDrop handler


        //button to initiate backup to directory created inside "Backups" directory in user's specified drive
        private void BtnBackup_Click(object sender, EventArgs e) {

            string backupDirName = "Backup" + GenerateKey();
            string pathToNewBackupDir = Path.Combine(pathToBackups, backupDirName);
                    
            
            

            StreamReader readFilePaths = new StreamReader(logFilePath);
            string line = "";


         
            //if there are no files in filesToBackup.txt: break out of method and inform user
            if (new FileInfo(logFilePath).Length == 0) {
                listBox_console.Items.Add(msgErrorNoPaths);
                listBox_console.TopIndex = listBox_console.Items.Count - 1;
            }//end if

            //else open logfile and loop through each line until end of file is reachedc
            else {

                //while filesToBackup.txt has another line, continue looping
                while ((line = readFilePaths.ReadLine()) != null) {

                    //create directory for backups to be stored
                    Directory.CreateDirectory(pathToNewBackupDir);

                    string sourceFile = line;

                    FileAttributes dirCheck = File.GetAttributes(sourceFile);

                    //test if current path is a directory
                    //if so, handle it differently
                    if ((dirCheck & FileAttributes.Directory) == FileAttributes.Directory) {
                        listBox_console.Items.Add("TEMP FATAL ERROR: CANNOT PROCESS DIRECTORIES YET");
                        readFilePaths.Close();
                        return;
                    }

                    //Build file name of newly created file by extracting info from source file
                    string copyFileName = Path.GetFileName(sourceFile);

                    //combine path to backups directory with semi-unique file name
                    string completeFileName = Path.Combine(pathToNewBackupDir, copyFileName);

                    //copy file over inside of keyed backup directory  
                    File.Copy(sourceFile, completeFileName);

                }//end while

                //close .txt file storing file paths
                readFilePaths.Close();

            }

            //inform user everything was sucessful
            listBox_console.Items.Add(msgSuccessBackup);
            listBox_console.TopIndex = listBox_console.Items.Count - 1;       

            

        }//end Backup Button Click


        private void btnFileRelease_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }//end textBoxFile_DragEnter


        //button to erase .txt file storing file paths for all source files
        private void BtnEraseFilePaths_Click(object sender, EventArgs e) {

            File.Create(logFilePath).Close();
            listbox_filePaths.Items.Clear();

            listBox_console.Items.Add(msgInfoDumpTxt);
            listBox_console.TopIndex = listBox_console.Items.Count - 1;
        }//end Erase Paths button click


        //button to clear console listbox
        private void Btn_clearConsole_Click(object sender, EventArgs e) {
            listBox_console.Items.Clear();
        }//end clear console button click


    }//end FormBackup
}//end namespace BackUpSave
