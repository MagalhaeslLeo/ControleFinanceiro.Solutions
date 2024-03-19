using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
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
        [HttpPost]
        [Route("AdicionarReceita")]
        public async Task<IActionResult> AdicionarReceita([FromBody] ReceitaService receitaService)
        {
            try
            {
                await serviceReceita.AddSave(receitaService);
                return Ok();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message, ex));
            }
        }
        [HttpPost("DeleteReceita")]
        [Route("DeleteReceita/{id:Guid}")]
        public async Task<IActionResult> DeleteReceita([FromRoute] Guid Id)
        {
            try
            {
                if (Id != Guid.Empty)
                {
                    await serviceReceita.MarkDeleted(Id);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message, ex));
            }
        }
        [HttpGet]
        [Route("GetByIdReceita")]
        public async Task<IActionResult> GetByIdReceita(Guid Id)
        {
            var receita = await serviceReceita.GetById(Id);
            return Ok(receita);
        }
    }
}
