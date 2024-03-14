using System;
using System.Collections.Generic;

namespace Tickets.Model;

public partial class Estado
{
    public int Id { get; set; }

    public string EstadoActual { get; set; } = null!;

    public string Comentario { get; set; } = null!;

    public int SolicitudId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Solicitud Solicitud { get; set; } = null!;
}
