using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace bolsaEmpleoBack.Models;

public partial class VacanteOfertadum
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "numeric(18, 0)")]
    public long VacanteOfertadaId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Codigo { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Cargo { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "varchar(50)")]
    public string Empresa { get; set; } = null!;

    [Column(TypeName = "numeric(18, 0)")]
    public long Salario { get; set; }

    [Column(TypeName = "numeric(18, 0)")]
    public long? CiudadanoId { get; set; }

    [ForeignKey("CiudadanoId")]
    public virtual Ciudadano? Ciudadano { get; set; }
}
