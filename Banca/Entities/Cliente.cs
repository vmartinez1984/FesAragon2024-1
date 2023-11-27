using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Banca.Entities;

public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    [Display(Name = "Primer apellido")]
    public string PrimerApellido { get; set; } = null!;

    [Display(Name = "Segundo apellido")]
    public string? SegundoApellido { get; set; }

    public string Rfc { get; set; } = null!;

    [Display(Name = "Calle y número")]
    public string CalleYnumero { get; set; } = null!;


    public string Colonia { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Municipio { get; set; } = null!;

    [Display(Name = "Registro")]
    public DateTime FechaDeRegistro { get; set; }= DateTime.Now;

    public bool EstaActivo { get; set; } = true;

    public virtual Ahorro? Ahorro { get; set; }
}
