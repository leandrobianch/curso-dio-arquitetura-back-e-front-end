using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.Cursos
{
    public class CursoViewModelInput
    {
        [Required(ErrorMessage = "O nome do curso é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }
    }
}
