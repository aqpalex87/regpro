using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproArchivo : BaseEntity
    {
        public long NIdArchivo { get; set; }
        public long? NIdDocumento { get; set; }
        public long NIdTiparch { get; set; }
        public string CNomarch { get; set; }
        public string CCodarch { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual TblRegproDocumento NIdDocumentoNavigation { get; set; }
    }
}
