using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IUserRepository
    {
        Task<int> CreateUser(UserEntity entity);
        Task<int> DeleteUser(int UserID);
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<int> UpdateUser(UserEntity entity);
    }
}