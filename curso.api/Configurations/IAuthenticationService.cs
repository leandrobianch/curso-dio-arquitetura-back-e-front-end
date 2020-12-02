using curso.api.Models.Usuarios;

namespace curso.api.Configurations
{
    public interface IAuthenticationService
    {
        string GerarToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
