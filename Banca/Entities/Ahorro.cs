using System;
using System.Collections.Generic;

namespace Banca.Entities;

public partial class Ahorro
{
    public int Id { get; set; }

    public decimal Balance { get; set; }

    public int ClienteId { get; set; }

    public string? Nota { get; set; }

    public DateTime FechaDeRegistro { get; set; }

    public bool EstaActivo { get; set; }

    public virtual Cliente IdNavigation { get; set; } = null!;

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
