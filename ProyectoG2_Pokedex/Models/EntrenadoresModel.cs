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

        [ForeignKey("NombreEquipo")]
        public EquipoLuchaModel Equipo { get; set; }
    }
}
