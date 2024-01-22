using AutoMapper;
using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;
using System.Security.Cryptography.X509Certificates;

namespace ControleFinanceiro.Service.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        protected readonly IMapper mapper;
        protected readonly IUsuarioRepository usuarioRepository;
        public ServiceUsuario(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            this.mapper = mapper;
            this.usuarioRepository = usuarioRepository;
        }
        public async Task AddSave(UsuarioService usuario)
        {
            try
            {
                var usuarioEntidade = mapper.Map<Usuario>(usuario);
                await usuarioRepository.AddSave(usuarioEntidade);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<UsuarioService>> GetAll()
        {
            try
            {
                var entityUsuario = await usuarioRepository.GetAll();
                var usuarioConvert = mapper.Map<IEnumerable<UsuarioService>>(entityUsuario);
                return usuarioConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<UsuarioService> GetById(Guid id)
        {
            try
            {
                var usuario = await usuarioRepository.GetById(id);
                var idConvert = mapper.Map<UsuarioService>(usuario);
                return idConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task MarkDeleted(UsuarioService usuario)
        {
            try
            {
                var deletedUsuario = await usuarioRepository.GetById(usuario.Id);
                deletedUsuario.IsDeleted= true;
                await usuarioRepository.MarkDeleted(deletedUsuario);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<UsuarioService> Update(UsuarioService usuario)
        {
            try
            {
                var UpdateUsuario = mapper.Map<Usuario>(usuario);
                var UpdateConvert = await usuarioRepository.Update(UpdateUsuario);
                var ConvertUsuario = mapper.Map<UsuarioService>(UpdateConvert);
                return ConvertUsuario;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
    }
}
