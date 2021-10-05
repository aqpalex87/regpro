using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class AudRegproCampo : BaseEntity
    {
        public AudRegproCampo()
        {
            AudRegproSolcams = new HashSet<AudRegproSolcam>();
        }

        public long NIdCamposaud { get; set; }
        public string CNomcamp { get; set; }
        public bool? BObligatorio { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual ICollection<AudRegproSolcam> AudRegproSolcams { get; set; }
    }
}
