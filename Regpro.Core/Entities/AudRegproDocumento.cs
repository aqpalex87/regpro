using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class AudRegproDocumento : BaseEntity
    {
        public AudRegproDocumento()
        {
            AudRegproArchivos = new HashSet<AudRegproArchivo>();
            AudRegproSolDocs = new HashSet<AudRegproSolDoc>();
        }

        public long NIdDocumentoaud { get; set; }
        public long? NIdTipdocu { get; set; }
        public string CNrodoc { get; set; }
        public DateTime? DFecdocu { get; set; }
        public string CCoddocu { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual ICollection<AudRegproArchivo> AudRegproArchivos { get; set; }
        public virtual ICollection<AudRegproSolDoc> AudRegproSolDocs { get; set; }
    }
}
