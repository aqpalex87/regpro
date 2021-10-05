using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproPeriodo : BaseEntity
    {
        public long NIdPeriodo { get; set; }
        public string CNomperiodo { get; set; }
        public DateTime DFecIniperiodo { get; set; }
        public DateTime DFecFinperiodo { get; set; }
        public DateTime DFecFinanio { get; set; }
        public string CCodgrup { get; set; }
        public string CCoditem { get; set; }
        public string CUsucrea { get; set; }
        public DateTime DFeccrea { get; set; }
    }
}
