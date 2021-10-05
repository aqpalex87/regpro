using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class TblRegproMaestro : BaseEntity
    {
        public TblRegproMaestro()
        {
            DetRegproProvedepas = new HashSet<DetRegproProvedepa>();
            InverseNIdMaestropadreNavigation = new HashSet<TblRegproMaestro>();
        }

        public long NIdMaestro { get; set; }
        public long? NIdMaestropadre { get; set; }
        public string CCodgrup { get; set; }
        public string CNom { get; set; }
        public string CDesc { get; set; }
        public string CCoditem { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }

        public virtual TblRegproMaestro NIdMaestropadreNavigation { get; set; }
        public virtual ICollection<DetRegproProvedepa> DetRegproProvedepas { get; set; }
        public virtual ICollection<TblRegproMaestro> InverseNIdMaestropadreNavigation { get; set; }
    }
}
