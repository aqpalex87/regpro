using Microsoft.EntityFrameworkCore;
using Regpro.Core.DTOs.TblRegproPrograma;
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
    public class TblRegproProgramaRepository : BaseRepository<TblRegproPrograma>, ITblRegproProgramaRepository
    {
        private readonly regproContext _context;
        public TblRegproProgramaRepository(regproContext context) : base(context) {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<TblRegproPrograma> GetProgramaById(long nIdPrograma)
        {
            return await _entities.Where(x=>x.NIdPrograma == nIdPrograma).FirstOrDefaultAsync();
        }

        public async Task<TblRegproPrograma> GetProgramaByCcodMod(string cCodMod,string Codooii)
        {
            return await _entities.Where(x => x.CCodmod == cCodMod && x.Codooii == Codooii).FirstOrDefaultAsync();
        }

        public async Task<CenterEducationalNearSelectDto> GetCenterEducationalNear(string cCodMod, string CodUgel)
        {
                   var result = await (from pr in _context.TblRegproProgramas 
                                      where (pr.CCodmod == cCodMod && pr.Codooii == CodUgel)
                                      select new CenterEducationalNearSelectDto 
                                      {
                                      CCodmod = pr.CCodmod,
                                      CNomprog= pr.CNomprog,
                                      NSemclat = pr.NProlat,
                                      NSemclon = pr.NProlon
                                      }).FirstOrDefaultAsync();
            return result;
        }
    }
}
