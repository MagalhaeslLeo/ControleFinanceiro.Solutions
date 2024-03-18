using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
            try
            {
                await service.AddSave(serviceDespesa);
                return Ok();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message, ex));
            }

        }

        [HttpPost("DeleteDespesa")]
        [Route("DeleteDespesa/{id:Guid}")]
        public async Task<IActionResult> DeleteDespesa([FromRoute] Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                  await service.MarkDeleted(Id);
                }
                
                return Ok();
            }
            catch(Exception ex) 
            {
               throw(new Exception(ex.Message, ex));
            }
        }

        [HttpGet]
        [Route("GetByIdDespesa")]
        public async Task<IActionResult> GetByIdDespesa(Guid Id)
        {
            var despesa = await service.GetById(Id);
            return Ok(despesa);
        }
    }
}
