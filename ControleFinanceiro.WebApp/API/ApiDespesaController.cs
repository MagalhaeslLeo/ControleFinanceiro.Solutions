using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using ControleFinanceiro.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                if (serviceDespesa.Id != Guid.Empty || serviceDespesa.Id != null)
                {
                    await service.Update(serviceDespesa);
                    return Ok();
                }
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
                var despesa = await service.GetById(Id);
                if (despesa != null)
                {
                  await service.MarkDeleted(despesa);
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
