using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;

namespace bolsaEmpleoBack.Services
{
    public interface IVacanteOfertadaService
    {
        Task<IEnumerable<VacatanteOfertadaConsultarDTO>> GetAllEnables();
        Task<VacatanteOfertadaConsultarDTO> GetById(long id);
        Task<VacatanteOfertadaConsultarDTO> Update(VacanteOfertadaActualizarDTO ofertaLaboralActualizarDTO);
    }
}
