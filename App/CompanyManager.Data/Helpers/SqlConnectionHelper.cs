using System.Data.SqlClient;

namespace CompanyManager.Data.Helpers
{
    public class SqlConnectionHelper
    {
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "company-manager.database.windows.net";
            builder.UserID = "company-manager";
            builder.Password = "Superpuperduperpassword123";
            builder.InitialCatalog = "CompanyManagerDB";

            return builder.ToString();
        }
    }
}
