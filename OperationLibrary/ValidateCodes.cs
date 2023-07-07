using SQLLibrary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OperationLibrary
{
    public class ValidateCodes
    {
        private ProductSQL productSQL = new ProductSQL();


        protected async Task<bool> ProductExist(string codeProduct, string storeHouse, int index)
        {
            string valueString = await productSQL.GetProduct(codeProduct, storeHouse);

            if (string.IsNullOrEmpty(valueString) || valueString == "0")
            {
                MessageBox.Show("El codigo: " + codeProduct + " no existe. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (valueString != "1")
            {
                MessageBox.Show("El codigo: " + codeProduct + " esta duplicado. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        protected async Task<bool> BulkExist(string codeBulk, string storeHouse, int index)
        {
            string valueString = await productSQL.GetBulk(codeBulk);
            var result = await productSQL.GetProductCodeAndQuantityByBulk(codeBulk);
            string priceProduct = await productSQL.GetProductPriceBulk(result.Item1, storeHouse);

            if (string.IsNullOrEmpty(valueString) || valueString == "0")
            {
                return false;
            }
            else if (valueString != "1")
            {
                MessageBox.Show("El codigo: " + codeBulk + " esta duplicado. Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (string.IsNullOrEmpty(priceProduct))
            {
                MessageBox.Show("El codigo: " + codeBulk + " del bulto contiene articulos que no pertenecen al almacen: " + storeHouse + ". Linea: " + index.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
