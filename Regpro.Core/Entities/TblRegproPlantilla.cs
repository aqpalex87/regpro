using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproPlantilla : BaseEntity
    {
        public long NIdPlantilla { get; set; }
        public string CNomplantilla { get; set; }
        public long NIdTipplantilla { get; set; }
        public string CDescplantilla { get; set; }
        public string CCodarch { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
    }
}
