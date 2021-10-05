using Regpro.Core.QueryFilters;
using System;

namespace Regpro.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(ProvinciaQueryFilter filter, string actionUrl);
    }
}