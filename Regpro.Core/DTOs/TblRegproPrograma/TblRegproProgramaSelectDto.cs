using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.DTOs.TblRegproPrograma
{
    public class TblRegproProgramaSelectDto
    {
        public long NIdPrograma { get; set; } 
        public string CCodmod { get; set; }
        public long NIdTipprog { get; set; } 
        public string CNomprog { get; set; } 
        public decimal? NProlat { get; set; } 
        public decimal? NProlon { get; set; }
        public long NIdTipgest { get; set; } 
        public long NIdTipdepe { get; set; } 
        public long NIdTipeges { get; set; } 
        public string Codooii { get; set; } 
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
        public string Codgeo { get; set; } 
        public string CCodccpp { get; set; } 
        public string CNomccpp { get; set; } 
        public string CCsemc { get; set; } 
        public string CNomsemc { get; set; } 
        public long? NIdTipprag { get; set; } 
        public string COtrpragua { get; set; } 
        public string CSumagua { get; set; } 
        public long? NIdTippren { get; set; } 
        public string COtrprener { get; set; }
        public string CSumener { get; set; } 
        public string CodArea { get; set; }
        public string CCodAreasig { get; set; } 
        public decimal? Nzoom { get; set; }
        public string Mcenso { get; set; }
        public string Marcocd { get; set; }
        public long NIdTipsitu { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public DateTime? DFecreprog { get; set; }
        public DateTime? DFecieprog { get; set; }
        public DateTime? DFerenprog { get; set; }
        public decimal? NCcpplat { get; set; } 
        public decimal? NCcpplon { get; set; } 
        public decimal? NSemclat { get; set; } 
        public decimal? NSemclon { get; set; } 
        public string CGeohash { get; set; } 
        public long? NIdTipreso { get; set; } 
        public string CNrodoc { get; set; }
        public DateTime? DFecdocu { get; set; }
        public string CCoddocu { get; set; }
        public long? NIdTipestado { get; set; }
        public string CCodlocal { get; set; }
    }
}
