using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;
using Microsoft.EntityFrameworkCore;

/**
 * name: TipoDocumentoRepository
 * description: controla la consulta a la base de datos de la entidad TipoDocumento
 **/
namespace bolsaEmpleoBack.Repository.Impl
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private BolsaEmpleoDbContext _bolsaEmpleoDbContext;

        //Constructor
        public TipoDocumentoRepository(BolsaEmpleoDbContext bolsaEmpleoDbContext)
        {
            _bolsaEmpleoDbContext = bolsaEmpleoDbContext;
        }

        /**
         * name: GetAll
         * description: obtiene una lista de objetos TipoDocumento
         * return: regresa una lista de objetos TipoDocumento
         **/
        public async Task<IEnumerable<TipoDocumento>> GetAll()
        {
            return await _bolsaEmpleoDbContext.TipoDocumentos.ToListAsync();
        }
    }
}
