using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleFinanceiro.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceModuloMenu service;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IServiceModuloMenu service)
        {
            _logger = logger;
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllModuloMenuSuspenso()
        {
            var listaModulo = service.GetAllModuloMenuSuspenso();
            return PartialView("_MenuSuspensoPartial", listaModulo);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Cadastro() 
        { 
            return PartialView("_MenuDespesaReceita");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}