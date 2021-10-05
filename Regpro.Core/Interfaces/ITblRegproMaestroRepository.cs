using Regpro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproMaestroRepository : IRepository<TblRegproMaestro>
    {
        Task<IEnumerable<TblRegproMaestro>> GetAllMaestro();
        Task<IEnumerable<TblRegproMaestro>> GetAllByCodGrop(string CCodgrup);
        Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropAndIdMaestropadre(string CCodgrup, long NIdMaestropadre);
        Task<IEnumerable<TblRegproMaestro>> GetAllByCodGropWithOutState(string CEstado);

        Task<IEnumerable<TblRegproMaestro>> GetAllByMaestroPadre(long NIdMaestropadre);

    }
}
