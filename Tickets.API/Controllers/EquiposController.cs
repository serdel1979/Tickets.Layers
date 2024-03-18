using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tickets.BLL.Services.Implements;
using Tickets.BLL.Services.Interfaces;
using Tickets.DAL.Repositories.Interfaces;
using Tickets.DAL.Repositories.Repositories;
using Tickets.DTO;
using Tickets.Model;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquiposController: ControllerBase
    {
        private readonly IEquipoService _equipoService;

        public EquiposController(IEquipoService equipoService)
        {
            this._equipoService = equipoService;
        }



        [HttpGet("GetAll/{buscar?}")]
        public async Task<List<EquipoDTO>> GetAll(string buscar = "todos")
        {
             return await _equipoService.GetAll(buscar);
        }

        [HttpPut("{Id:int}")]
      //  [Authorize(Policy = "EsAdmin")]
        public async Task<ActionResult> Put(EquipoDTO equipoDto, int Id)
        {

            var equipment = await _equipoService.Get(Id);
            if (equipment == null)
            {
                return NotFound();
            }

            if (await _equipoService.ExistInventory(equipoDto.Inventario, Id))
            {
                return StatusCode(400, $"Ya existe el inventario {equipoDto.Inventario}");
            }

            await _equipoService.Edit(equipoDto);
            
            return NoContent();
        }



    }
}
