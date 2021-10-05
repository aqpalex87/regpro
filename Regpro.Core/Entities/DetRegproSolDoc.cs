using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class DetRegproSolDoc : BaseEntity
    {
        public long NIdDocumento { get; set; }
        public long NIdSolicitud { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual TblRegproDocumento NIdDocumentoNavigation { get; set; }
        public virtual TblRegproSolicitud NIdSolicitudNavigation { get; set; }
    }
}
