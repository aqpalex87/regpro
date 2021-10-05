using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class TblRegproArchivoDto
    {
        public long NIdArchivo { get; set; }
        public long? NIdDocumento { get; set; }
        public long NIdTiparch { get; set; }
        public string CNomarch { get; set; }
        public string CCodarch { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public string CEstado { get; set; }
    }
}
