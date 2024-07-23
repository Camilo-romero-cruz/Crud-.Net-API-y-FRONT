using DEVCRUD.Models;


namespace DEVCRUD.Clases
{
    public class DAO_Dios
    {

        public int? Login(string Username, string Password)
        {
            try
            {
                using (var cn = new LoginSystemContext())
                {
                    // Busca el usuario por nombre de usuario
                    var usuario = cn.Users.FirstOrDefault(u => u.Username == Username);

                    // Verifica si el usuario existe y si la contraseña coincide
                    if (usuario != null && usuario.Password == Password)
                    {
                        // Retorna el RoleId del usuario
                        return usuario.RoleId;
                    }

                    // Si el usuario no existe o la contraseña no coincide, retorna 0
                    return 0;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                throw new Exception("Error al intentar iniciar sesión", ex);
            }
        }


        public List<Producto> traerProductosAdmin()
        {
            using (var cn = new LoginSystemContext())  // Crea un contexto de base de datos llamado PruebaContext
            {
                var tabla = cn.Productos.ToList();  // Obtiene todos los usuarios de la tabla Usuarios y los guarda en una lista llamada tabla
                return tabla;  // Retorna la lista de usuarios
            }



        }
        public List<Producto> traerProductosGestor()
        {
            using (var cn = new LoginSystemContext())  // Crea un contexto de base de datos llamado PruebaContext
            {
                var tabla = cn.Productos.ToList();  // Obtiene todos los usuarios de la tabla Usuarios y los guarda en una lista llamada tabla
                return tabla.Where(p => p.Activo.GetValueOrDefault()).ToList();
            }
        }
        public string Edit(int ProductoId)
        {
            try  // Intenta hacer lo siguiente:
            {
                using (var cn = new LoginSystemContext())  // Crea un contexto de base de datos llamado PruebaContext
                {
                    var cs =  cn.Productos.Where(e=>e.ProductoId== ProductoId).FirstOrDefault();  // Actualiza el usuario pasado como parámetro en la tabla Usuarios del contexto
                    if (cs.Activo ==true )
                    {
                        cs.Activo = false;

                    }
                    else
                    {
                        cs.Activo = true;
                    }
                    
                    cn.SaveChanges();  // Guarda los cambios en la base de datos
                    return "ok";  // Retorna "ok" si todo salió bien
                }
            }
            catch (Exception)
            {
                throw;  // En caso de error, lanza una excepción para manejar errores
            }
        }

    }
}
