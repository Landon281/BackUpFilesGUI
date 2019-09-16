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
        public string GenerateFileKey() {
            return ("_Backup[" + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Year + "-" + DateTime.Now.Hour + DateTime.Now.Millisecond + "]");
        }
        //capture current users name (used to create Backup directory in appropriate place)
        static String currentUser = Environment.UserName;
        
       

       

        //method that convers a string array to a normal string via StringBuilder
        static string ConvertStringArray(string[] array) {
       
            StringBuilder storage = new StringBuilder();

            foreach (string value in array) {
                storage.Append(value);
            }

            return (storage.ToString());
        }//end convert method



        //On Form Load
        private void Form1_Load(object sender, EventArgs e) {
            btnFileRelease.AllowDrop = true;

            string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
            string logFile = Path.Combine(pathToBackups, "filesToBackup.txt");

            //On form load, create a directory titled "Backups" in current user's home directory
            //will be ignored automatically if directory already exists
            Directory.CreateDirectory(pathToBackups);

            if (!File.Exists(logFile)) {
                File.Create(logFile).Close();
            }

            long logFileLength = new FileInfo(logFile).Length;

            if (logFileLength == 0) {
                //do nothing 
            }
            else {

                StreamReader readFilePaths = new StreamReader(logFile);
                string temp = "";

                while ((temp = readFilePaths.ReadLine()) != null) {
                    listBox1.Items.Add(temp);
                }
  
                readFilePaths.Close();
            }
            

        }//end Form1_Load



        private void btnFileRelease_DragDrop(object sender, DragEventArgs e) {

            string pathToBackups = (@"C:\Users\" + currentUser + @"\Backups");
            string logFile = Path.Combine(pathToBackups, "filesToBackup.txt");

            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string sourceFile = ConvertStringArray(s);


            //Build file name of newly created file by extracting info from source file
            string copyFileName = Path.GetFileNameWithoutExtension(sourceFile);
            string copyExtension = Path.GetExtension(sourceFile);
            string keyedFileName = (copyFileName + GenerateFileKey() + copyExtension);

            //combine path to backups directory with semi-unique file name
            string destFile = Path.Combine(pathToBackups, keyedFileName);
            string successfulCopyMsg = "File successfully copied!";
            string duplicateCopyMsg = "File is already scheduled to backed up!";

            


            if (File.ReadAllText(logFile).Contains(sourceFile)) {  
                listBox2.Items.Add(duplicateCopyMsg);
            }
            else {

                File.AppendAllText(logFile, sourceFile + Environment.NewLine);

                listBox1.Items.Add(sourceFile);
                listBox2.Items.Add(successfulCopyMsg);

                //copy file to destination
                File.Copy(sourceFile, destFile);
               
            }

        }//end textBoxFile_DragDrop


        private void btnFileRelease_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }//end textBoxFile_DragEnter


    }
}
