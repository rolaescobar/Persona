using Microsoft.EntityFrameworkCore;
using Persona.Models; // Asegúrate de usar el namespace correcto de tu DbContext

class Program
{
    static void Main(string[] args)
    {
        // Configurar el DbContextOptions con la cadena de conexión
        var optionsBuilder = new DbContextOptionsBuilder<PersonasDBContext>();
        optionsBuilder.UseSqlServer("Server=LAPTOP-CTDBT2LP\\SQLEXPRESS;Database=PersonasDB;Trusted_Connection=True;");

        // Crear una instancia del DbContext con las opciones configuradas
        using (var context = new PersonasDBContext(optionsBuilder.Options))
        {
            // Probar la conexión a la base de datos
            try
            {
                // Si la conexión es exitosa, el siguiente comando no lanzará una excepción
                context.Database.OpenConnection();
                Console.WriteLine("Conexión a la base de datos establecida correctamente.");

            
                var usuarios = context.Usuarios
                    .Include(u=> u.IdTipoUsuarioNavigation)
                   .Where(u => u.IdUsuario == 1)
                    .Select(u=> new
                    {
                        NombreUsuario = u.NombreUsuario,
                        TipoUsuario = u.IdTipoUsuarioNavigation.Descripcion

                    })
                    .ToList();

                foreach(var usuario in usuarios)
                {
                    Console.WriteLine($"Nombre de usuario: {usuario.NombreUsuario},Tipo de usuario: {usuario.TipoUsuario}");
                }
             
                
                
            }
            catch (Exception ex)
            {
                // En caso de error, muestra el mensaje
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
            }
            finally
            {
                // Asegurarse de cerrar la conexión cuando ya no se necesite
                context.Database.CloseConnection();
            }
        }
    }
}
