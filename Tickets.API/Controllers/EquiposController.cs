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



        [HttpGet("GetAll/{find?}")]
        public async Task<IActionResult> GetAll(string find = "todos")
        {

            var response = new ResponseDTO<List<EquipoDTO>>();

            try
            {
                response.Result = await _equipoService.GetAll(find);
                response.IsSuccess = true;
            }
            catch (Exception ex) { 
                
                response.IsSuccess = false;
                response.Message = ex.Message;

            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> New(EquipoDTO equipment)
        {
            var response = new ResponseDTO<EquipoDTO>();
            try
            {
                response.IsSuccess = true;
                response.Result = await _equipoService.New(equipment);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }



        [HttpGet("GetByInventory/{Inventory}")]
        public async Task<IActionResult> GetByInventory(string Inventory)
        {
            var response = new ResponseDTO<EquipoDTO>();
            try
            {
                response.IsSuccess = true;
                response.Result = await _equipoService.GetByInventory(Inventory);

            }catch (Exception ex)
            {
                response.IsSuccess=false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }




        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Put(EquipoDTO equipoDto)
        {
            var response = new ResponseDTO<EquipoDTO>();
            try
            {
                response.IsSuccess = true;
                response.Result = await _equipoService.Edit(equipoDto);

 
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message; 
            }
            return Ok(response);
        }


        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.IsSuccess = await _equipoService.Delete(Id);
                response.Result=true;
            }
            catch (Exception ex)
            {
                response.Result=false;
                response.Message=ex.Message;
            }
            return Ok(response);
        }


    }
}
