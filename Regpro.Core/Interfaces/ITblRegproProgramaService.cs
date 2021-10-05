using Regpro.Core.CustomEntities;
using Regpro.Core.DTOs.TblRegproPrograma;
using Regpro.Core.Entities;
using Regpro.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Regpro.Core.Interfaces
{
    public interface ITblRegproProgramaService
    {
      
        Task<TblRegproPrograma> GetProgramaById(long nIdPrograma);

        Task InsertPrograma(TblRegproPrograma programa);
        Task<bool> UpdatePrograma(TblRegproPrograma programa);
        Task<TblRegproProgramaSelectDto> GetProgramaByCcodMod(string cCodMod, string Codooii);
        Task<CenterEducationalNearSelectDto> GetCenterEducationalNear(string cCodMod, string CodUgel);

    }
}