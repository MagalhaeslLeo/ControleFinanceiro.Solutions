using AutoMapper;
using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Service.ServiceEntity;

namespace ControleFinanceiro.Service.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Despesa, DespesaService>().ReverseMap();
            CreateMap<Receita, ReceitaService>().ReverseMap();
        }
    }
}
