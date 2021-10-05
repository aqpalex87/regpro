using Regpro.Core.CustomEntities;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproArchivoService
    {
        Task<IEnumerable<TblRegproArchivo>> GetAllArchivo();
        Task InsertArchivo(TblRegproArchivo archivo);
        Task<TblRegproArchivo> GetArchivoById(long NIdArchivo);
    }
}