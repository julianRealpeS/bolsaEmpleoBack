using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bolsaEmpleoBack.Models;

public partial class TipoDocumento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(TypeName = "numeric(18, 0)")]
    public long TipoDocumentoId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ciudadano> Ciudadanos { get; set; } = new List<Ciudadano>();
}
