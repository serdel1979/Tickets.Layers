using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.DTO;

namespace Tickets.BLL.Services.Interfaces
{
    public interface IEquipoService
    {
        Task<List<EquipoDTO>> GetAll(string buscar);

        Task<EquipoDTO> Get(int id);

        Task<EquipoDTO> New(EquipoDTO model);

        Task<bool> Edit(EquipoDTO modelo);


        Task<EquipoDTO> GetByInventory(string numInventory);

        Task<bool> ExistInventory(string numInventory, int Id);

        Task<bool> Delete(int Id);
    }
}
