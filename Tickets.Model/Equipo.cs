using System;
using System.Collections.Generic;

namespace Tickets.Model;

public partial class Equipo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? UsuarioId { get; set; }

    public string? UrlImagen { get; set; }

    public string? Inventario { get; set; }

    public string? Serie { get; set; }

    public string? Comentario { get; set; }

    public virtual AspNetUser? Usuario { get; set; }
}
