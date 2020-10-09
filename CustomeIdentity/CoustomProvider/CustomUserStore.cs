using IdentityHelper.Library.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomeIdentity.CoustomProvider
{
    public class CustomUserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>
    {
        private readonly string _connectionString;

        public CustomUserStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            UserDataAccess userDataAccess = new UserDataAccess();

            var p = new
            {
                @UserId = user.Id.ToString(),
                @UserName = user.UserName.ToString(),
                @Email = user.Email.ToString(),
                @Password = user.PasswordHash.ToString()
            };

            await userDataAccess.AddNewUser<dynamic>(_connectionString, p, "dbo.spUsers_AddUser");

            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    await connection.ExecuteAsync("dbo.spUsers_AddUser", new
            //    {
            //        @UserId = user.Id.ToString(),
            //        @UserName = user.UserName.ToString(),
            //        @Email = user.Email.ToString(),
            //        @Password = user.PasswordHash.ToString()
            //    }, commandType: CommandType.StoredProcedure);

            //}




            return IdentityResult.Success;

            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //
        }

        public Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();


            UserDataAccess userDataAccess = new UserDataAccess();

            var p = new
            {
                @NormalizedUserName = normalizedUserName
            };
            return await userDataAccess.LoadUserByName<ApplicationUser, dynamic>(_connectionString, p, "dbo.spUsers_GetUserByName");

            //var rows = await connection.QuerySingleOrDefaultAsync<ApplicationUser>("dbo.spUsers_GetUserByName",
            //    new { @NormalizedUserName = normalizedUserName },
            //    commandType: CommandType.StoredProcedure);

            //return rows;


            // from the net
            //using (var connection = new SqlConnection(_connectionString))
            //{
            //    //  await connection.OpenAsync(cancellationToken);
            //    return await connection.QuerySingleOrDefaultAsync<ApplicationUser>($@"SELECT * FROM dbo.Users
            //    WHERE [NormalizedUserName] = @{nameof(normalizedUserName)}", new { normalizedUserName });
            //}
        }

        public Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.NormalizedUserName);
        }

        public Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // password has 
        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash != null);
        }
    }
}

