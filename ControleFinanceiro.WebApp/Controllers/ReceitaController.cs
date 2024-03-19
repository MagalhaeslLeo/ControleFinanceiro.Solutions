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
        public IActionResult GetAllReceita()
        {
            return View("GetAllReceita");
        }
        //public async Task<IActionResult> GetAllReceita()
        //{
        //    var listaReceita = await service.GetAll();
        //    return View(listaReceita);
        //}
        // GET: ReceitaController
        public IActionResult Index()
        {
            return View();
        }

        // GET: ReceitaController/Details/5
        public IActionResult ConsultReceita(Guid id)
        {
           ViewBag.Id = id;
           ViewBag.Action = "Consult";
           return View("CreateReceita");
        }

        // GET: ReceitaController/Create
        public ActionResult CreateReceita()
        {
            return View("CreateReceita");
        }

        // GET: ReceitaController/Edit/5
        public IActionResult EditReceita(Guid id)
        {
            ViewBag.Id = id;
            ViewBag.Action = "Edit";
            return View("CreateReceita");
        }
    }
}
