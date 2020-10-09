using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DBConnection.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {

        public string GetConnectionString(string stringName)
        {
            // return the connection string from config file 
            return ConfigurationManager.ConnectionStrings[stringName].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedure, U Parameter, string connectionStringName)
        {
            // geting the connection string name from the caller config file 

            string connectionString = GetConnectionString(connectionStringName);

            // load data using dapper
            using (IDbConnection connection = new SqlConnection(connectionString))
            {

                List<T> rows = connection.Query<T>(storedProcedure, Parameter, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        // load data from DB 

        public void SaveData<T>(string storedProcedure, T Parameter, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProcedure, Parameter, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
