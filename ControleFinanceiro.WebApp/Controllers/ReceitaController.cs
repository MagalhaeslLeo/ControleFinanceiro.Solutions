using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class ReceitaController : Controller
    {
        protected readonly IServiceReceita service;
        public ReceitaController(IServiceReceita service)
        {
            this.service = service;
        }
        public async Task<IActionResult> GetAllReceita()
        {
            var listaReceita = await service.GetAll();
            return View(listaReceita);
        }
        // GET: ReceitaController
        public IActionResult Index()
        {
            return View();
        }

        // GET: ReceitaController/Details/5
        public async Task<IActionResult> ConsultReceita(Guid id)
        {
            var consulta = await service.GetById(id);
            return PartialView(consulta);
        }

        // GET: ReceitaController/Create
        public ActionResult CreateReceita()
        {
            return View();
        }

        // POST: ReceitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateReceita(ReceitaService receitaService)
        {
            try
            {
                await service.AddSave(receitaService);
                return RedirectToAction(nameof(GetAllReceita));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceitaController/Edit/5
        public async Task<IActionResult> EditReceita(Guid id)
        {
            var receita = await service.GetById(id);
            return PartialView(receita);
        }

        // POST: ReceitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditReceita(ReceitaService receitaService)
        {
            try
            {
                var receita = await service.Update(receitaService);
                return RedirectToAction(nameof(GetAllReceita));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReceitaController/Delete/5
        public async Task<IActionResult> DeleteReceita(Guid id)
        {
            var receitaDelete = await service.GetById(id);
            return PartialView("DeleteReceita", receitaDelete);
        }

        // POST: ReceitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteReceita(ReceitaService receita)
        {
            try
            {
                await service.MarkDeleted(receita);
                return RedirectToAction(nameof(GetAllReceita));
            }
            catch
            {
                return View();
            }
        }
    }
}
