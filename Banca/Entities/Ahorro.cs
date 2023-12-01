using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banca.Entities;

public partial class Ahorro
{
    public int Id { get; set; }

    public decimal Balance { get; set; } = 0;

    [ForeignKey(nameof(Cliente))]
    public int ClienteId { get; set; }

    public string? Nota { get; set; }

    public DateTime FechaDeRegistro { get; set; } = DateTime.Now;

    public bool EstaActivo { get; set; } = true;

    public virtual Cliente IdNavigation { get; set; }

    public virtual ICollection<Transaccion> Transaccions { get; set; } = new List<Transaccion>();
}
