using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Model;

namespace Tickets.DAL.Repositories.Interfaces
{
    public interface IRepositoryEquipo
    {
        Task<List<Equipo>> GetEquipos(Equipo equipo);

        Task<Equipo> GetEquipo(int Id);
        Task<Equipo> SaveEquipo(Equipo equipo);

        Task EditEquipo(Equipo equipoDto);

        Task DeletEquipo(Equipo equipoDto);
    }
}
