using bolsaEmpleoBack.Models;
using Microsoft.EntityFrameworkCore;

namespace bolsaEmpleoBack.Repository.Impl
{
    /**
     * name: VacanteOfertadaRepository
     * description: controla la consulta a la base de datos de la entidad VacanteOfertada
     **/
    public class VacanteOfertadaRepository : IVacanteOfertadaRepository
    {

        //Injeccion del context
        private BolsaEmpleoDbContext _bolsaEmpleoDbContext;

        //Constructor
        public VacanteOfertadaRepository(BolsaEmpleoDbContext bolsaEmpleoDbContext)
        {
            _bolsaEmpleoDbContext = bolsaEmpleoDbContext;
        }

        /**
         * name: GetAllEnables
         * description: obtiene una lista de objetos VacanteOfertada de no tenga un Ciudadano registrado
         * return: regresa una lista de objetos VacanteOfertada
         **/
        public async Task<IEnumerable<VacanteOfertadum>> GetAllEnables()
        {
            return await _bolsaEmpleoDbContext.VacanteOfertada.Where(vacante => vacante.CiudadanoId == null).ToListAsync();
        }

        /**
         * name: GetById
         * description: obtiene un objeto VacanteOfertada por un id dado
         * params: {
         *  id: id de la VacanteOfertada buscada
         * }
         * return: regresa un objeto VacanteOfertada
         **/
        public async Task<VacanteOfertadum> GetById(long id)
        {
            return await _bolsaEmpleoDbContext.VacanteOfertada.Where(vacante => vacante.VacanteOfertadaId == id).FirstOrDefaultAsync();
        }

        /**
         * name: Update
         * description: actualiza un objeto VacanteOfertada
         * params: {
         *  ciudadano: objeto VacanteOfertada para actualizar
         * }
         **/
        public void Update(VacanteOfertadum vacanteOfertadum)
        {
            _bolsaEmpleoDbContext.VacanteOfertada.Attach(vacanteOfertadum);
            _bolsaEmpleoDbContext.VacanteOfertada.Entry(vacanteOfertadum).State = EntityState.Modified;
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
