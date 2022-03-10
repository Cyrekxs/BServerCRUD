using BServerCRUD.Data.DTO;
using Infrastructure.Entities;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BServerCRUD.Data
{
    public class UserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> CreateUser(UserDTO dto)
        {
            UserEntity entity = new UserEntity()
            {
                UserID = 0,
                Lastname = dto.Lastname,
                Firstname = dto.Firstname,
                Username = dto.Username,
                Password = dto.Password
            };

            var result = await repository.CreateUser(entity);
            return result;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var result = await repository.GetUsers();
            List<UserModel> Users = new List<UserModel>();
            foreach (var item in result)
            {
                Users.Add(new UserModel()
                {
                    UserID = item.UserID,
                    Lastname = item.Lastname,
                    Firstname = item.Firstname,
                    Username = item.Username,
                    Password = item.Password
                });
            }
            return Users;
        }

        public async Task<int> UpdateUser(UserDTO dto)
        {
            UserEntity entity = new UserEntity()
            {
                UserID = dto.UserID,
                Lastname = dto.Lastname,
                Firstname = dto.Firstname,
                Username = dto.Username,
                Password = dto.Password
            };

            var result = await repository.UpdateUser(entity);
            return result;
        }

        public async Task<int> DeleteUser(int UserID)
        {
            var result = await repository.DeleteUser(UserID);
            return result;
        }
    }
}
