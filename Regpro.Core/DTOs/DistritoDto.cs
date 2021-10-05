using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class DistritoDto
    {
        public string IdDistrito { get; set; }
        public string IdProvincia { get; set; }
        public string Distrito1 { get; set; }
        public decimal? Municip { get; set; }
        public decimal? IndVerna { get; set; }
        public decimal? PointX { get; set; }
        public decimal? PointY { get; set; }
        public decimal? Zoom { get; set; }

    }
}
