using System;
using System.Collections.Generic;

namespace DEVCRUD.Models
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool? Activo { get; set; }
    }
}
