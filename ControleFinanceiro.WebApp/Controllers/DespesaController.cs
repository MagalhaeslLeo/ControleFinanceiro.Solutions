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
        public IActionResult GetAllDespesa(string adicionarNull)
        {
            if (string.IsNullOrEmpty(adicionarNull))
            {
                ViewBag.Layout = "_Layout";
                return View("GetAllDespesa");
            }
            ViewBag.Layout = null;
            return View("GetAllDespesa");
        }

        // GET: DespesaController
        public IActionResult Index()
        {
            return View();
        }

        // GET: DespesaController/Details/5
        public IActionResult ConsultDespesa(Guid id)
        {
            ViewBag.Id = id;
            ViewBag.Action = "Consult";
            return View("_ConsultDespesa");
        }

        // GET: DespesaController/Create
        public IActionResult CreateDespesa()
        {
            return PartialView("_CreateDespesa");
        }

        public IActionResult EditDespesa(Guid Id)
        {
            ViewBag.Id = Id;
            ViewBag.Action = "Edit";
            return View("_CreateDespesa");
        }

    }
}
