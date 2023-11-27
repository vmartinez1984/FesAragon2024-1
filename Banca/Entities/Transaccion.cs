using System;
using System.Collections.Generic;

namespace Banca.Entities;

public partial class Transaccion
{
    public int Id { get; set; }

    public decimal Cantidad { get; set; }

    public string Tipo { get; set; } = null!;

    public DateTime FechaDeRegistro { get; set; }

    public int AhorroId { get; set; }

    public virtual Ahorro Ahorro { get; set; } = null!;
}
