using curso.web.mvc.Models.Cursos;
using curso.web.mvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace curso.web.mvc.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CursoController : Controller
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarCursoViewModelInput cadastrarCursoViewModelInput)
        {
            try
            {
                var curso = await _cursoService.Registrar(cadastrarCursoViewModelInput);

                ModelState.AddModelError("", $"O curso foi cadastrado com sucesso {curso.Nome}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Listar()
        {
            var cursos = await _cursoService.Obter();

            return View(cursos);
        }
    }
}
