using IdentityHelper.Library.Internal.SqlDataAccess;
using System.Threading.Tasks;

namespace IdentityHelper.Library.DataAccess
{
    public class RoleDataAccess
    {
        SqlDataAccess sqlDataAccess;
        public RoleDataAccess()
        {
            sqlDataAccess = new SqlDataAccess();

        }
        public async Task AddNewRole<T>(string connectionString, T parameters, string procedureName)
        {


            await sqlDataAccess.SaveData<T>(connectionString, procedureName, parameters);
        }

        public async Task<T> FindRoleByID<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await sqlDataAccess.LoadData<T, dynamic>(parameters, connectionString, procedureName);

        }
        public async Task<T> FindRoleByName<T, U>(string connectionString, U parameters, string procedureName)
        {
            return await sqlDataAccess.LoadData<T, dynamic>(parameters, connectionString, procedureName);

        }
    }
}
