using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.BLL.Services.Interfaces;
using Tickets.DAL.Repositories.Interfaces;
using Tickets.DTO;
using Tickets.Model;

namespace Tickets.BLL.Services.Implements
{
    public class EquipoService : IEquipoService
    {
        private readonly IGenericRepository<Equipo> _genericRepository;
        private readonly IMapper _mapper;

        public EquipoService(IGenericRepository<Equipo> genericRepository, IMapper mapper)
        {
            this._genericRepository = genericRepository;
            this._mapper = mapper;
        }


        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Edit(EquipoDTO modelo)
        {
            throw new NotImplementedException();
        }

        public Task<EquipoDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EquipoDTO>> GetAll(string buscar)
        {
            try
            {
                // Verificar si buscar es "todos" para devolver todos los equipos
                if (buscar != null && buscar.ToLower() == "todos")
                {
                    var equipos = await _genericRepository.GetAll().ToListAsync();
                    var equipoDTOs = _mapper.Map<List<EquipoDTO>>(equipos);
                    return equipoDTOs;
                }
                else
                {
                    // Aplicar filtro por nombre si buscar no es "todos"
                    var query = _genericRepository.GetAll(p => p.Nombre != null && p.Nombre.ToLower().Contains(buscar.ToLower()));
                    var equipos = await query.ToListAsync();
                    var equipoDTOs = _mapper.Map<List<EquipoDTO>>(equipos);
                    return equipoDTOs;
                }
            }
            catch (Exception ex)
            {
                // No es necesario capturar y reenviar la excepción aquí
                throw;
            }
        }



        public Task<EquipoDTO> New(EquipoDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
