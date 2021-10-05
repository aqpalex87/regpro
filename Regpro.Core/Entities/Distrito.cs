using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class Distrito : BaseEntity
    {
        public Distrito()
        {
            DreGeos = new HashSet<DreGeo>();
            TblRegproSolicituds = new HashSet<TblRegproSolicitud>();
        }

        public string IdDistrito { get; set; }
        public string IdProvincia { get; set; }
        public string Distrito1 { get; set; }
        public decimal? Municip { get; set; }
        public decimal? IndVerna { get; set; }
        public decimal? PointX { get; set; }
        public decimal? PointY { get; set; }
        public decimal? Zoom { get; set; }

        [NotMapped]
        public string CEstado { get; set; }
        public virtual Provincia IdProvinciaNavigation { get; set; }
        public virtual ICollection<DreGeo> DreGeos { get; set; }
        public virtual ICollection<TblRegproSolicitud> TblRegproSolicituds { get; set; }
    }
}
