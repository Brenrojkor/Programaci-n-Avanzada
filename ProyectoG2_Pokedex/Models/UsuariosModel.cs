using System.ComponentModel.DataAnnotations;

namespace ProyectoG2_Pokedex.Models
{
    public class UsuariosModel
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Usuario { get; set; }

        [Required]
        [MaxLength(100)]
        public string? NombreUsuario { get; set; }

        [Required]
        [MaxLength(255)]
        public string? Contrasena { get; set; }

        [Required]
        public string? Rol { get; set; }
    }
}