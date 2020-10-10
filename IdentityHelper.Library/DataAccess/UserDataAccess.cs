using IdentityHelper.Library.Internal.SqlDataAccess;
using System.Threading.Tasks;

namespace IdentityHelper.Library.DataAccess
{
    public class UserDataAccess
    {
        SqlDataAccess sqlDataAccess;
        public UserDataAccess()
        {
            sqlDataAccess = new SqlDataAccess();

        }
        public async Task AddNewUser<T>(string connectionString, T parameters, string procedureName)
        {


            await sqlDataAccess.SaveData<T>(connectionString, procedureName, parameters);
        }

        public async Task<T> LoadUserByName<T, U>(string connectionString, U parameters, string procedureName)
        {


            return await sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);

        }
        public async Task<T> LoadUserById<T, U>(string connectionString, U parameters, string procedureName)
        {


            return await sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);

        }

        public async Task<T> LoadUserByEmail<T, U>(string connectionString, U parameters, string procedureName)
        {


            return await sqlDataAccess.LoadData<T, U>(parameters, connectionString, procedureName);

        }
    }
}
