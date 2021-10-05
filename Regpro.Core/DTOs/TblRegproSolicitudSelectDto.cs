using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class TblRegproSolicitudSelectDto
    {
        public long NIdSolicitud { get; set; }
        public string Codigo { get; set; }
        public string IdDistrito { get; set; }
        public string CCodsoli { get; set; }
        public long NIdTipsoli { get; set; }
        public string CCodmod { get; set; }
        public long NIdTipprog { get; set; }
        public string CNomprog { get; set; }
        public decimal? NProlat { get; set; }
        public decimal? NProlon { get; set; }
        public long NIdTipgest { get; set; }
        public long NIdTipdepe { get; set; }
        public long NIdTipeges { get; set; }
        public long NIdTipturn { get; set; }
        public long NIdTipcjes { get; set; }
        public long? NIdTipvia { get; set; }
        public string CDirnomvia { get; set; }
        public string CDirnumvia { get; set; }
        public string CDirmz { get; set; }
        public string CDirlote { get; set; }
        public long NIdTiplocd { get; set; }
        public string CDirlocd { get; set; }
        public string CDiretap { get; set; }
        public string CDirsect { get; set; }
        public string CDirzona { get; set; }
        public string CDirotro { get; set; }
        public string CDirrefe { get; set; }
        public string CCodccpp { get; set; }
        public string CNomccpp { get; set; }
        public decimal? NCcpplat { get; set; }
        public decimal? NCcpplon { get; set; }
        public string CCsemc { get; set; }
        public string CNomsemc { get; set; }
        public decimal? NSemclat { get; set; }
        public decimal? NSemclon { get; set; }
        public long? NIdTipprag { get; set; }
        public string COtrpragua { get; set; }
        public string CSumagua { get; set; }
        public long? NIdTippren { get; set; }
        public string COtrprener { get; set; }
        public string CSumener { get; set; }
        public long NIdTipsitu { get; set; }
        public string CUsuenv { get; set; }
        public string CNomusuenv { get; set; }
        public DateTime? DFecenv { get; set; }
        public string CUsumodi { get; set; }
        public string CNomusumodi { get; set; }
        public DateTime? DFecmodi { get; set; }
        public string CUsurevi { get; set; }
        public string CNomusurevi { get; set; }
        public DateTime? DFecrevi { get; set; }
        public string CUsurevs { get; set; }
        public string CNomusurevs { get; set; }
        public DateTime? DFecrevs { get; set; }
        public DateTime? DFecaten { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public string CGeohash { get; set; }
        public string CCodArea { get; set; } = string.Empty;
        public string CCodAreasig { get; set; } = string.Empty;
        public long? NIdTipsituprog { get; set; }
        public long? NIdTipsiturev { get; set; }
        public long? NIdTipsiturevsig { get; set; }
        public string CIndult { get; set; }
        public long NIdTipoperiodo { get; set; }

        public IEnumerable<TblRegproArchivoDto> Archivos { get; set; }
        public TblRegproDocumentoDto Documento { get; set; }
    }
}
