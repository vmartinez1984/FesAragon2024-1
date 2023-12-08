using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banca.Entities;

public partial class Transaccion
{
    public int Id { get; set; }

    [Range(0, int.MaxValue)]
    [DataType(DataType.Currency)]
    public decimal Cantidad { get; set; }

    public string Tipo { get; set; } = null!;

    [Display(Name = "Fecha de registro")]
    public DateTime FechaDeRegistro { get; set; }

    public int AhorroId { get; set; }

    public virtual Ahorro Ahorro { get; set; } = null!;
}

public class Tipo
{
    public const string Deposito = "Deposito";
    public const string Retiro = "Retiro";
}
