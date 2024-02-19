using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bolsaEmpleoBack.Models;

public partial class Ciudadano
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "numeric(18, 0)")]
    public long CiudadanoId { get; set; }

    [ForeignKey("TipoDocumentoId")]
    [Column(TypeName = "numeric(18, 0)")]
    public long TipoDocumentoId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Cedula { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Nombres { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Apellidos { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateOnly FechaNacimiento { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Profesion { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    public long AspiracionSalarial { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string CorreoElectronico { get; set; } = null!;

    public virtual TipoDocumento TipoDocumento { get; set; } = null!;

    public virtual ICollection<VacanteOfertadum> VacanteOfertada { get; set; } = new List<VacanteOfertadum>();
}
