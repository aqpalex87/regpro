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
    public class TblRegproDocumentoRepository : BaseRepository<TblRegproDocumento>, ITblRegproDocumentoRepository
    {
        public TblRegproDocumentoRepository(regproContext context) : base(context) { }
        
        public async Task<IEnumerable<TblRegproDocumento>> GetAllDocumento()
        {
            return await _entities.ToListAsync();
        }
        public async Task<TblRegproDocumento> GetAllDocumentoById(long NIdDocumento)
        {
            return await _entities.Where(x=>x.NIdDocumento == NIdDocumento).FirstOrDefaultAsync();
        }
        public async Task<TblRegproDocumento> GetAllDocumentoByCCoddocu(string CCoddocu)
        {
            return await _entities.Where(x => x.CCoddocu == CCoddocu).FirstOrDefaultAsync();
        }
    }
}
