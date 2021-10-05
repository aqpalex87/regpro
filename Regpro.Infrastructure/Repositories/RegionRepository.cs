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
    public class RegionRepository : BaseRepository<Regione>, IRegionRepository
    {
        private readonly regproContext _context;
        public RegionRepository(regproContext context) : base(context) {

            _context = context ??
        throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Regione>> GetAllRegion()
        {
            return await _entities.ToListAsync();
        }

        public async Task<Regione> GetRegionById(string IdRegion)
        {
            return await _entities.Where(x=>x.IdRegion == IdRegion).FirstOrDefaultAsync();
        }

    }
}
