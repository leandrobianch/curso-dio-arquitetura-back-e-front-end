using System.ComponentModel.DataAnnotations;

namespace curso.web.mvc.Models.Usuarios
{
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }
    }
}
