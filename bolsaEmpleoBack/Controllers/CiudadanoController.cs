using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;
using bolsaEmpleoBack.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace bolsaEmpleoBack.Controllers
{
    /**
     * name: CiudadanoController
     * description: controla las solicitudes de la entidad Ciudadano
     **/
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadanoController : ControllerBase
    {
        //Injeccion del ciudadanoService
        private ICiudadanoService _ciudadanoService;

        //Constructor
        public CiudadanoController(ICiudadanoService ciudadanoService)
        {
            _ciudadanoService = ciudadanoService;
        }

        /**
         * name: getAll
         * description: consulta todos los ciudadanos en base de datos
         * return: regresa una lista de CiudadanoGeneralDTO
         **/
        [HttpGet("ciudadanos")]
        public async Task<IEnumerable<CiudadanoGeneralDTO>> getAll(){
            return await _ciudadanoService.GetAll();
        }

        /**
         * name: getById
         * description: consulta un Ciudadano por un id dado
         * params: {
         *  id: id del ciudadano buscado
         * }
         * return: regresa un Ciudadano
         **/
        [HttpGet("ciudadano/{id}")]
        public async Task<ActionResult<CiudadanoGeneralDTO>> GetById(long id)
        {
            var ciudadano = await _ciudadanoService.GetById(id);
            return ciudadano == null ? NotFound() : Ok(ciudadano);
        }

        /**
         * name: Save
         * description: registra un Ciudadano
         * body: {
         *  ciudadano: obteto Ciudadano a registrar
         * }
         * return: regresa el Ciudadano registrado
         **/
        [HttpPost("registrar")]
        public async Task<ActionResult<CiudadanoRegistrarDTO>> Save(CiudadanoRegistrarDTO ciudadano)
        {
            //Validation
            var errorBody = "EL ciudadano debe tener un";
            var errorLog = new List<string>();
            if (ciudadano.TipoDocumentoId == 0) {
                errorLog.Add(errorBody + " tipo de documento");
            }
            if (ciudadano.Cedula == null || ciudadano.Cedula == "")
            {
                errorLog.Add(errorBody + "a cedula");
            }
            if (ciudadano.Nombres == null || ciudadano.Nombres == "")
            {
                errorLog.Add(errorBody + " nombre");
            }
            if (ciudadano.Apellidos == null || ciudadano.Apellidos == "")
            {
                errorLog.Add(errorBody + " apellido");
            }
            if (ciudadano.Profesion == null || ciudadano.Profesion == "")
            {
                errorLog.Add(errorBody + "a profesion");
            }
            if (ciudadano.CorreoElectronico == null || ciudadano.CorreoElectronico == "")
            {
                errorLog.Add(errorBody + " correo electronico");
            }
            if (errorLog.Count > 0) {
                return BadRequest(errorLog);
            }
            //Save code
            var ciudadanoRegistrado = await _ciudadanoService.Save(ciudadano);
            return Ok(ciudadanoRegistrado);
        }

        /**
         * name: Update
         * description: actualiza un Ciudadano
         * body: {
         *  ciudadano: obteto Ciudadano a actualizar
         * }
         * return: regresa el Ciudadano actualizado
         **/
        [HttpPut("actualizar")]
        public async Task<ActionResult<CiudadanoRegistrarDTO>> Update(CiudadanoGeneralDTO ciudadano)
        {
            //Validation
            var errorBody = "EL ciudadano debe tener un";
            var errorLog = new List<string>();
            if (ciudadano.CiudadanoId == 0)
            {
                errorLog.Add(errorBody + " id");
            }
            if (ciudadano.TipoDocumentoId == 0)
            {
                errorLog.Add(errorBody + " tipo de documento");
            }
            if (ciudadano.Cedula == null || ciudadano.Cedula == "")
            {
                errorLog.Add(errorBody + "a cedula");
            }
            if (ciudadano.Nombres == null || ciudadano.Nombres == "")
            {
                errorLog.Add(errorBody + " nombre");
            }
            if (ciudadano.Apellidos == null || ciudadano.Apellidos == "")
            {
                errorLog.Add(errorBody + " apellido");
            }
            if (ciudadano.Profesion == null || ciudadano.Profesion == "")
            {
                errorLog.Add(errorBody + "a profesion");
            }
            if (ciudadano.CorreoElectronico == null || ciudadano.CorreoElectronico == "")
            {
                errorLog.Add(errorBody + " correo electronico");
            }
            if (errorLog.Count > 0)
            {
                return BadRequest(errorLog);
            }
            //Update code
            var ciudadanoActualizado = await _ciudadanoService.Update(ciudadano);
            return Ok(ciudadanoActualizado);
        }

        /**
         * name: Delete
         * description: elimina un Ciudadano
         * params: {
         *  id: id del ciudadano a eliminar
         * }
         * return: regresa el Ciudadano eliminado
         **/
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<CiudadanoRegistrarDTO>> Delete(long id)
        {
            var ciudadanoEliminado = await _ciudadanoService.Delete(id);
            return Ok(ciudadanoEliminado);
        }

    }
}