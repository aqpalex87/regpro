using Regpro.Core.DTOs.TblRegproPrograma;
using Regpro.Core.Entities;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproProgramaRepository : IRepository<TblRegproPrograma>
    {
       Task<TblRegproPrograma> GetProgramaById(long nIdPrograma);

        Task<TblRegproPrograma> GetProgramaByCcodMod(string cCodMod, string Codooii);
        Task<CenterEducationalNearSelectDto> GetCenterEducationalNear(string cCodMod, string CodUgel);
    }
}
