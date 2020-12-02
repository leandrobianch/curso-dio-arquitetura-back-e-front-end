using curso.web.mvc.Models.Cursos;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace curso.web.mvc.Services
{
    public interface ICursoService
    {
        [Post("/api/v1/cursos")]
        [Headers("Authorization: Bearer")]
        Task<CadastrarCursoViewModelOutput> Registrar(CadastrarCursoViewModelInput CadastrarCursoViewModelInput);

        [Get("/api/v1/cursos")]
        [Headers("Authorization: Bearer")]
        Task<IList<ListarCursoViewModelOutput>> Obter();
    }
}
