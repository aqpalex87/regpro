using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class AudRegproSolDoc : BaseEntity
    {
        public long NIdDocumentoaud { get; set; }
        public long NIdSolicitudaud { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual AudRegproDocumento NIdDocumentoaudNavigation { get; set; }
        public virtual AudRegproSolicitud NIdSolicitudaudNavigation { get; set; }
    }
}
