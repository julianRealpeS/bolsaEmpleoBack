using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bolsaEmpleoBack.Controllers
{
    /**
     * name: TipoDocumentoController
     * description: controla las solicitudes de la entidad TipoDocumento
     **/
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        //Injeccion de TipoDocumentoService
        private ITipoDocumentoService _tipoDocumentoService;

        //Contructor
        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoService) {
            _tipoDocumentoService = tipoDocumentoService;
        }

        /**
         * name: getAll
         * description: consulta todos los tipos de documento en base de datos
         * return: regresa una lista de tiposDocumentoDTO
         **/
        [HttpGet("tiposDocumento")]
        public async Task<IEnumerable<TipoDocumentoDTO>> getAll()
        {
            return await _tipoDocumentoService.getAll();
        }
    }
}
