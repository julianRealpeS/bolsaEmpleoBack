using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;
using bolsaEmpleoBack.Services;
using bolsaEmpleoBack.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bolsaEmpleoBack.Controllers
{
    /**
     * name: VacanteOfertadaController
     * description: controla las solicitudes de la entidad VacanteOfertada
     **/
    [Route("api/[controller]")]
    [ApiController]
    public class VacanteOfertadaController : ControllerBase
    {
        //Injeccion de VacanteOfertadaService
        private IVacanteOfertadaService _vacanteOfertadaService;

        //Constructor
        public VacanteOfertadaController(IVacanteOfertadaService vacanteOfertadaService) {
            _vacanteOfertadaService = vacanteOfertadaService;
        }

        /**
         * name: GetAllEnables
         * description: consulta todas las Vacantes Ofertadas sin ciudadano asignado
         * return: regresa una lista de Vacantes Ofertadas
         **/
        [HttpGet("vacantesDisponibles")]
        public async Task<IEnumerable<VacatanteOfertadaConsultarDTO>> GetAllEnables()
        {
            return await _vacanteOfertadaService.GetAllEnables();
        }

        /**
         * name: getById
         * description: consulta una VacanteOfertada por un id dado
         * params: {
         *  id: id de la VacanteOfertada buscada
         * }
         * return: regresa un VacanteOfertada
         **/
        [HttpGet("vacante/{id}")]
        public async Task<ActionResult<VacatanteOfertadaConsultarDTO>> GetById(long id)
        {
            var vacante = await _vacanteOfertadaService.GetById(id);
            return vacante == null ? NotFound() : Ok(vacante);
        }

        /**
         * name: Update
         * description: actualiza una VacanteOfertada
         * body: {
         *  vacanteOfertada: obteto VacanteOfertada a actualizar
         * }
         * return: regresa la VacanteOfertada actualizada
         **/
        [HttpPut("postular")]
        public async Task<ActionResult<VacatanteOfertadaConsultarDTO>> Update(VacanteOfertadaActualizarDTO vacanteOfertadaActualizarDTO)
        {
            //Validation
            var errorBody = "La vacante debe tener un";
            var errorLog = new List<string>();
            if (vacanteOfertadaActualizarDTO.CiudadanoId == 0)
            {
                errorLog.Add(errorBody+" ciudadano para asignar");
            }
            if (vacanteOfertadaActualizarDTO.VacanteOfertadaId == 0)
            {
                errorLog.Add(errorBody+" id");
            }
            if (errorLog.Count > 0)
            {
                return BadRequest(errorLog);
            }
            //Update code
            var vacanteActualizada = await _vacanteOfertadaService.Update(vacanteOfertadaActualizarDTO);
            if (vacanteActualizada == null)
            {
                BadRequest();
            }
            return Ok(vacanteActualizada);
        }
    }
}
