using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;

namespace bolsaEmpleoBack.Repository
{
    public interface ITipoDocumentoRepository
    {
        Task<IEnumerable<TipoDocumento>> GetAll();

    }
}
