using IdentityHelper.Library.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomeIdentity.CoustomProvider
{
    public class CustomRoleStore : IRoleStore<ApplicationRole>
    {
        private readonly string _connectionString;
        RoleDataAccess roleDataAccess;
        public CustomRoleStore(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            roleDataAccess = new RoleDataAccess();
        }
        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var Parameters = new { @RoleID = role.Id, @RoleName = role.Name };

            await roleDataAccess.AddNewRole<dynamic>(_connectionString, Parameters, "dbo.spRoles_AddNewRole");

            return IdentityResult.Success;
        }

        public Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            //
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var Parameters = new { @RoleID = roleId };

            return await roleDataAccess.FindRoleByID<ApplicationRole, dynamic>
                (_connectionString, Parameters, "dbo.spRoles_GetRoleByID");

        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var Parameters = new { @RoleName = normalizedRoleName };

            return await roleDataAccess.FindRoleByName<ApplicationRole, dynamic>
                (_connectionString, Parameters, "dbo.spRoles_GetRoleByName");

        }

        public Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Id.ToString());
        }

        public Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            return Task.FromResult(role.Name);
        }

        public Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
