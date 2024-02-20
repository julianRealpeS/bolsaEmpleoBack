using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;
using bolsaEmpleoBack.Repository;

namespace bolsaEmpleoBack.Services.Impl
{
    /**
     * name: CiudadanoService
     * description: controla la logica de negocio de la entidad Ciudadano
     **/
    public class CiudadanoService: ICiudadanoService
    {
        //Injeccion de CiudadanoRepository
        private ICiudadanoRepository _ciudadanoRepository;

        //Constructor
        public CiudadanoService(ICiudadanoRepository ciudadanoRepository)
        {
            _ciudadanoRepository = ciudadanoRepository;
        }

        /**
         * name: GetAll
         * description: obtiene una lista de objetos CiudadanoGenerarDTO
         * return: regresa una lista de objetos CiudadanoGenerarDTO
         **/
        public async Task<IEnumerable<CiudadanoGeneralDTO>> GetAll()
        {

            var ciudadanos = await _ciudadanoRepository.GetAll();
            return ciudadanos.Select(ciudadano => new CiudadanoGeneralDTO()
            {
                CiudadanoId = ciudadano.CiudadanoId,
                Cedula = ciudadano.Cedula,
                Nombres = ciudadano.Nombres,
                Apellidos = ciudadano.Apellidos,
                FechaNacimiento = ciudadano.FechaNacimiento,
                Profesion = ciudadano.Profesion,
                AspiracionSalarial = ciudadano.AspiracionSalarial,
                CorreoElectronico = ciudadano.CorreoElectronico
            });
        }

        /**
         * name: GetById
         * description: obtiene un objeto Ciudadano por un id dado y lo transforma en un objeto CiudadanoGeneralDTO
         * params: {
         *  id: id del ciudadano buscado
         * }
         * return: regresa un objeto CiudadanoGeneralDTO
         **/
        public async Task<CiudadanoGeneralDTO> GetById(long id)
        {
            var ciudadanoBuscado = await _ciudadanoRepository.GetById(id);
            if (ciudadanoBuscado == null)
            {
                return null;
            }
            return new CiudadanoGeneralDTO()
            {
                CiudadanoId = ciudadanoBuscado.CiudadanoId,
                TipoDocumentoId = ciudadanoBuscado.TipoDocumentoId,
                Cedula = ciudadanoBuscado.Cedula,
                Nombres = ciudadanoBuscado.Nombres,
                Apellidos = ciudadanoBuscado.Apellidos,
                FechaNacimiento = ciudadanoBuscado.FechaNacimiento,
                Profesion = ciudadanoBuscado.Profesion,
                AspiracionSalarial = ciudadanoBuscado.AspiracionSalarial,
                CorreoElectronico = ciudadanoBuscado.CorreoElectronico
            };
        }

        /**
         * name: Save
         * description: guarda un objeto ciudadano
         * params: {
         *  ciudadanoGeneralDTO: objeto CiudadanoGeneralDTO para guardar
         * }
         **/
        public async Task<CiudadanoRegistrarDTO> Save(CiudadanoRegistrarDTO ciudadanoRegistrarDTO)
        {
            var ciudadanoRegistrar = new Ciudadano()
            {
                TipoDocumentoId = ciudadanoRegistrarDTO.TipoDocumentoId,
                Cedula = ciudadanoRegistrarDTO.Cedula,
                Nombres = ciudadanoRegistrarDTO.Nombres,
                Apellidos = ciudadanoRegistrarDTO.Apellidos,
                FechaNacimiento = ciudadanoRegistrarDTO.FechaNacimiento,
                Profesion = ciudadanoRegistrarDTO.Profesion,
                AspiracionSalarial = ciudadanoRegistrarDTO.AspiracionSalarial,
                CorreoElectronico = ciudadanoRegistrarDTO.CorreoElectronico
            };
            await _ciudadanoRepository.Add(ciudadanoRegistrar);
            await _ciudadanoRepository.Save();

            return new CiudadanoRegistrarDTO()
            {
                Cedula = ciudadanoRegistrarDTO.Cedula,
                Nombres = ciudadanoRegistrarDTO.Nombres,
                Apellidos = ciudadanoRegistrarDTO.Apellidos,
                FechaNacimiento = ciudadanoRegistrarDTO.FechaNacimiento,
                Profesion = ciudadanoRegistrarDTO.Profesion,
                AspiracionSalarial = ciudadanoRegistrarDTO.AspiracionSalarial,
                CorreoElectronico = ciudadanoRegistrarDTO.CorreoElectronico
            };
        }

