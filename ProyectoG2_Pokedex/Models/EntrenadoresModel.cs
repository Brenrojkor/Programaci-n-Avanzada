using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoG2_Pokedex.Models
{
    public class EntrenadoresModel
    {
        [Key]
        public int IdEntrenador { get; set; }
        public string NombreEntrenador{ get;set; }
        public string NombreEquipo {  get; set; }
        public int Nivel {  get; set; }
        public bool Estado {  get; set; }

        // Relación con el modelo de usuario
        [ForeignKey("NombreEquipo")]
        public EquipoModel Equipo { get; set; }
    }
}
