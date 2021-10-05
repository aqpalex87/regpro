using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class DreGeo : BaseEntity
    {
        public string Codigo { get; set; }
        public string IdDistrito { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual DreUgel CodigoNavigation { get; set; }
        public virtual Distrito IdDistritoNavigation { get; set; }
    }
}
