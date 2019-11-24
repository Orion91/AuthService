using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AuthService.Core.Models;
using AuthService.Core.Repositories;
using AuthService.Infrastructure.Settings;
using Dapper;

namespace AuthService.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
		private readonly SqlSettings _sqlSettings;

		public UserRepository(SqlSettings sqlSettings)
		{
			_sqlSettings = sqlSettings;
		}
        public async Task AddAsync(User user)
        {
			using (IDbConnection conn = new SqlConnection(_sqlSettings.ConnectionString))
			{
				if (conn.State == ConnectionState.Closed)
					conn.Open();

				DynamicParameters parameters = new DynamicParameters();
				parameters.Add("@Username", user.Username);
				parameters.Add("@Email", user.Email);
				parameters.Add("@PasswordHash", user.PasswordHash);
				parameters.Add("@PasswordSalt", user.PasswordSalt);
				parameters.Add("@CreatedDate", user.CreatedAt);
				parameters.Add("@LastActiveDate", user.LastActive);
				await conn.ExecuteAsync("Users_CreateNewUser", parameters, commandType: CommandType.StoredProcedure);
			}
        }

        public Task<User> GetAsync(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}