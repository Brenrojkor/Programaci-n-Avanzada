using System.ComponentModel.DataAnnotations;

namespace ProyectoG2_Pokedex.Models
{
    public class EnfermeriaModel
    {
        [Key]
        public int AtencionID { get; set; }
        [Required]
        public string NombrePokemon { get; set; }
        [Required]
        public string NombreDueño { get; set; }
        [Required]
        public string Padecimiento { get; set; }
        public string? Estado { get; set; } // Estado opcional
    }
}
