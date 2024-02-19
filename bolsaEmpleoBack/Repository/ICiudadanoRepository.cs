using bolsaEmpleoBack.Models;

namespace bolsaEmpleoBack.Repository
{
    public interface ICiudadanoRepository
    {
        Task<IEnumerable<Ciudadano>> GetAll();
        Task<Ciudadano> GetById(long id);
        Task Add(Ciudadano ciudadano);
        void Update(Ciudadano ciudadano);
        void Delete(Ciudadano ciudadano);
        Task Save();
    }
}
