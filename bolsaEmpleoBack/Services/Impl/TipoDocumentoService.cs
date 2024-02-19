using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;
using bolsaEmpleoBack.Repository;
using bolsaEmpleoBack.Repository.Impl;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bolsaEmpleoBack.Services.Impl
{
    /**
     * name: TipoDocumentoService
     * description: controla la logica de negocio de la entidad TipoDocumento
     **/
    public class TipoDocumentoService : ITipoDocumentoService
    {
        //Injeccion de TipoDocumentoRepository
        private ITipoDocumentoRepository _tipoDocumentoRepository;

        //Contructor
        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }
        /**
         * name: getAll
         * description: obtiene una lista de objetos TipoDocumento y los transforma en una lista de objetos TipoDocumentoDTO
         * return: regresa una lista de objetos TipoDocumentoDTO
         **/
        public async Task<IEnumerable<TipoDocumentoDTO>> getAll()
        {
            var tiposDocumento = await _tipoDocumentoRepository.GetAll();
            return tiposDocumento.Select(tipoDocumento => new TipoDocumentoDTO
            {
                tipoDocumentoId = tipoDocumento.TipoDocumentoId,
                nombre = tipoDocumento.Nombre
            });
        }

    }
}
