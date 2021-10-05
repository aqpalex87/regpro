using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IProvinciaRepository : IRepository<Provincia>
    {
        Task<IEnumerable<Provincia>> GetAllProvincia();
        Task<Provincia> GetProvinciaById(string IdProvincia);
        Task<IEnumerable<Provincia>> GetProvinciaByIdRegion(string IdRegion);

    }
}
