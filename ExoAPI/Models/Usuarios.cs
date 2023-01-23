using System.ComponentModel.DataAnnotations;

namespace ExoAPI.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Tipo { get; set; }
    }
}
