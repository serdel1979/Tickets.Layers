using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : class
    {

        IQueryable<TModel> GetAll(Expression<Func<TModel, bool>>? filter = null);

        Task<TModel> GetById(int Id);

        Task<TModel> New(TModel model);

        Task<TModel> Edit(TModel model);

        Task<bool> Delete(TModel model);

    }
}
