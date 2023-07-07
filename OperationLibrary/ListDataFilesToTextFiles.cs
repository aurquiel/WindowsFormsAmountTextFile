using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace OperationLibrary
{
    public class ListDataFilesToTextFiles
    {
        private static readonly string fileName = "ARCHIVO";
        private int counter = 0;

        public bool TransforListDataFilesToTextFiles(List<QueueItem> ListOfItem, string folderSavingPath)
        {
            try
            {
                counter = 0;
                //Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ARCHIVOS_TXT"));
                //DateTime auxTime = DateTime.Now;
                //string dateTime = auxTime.Day.ToString() + "-" + auxTime.Month.ToString() + "-" + auxTime.Year.ToString() + "-" + auxTime.Hour.ToString() + "-" + auxTime.Minute.ToString() + "-" + auxTime.Second.ToString();
                //folderSavingPath = folderSavingPath + "-" + dateTime;
                //Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ARCHIVOS_TXT", folderSavingPath));
                //EliminateAllFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ARCHIVOS_TXT\\");

                foreach (QueueItem aux in ListOfItem)
                {
                    string path = folderSavingPath + "\\" + fileName + counter.ToString() + ".txt";
                    using (FileStream fs = File.Create(path))
                    {
                        int rowLast = 1;
                        foreach(DataRow row in aux.Data.Rows)
                        {
                            byte[] info;
                            if (rowLast < aux.Data.Rows.Count)
                            {
                                info = new UTF8Encoding(true).GetBytes(row[0].ToString() + "," + row[1].ToString() + "\r\n");
                            }
                            else
                            {
                                info = new UTF8Encoding(true).GetBytes(row[0].ToString() + "," + row[1].ToString());
                            }
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                            rowLast++;
                        } 
                    }

                    counter++;
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Error al crear archivos de texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void EliminateAllFiles(string rootFolder)
        {
            string[] files = Directory.GetFiles(rootFolder);
            foreach (string file in files)
            {
                File.Delete(file);
            }

        }
    }
}
