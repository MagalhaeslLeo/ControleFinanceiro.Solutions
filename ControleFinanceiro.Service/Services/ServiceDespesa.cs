using AutoMapper;
using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Service.Services
{
    public class ServiceDespesa : IServiceDespesa
    {
        protected readonly IMapper mapper;
        protected readonly IDespesaRepository despesaRepository;

        public ServiceDespesa(IMapper mapper, IDespesaRepository despesaRepository)
        {
            this.mapper = mapper;
            this.despesaRepository = despesaRepository;
        }
        public async Task AddSave(DespesaService despesa)
        {
            try
            {
                var despesaEntidade = mapper.Map<Despesa>(despesa);
                await despesaRepository.AddSave(despesaEntidade);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<IEnumerable<DespesaService>> GetAll()
        {
            try
            {
                var entityDespesa = await despesaRepository.GetAll();
                var DespesaConvert = mapper.Map<IEnumerable<DespesaService>>(entityDespesa);
                return DespesaConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<DespesaService> GetById(Guid id)
        {
            try
            {
                var despesa = await despesaRepository.GetById(id);
                var idConvert = mapper.Map<DespesaService>(despesa);
                return idConvert;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task MarkDeleted(DespesaService despesa)
        {
            try
            {
                var deletedDespesa = await despesaRepository.GetById(despesa.Id);
                deletedDespesa.IsDeleted = true;
                await despesaRepository.MarkDeleted(deletedDespesa);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<DespesaService> Update(DespesaService despesa)
        {
            try
            {
                var UpdateDespesa = mapper.Map<Despesa>(despesa);
                var UpdateConvert = await despesaRepository.Update(UpdateDespesa);
                var ConvertDespesa = mapper.Map<DespesaService>(UpdateConvert);
                return ConvertDespesa;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
