using System.ComponentModel.DataAnnotations;

namespace ProyectoG2_Pokedex.Models
{
    public class EnfermeriaModel
    {
        [Key]
        public int AtencionID { get; set; }
        public string NombrePokemon { get; set; }
        public string NombreDueño { get; set; }
        public string Padecimiento { get; set; }
        public string Estado { get; set; }
    }
}
