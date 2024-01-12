using ControleFinanceiro.Domain.Guids;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace ControleFinanceiro.Repository.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityGuid
    {
        protected readonly Context context;
        protected DbSet<T> dbset;

        public RepositoryBase(Context context)
        {
            this.context = context;
            this.dbset = context.Set<T>();
        }
        public async Task AddSave(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                {
                    entity.Id = Guid.NewGuid();
                }
                dbset.Add(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }

        }

        public async Task<T> GetById(Guid id)
        {
            try
            {
               return await dbset.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message, ex);
            }
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await dbset.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        
        }

        public async Task MarkDeleted(T entity)
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                var ItemUpdate = await dbset.SingleOrDefaultAsync(x => x.Id.Equals(entity.Id));
             if (ItemUpdate == null)
                {
                    return null;
                }
                else
                {
                    context.Entry(ItemUpdate).CurrentValues.SetValues(entity);
                    await context.SaveChangesAsync();
                }
                return entity;
             
            }
            catch (Exception ex)
            { 

                throw new Exception(ex.Message, ex);
            }
        }
      
    }
}
