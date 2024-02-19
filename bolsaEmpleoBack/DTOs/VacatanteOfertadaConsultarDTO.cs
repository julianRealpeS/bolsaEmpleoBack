using System.ComponentModel.DataAnnotations.Schema;

namespace bolsaEmpleoBack.DTOs
{
    public class VacatanteOfertadaConsultarDTO
    {
        public long VacanteOfertadaId { get; set; }
        public string Codigo { get; set; }
        public string Cargo { get; set; }
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
        public long Salario { get; set; }
    }
}
