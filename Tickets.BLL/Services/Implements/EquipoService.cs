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


        public async Task<bool> Delete(int Id)
        {
            try
            {
                var existingEquipment = await _genericRepository.GetById(Id);

                if (existingEquipment == null)
                {
                    throw new Exception("El equipo no existe.");
                }

                return await _genericRepository.Delete(existingEquipment);

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<EquipoDTO> Edit(EquipoDTO model)
        {

            var existingEquipment = await _genericRepository.GetById(model.Id);

            if (existingEquipment == null)
            {
                throw new Exception("El equipo no existe.");
            }

            var inventoryEquipment = await _genericRepository.GetAll(p=>p.Inventario == model.Inventario).FirstOrDefaultAsync();

            if (inventoryEquipment != null && inventoryEquipment.Id != existingEquipment.Id)
            {
                throw new Exception($"El inventario {model.Inventario} pertenece a otro equipo!!!");
            }

            existingEquipment.Nombre = model.Nombre;
            existingEquipment.UsuarioId = model.UsuarioId;
            existingEquipment.UrlImagen = model.UrlImagen;
            existingEquipment.Inventario = model.Inventario;
            existingEquipment.Serie = model.Serie;
            existingEquipment.Comentario = model.Comentario;


            try
            {
                return _mapper.Map<EquipoDTO>(await _genericRepository.Edit(existingEquipment));
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"{ex.Message}");

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
                throw new Exception($"{ex.Message}");
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
                throw new Exception($"{ex.Message}");
            }
        }



        public async Task<EquipoDTO> New(EquipoDTO model)
        {
            try
            {
                var query = _genericRepository.GetAll(p => p.Inventario != null && p.Inventario == model.Inventario);
                var equipment = await query.FirstOrDefaultAsync();
                if(equipment != null)
                {
                    throw new Exception($"Ya existe un equipo con inventario {model.Inventario}");
                }
                equipment = _mapper.Map<Equipo>(model);
                var response = await _genericRepository.New(equipment);
                return _mapper.Map<EquipoDTO>(response);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
