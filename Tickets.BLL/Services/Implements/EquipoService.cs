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

        public async Task<bool> Edit(EquipoDTO model)
        {

            var existingEquipment = await _genericRepository.GetById(model.Id);

            if (existingEquipment == null)
            {
                return false; 
            }
            //var query = _genericRepository.GetAll(p => p.Inventario == model.Inventario && p.Id != model.Id);
            //var equipment = await query.FirstOrDefaultAsync();
            //if(equipment != null)
            //{
            //    return false;
            //}

            existingEquipment.Nombre = model.Nombre;
            existingEquipment.UsuarioId = model.UsuarioId;
            existingEquipment.UrlImagen = model.UrlImagen;
            existingEquipment.Inventario = model.Inventario;
            existingEquipment.Serie = model.Serie;
            existingEquipment.Comentario = model.Comentario;


            try
            {
                await _genericRepository.Edit(existingEquipment);
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Manejar la excepción de actualización de base de datos
                return false;
            }

        }

        public async Task<EquipoDTO> Get(int id)
        {
            var equipment = await _genericRepository.GetById(id);
            return _mapper.Map<EquipoDTO>(equipment);
        }



        public async Task<EquipoDTO> GetByInventory(string numInventory)
        {
            try
            {
                    var query = _genericRepository.GetAll(p => p.Inventario != null && p.Inventario == numInventory);
                    var equipment = await query.FirstOrDefaultAsync();
                    var equipoDTO = _mapper.Map<EquipoDTO>(equipment);
                    return equipoDTO;
                
            }
            catch (Exception ex)
            {
                // No es necesario capturar y reenviar la excepción aquí
                throw;
            }
        }

        public async Task<bool> ExistInventory(string numInventory, int Id)
        {
            try
            {
                var query = _genericRepository.GetAll(p => p.Inventario == numInventory && p.Id != Id);
                var equipment = await query.FirstOrDefaultAsync();
                return equipment != null;

            }
            catch (Exception ex)
            {
                // No es necesario capturar y reenviar la excepción aquí
                throw;
            }
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
