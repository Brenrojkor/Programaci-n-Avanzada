using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoG2_Pokedex.Models
{
    public class MensajeModel
    {
        [Key]
        public int IdMensaje { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Mensaje { get; set; }

        public DateTime Fecha { get; set; }

        [ForeignKey("IdUsuario")]
        public UsuariosModel Usuario { get; set; }
    }
}

