using Regpro.Core.Entities;
using Regpro.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task<BaseResponse<User>>  Login(String userName, String password);
    }
}
