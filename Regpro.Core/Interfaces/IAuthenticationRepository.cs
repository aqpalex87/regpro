using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Regpro.Core.Entities;

namespace Regpro.Core.Interfaces
{
    public interface IAuthenticationRepository 
    {
        Task<SignInResult> CheckPasswordSignIn(User user, string password);
    }
}