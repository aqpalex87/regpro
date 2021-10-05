using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproMaestroService
    {
        Task<IEnumerable<TblRegproMaestro>> GetAllByCodGrop(string CCodgrup);
        Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropAndIdMaestropadre(string CCodgrup, long NIdMaestropadre);
        Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropWithOutState(string CEstado);
        Task<IEnumerable<TblRegproMaestro>> GetAllByMaestroPadre(long NIdMaestropadre);
        Task<IEnumerable<TblRegproMaestro>> GetMaestroByCodGropAndEstado(string CCodgrup, string CEstado);

    }
}