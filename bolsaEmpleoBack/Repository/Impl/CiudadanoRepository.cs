using bolsaEmpleoBack.Models;
using Microsoft.EntityFrameworkCore;

namespace bolsaEmpleoBack.Repository.Impl
{
    /**
     * name: CiudadanoRepository
     * description: controla la consulta a la base de datos de la entidad Ciudadano
     **/
    public class CiudadanoRepository : ICiudadanoRepository
    {
        //Injeccion del context
        private BolsaEmpleoDbContext _bolsaEmpleoDbContext;

        //Constructor
        public CiudadanoRepository(BolsaEmpleoDbContext bolsaEmpleoDbContext)
        {
            _bolsaEmpleoDbContext = bolsaEmpleoDbContext;
        }

        /**
         * name: GetAll
         * description: obtiene una lista de objetos Ciudadano
         * return: regresa una lista de objetos Ciudadano
         **/
        public async Task<IEnumerable<Ciudadano>> GetAll()
        {
            return await _bolsaEmpleoDbContext.Ciudadanos.ToListAsync();
        }

        /**
         * name: GetById
         * description: obtiene un objeto Ciudadano por un id dado
         * params: {
         *  id: id del ciudadano buscado
         * }
         * return: regresa un objeto Ciudadano
         **/
        public async Task<Ciudadano> GetById(long id)
        {
            return await _bolsaEmpleoDbContext.Ciudadanos.Where(ciudadano => ciudadano.CiudadanoId == id).FirstOrDefaultAsync();
        }

        /**
         * name: Add
         * description: agrega un objeto ciudadano
         * params: {
         *  ciudadano: objeto ciudadano para agregar
         * }
         **/
        public async Task Add(Ciudadano ciudadano)
        {
            await _bolsaEmpleoDbContext.Ciudadanos.AddAsync(ciudadano);
        }

        /**
         * name: Update
         * description: actualiza un objeto ciudadano
         * params: {
         *  ciudadano: objeto ciudadano para actualizar
         * }
         **/
        public void Update(Ciudadano ciudadano)
        {
            _bolsaEmpleoDbContext.Ciudadanos.Attach(ciudadano);
            _bolsaEmpleoDbContext.Ciudadanos.Entry(ciudadano).State = EntityState.Modified;

        }

        /**
         * name: Delete
         * description: elimina un objeto ciudadano
         * params: {
         *  ciudadano: objeto ciudadano para eliminar
         * }
         **/
        public void Delete(Ciudadano ciudadano)
        {
            _bolsaEmpleoDbContext.Ciudadanos.Remove(ciudadano);
        }

        /**
         * name: Save
         * description: ejecuta los cambios almacenados a la bd
         **/
        public async Task Save()
        {
            await _bolsaEmpleoDbContext.SaveChangesAsync();
        }
    }
}
