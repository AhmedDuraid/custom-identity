using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IdentityHelper.Library.Internal.SqlDataAccess
{
    internal class SqlDataAccess
    {

        public async Task SaveData<T>(string connectionString, string procedureName, T parameters)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(procedureName,
                    parameters
                    , commandType: CommandType.StoredProcedure);
            }

        }

        public async Task<T> LoadData<T, U>(U parameters, string connectionString, string procedureName)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var rows = await connection.QuerySingleOrDefaultAsync<T>(procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                return rows;
            }

        }
    }
}
