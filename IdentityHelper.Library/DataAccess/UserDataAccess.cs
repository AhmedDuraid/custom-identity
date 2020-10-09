using IdentityHelper.Library.Internal.SqlDataAccess;
using System.Threading.Tasks;

namespace IdentityHelper.Library.DataAccess
{
    public class UserDataAccess
    {
        public async Task AddNewUser<T>(string connectionString, T parameters, string procedureName)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            await sqlDataAccess.SaveData<T>(connectionString, procedureName, parameters);
        }

        public async Task<T> LoadUserByName<T, U>(string connectionString, U parameters, string procedureName)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            return await sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);

        }
    }
}
