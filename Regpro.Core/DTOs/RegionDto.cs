using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class RegionDto
    {
        public string IdRegion { get; set; }
        public string Region { get; set; }
        public decimal? IndVerna { get; set; }
        public decimal? PointX { get; set; }
        public decimal? PointY { get; set; }
        public decimal? Zoom { get; set; }
    }
}
