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



        [HttpGet("GetByInventory/{Inventory}")]
        public async Task<EquipoDTO> GetByInventory(string Inventory)
        {
            return await _equipoService.GetByInventory(Inventory);
        }




        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Put(EquipoDTO equipoDto)
        {
            try
            {
                var equipoActualizado = await _equipoService.Edit(equipoDto);
                return Ok(equipoActualizado); // Devuelve 200 OK con el objeto actualizado
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); // Devuelve un mensaje de error en formato JSON
            }
        }




    }
}
