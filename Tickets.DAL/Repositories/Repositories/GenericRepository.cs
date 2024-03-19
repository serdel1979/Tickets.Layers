using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.DBContext;
using Tickets.DAL.Repositories.Interfaces;

namespace Tickets.DAL.Repositories.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly TicketsDbContext _dbContext;

        public GenericRepository(TicketsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(TModel modelo)
        {
            try
            {

                _dbContext.Set<TModel>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<TModel> Edit(TModel model)
        {
            try
            {

                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return model;

            }
            catch
            {
                throw;
            }
        }

        public IQueryable<TModel> GetAll(Expression<Func<TModel, bool>>? filter = null)
        {
            IQueryable<TModel> request = (filter == null) ?
            _dbContext.Set<TModel>() :
                _dbContext.Set<TModel>().Where(filter);

            return request;
        }

        public async Task<TModel> GetById(int Id)
        {
            return await _dbContext.Set<TModel>().FindAsync(Id);
        }

        public async Task<TModel> New(TModel model)
        {
            try
            {

                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;

            }
            catch
            {
                throw;
            }
        }
    }
}
