using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.DTOs
{
    public class TblRegproMaestroDto
    {
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
        public string CEstado { get; set; }

    }
}
