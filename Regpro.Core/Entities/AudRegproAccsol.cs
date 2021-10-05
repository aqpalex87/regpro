using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class AudRegproAccsol : BaseEntity
    {
        public long NIdAccionsoliaud { get; set; }
        public long? NIdSolicitudaud { get; set; }
        public long NIdTipaccs { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual AudRegproSolicitud NIdSolicitudaudNavigation { get; set; }
    }
}
