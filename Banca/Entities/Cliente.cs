using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banca.Entities;

public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Anote el nombre")]
    public string Nombres { get; set; } = null!;

    [Display(Name = "Primer apellido")]
    [Required(ErrorMessage = "Anote el primer apellido")]
    public string PrimerApellido { get; set; } = null!;

    [Display(Name = "Segundo apellido")]
    public string SegundoApellido { get; set; }

    [Required(ErrorMessage = "Anote el RFC")]
    public string Rfc { get; set; } = null!;

    [Display(Name = "Calle y número")]
    [Required(ErrorMessage = "Anote la calle y número")]
    public string CalleYnumero { get; set; } = null!;

    [MaxLength(5)]
    [Required(ErrorMessage = "Anote el código postal")]
    public string CodigoPostal { get; set; }

    [Required(ErrorMessage = "Anote el nombre")]
    public string Colonia { get; set; } = null!;

    [Required(ErrorMessage = "Anote el estado")]
    public string Estado { get; set; } = null!;

    [Required(ErrorMessage = "Anote el municipio")]
    public string Municipio { get; set; } = null!;

    [Display(Name = "Registro")]
    public DateTime FechaDeRegistro { get; set; }= DateTime.Now;

    public bool EstaActivo { get; set; } = true;

    public virtual List<Ahorro> Ahorros { get; set; }

    [NotMapped]
    public string NombreCompleto { get
        {
            return $"{Nombres} {PrimerApellido} {SegundoApellido}";
        }
    }
}
