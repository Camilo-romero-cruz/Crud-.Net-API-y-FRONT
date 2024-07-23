namespace fronts.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int? RoleId { get; set; }


        public int ProductoId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool? Activo { get; set; }
    }
}
