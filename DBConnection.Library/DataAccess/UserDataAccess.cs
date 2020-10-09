using DBConnection.Library.Internal.DataAccess;
using DBConnection.Library.Models;
using System;
using System.Collections.Generic;

namespace DBConnection.Library.DataAccess
{
    public class UserDataAccess
    {
        private readonly string ConnectionName = "DefaultConnection";

        public void AddUser(Guid id, string userName, string email, string password)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();

            var Parameters = new
            {
                @UserId = id,
                @UserName = userName,
                @Email = email,
                @Password = password

            };

            sqlDataAccess.SaveData<dynamic>("dbo.spUsers_AddUser", Parameters, ConnectionName);

        }

        public List<UserModel> GetUserByName(string name)
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();


            var output = sqlDataAccess.LoadData<UserModel, dynamic>("dbo.spUsers_GetUserByName", new { @NormalizedUserName = name }, ConnectionName);

            return output;
        }
    }
}
