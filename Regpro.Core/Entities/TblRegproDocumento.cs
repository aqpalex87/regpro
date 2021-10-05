using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproDocumento : BaseEntity
    {
        public TblRegproDocumento()
        {
            DetRegproSolDocs = new HashSet<DetRegproSolDoc>();
            TblRegproArchivos = new HashSet<TblRegproArchivo>();
        }

        public long NIdDocumento { get; set; }
        public long? NIdTipdocu { get; set; }
        public string CNrodoc { get; set; }
        public DateTime? DFecdocu { get; set; }
        public string CCoddocu { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public string Codooii { get; set; }
        public long? NIdTipreso { get; set; }

        public virtual ICollection<DetRegproSolDoc> DetRegproSolDocs { get; set; }
        public virtual ICollection<TblRegproArchivo> TblRegproArchivos { get; set; }
    }
}
