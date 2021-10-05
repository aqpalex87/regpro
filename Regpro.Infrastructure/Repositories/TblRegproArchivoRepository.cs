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
    public class TblRegproArchivoRepository : BaseRepository<TblRegproArchivo>, ITblRegproArchivoRepository
    {
        public TblRegproArchivoRepository(regproContext context) : base(context) { }


        public async Task<IEnumerable<TblRegproArchivo>> GetAllArchivo()
        {
            return await _entities.ToListAsync();
        }
        public async Task<TblRegproArchivo> GetArchivoById(long NIdArchivo)
        {
            return await _entities.Where(x => x.NIdArchivo == NIdArchivo).FirstOrDefaultAsync();
        }
    }
}
