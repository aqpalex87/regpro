using Microsoft.EntityFrameworkCore;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Infrastructure.Repositories
{
    public class DetRegproSolDocRepository : BaseRepository<DetRegproSolDoc>, IDetRegproSolDocRepository
    {
        public DetRegproSolDocRepository(regproContext context) : base(context) { }

        public async Task<List<DetRegproSolDoc>> GetDetRegproSolDocByIdDocumentoIdSolicitud(long NIdDocumento, long NIdSolicitud)
        {
            return await _entities.Where(x => x.NIdDocumento == NIdDocumento && x.NIdSolicitud == NIdSolicitud).ToListAsync();
        }
    }
}
