using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class DetRegproProvedepa : BaseEntity
    {
        public string IdRegion { get; set; }
        public long NIdMaestro { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual Regione IdRegionNavigation { get; set; }
        public virtual TblRegproMaestro NIdMaestroNavigation { get; set; }
    }
}
