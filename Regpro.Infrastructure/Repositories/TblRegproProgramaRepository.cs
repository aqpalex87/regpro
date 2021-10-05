using Microsoft.EntityFrameworkCore;
using Regpro.Core.DTOs.TblRegproPrograma;
using Regpro.Core.Entities;
using Regpro.Core.Interfaces;
using Regpro.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regpro.Infrastructure.Repositories
{
    public class TblRegproProgramaRepository : BaseRepository<TblRegproPrograma>, ITblRegproProgramaRepository
    {
        private readonly regproContext _context;
        public TblRegproProgramaRepository(regproContext context) : base(context) {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<TblRegproPrograma> GetProgramaById(long nIdPrograma)
        {
            return await _entities.Where(x=>x.NIdPrograma == nIdPrograma).FirstOrDefaultAsync();
        }

        public async Task<TblRegproProgramaSelectDto> GetProgramaByCcodMod(string cCodMod,string Codooii)
        {
            var result = await (from pr in _context.TblRegproProgramas
                                where (pr.CCodmod == cCodMod && pr.Codooii == Codooii)
                                select new TblRegproProgramaSelectDto
                                {
                                    NIdPrograma = pr.NIdPrograma,
                                    CCodmod = pr.CCodmod == null? "": pr.CCodmod,
                                    NIdTipprog = pr.NIdTipprog,
                                    CNomprog = pr.CNomprog == null ? "" : pr.CNomprog,
                                    NProlat = pr.NProlat == null ? 0 : pr.NProlat,
                                    NProlon = pr.NProlon == null ? 0 : pr.NProlon,
                                    NIdTipgest = pr.NIdTipgest,
                                    NIdTipdepe = pr.NIdTipdepe,
                                    NIdTipeges = pr.NIdTipeges,
                                    Codooii = pr.Codooii == null ? "" : pr.Codooii,
                                    NIdTipturn = pr.NIdTipturn,
                                    NIdTipcjes = pr.NIdTipcjes,
                                    NIdTipvia = pr.NIdTipvia == null ? 0 : pr.NIdTipvia,
                                    CDirnomvia = pr.CDirnomvia == null ? "" : pr.CDirnomvia,
                                    CDirnumvia = pr.CDirnumvia == null ? "" : pr.CDirnumvia,
                                    CDirmz = pr.CDirmz == null ? "" : pr.CDirmz,
                                    CDirlote = pr.CDirlote == null ? "" : pr.CDirlote,
                                    NIdTiplocd = pr.NIdTiplocd,
                                    CDirlocd = pr.CDirlocd == null ? "" : pr.CDirlocd,
                                    CDiretap = pr.CDiretap == null ? "" : pr.CDiretap,
                                    CDirsect = pr.CDirsect == null ? "" : pr.CDirsect,
                                    CDirzona = pr.CDirzona == null ? "" : pr.CDirzona,
                                    CDirotro = pr.CDirotro == null ? "" : pr.CDirotro,
                                    CDirrefe = pr.CDirrefe == null ? "" : pr.CDirrefe,
                                    Codgeo = pr.Codgeo == null ? "" : pr.Codgeo,
                                    CCodccpp = pr.CCodccpp == null ? "" : pr.CCodccpp,
                                    CNomccpp = pr.CNomccpp == null ? "" : pr.CNomccpp,
                                    CCsemc = pr.CCsemc == null ? "" : pr.CCsemc,
                                    CNomsemc = pr.CNomsemc == null ? "" : pr.CNomsemc,
                                    NIdTipprag = pr.NIdTipprag == null ? 0 : pr.NIdTipprag,
                                    COtrpragua = pr.COtrpragua == null ? "" : pr.COtrpragua,
                                    CSumagua = pr.CSumagua == null ? "" : pr.CSumagua,
                                    NIdTippren = pr.NIdTippren == null ? 0 : pr.NIdTippren,
                                    COtrprener = pr.COtrprener == null ? "" : pr.COtrprener,
                                    CSumener = pr.CSumener == null ? "" : pr.CSumener,
                                    CodArea = pr.CodArea == null ? "" : pr.CodArea,
                                    CCodAreasig = pr.CCodAreasig == null ? "" : pr.CCodAreasig,
                                    Nzoom = pr.Nzoom == null ? 0 : pr.Nzoom,
                                    Mcenso = pr.Mcenso,
                                    Marcocd = pr.Marcocd,
                                    NIdTipsitu = pr.NIdTipsitu,
                                    DFeccre = pr.DFeccre,
                                    CUsucre = pr.CUsucre,
                                    DFecumo = pr.DFecumo == null ? DateTime.MinValue : pr.DFecumo,
                                    CUsuumo = pr.CUsuumo,
                                    DFecreprog = pr.DFecreprog == null ? DateTime.MinValue : pr.DFecreprog,
                                    DFecieprog = pr.DFecieprog == null ? DateTime.MinValue : pr.DFecieprog,
                                    DFerenprog = pr.DFerenprog == null ? DateTime.MinValue : pr.DFerenprog,
                                    NCcpplat = pr.NCcpplat == null ? 0 : pr.NCcpplat,
                                    NCcpplon = pr.NCcpplon == null ? 0 : pr.NCcpplon,
                                    NSemclat = pr.NSemclat == null ? 0 : pr.NSemclat,
                                    NSemclon = pr.NSemclon == null ? 0 : pr.NSemclon,
                                    CGeohash = pr.CGeohash == null ? "" : pr.CGeohash,
                                    NIdTipreso = pr.NIdTipreso == null ? 0 : pr.NIdTipreso,
                                    CNrodoc = pr.CNrodoc,
                                    DFecdocu = pr.DFecdocu == null ? DateTime.MinValue : pr.DFecdocu,
                                    CCoddocu = pr.CCoddocu,
                                    NIdTipestado = pr.NIdTipestado == null ? 0 : pr.NIdTipestado,
                                    CCodlocal = pr.CCodlocal
                                }).FirstOrDefaultAsync();
            //if (result.CCodmod == null)
            //    result.CCodmod = "";

            return result;
        }

        public async Task<CenterEducationalNearSelectDto> GetCenterEducationalNear(string cCodMod, string CodUgel)
        {
                   var result = await (from pr in _context.TblRegproProgramas 
                                      where (pr.CCodmod == cCodMod && pr.Codooii == CodUgel)
                                      select new CenterEducationalNearSelectDto 
                                      {
                                      CCodmod = pr.CCodmod,
                                      CNomprog= pr.CNomprog,
                                      NSemclat = pr.NProlat,
                                      NSemclon = pr.NProlon
                                      }).FirstOrDefaultAsync();
            return result;
        }
    }
}
