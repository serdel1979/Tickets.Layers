using System;
using System.Collections.Generic;

namespace Tickets.Model;

public partial class Mensaje
{
    public int Id { get; set; }

    public int SolicitudId { get; set; }

    public string Usuario { get; set; } = null!;

    public string TxtMensaje { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public virtual Solicitud Solicitud { get; set; } = null!;
}
