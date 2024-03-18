using ControleFinanceiro.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiReceitaController : ControllerBase
    {
        protected readonly IServiceReceita serviceReceita;
        public ApiReceitaController(IServiceReceita serviceReceita)
        {
            this.serviceReceita = serviceReceita;
        }
        [HttpPost]
        [Route("GetReceita")]
        public async Task<IActionResult> GetReceita()
        {
            var listaReceita = await serviceReceita.GetAll();
            return Ok(listaReceita);
        }
    }
}
