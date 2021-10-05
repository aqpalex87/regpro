using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class Regione : BaseEntity
    {
        public Regione()
        {
            DetRegproProvedepas = new HashSet<DetRegproProvedepa>();
            Provincia = new HashSet<Provincia>();
        }

        public string IdRegion { get; set; }
        public string Region { get; set; }
        public decimal? IndVerna { get; set; }
        public decimal? PointX { get; set; }
        public decimal? PointY { get; set; }
        public decimal? Zoom { get; set; }

        [NotMapped]
        public string CEstado { get; set; }

        public virtual ICollection<DetRegproProvedepa> DetRegproProvedepas { get; set; }
        public virtual ICollection<Provincia> Provincia { get; set; }
    }
}
