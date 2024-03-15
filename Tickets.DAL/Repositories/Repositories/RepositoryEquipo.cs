using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DAL.DBContext;
using Tickets.DAL.Repositories.Interfaces;
using Tickets.Model;

namespace Tickets.DAL.Repositories.Repositories
{
    public class RepositoryEquipo : IRepositoryEquipo
    {
        private readonly TicketsDbContext _dbContext;

        public RepositoryEquipo(TicketsDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task DeletEquipo(Equipo equipo)
        {
            try
            {
                _dbContext.Equipos.Update(equipo);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task EditEquipo(Equipo equipo)
        {
            try
            {
                _dbContext.Equipos.Update(equipo);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Equipo> GetEquipo(int Id)
        {
            try
            {
                return await _dbContext.Equipos.Where(eq=>eq.Id == Id).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Equipo>> GetEquipos(Equipo equipo)
        {
            try
            {
                return await _dbContext.Equipos.ToListAsync();
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<Equipo> SaveEquipo(Equipo equipo)
        {
            try
            {
                _dbContext.Equipos.Add(equipo);
                await _dbContext.SaveChangesAsync();
                return (equipo);
            }
            catch
            {
                throw;
            }

        }
    }
}
