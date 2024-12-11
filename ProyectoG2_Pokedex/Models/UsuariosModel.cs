using System.ComponentModel.DataAnnotations;

namespace ProyectoG2_Pokedex.Models
{
    public class UsuariosModel
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Usuario { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public string Rol { get; set; }
    }
}
