using System.ComponentModel.DataAnnotations;

namespace ExoAPI.Models
{
    public class Projetos
    {
        [Key]
        public int IdProjeto { get; set; }
        public string? Titulo { get; set; }
        public string? Situacao { get; set; }
        public DateTime DataInicio { get; set; }
        public string? Tecnologia { get; set; }
        public string? Requisitos { get; set; }
        public string? Area { get; set; }

    }
}
