using System.Configuration;

namespace SQLLibrary
{
    public class Database
    {
        internal int SQL_TIMEOUT_EXECUTION_COMMAND = 5;

        internal string GetSettingsConenction()
        {
            string setting = ConfigurationManager.ConnectionStrings["Sap"].ConnectionString;
            return setting;
        }
    }
}
