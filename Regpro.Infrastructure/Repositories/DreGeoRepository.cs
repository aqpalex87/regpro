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
    public class DreGeoRepository : BaseRepository<DreGeo>, IDreGeoRepository
    {
        public DreGeoRepository(regproContext context) : base(context) { }

        public async Task<IEnumerable<DreGeo>> GetAllDreGeo()
        {
            return await _entities.ToListAsync();
        }

        public async Task<IEnumerable<DreGeo>> GetAllDreGeoByCodUgel(string codUgel)
        {
            return await _entities.Where(x=>x.Codigo == codUgel).ToListAsync();
        }
    }
}
