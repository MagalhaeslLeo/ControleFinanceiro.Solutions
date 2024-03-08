using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
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
        [HttpPost]
        [Route("AdicionarDespesa")]
        public async Task<IActionResult> AdicionarDespesa([FromBody] DespesaService serviceDespesa)
        {
            await service.AddSave(serviceDespesa);
            return Ok();
        }
    }
}
