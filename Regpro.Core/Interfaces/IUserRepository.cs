using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IUserRepository : IIdentidadRepository<User>
    {
        Task<User> CreateUser(User User, String Password);
        Task<User> GetUserById(int id);
        
        Task<IEnumerable<User>> GetUsers();        
        Task<User> GetUserRoles(User user);

        Task<User> AddUserRoles(User user, IEnumerable<string> rolesForAdd, IEnumerable<string> rolesForExclude);

        Task<User> RemoveUserRoles(User user, IEnumerable<string> rolesForRemove, IEnumerable<string> rolesForExclude);

        Task<User> UpdateUser(User userForBeUpdated);
        Task<User> GetUserByUserName(string userName);
        Task<User> ResetPassword(User user, string newPassword);
    }
}