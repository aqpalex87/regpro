using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IDistritoService
    {
        Task<IEnumerable<Distrito>> GetAllDistrito();
        Task<IEnumerable<Distrito>> GetDistritoByCodUgel(string codUgel, string IdProvincial);

    }
}