using AutoMapper;
using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;

namespace ControleFinanceiro.Service.Services
{
    public class ServiceDemonstrativoFinanceiro : IServiceDemonstrativoFinanceiro
    {
        protected readonly IMapper mapper;
        protected readonly IDemonstrativoFinanceiroRepository demonstrativoFinanceiroRepository;
        public ServiceDemonstrativoFinanceiro(IMapper mapper, IDemonstrativoFinanceiroRepository demonstrativoFinanceiroRepository)
        {
            this.mapper = mapper;
            this.demonstrativoFinanceiroRepository = demonstrativoFinanceiroRepository;
        }
        public async Task AddSave(DemonstrativoFinanceiroService demonstrativoFinanceiro)
        {
            try
            {
                var demonstrativoFinanceiroEntidade = mapper.Map<DemonstrativoFinanceiro>(demonstrativoFinanceiro);
                await demonstrativoFinanceiroRepository.AddSave(demonstrativoFinanceiroEntidade);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<DemonstrativoFinanceiroService>> GetAll()
        {
            try
            {
                var entityDemonstrativoFinanceiro = await demonstrativoFinanceiroRepository.GetAll();
                var DemonstrativoFinanceiroConvert = mapper.Map<IEnumerable<DemonstrativoFinanceiroService>>(entityDemonstrativoFinanceiro);
                return DemonstrativoFinanceiroConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<DemonstrativoFinanceiroService> GetById(Guid id)
        {
            try
            {
                var demonstrativoFinanceiro = await demonstrativoFinanceiroRepository.GetById(id);
                var idConvert = mapper.Map<DemonstrativoFinanceiroService>(demonstrativoFinanceiro);
                return idConvert;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task MarkDeleted(DemonstrativoFinanceiroService demonstrativoFinanceiro)
        {
            try
            {
                var deletedDemonstrativo = await demonstrativoFinanceiroRepository.GetById(demonstrativoFinanceiro.Id);
                deletedDemonstrativo.IsDeleted = true;
                await demonstrativoFinanceiroRepository.MarkDeleted(deletedDemonstrativo);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<DemonstrativoFinanceiroService> Update(DemonstrativoFinanceiroService demonstrativoFinanceiro)
        {
            try
            {
                var UpdateDemonstrativo = mapper.Map<DemonstrativoFinanceiro>(demonstrativoFinanceiro);
                var UpdateConvert = await demonstrativoFinanceiroRepository.Update(UpdateDemonstrativo);
                var ConvertDemonstrativo = mapper.Map<DemonstrativoFinanceiroService>(UpdateConvert);
                return ConvertDemonstrativo;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
   
}
