using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class AudRegproSolcam : BaseEntity
    {
        public long NIdSolcamaud { get; set; }
        public long NIdSolicitudaud { get; set; }
        public long NIdCamposaud { get; set; }
        public string CEsteval { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual AudRegproCampo NIdCamposaudNavigation { get; set; }
        public virtual AudRegproSolicitud NIdSolicitudaudNavigation { get; set; }
    }
}
