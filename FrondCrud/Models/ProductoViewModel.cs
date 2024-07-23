namespace FrondCrud.Models
{
    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool? Activo { get; set; } 

    }
}
