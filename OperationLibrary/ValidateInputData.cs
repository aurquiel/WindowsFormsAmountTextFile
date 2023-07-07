using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationLibrary
{
    public class ValidateInputData : ValidateCodes
    {
        public async Task<bool> ValidateFileInfo(string pathFile, string storeHouse, DataTable dataInput)
        {
            try
            {
                int index = 1;
                dataInput.Clear();
                foreach (string line in GetLinesOfFile(pathFile))
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        MessageBox.Show("El archivo contiene una linea en blanco. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (line.Contains(","))
                    {
                        string[] splited = line.Split(',');

                        if (!isAlphaNumeric(splited[0]))
                        {
                            MessageBox.Show("El archivo contiene un codigo no alfanumerico. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else if (!isNumeric(splited[1]))
                        {
                            MessageBox.Show("El archivo contiene una cantidad ques no es numerica. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        else if (await BulkExist(splited[0], storeHouse, index) == true) //is a bulk
                        {
                            dataInput.Rows.Add(splited[0], splited[1]);
                        }
                        else if (await ProductExist(splited[0], storeHouse, index) == false) //is a product
                        {
                            return false;
                        }
                        else
                        {
                            dataInput.Rows.Add(splited[0], splited[1]);
                        }
                    }
                    index++;
                }
                return true;
            }
            catch
            {
                dataInput.Rows.Clear();
                MessageBox.Show("El al validar los datos de entrada ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private string[] GetLinesOfFile(string pathFile)
        {
            return File.ReadAllLines(pathFile);
        }

        private bool isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(strToCheck);
        }

        private bool isNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^\d+$");
            return rg.IsMatch(strToCheck);
        }

        public bool ValidateFolderSavingPath(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                MessageBox.Show("La direccion de la carpeta de guardado esta vacio o en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
