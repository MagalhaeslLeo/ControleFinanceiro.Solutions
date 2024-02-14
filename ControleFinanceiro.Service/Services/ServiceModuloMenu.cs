using AutoMapper;
using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.Repositories;
using ControleFinanceiro.Service.Interfaces;
using ControleFinanceiro.Service.ServiceEntity;

namespace ControleFinanceiro.Service.Services
{
    public class ServiceModuloMenu : IServiceModuloMenu
    {
        protected readonly IMapper mapper;
        protected readonly IModuloMenuRepository moduloMenuRepository;

        public ServiceModuloMenu(IMapper mapper, IModuloMenuRepository moduloMenuRepository)
        {
            this.mapper = mapper;
            this.moduloMenuRepository = moduloMenuRepository;
        }
        public async Task AddSave(ModuloMenuService moduloMenu)
        {
            try
            {
                var moduloMenuEntidade = mapper.Map<ModuloMenu>(moduloMenu);
                await moduloMenuRepository.AddSave(moduloMenuEntidade);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<IEnumerable<ModuloMenuService>> GetAll()
        {
            try
            {
                var entityModuloMenu = await moduloMenuRepository.GetAll();
                var ModuloMenuConvert = mapper.Map<IEnumerable<ModuloMenuService>>(entityModuloMenu);
                return ModuloMenuConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<ModuloMenuService> GetById (Guid id)
        {
            try
            {
                var moduloMenu = await moduloMenuRepository.GetById(id);
                var idConvert = mapper.Map<ModuloMenuService>(moduloMenu);
                return idConvert;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task MarkDeleted (ModuloMenuService moduloMenu)
        {
            try
            {
                var deletedModuloMenu = await moduloMenuRepository.GetById(moduloMenu.Id);
                deletedModuloMenu.IsDeleted= true;
                await moduloMenuRepository.MarkDeleted(deletedModuloMenu);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<ModuloMenuService> Update (ModuloMenuService moduloMenu)
        {
            try
            {
                var UpdateModuloMenu = mapper.Map<ModuloMenu>(moduloMenu);
                var UpdateConvert = await moduloMenuRepository.Update(UpdateModuloMenu);
                var ConvertModuloMenu = mapper.Map<ModuloMenuService>(UpdateConvert);
                return ConvertModuloMenu;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }
        
        public List<ModuloMenuService> GetAllModuloMenu(string modulo)
        {

            var menuModulo = moduloMenuRepository.GetAllModuloMenu(modulo);
            var moduloConvert = mapper.Map<List<ModuloMenuService>>(menuModulo);
            return moduloConvert;
        }
        public List<ModuloMenuSuspensoService> GetAllModuloMenuSuspenso()
        {
            var menuModulo = moduloMenuRepository.GetAllModuloMenuSuspenso();
            var moduloConvert = mapper.Map<List<ModuloMenuSuspensoService>>(menuModulo);
            return moduloConvert;
        }
    }
}
