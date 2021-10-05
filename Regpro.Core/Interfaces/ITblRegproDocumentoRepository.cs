using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproDocumentoRepository : IRepository<TblRegproDocumento>
    {
        Task<IEnumerable<TblRegproDocumento>> GetAllDocumento();
        Task<TblRegproDocumento> GetAllDocumentoById(long NIdDocumento);
        Task<TblRegproDocumento> GetAllDocumentoByCCoddocu(string CCoddocu);
    }
}
