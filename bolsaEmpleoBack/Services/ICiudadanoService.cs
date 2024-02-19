using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;

namespace bolsaEmpleoBack.Services
{
    public interface ICiudadanoService
    {
        Task<IEnumerable<CiudadanoGeneralDTO>> GetAll();
        Task<CiudadanoGeneralDTO> GetById(long id);
        Task<CiudadanoRegistrarDTO> Save(CiudadanoRegistrarDTO iudadanoConsultaDTO);
        Task<CiudadanoRegistrarDTO> Update(CiudadanoGeneralDTO ciudadanoGeneralDTO);
        Task<CiudadanoRegistrarDTO> Delete(long id);
    }
}
