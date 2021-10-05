using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class CentroPobladoDto
    {
        public string UBIGEO { get; set; }
        public string CODCP { get; set; }
        public string DENOMINACION { get; set; }
        public double LONGITUD_DEC { get; set; }
        public double LATITUD_DEC { get; set; }
        public string AREA { get; set; }
        public string AREA_SIG { get; set; }
        public string IDDIST { get; set; }
        public string NOMB_UBIGEO { get; set; }
        public string ORIGINAL { get; set; }
        public string BORRADO { get; set; }
        public object IDDUP { get; set; }
        public object CODCPDUP { get; set; }
        public string FECHA { get; set; }

    }
}
