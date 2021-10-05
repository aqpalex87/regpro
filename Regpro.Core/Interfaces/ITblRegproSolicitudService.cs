using Microsoft.AspNetCore.Http;
using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproSolicitudService
    {
        Task<TblRegproSolicitud> GetFindRequest(long NIdSolicitud);
        Task InsertSolicitud(TblRegproSolicitud solicitud, List<IFormFile> files, IFormFile croquis);
    }
}