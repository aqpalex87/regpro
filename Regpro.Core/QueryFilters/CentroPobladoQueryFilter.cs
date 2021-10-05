using System;
using System.Collections.Generic;
using System.Text;

namespace Regpro.Core.QueryFilters
{
    public class CentroPobladoQueryFilter
    {
        public string UBIGEO { get; set; }
        public string CODCP { get; set; }
        public string DENOMINACION { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
