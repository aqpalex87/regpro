using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class DreUgel : BaseEntity
    {
        public DreUgel()
        {
            DreGeos = new HashSet<DreGeo>();
            TblRegproCoords = new HashSet<TblRegproCoord>();
            TblRegproSolicituds = new HashSet<TblRegproSolicitud>();
        }

        public string Codigo { get; set; }
        public string Nombreoi { get; set; }
        public string Tipo { get; set; }
        public decimal? InVerna { get; set; }
        public decimal? PointX { get; set; }
        public decimal? PointY { get; set; }
        public decimal? Zoom { get; set; }

        public virtual ICollection<DreGeo> DreGeos { get; set; }
        public virtual ICollection<TblRegproCoord> TblRegproCoords { get; set; }
        public virtual ICollection<TblRegproSolicitud> TblRegproSolicituds { get; set; }
    }
}
