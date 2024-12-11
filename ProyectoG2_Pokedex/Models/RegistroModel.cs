using System.ComponentModel.DataAnnotations;

namespace ProyectoG2_Pokedex.Models
{
    public class RegistroModel
    {
        public int UsuarioID { get; set; }

       
        [StringLength(45, ErrorMessage = "El Nombre de Usuario no debe exceder los 45 caracteres")]
        public string NombreUsuario { get; set; }

      
        [StringLength(80, ErrorMessage = "La Contraseña no debe exceder los 80 caracteres")]
        public string Contraseña { get; set; }

        [StringLength(100, ErrorMessage = "El Nombre Completo no debe exceder los 100 caracteres")]
        public string NombreCompleto { get; set; }

        
    }
}