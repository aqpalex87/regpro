using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class Provincia : BaseEntity
    {
        public Provincia()
        {
            Distritos = new HashSet<Distrito>();
        }

        public string IdProvincia { get; set; }
        public string IdRegion { get; set; }
        public string Provincia1 { get; set; }
        public decimal? IndVerna { get; set; }
        public decimal? PointX { get; set; }
        public decimal? PointY { get; set; }
        public decimal? Zoom { get; set; }
        [NotMapped]
        public string CEstado { get; set; }
        public virtual Regione IdRegionNavigation { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; }
    }
}
