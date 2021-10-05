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
    public class TblRegproMaestroRepository : BaseRepository<TblRegproMaestro>, ITblRegproMaestroRepository
    {
        public TblRegproMaestroRepository(regproContext context) : base(context) { }

        public async Task<IEnumerable<TblRegproMaestro>> GetAllMaestro()
        {
            return await _entities.ToListAsync();
        }
        public async Task<IEnumerable<TblRegproMaestro>> GetAllByCodGrop(string CCodgrup)
        {
            return await _entities.Where(x => x.CCodgrup == CCodgrup).ToListAsync();
        }

        public async Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropAndIdMaestropadre(string CCodgrup, long NIdMaestropadre)
        {
            return await _entities.Where(x => x.CCodgrup == CCodgrup && x.NIdMaestropadre == NIdMaestropadre).ToListAsync();
        }
        public async Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropWithOutState(string CEstado)
        {
            return await _entities.Where(x => x.CEstado == CEstado).ToListAsync();
        }
        public async Task<IEnumerable<TblRegproMaestro>> GetAllByMaestroPadre(long NIdMaestropadre)
        {
            return await _entities.Where(x => x.NIdMaestropadre == NIdMaestropadre).ToListAsync();
        }
    }
}
