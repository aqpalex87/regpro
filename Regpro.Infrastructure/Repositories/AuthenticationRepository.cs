using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Regpro.Core.Entities;
using Regpro.Infrastructure.Data;
using Regpro.Core.Interfaces;

namespace Regpro.Infrastructure.Repositories
{
    public class AuthenticationRepository : IdentidadRepository<User>, IAuthenticationRepository
    {
        private readonly SignInManager<User> _signInManager;

        private readonly IdentidadContext _context;
        public AuthenticationRepository(SignInManager<User> signInManager, IdentidadContext context)
        : base(context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<SignInResult> CheckPasswordSignIn(User user, string password)
        {

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);


            return result;

        }
    }
}


