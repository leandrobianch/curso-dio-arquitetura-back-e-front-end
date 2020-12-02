using curso.web.mvc.Models.Usuarios;
using Refit;
using System.Threading.Tasks;

namespace curso.web.mvc.Services
{
    public interface IUsuarioService
    {
        [Post("/api/v1/usuario/registrar")]
        Task<RegistrarUsuarioViewModelInput> Registrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput);

        [Post("/api/v1/usuario/logar")]
        Task<LoginViewModelOutput> Logar(LoginViewModelInput loginViewModelInput);
    }
}
