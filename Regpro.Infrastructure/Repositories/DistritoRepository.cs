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
    public class DistritoRepository : BaseRepository<Distrito>, IDistritoRepository
    {
        public DistritoRepository(regproContext context) : base(context) { }

        public async Task<IEnumerable<Distrito>> GetDistritoByIdProvincia(string IdProvincia)
        {
            return await _entities.Where(x => x.IdProvincia == IdProvincia).ToListAsync();
        }
        public async Task<IEnumerable<Distrito>> GetAllDistrito()
        {
            return await _entities.ToListAsync();
        }

        public async Task<Distrito> GetDistritoById(string IdDistrito)
        {
            return await _entities.Where(x=>x.IdDistrito == IdDistrito).FirstOrDefaultAsync();
        }
    }
}