        /**
         * name: Update
         * description: actualiza un objeto ciudadano
         * params: {
         *  ciudadanoGeneralDTO: objeto CiudadanoGeneralDTO para actualizar
         * }
         **/
        public async Task<CiudadanoRegistrarDTO> Update(CiudadanoGeneralDTO ciudadanoGeneralDTO)
        {
            var ciudadanoEditar = await _ciudadanoRepository.GetById(ciudadanoGeneralDTO.CiudadanoId);
            if (ciudadanoEditar == null)
            {
                return null;
            }
            ciudadanoEditar.TipoDocumentoId = ciudadanoGeneralDTO.TipoDocumentoId;
            ciudadanoEditar.Cedula = ciudadanoGeneralDTO.Cedula;
            ciudadanoEditar.Nombres = ciudadanoGeneralDTO.Nombres;
            ciudadanoEditar.Apellidos = ciudadanoGeneralDTO.Apellidos;
            ciudadanoEditar.FechaNacimiento = ciudadanoGeneralDTO.FechaNacimiento;
            ciudadanoEditar.Profesion = ciudadanoGeneralDTO.Profesion;
            ciudadanoEditar.AspiracionSalarial = ciudadanoGeneralDTO.AspiracionSalarial;
            ciudadanoEditar.CorreoElectronico = ciudadanoGeneralDTO.CorreoElectronico;

            _ciudadanoRepository.Update(ciudadanoEditar);
            await _ciudadanoRepository.Save();

            return new CiudadanoRegistrarDTO()
            {
                TipoDocumentoId = ciudadanoGeneralDTO.TipoDocumentoId,
                Cedula = ciudadanoGeneralDTO.Cedula,
                Nombres = ciudadanoGeneralDTO.Nombres,
                Apellidos = ciudadanoGeneralDTO.Apellidos,
                FechaNacimiento = ciudadanoGeneralDTO.FechaNacimiento,
                Profesion = ciudadanoGeneralDTO.Profesion,
                AspiracionSalarial = ciudadanoGeneralDTO.AspiracionSalarial,
                CorreoElectronico = ciudadanoGeneralDTO.CorreoElectronico,
            };
        }

        /**
         * name: Delete
         * description: elimina un objeto ciudadano
         * params: {
         *  id: id del ciudadano para eliminar
         * }
         **/
        public async Task<CiudadanoRegistrarDTO> Delete(long id)
        {
            var ciudadanoEliminar = await _ciudadanoRepository.GetById(id);
            _ciudadanoRepository.Delete(ciudadanoEliminar);
            await _ciudadanoRepository.Save();

            return new CiudadanoRegistrarDTO()
            {
                TipoDocumentoId = ciudadanoEliminar.TipoDocumentoId,
                Cedula = ciudadanoEliminar.Cedula,
                Nombres = ciudadanoEliminar.Nombres,
                Apellidos = ciudadanoEliminar.Apellidos,
                FechaNacimiento = ciudadanoEliminar.FechaNacimiento,
                Profesion = ciudadanoEliminar.Profesion,
                AspiracionSalarial = ciudadanoEliminar.AspiracionSalarial,
                CorreoElectronico = ciudadanoEliminar.CorreoElectronico,
            };
        }

    }
}
