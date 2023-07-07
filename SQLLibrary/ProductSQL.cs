using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLLibrary
{
    public class ProductSQL : Database
    {
        public async Task<string> GetBulk(string codeBulk)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    string query = String.Format("select count(*) from p01.MARM where EAN11 = '{0}' and MEINH = 'PAK'", codeBulk);
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        return reader[0].ToString();
                    }
                    return string.Empty;
                }
                catch
                {
                    MessageBox.Show("Error de conexion de base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
        }

        public async Task<Tuple<string, string>> GetProductCodeAndQuantityByBulk(string codeBulk)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    string query = String.Format("select MATNR,UMREZ from p01.MARM where EAN11 = '{0}' and MEINH = 'PAK'", codeBulk);
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        return new Tuple<string, string>(reader[0].ToString(), reader[1].ToString());
                    }

                    return new Tuple<string, string>(string.Empty, string.Empty); 
                }
                catch
                {
                    MessageBox.Show("Error de conexion de base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new Tuple<string, string>(string.Empty, string.Empty);
                }
            }
        }

        public async Task<string> GetProduct(string codeProdcut, string storeHouse)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    string query = String.Format("select count(*) from p01.MARA m, p01.MBEW mb where m.EAN11 = '{0}' and mb.MATNR = m.MATNR and mb.BWKEY = {1}", codeProdcut, storeHouse);
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        return reader[0].ToString();
                    }
                    return string.Empty;
                }
                catch
                {
                    MessageBox.Show("Error de conexion de base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
        }

        public async Task<string> GetProductPrice(string codeProdcut, string storeHouse)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    string query = String.Format("select m.EAN11,mb.MATNR,mb.VERPR from p01.MARA m, p01.MBEW mb where m.EAN11 = '{0}' and mb.MATNR = m.MATNR and mb.BWKEY = {1} and mb.MANDT = 400", codeProdcut, storeHouse);
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        return reader[2].ToString();
                    }
                    return string.Empty;
                }
                catch
                {
                    MessageBox.Show("Error de conexion de base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
        }

        public async Task<string> GetProductPriceBulk(string codeProdcut, string storeHouse)
        {
            using (SqlConnection sqlConnection = new SqlConnection(GetSettingsConenction()))
            {
                try
                {
                    await sqlConnection.OpenAsync();
                    string query = String.Format("select m.EAN11,mb.MATNR,mb.VERPR from p01.MARA m, p01.MBEW mb where m.MATNR = '{0}' and mb.MATNR = m.MATNR and mb.BWKEY = {1} and mb.MANDT = 400", codeProdcut, storeHouse);
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = SQL_TIMEOUT_EXECUTION_COMMAND;

                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        return reader[2].ToString();
                    }
                    return string.Empty;
                }
                catch
                {
                    MessageBox.Show("Error de conexion de base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return string.Empty;
                }
            }
        }
    }
}
