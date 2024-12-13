using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoG2_Pokedex.Models
{
    public class EquipoLuchaModel
    {
        [Key]
        public string NombreEquipo { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        // Relación con el modelo de usuario
        [ForeignKey("IdUsuario")]
        public UsuariosModel Usuario { get; set; }
    }
}