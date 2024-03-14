using System;
using System.Collections.Generic;

namespace Tickets.Model;

public partial class Solicitud
{
    public int Id { get; set; }

    public string UsuarioId { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Departamento { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Equipo { get; set; } = null!;

    public string? UrlImagen { get; set; }

    public DateTime Fecha { get; set; }

    public string EstadoActual { get; set; } = null!;

    public int ContadorMensajes { get; set; }

    public virtual ICollection<Estado> Estados { get; set; } = new List<Estado>();

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();
}
