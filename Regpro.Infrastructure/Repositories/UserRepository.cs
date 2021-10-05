using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using System.Transactions;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Infrastructure.Data;

namespace Regpro.Infrastructure.Repositories
{
    public class UserRepository : IdentidadRepository<User>, IUserRepository 
    {
        private readonly UserManager<User> _userManager;

        private readonly IdentidadContext _context;
        public UserRepository( UserManager<User> userManager, IdentidadContext context)
        : base(context)
        { 
            _userManager = userManager;
            _context = context;
        }

        public async Task<User> GetUserById(int id)
        {
            var userFrom = await _context.Users.AsNoTracking()
            .Select(user => new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName
                ,SecurityStamp = user.SecurityStamp
                ,PasswordHash = user.PasswordHash
                ,Status = user.Status
            })
            .FirstOrDefaultAsync(user => user.Id == id); 
            
            return userFrom;
            
        } 
        public async Task<IEnumerable<User>> GetUsers()
        {
            //var roles = _userManager.GetRolesAsync()
            var users = await _userManager.Users.AsNoTracking()
            .Select(user => new User
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                LastName = user.LastName
                ,SecurityStamp = user.SecurityStamp
                ,Status = user.Status
            }).ToListAsync();

            return users; 
        }         
        public async Task<User> CreateUser(User User, String Password)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await _userManager.CreateAsync(User, Password);
                if (result.Succeeded)
                {
                var result2 = await _userManager.AddToRolesAsync(User, User.RoleNames);
                }
                scope.Complete();
            }
            return User;
        }
        public async Task<User> GetUserRoles(User user)
        {
            user.RoleNames = await _userManager.GetRolesAsync(user);
            return user; 
        }

        public async Task<User> AddUserRoles(User user, IEnumerable<string> rolesForAdd, IEnumerable<string> rolesForExclude)
        {
            await _userManager.AddToRolesAsync(user, rolesForAdd.Except(rolesForExclude));
            return user; 
        }
        public async Task<User> RemoveUserRoles(User user, IEnumerable<string> rolesForRemove, IEnumerable<string> rolesForExclude)
        {
            await _userManager.RemoveFromRolesAsync(user, rolesForRemove.Except(rolesForExclude));
            return user; 
        }
        public async Task<User> UpdateUser(User userForBeUpdated)
        {
            IdentityResult result =  await _userManager.UpdateAsync(userForBeUpdated);

            //var userFromRepo = await GetUserById(userForBeUpdated.Id);
            
            return userForBeUpdated; 
        }
        public async Task<User> GetUserByUserName(string userName)
        {
            var userFrom = await _context.Users.AsNoTracking()
            .Select(user => new User
            {
                Id = user.Id
                ,UserName = user.UserName
                ,Name = user.Name
                ,LastName = user.LastName
                ,CodUgel = user.CodUgel
                ,SecurityStamp = user.SecurityStamp
                ,PasswordHash = user.PasswordHash
                ,Status = user.Status
            })
            .FirstOrDefaultAsync(user => user.UserName == userName);

            var rolesList = await _userManager.GetRolesAsync(userFrom).ConfigureAwait(false);
            userFrom.RoleNames = rolesList.ToList();

            return userFrom;

        }
        public async Task<User> ResetPassword(User user, string newPassword)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            return user;
        }
    }
}

