using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface IProvinciaService
    {
        PagedList<Provincia> GetProvincias(ProvinciaQueryFilter filters);

        Task<Provincia> GetProvincia(string id);

        Task InsertProvincia(Provincia provincia);

        Task<bool> UpdateProvincia(Provincia provincia);

        Task<bool> DeleteProvincia(int id);
        Task<IEnumerable<Provincia>> GetProvinciaByCodUgel(string codUgel, string IdRegion);

    }
}