using Microsoft.AspNetCore.Mvc;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Http;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        protected readonly IServiceUsuario service;
        public UsuarioController(IServiceUsuario service)
        {
            this.service = service;
        }
        public async Task<IActionResult> GetAllUsuario()
        {
            var listaUsuario = await service.GetAll();
            return View(listaUsuario);
        }
        // GET: UsuarioController
        public IActionResult Index()
        {
            return View();
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> ConsultUsuario(Guid id)
        {
            var consulta = await service.GetById(id);
            return View(consulta);
        }

        // GET: UsuarioController/Create
        public ActionResult CreateUsuario()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUsuario(UsuarioService usuarioService)
        {
            try
            {
                await service.AddSave(usuarioService);
                return RedirectToAction(nameof(GetAllUsuario));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> EditUsuario(Guid id)
        {
            var usuario = await service.GetById(id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUsuario(UsuarioService usuarioService)
        {
            try
            {
                var usuario = await service.Update(usuarioService);
                return RedirectToAction(nameof(GetAllUsuario));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuarioDelete = await service.GetById(id);
            return PartialView("DeleteUsuario", usuarioDelete);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUsuario(UsuarioService usuario)
        {
            try
            {
                await service.MarkDeleted(usuario);
                return RedirectToAction(nameof(GetAllUsuario));
            }
            catch
            {
                return View();
            }
        }
    }
}
