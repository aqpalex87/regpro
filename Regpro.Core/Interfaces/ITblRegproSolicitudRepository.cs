using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproSolicitudRepository : IRepository<TblRegproSolicitud>
    {
        Task<IEnumerable<TblRegproSolicitud>> GetAllSolicitud();
        Task<TblRegproSolicitud> GetFindRequest(long NIdSolicitud);

    }
}
