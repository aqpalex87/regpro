using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities 
{
    public partial class TblRegproAccsoli : BaseEntity
    {
        public long NIdAccionsoli { get; set; }
        public long? NIdSolicitud { get; set; }
        public long NIdTipsitu { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public string CObs { get; set; }
        public string CPerfrev { get; set; }

        public virtual TblRegproSolicitud NIdSolicitudNavigation { get; set; }
    }
}
