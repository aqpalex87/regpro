using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IDetRegproSolDocRepository : IRepository<DetRegproSolDoc>
    {
        Task<List<DetRegproSolDoc>> GetDetRegproSolDocByIdDocumentoIdSolicitud(long NIdDocumento, long NIdSolicitud);
    }
}
