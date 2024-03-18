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
            try
            {
                return await _equipoService.GetAll(buscar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
