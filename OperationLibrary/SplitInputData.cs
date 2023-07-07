using SQLLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationLibrary
{
    public class SplitInputData : ValidateCodes
    {
        private ListDataFilesToTextFiles dataFilesToTextFiles = new ListDataFilesToTextFiles();
        private ProductSQL productSQL = new ProductSQL();
        private ListQueueItem listQueueItem = new ListQueueItem();

        public async Task<bool> SplitValuesPerLine(DataTable dataInput, DataTable dataFormat, string storeHouse, string folderSavingPath)
        {
            dataFormat.Clear();
            listQueueItem.ListOfItem.Clear();
            listQueueItem = new ListQueueItem();

            int index = 1;
            foreach (DataRow row in dataInput.Rows)
            {
                if (await BulkExist(row[0].ToString(), storeHouse, index) == true)
                {
                    if (await SplitBulk(row, storeHouse) == false)
                    {
                        return false;
                    }
                }
                else
                {
                    if(await SplitProducts(row, storeHouse) == false)
                    {
                        return false;
                    }
                }
            }

            ListDataFiLesToDataFormat(dataFormat);
            return await Task.Run(() => dataFilesToTextFiles.TransforListDataFilesToTextFiles(listQueueItem.ListOfItem, folderSavingPath));
        }

        private void ListDataFiLesToDataFormat(DataTable dataFormat)
        {
            dataFormat.Rows.Add("---------------------------------", "---------------------------------");
            foreach (QueueItem aux in listQueueItem.ListOfItem)
            {
                foreach (DataRow row in aux.Data.Rows)
                {
                    dataFormat.Rows.Add(row[0].ToString(), row[1].ToString());
                }
                dataFormat.Rows.Add("---------------------------------", "---------------------------------");
            }
        }

        private async Task<bool> SplitBulk(DataRow row, string storeHouse)
        {
            try
            {
                var results = await productSQL.GetProductCodeAndQuantityByBulk(row[0].ToString());
                string codeProduct = results.Item1;
                int quantityProductsInBLuk = Int32.Parse(results.Item2);
                string codeBulk = row[0].ToString();
                int quantityBulk = Int32.Parse(row[1].ToString());
                decimal priceProduct = Decimal.Parse(await productSQL.GetProductPriceBulk(codeProduct, storeHouse));

                listQueueItem.AddItem(codeBulk, quantityBulk, priceProduct * quantityProductsInBLuk);
                return true;
            }
            catch
            {
                MessageBox.Show("Error al dividir bulto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async Task<bool> SplitProducts(DataRow row, string storeHouse)
        {
            try
            {
                string code = row[0].ToString();
                decimal price = Decimal.Parse(await productSQL.GetProductPrice(row[0].ToString(), storeHouse));
                int quantity = Int32.Parse(row[1].ToString());

                listQueueItem.AddItem(code, quantity, price);
                return true;
            }
            catch
            {
                MessageBox.Show("Error al dividir productos por valor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
