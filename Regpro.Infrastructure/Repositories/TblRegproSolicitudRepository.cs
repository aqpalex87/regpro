using Microsoft.EntityFrameworkCore;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Regpro.Infrastructure.Repositories
{
    public class TblRegproSolicitudRepository : BaseRepository<TblRegproSolicitud>, ITblRegproSolicitudRepository
    {
        public TblRegproSolicitudRepository(regproContext context) : base(context) { }

        public async Task<IEnumerable<TblRegproSolicitud>> GetAllSolicitud()
        {
            return await _entities.ToListAsync();
        }
        public async Task<TblRegproSolicitud> GetFindRequest(long NIdSolicitud)
        {
            return await _entities.Where(x => x.NIdSolicitud == NIdSolicitud).FirstOrDefaultAsync();
        }

    }
}
