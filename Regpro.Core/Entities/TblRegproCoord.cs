using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities 
{
    public partial class TblRegproCoord : BaseEntity
    {
        public long NIdCoord { get; set; }
        public string Codigo { get; set; }
        public string CUsucoord { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual DreUgel CodigoNavigation { get; set; }
    }
}
