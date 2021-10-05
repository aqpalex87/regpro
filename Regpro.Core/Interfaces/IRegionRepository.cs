using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IRegionRepository : IRepository<Regione>
    {
        Task<IEnumerable<Regione>> GetAllRegion();
        Task<Regione> GetRegionById(string IdRegion);

    }
}
