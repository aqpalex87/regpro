using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class TblRegproDocumentoDto
    {
        public long? NIdTipdocu { get; set; }
        public string CNrodoc { get; set; }
        public DateTime? DFecdocu { get; set; }
        public string CCoddocu { get; set; }
        public DateTime DFeccre { get; set; }
        public string CUsucre { get; set; }
        public DateTime? DFecumo { get; set; }
        public string CUsuumo { get; set; }
        public string Codooii { get; set; }
        public long? NIdTipreso { get; set; }
        public string CEstado { get; set; }
    }
}
