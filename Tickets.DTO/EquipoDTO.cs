using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.DTO
{
    public class EquipoDTO
    {
            public int Id { get; set; }
            [Required]
            [StringLength(50)]
            public string Nombre { get; set; }
            [StringLength(450)]
            public string UsuarioId { get; set; }
            public string UrlImagen { get; set; }
            [StringLength(100)]
            public string Inventario { get; set; }
            [StringLength(100)]
            public string Serie { get; set; }
            [StringLength(250)]
            public string Comentario { get; set; }

    }
}
