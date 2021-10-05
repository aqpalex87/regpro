using System;
using System.Collections.Generic;

#nullable disable

namespace Regpro.Core.Entities
{
    public partial class CodmodAsig : BaseEntity
    {
        public long Id { get; set; }
        public string Codmod { get; set; }
        public string Asignado { get; set; }
        public string CodooiiAsig { get; set; }
        public string UsuarioAsig { get; set; }
        public DateTime? FechaAsig { get; set; }
    }
}
