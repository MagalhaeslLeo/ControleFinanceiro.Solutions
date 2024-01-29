using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class DemonstrativoController : Controller
    {
        protected readonly IServiceDemonstrativoFinanceiro service;
        public DemonstrativoController(IServiceDemonstrativoFinanceiro service)
        {
            this.service = service;
        }
        public async Task<IActionResult> GetAllDemonstrativo()
        {
            var listaDemonstrativo = await service.GetAll();
            return View(listaDemonstrativo);
        }
        // GET: DemonstrativoController
        public IActionResult Index()
        {
            return View();
        }
        // GET: DemonstrativoController/Details/5
        public async Task<IActionResult> ConsultDemonstrativo(Guid id)
        {
            var demonstrativo = await service.GetById(id);
            return View(demonstrativo);
        }
        // GET: DemonstrativoController/Create
        public ActionResult CreateDemonstrativo()
        {
            return View();
        }
        // POST: DemonstrativoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDemonstrativo(DemonstrativoFinanceiroService demonstrativoFinanceiroService)
        {
            try
            {
                await service.AddSave(demonstrativoFinanceiroService);
                return RedirectToAction(nameof(GetAllDemonstrativo));
            }
            catch
            {
                return View();
            }
        }
        // GET: DemonstrativoController/Edit/5
        public async Task<IActionResult> EditDemonstrativo(Guid id)
        {
            var demonstrativoFinanceiro = await service.GetById(id);
            return View(demonstrativoFinanceiro);
        }
        // POST: DemonstrativoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDemonstrativo(DemonstrativoFinanceiroService demonstrativoFinanceiroService)
        {
            try
            {
                var demonstrativoFinanceiro = await service.Update(demonstrativoFinanceiroService);
                return RedirectToAction(nameof(GetAllDemonstrativo));
            }
            catch
            {
                return View();
            }
        }
        // GET: DemonstrativoController/Delete/5
        public async Task<IActionResult> DeleteDemonstrativo(Guid id)
        {
            var demonstrativoFinanceiroDelete = await service.GetById(id);
            return View("DeleteDemonstrativo", demonstrativoFinanceiroDelete);
        }
        // POST: DemonstrativoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDemonstrativo(DemonstrativoFinanceiroService demonstrativoFinanceiro)
        {
            try
            {
                await service.MarkDeleted(demonstrativoFinanceiro);
                return RedirectToAction(nameof(GetAllDemonstrativo));
            }
            catch
            {
                return View();
            }
        }
    }
}
