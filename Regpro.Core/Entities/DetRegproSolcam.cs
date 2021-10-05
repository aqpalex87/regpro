using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class DetRegproSolcam : BaseEntity
    {
        public long NIdSolcam { get; set; }
        public long NIdSolicitud { get; set; }
        public long NIdCampos { get; set; }
        public string CEsteval { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public string CPerfrev { get; set; }

        public virtual TblRegproCampo NIdCamposNavigation { get; set; }
        public virtual TblRegproSolicitud NIdSolicitudNavigation { get; set; }
    }
}
