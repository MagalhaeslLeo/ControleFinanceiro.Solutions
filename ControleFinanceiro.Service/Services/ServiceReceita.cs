using AutoMapper;
using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;

namespace ControleFinanceiro.Service.Services
{
    public class ServiceReceita : IServiceReceita
    {
        protected readonly IMapper mapper;
        protected readonly IReceitaRepository receitaRepository;

        public ServiceReceita(IMapper mapper, IReceitaRepository receitaRepository)
        {
            this.mapper = mapper;
            this.receitaRepository = receitaRepository;
        }

        public async Task AddSave(ReceitaService receita)
        {
            try
            {
                var receitaEntidade = mapper.Map<Receita>(receita);
                await receitaRepository.AddSave(receitaEntidade);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<ReceitaService>> GetAll()
        {
            try
            {
                var entityReceita = await receitaRepository.GetAll();
                var ReceitaConvert = mapper.Map<IEnumerable<ReceitaService>>(entityReceita);
                return ReceitaConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ReceitaService> GetById(Guid id)
        {
            try
            {
                var receita = await receitaRepository.GetById(id);
                var idConvert = mapper.Map<ReceitaService>(receita);
                return idConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task MarkDeleted(ReceitaService receita)
        {
            try
            {
                var deletedReceita = await receitaRepository.GetById(receita.Id);
                deletedReceita.IsDeleted = true;
                await receitaRepository.MarkDeleted(deletedReceita);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<ReceitaService> Update(ReceitaService receita)
        {
            try
            {
                var UpdateReceita = mapper.Map<Receita>(receita);
                var UpdateConvert = await receitaRepository.Update(UpdateReceita);
                var ConvertReceita = mapper.Map<ReceitaService>(UpdateConvert);
                return ConvertReceita;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
