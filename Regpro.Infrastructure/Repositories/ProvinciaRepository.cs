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
    public class ProvinciaRepository : BaseRepository<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(regproContext context) : base(context) { }

        public async Task<IEnumerable<Provincia>> GetAllProvincia()
        {
            return await _entities.ToListAsync();
        }
        public async Task<Provincia> GetProvinciaById(string IdProvincia)
        {
            return await _entities.Where(x=>x.IdProvincia == IdProvincia).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Provincia>> GetProvinciaByIdRegion(string IdRegion)
        {
            return await _entities.Where(x => x.IdRegion == IdRegion).ToListAsync();
        }
    }
}
