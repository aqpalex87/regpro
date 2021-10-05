using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IDreGeoRepository : IRepository<DreGeo>
    {
        Task<IEnumerable<DreGeo>> GetAllDreGeo();
        Task<IEnumerable<DreGeo>> GetAllDreGeoByCodUgel(string codUgel);
    }
}
