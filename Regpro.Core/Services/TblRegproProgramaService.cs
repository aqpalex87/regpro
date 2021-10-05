using Microsoft.Extensions.Options;
using Regpro.Core.CustomEntities;
using Regpro.Core.DTOs.TblRegproPrograma;
using Regpro.Core.Entities;
using Regpro.Core.Exceptions;
using Regpro.Core.Interfaces;
using Regpro.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Regpro.Core.Services
{
    public class TblRegproProgramaService : ITblRegproProgramaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;

        public TblRegproProgramaService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<TblRegproPrograma> GetProgramaById(long nIdPrograma)
        {
            return await _unitOfWork.TblRegproProgramaRepository.GetProgramaById(nIdPrograma);
        }



        public async Task InsertPrograma(TblRegproPrograma programa)
        {

            await _unitOfWork.TblRegproProgramaRepository.Add(programa);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrograma(TblRegproPrograma programa)
        {
            var existingProvincia = await _unitOfWork.TblRegproProgramaRepository.GetProgramaById(programa.NIdPrograma);
            existingProvincia.CCodmod = programa.CCodmod;
            existingProvincia.NIdTipprog = programa.NIdTipprog;
            existingProvincia.CNomprog = programa.CNomprog;
            existingProvincia.NProlat = programa.NProlat;
            existingProvincia.NProlon = programa.NProlon;
            existingProvincia.NIdTipgest = programa.NIdTipgest;
            existingProvincia.NIdTipdepe = programa.NIdTipdepe;
            existingProvincia.NIdTipeges = programa.NIdTipeges;
            existingProvincia.Codooii = programa.Codooii;
            existingProvincia.NIdTipturn = programa.NIdTipturn;
            existingProvincia.NIdTipcjes = programa.NIdTipcjes;
            existingProvincia.NIdTipvia = programa.NIdTipvia;
            existingProvincia.CDirnomvia = programa.CDirnomvia;
            existingProvincia.CDirnumvia = programa.CDirnumvia;
            existingProvincia.CDirmz = programa.CDirmz;
            existingProvincia.CDirlote = programa.CDirlote;
            existingProvincia.NIdTiplocd = programa.NIdTiplocd;
            existingProvincia.CDirlocd = programa.CDirlocd;
            existingProvincia.CDiretap = programa.CDiretap;
            existingProvincia.CDirsect = programa.CDirsect;
            existingProvincia.CDirzona = programa.CDirzona;
            existingProvincia.CDirotro = programa.CDirotro;
            existingProvincia.CDirrefe = programa.CDirrefe;
            existingProvincia.Codgeo = programa.Codgeo;
            existingProvincia.CCodccpp = programa.CCodccpp;
            existingProvincia.CNomccpp = programa.CNomccpp;
            existingProvincia.CCsemc = programa.CCsemc;
            existingProvincia.CNomsemc = programa.CNomsemc;
            existingProvincia.NIdTipprag = programa.NIdTipprag;
            existingProvincia.COtrpragua = programa.COtrpragua;
            existingProvincia.CSumagua = programa.CSumagua;
            existingProvincia.NIdTippren = programa.NIdTippren;
            existingProvincia.COtrprener = programa.COtrprener;
            existingProvincia.CSumener = programa.CSumener;
            existingProvincia.CodArea = programa.CodArea;
            existingProvincia.CCodAreasig = programa.CCodAreasig;
            existingProvincia.Nzoom = programa.Nzoom;
            existingProvincia.Mcenso = programa.Mcenso;
            existingProvincia.Marcocd = programa.Marcocd;
            existingProvincia.NIdTipsitu = programa.NIdTipsitu;
            existingProvincia.DFeccre = programa.DFeccre;
            existingProvincia.CUsucre = programa.CUsucre;
            existingProvincia.DFecumo = programa.DFecumo;
            existingProvincia.CUsuumo = programa.CUsuumo;
            existingProvincia.DFecreprog = programa.DFecreprog;
            existingProvincia.DFecieprog = programa.DFecieprog;
            existingProvincia.DFerenprog = programa.DFerenprog;
            existingProvincia.NCcpplat = programa.NCcpplat;
            existingProvincia.NCcpplon = programa.NCcpplon;
            existingProvincia.NSemclat = programa.NSemclat;
            existingProvincia.NSemclon = programa.NSemclon;
            existingProvincia.CGeohash = programa.CGeohash;
            existingProvincia.NIdTipreso = programa.NIdTipreso;
            existingProvincia.CNrodoc = programa.CNrodoc;
            existingProvincia.DFecdocu = programa.DFecdocu;
            existingProvincia.CCoddocu = programa.CCoddocu;
            existingProvincia.NIdTipestado = programa.NIdTipestado;

            _unitOfWork.TblRegproProgramaRepository.Update(existingProvincia);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<TblRegproProgramaSelectDto> GetProgramaByCcodMod(string cCodMod, string Codooii)
        {
            return await _unitOfWork.TblRegproProgramaRepository.GetProgramaByCcodMod(cCodMod, Codooii);
        }
        public async Task<CenterEducationalNearSelectDto> GetCenterEducationalNear(string cCodMod, string CodUgel)
        {
            return await _unitOfWork.TblRegproProgramaRepository.GetCenterEducationalNear(cCodMod, CodUgel);
        }
    }
}
