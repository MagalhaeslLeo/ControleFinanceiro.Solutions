
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class ModuloMenuController : Controller
    {
        protected readonly IServiceModuloMenu service;
        public ModuloMenuController(IServiceModuloMenu service)
        {
            this.service = service;
        }

        public async Task<IActionResult> GetAllModuloMenu()
        {
            var listaModuloMenu = await service.GetAll();
            return View(listaModuloMenu);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ConsultModuloMenu(Guid id)
        {
            var consulta = await service.GetById(id);
            return View(consulta);
        }
        public ActionResult CreateModuloMenu()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateModuloMenu(ModuloMenuService moduloMenuService)
        {
            try
            {
                await service.AddSave(moduloMenuService);
                return RedirectToAction(nameof(GetAllModuloMenu));
            }
            catch
            {
                return View();
            }
        }
        public async Task<IActionResult> EditModuloMenu(Guid id)
        {
            var moduloMenu = await service.GetById(id);
            return View(moduloMenu);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditModuloMenu(ModuloMenuService moduloMenuService)
        {
            try
            {
                var moduloMenu = await service.Update(moduloMenuService);
                return RedirectToAction(nameof(GetAllModuloMenu));
            }
            catch
            { 
                return View();
            }
        }
        public async Task<IActionResult> DeleteModuloMenu(Guid id)
        {
            var moduloMenuDelete = await service.GetById(id);
            return View(moduloMenuDelete);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteModuloMenu(ModuloMenuService moduloMenu)
        {
            try
            {
                await service.MarkDeleted(moduloMenu);
                return RedirectToAction(nameof(GetAllModuloMenu));
            }
            catch
            {
                return View();
            }
        }
    }
}
