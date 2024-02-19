using bolsaEmpleoBack.DTOs;
using bolsaEmpleoBack.Models;

namespace bolsaEmpleoBack.Repository
{
    public interface IVacanteOfertadaRepository
    {
        Task<IEnumerable<VacanteOfertadum>> GetAllEnables();
        Task<VacanteOfertadum> GetById(long id);
        void Update(VacanteOfertadum vacanteOfertadum);
        Task Save();
    }
}
