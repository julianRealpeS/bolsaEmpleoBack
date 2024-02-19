using bolsaEmpleoBack.DTOs;

namespace bolsaEmpleoBack.Services
{
    public interface ITipoDocumentoService
    {

        public Task<IEnumerable<TipoDocumentoDTO>> getAll();

    }
}
