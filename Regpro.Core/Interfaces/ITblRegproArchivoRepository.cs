using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproArchivoRepository : IRepository<TblRegproArchivo>
    {
        Task<IEnumerable<TblRegproArchivo>> GetAllArchivo();
        Task<TblRegproArchivo> GetArchivoById(long NIdArchivo);
    }
}
