using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproPrograma : BaseEntity
    {
        public long NIdPrograma { get; set; } = 0;
        public string CCodmod { get; set; } = string.Empty;
        public long NIdTipprog { get; set; } = 0;
        public string CNomprog { get; set; } = string.Empty;
        public decimal? NProlat { get; set; } = 0;
        public decimal? NProlon { get; set; } = 0;
        public long NIdTipgest { get; set; } = 0;
        public long NIdTipdepe { get; set; } = 0;
        public long NIdTipeges { get; set; } = 0;
        public string Codooii { get; set; }=string.Empty;
        public long NIdTipturn { get; set; } = 0;
        public long NIdTipcjes { get; set; } = 0;
        public long? NIdTipvia { get; set; } = 0;
        public string CDirnomvia { get; set; } = string.Empty;
        public string CDirnumvia { get; set; } = string.Empty;
        public string CDirmz { get; set; } = string.Empty;
        public string CDirlote { get; set; } = string.Empty;
        public long NIdTiplocd { get; set; } = 0;
        public string CDirlocd { get; set; } = string.Empty;
        public string CDiretap { get; set; } = string.Empty;
        public string CDirsect { get; set; } = string.Empty;
        public string CDirzona { get; set; } = string.Empty;
        public string CDirotro { get; set; } = string.Empty;
        public string CDirrefe { get; set; } = string.Empty;
        public string Codgeo { get; set; } = string.Empty;
        public string CCodccpp { get; set; } = string.Empty;
        public string CNomccpp { get; set; } = string.Empty;
        public string CCsemc { get; set; } = string.Empty;
        public string CNomsemc { get; set; } = string.Empty;
        public long? NIdTipprag { get; set; } = 0;
        public string COtrpragua { get; set; } = string.Empty;
        public string CSumagua { get; set; } = string.Empty;
        public long? NIdTippren { get; set; } = 0;
        public string COtrprener { get; set; } = string.Empty;
        public string CSumener { get; set; } = string.Empty;
        public string CodArea { get; set; } = string.Empty;
        public string CCodAreasig { get; set; } = string.Empty;
        public decimal? Nzoom { get; set; } = 0;
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
        public decimal? NCcpplat { get; set; } = 0;
        public decimal? NCcpplon { get; set; } = 0;
        public decimal? NSemclat { get; set; } = 0;
        public decimal? NSemclon { get; set; } = 0;
        public string CGeohash { get; set; } = string.Empty;
        public long? NIdTipreso { get; set; } = 0;
        public string CNrodoc { get; set; }
        public DateTime? DFecdocu { get; set; }
        public string CCoddocu { get; set; }
        public long? NIdTipestado { get; set; } = 0;
        public string CCodlocal { get; set; }
    }
}
