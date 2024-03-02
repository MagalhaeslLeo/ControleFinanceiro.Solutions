using ControleFinanceiro.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.WebApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDespesaController : ControllerBase
    {
        protected readonly IServiceDespesa service;

        public ApiDespesaController(IServiceDespesa service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("GetDespesa")]
        public async Task<IActionResult> GetDespesa()
        {
            var listaDespesa = await service.GetAll();
            return Ok(listaDespesa);
        }
    }
}
