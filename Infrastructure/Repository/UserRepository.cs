using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration config;
        private readonly string ConnectionString;
        public UserRepository(IConfiguration config)
        {
            this.config = config;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }
        public async Task<int> CreateUser(UserEntity entity)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql_insert = "INSERT INTO users VALUES (@Lastname,@Firstname,@Username,@Password)";
            var insert_result = await conn.ExecuteAsync(sql_insert, entity);
            return insert_result;
        }

        public async Task<IEnumerable<UserEntity>> GetUsers()
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql_get = "SELECT * FROM users ORDER BY Lastname,Firstname ASC";
            var get_result = await conn.QueryAsync<UserEntity>(sql_get);
            return get_result;
        }

        public async Task<int> UpdateUser(UserEntity entity)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql_update = "UPDATE users SET Lastname = @Lastname, Firstname = @Firstname WHERE UserID = @UserID";
            var result = await conn.ExecuteAsync(sql_update, entity);
            return result;
        }

        public async Task<int> DeleteUser(int UserID)
        {
            using SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            string sql = "DELETE FROM users WHERE UserID = @UserID";
            var result = await conn.ExecuteAsync(sql, new { UserID });
            return result;
        }
    }
}
