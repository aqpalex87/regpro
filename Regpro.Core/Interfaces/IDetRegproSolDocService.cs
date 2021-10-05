using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IDetRegproSolDocService
    {
        Task<List<DetRegproSolDoc>> GetDetRegproSolDocByIdDocumentoIdSolicitud(long NIdDocumento, long NIdSolicitud);
        Task InsertDetRegproSolDoc(DetRegproSolDoc detRegproSolDoc);

    }
}