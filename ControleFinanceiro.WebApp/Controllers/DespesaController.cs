using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class DespesaController : Controller
    {
        protected readonly IServiceDespesa service;
        public DespesaController(IServiceDespesa service)
        {
            this.service = service;
        }
        //public async Task<IActionResult> GetAllDespesa()
        //{
        //    var listaDespesa = await service.GetAll();
        //    return Ok(listaDespesa);
        //}

        public IActionResult GetAllDespesa()
        {
            return View("GetAllDespesa");
        }

        // GET: DespesaController
        public IActionResult Index()
        {
            return View();
        }

        // GET: DespesaController/Details/5
        public async Task<IActionResult> ConsultDespesa(Guid id)
        {
            var consulta = await service.GetById(id);
            return PartialView(consulta);
        }

        // GET: DespesaController/Create
        public IActionResult CreateDespesa()
        {
            return View("CreateDespesa");
        }

        public IActionResult EditDespesa(Guid Id)
        {
            ViewBag.Id = Id;
            ViewBag.Action = "Edit";
            return View("CreateDespesa");
        }

        // POST: DespesaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDespesa(DespesaService despesaService)
        {
            try
            {
                var despesa = await service.Update(despesaService);
                return RedirectToAction(nameof(GetAllDespesa));
            }
            catch
            {
                return View();
            }
        }

        // GET: DespesaController/Delete/5
        //public async Task<IActionResult> DeleteDespesa(Guid id)
        //{
        //    var despesaDelete = await service.GetById(id);
        //    return PartialView("DeleteDespesa", despesaDelete);
        //}

        // POST: DespesaController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteDespesa(DespesaService despesa)
        //{
        //    try
        //    {
        //        await service.MarkDeleted(despesa);
        //        return RedirectToAction(nameof(GetAllDespesa));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
