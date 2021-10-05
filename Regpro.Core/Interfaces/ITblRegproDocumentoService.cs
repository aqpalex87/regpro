using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproDocumentoService
    {
        Task<TblRegproDocumento> GetAllDocumentoById(long NIdDocumento);
        Task InsertDocumento(TblRegproDocumento documento);
        

    }
}