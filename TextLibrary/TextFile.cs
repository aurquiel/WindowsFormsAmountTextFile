using SQLLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextLibrary
{
    public class TextFile
    {
        private decimal MAX_AMOUNT = 999999999;
        private decimal counter = 0;
        public List<DataTable> ListDataFiles { get; set; } = new List<DataTable>();

        ProductSQL prodcutSQL = new ProductSQL();

        public async Task<bool> ReadFilePerLine(string path, DataTable dataTable, string stroreHouse)
        {
            dataTable.Rows.Clear();
            string[] lines = File.ReadAllLines(path);

            int index = 1;
            foreach (string line in lines)
            {
                if(string.IsNullOrEmpty(line))
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
                        MessageBox.Show("El archivo contiene un codigo de cantidad no numerico. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    else if (await BulkExist(splited[0],index) == true) //is a bulk
                    {
                        dataTable.Rows.Add(splited[0], splited[1]);
                    }
                    else if (await ProductExist(splited[0], stroreHouse, index) == false) //is a product
                    {
                        dataTable.Rows.Clear();
                        return false;
                    }
                    else
                    {
                        dataTable.Rows.Add(splited[0], splited[1]);
                    }
                }
                 
                index++;
            }
            return true;
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

        private async Task<bool> ProductExist(string codeProduct, string storeHouse, int index)
        {
            string valueString = await prodcutSQL.GetProduct(codeProduct, storeHouse);

            if(string.IsNullOrEmpty(valueString) || valueString == "0")
            {
                MessageBox.Show("El codigo: " + codeProduct + " no existe. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if(valueString != "1")
            {
                MessageBox.Show("El codigo: " + codeProduct + " esta duplicado. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private async Task<bool> BulkExist(string codeBulk, int index)
        {
            string valueString = await prodcutSQL.GetBulk(codeBulk);

            if (string.IsNullOrEmpty(valueString) || valueString == "0")
            {
                return false;
            }
            else if (valueString != "1")
            {
                MessageBox.Show("El codigo: " + codeBulk + " esta duplicado. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }




        private DataTable CreateNewDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("CODIGO", typeof(string));
            dataTable.Columns.Add("CANTIDAD", typeof(string));
            return dataTable;
        }


        
    }
}
