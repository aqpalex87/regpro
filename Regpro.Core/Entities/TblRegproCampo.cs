using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities 
{
    public partial class TblRegproCampo : BaseEntity
    {
        public TblRegproCampo()
        {
            DetRegproSolcams = new HashSet<DetRegproSolcam>();
        }

        public long NIdCampos { get; set; }
        public string CNomcamp { get; set; }
        public string CCodcamp { get; set; }
        public bool? BObligatorio { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual ICollection<DetRegproSolcam> DetRegproSolcams { get; set; }
    }
}
