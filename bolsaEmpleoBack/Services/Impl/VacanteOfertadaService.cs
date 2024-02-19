using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Repository;

namespace bolsaEmpleoBack.Services.Impl
{
    /**
     * name: VacanteOfertadaService
     * description: controla la logica de negocio de la entidad VacanteOfertada
     **/
    public class VacanteOfertadaService : IVacanteOfertadaService
    {
        //Injeccion de CiudadanoRepository
        private IVacanteOfertadaRepository _vacanteOfertadaRepository;

        //Contructor
        public VacanteOfertadaService(IVacanteOfertadaRepository vacanteOfertadaRepository)
        {
            _vacanteOfertadaRepository = vacanteOfertadaRepository;
        }

        /**
         * name: GetAllEnables
         * description: obtiene una lista de objetos VacanteOfertada sin ciudadano asignado y los transforma en una lista de objetos VacanteOfertadaConsultarDTO
         * return: regresa una lista de objetos VacanteOfertadaConsultarDTO
         **/
        public async Task<IEnumerable<VacatanteOfertadaConsultarDTO>> GetAllEnables()
        {
            var vacantes = await _vacanteOfertadaRepository.GetAllEnables();
            return vacantes.Select(vacante => new VacatanteOfertadaConsultarDTO()
            {
                VacanteOfertadaId = vacante.VacanteOfertadaId,
                Codigo = vacante.Codigo,
                Cargo = vacante.Cargo,
                Descripcion = vacante.Descripcion,
                Empresa = vacante.Empresa,
                Salario = vacante.Salario
            });
        }

        /**
         * name: GetById
         * description: obtiene un objeto VacanteOfertada por un id dado y lo transforma en un objeto VacanteOfertadaConsultarDTO
         * params: {
         *  id: id de la VacanteOfertada buscada
         * }
         * return: regresa un objeto VacanteOfertadaConsultarDTO
         **/
        public async Task<VacatanteOfertadaConsultarDTO> GetById(long id)
        {
            var vacante = await _vacanteOfertadaRepository.GetById(id);
            if (vacante == null) {
                return null;
            }
            return new VacatanteOfertadaConsultarDTO() {
                VacanteOfertadaId = vacante.VacanteOfertadaId,
                Codigo = vacante.Codigo,
                Cargo = vacante.Cargo,
                Descripcion = vacante.Descripcion,
                Empresa = vacante.Empresa,
                Salario = vacante.Salario
            };
        }

        /**
         * name: Update
         * description: actualiza un objeto VacanteOfertada
         * params: {
         *  ofertaLaboralActualizarDTO: objeto VacanteOfertadaConsultarDTO para actualizar
         * }
         **/
        public async Task<VacatanteOfertadaConsultarDTO> Update(VacanteOfertadaActualizarDTO ofertaLaboralActualizarDTO)
        {
            var vacanteEditar = await _vacanteOfertadaRepository.GetById(ofertaLaboralActualizarDTO.VacanteOfertadaId);
            if (vacanteEditar == null || vacanteEditar.CiudadanoId != null)
            {
                return null;
            }
            vacanteEditar.CiudadanoId = ofertaLaboralActualizarDTO.CiudadanoId;
            _vacanteOfertadaRepository.Update(vacanteEditar);
            await _vacanteOfertadaRepository.Save();

            return new VacatanteOfertadaConsultarDTO()
            {
                VacanteOfertadaId = vacanteEditar.VacanteOfertadaId,
                Codigo = vacanteEditar.Codigo,
                Cargo = vacanteEditar.Cargo,
                Descripcion = vacanteEditar.Descripcion,
                Empresa = vacanteEditar.Empresa,
                Salario = vacanteEditar.Salario
            };
        }
    }
}
