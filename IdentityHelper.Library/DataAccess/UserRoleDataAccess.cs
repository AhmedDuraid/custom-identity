using Dapper;
using IdentityHelper.Library.Internal.SqlDataAccess;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace IdentityHelper.Library.DataAccess
{
    public class UserRoleDataAccess
    {
        SqlDataAccess _sqlDataAccess;
        public UserRoleDataAccess()
        {
            _sqlDataAccess = new SqlDataAccess();
        }
        public List<T> LoadUserRoleByID<T, U>(string connectionString, U parameters, string procedureName)
        {
            using (var connection = new SqlConnection(connectionString))
            {

                var rows = connection.Query<T>(procedureName,
                    parameters,
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }



        }
    }
}
