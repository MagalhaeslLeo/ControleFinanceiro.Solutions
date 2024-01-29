using ControleFinanceiro.Domain.Entidades;
using ControleFinanceiro.Domain.Interfaces;
using ControleFinanceiro.Repository.ContextDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.Repositories
{
    public class DemonstrativoFinanceiroRepository : RepositoryBase<DemonstrativoFinanceiro>, IDemonstrativoFinanceiroRepository
    {
        public DemonstrativoFinanceiroRepository(Context context) : base(context)  { }
    }
}
