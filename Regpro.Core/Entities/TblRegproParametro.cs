using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproParametro : BaseEntity
    {
        public long NIdParametro { get; set; }
        public string CCodparame { get; set; }
        public string CDesparam { get; set; }
        public string CValorparam { get; set; }
        public decimal? NValorparam { get; set; }
        public DateTime? DValorparam { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
    }
}
