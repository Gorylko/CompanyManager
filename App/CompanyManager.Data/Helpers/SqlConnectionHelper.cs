using System.Data.SqlClient;

namespace CompanyManager.Data.Helpers
{
    public class SqlConnectionHelper
    {
        public string GetConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "kiryl.database.windows.net";
            builder.UserID = "gorylko";
            builder.Password = "Rbhbkk78901234";
            builder.InitialCatalog = "FinanceAnalyzer";

            return builder.ToString();
        }
    }
}
