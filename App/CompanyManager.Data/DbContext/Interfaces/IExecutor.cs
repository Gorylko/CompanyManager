namespace CompanyManager.Data.DbContext.Interfaces
{
    using System.Collections.Generic;
    using System.Data;

    public interface IExecutor
    {
        DataSet ExecuteDataSet(string procedureName, IDictionary<string, object> values = null);

        object ExecuteScalar(string procedureName, IDictionary<string, object> values = null);

        int ExecuteNonQuery(string procedureName, IDictionary<string, object> values = null);
    }
}
