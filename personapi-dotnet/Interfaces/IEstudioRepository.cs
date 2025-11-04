using personapi_dotnet.Models.Entities;
namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository
    {
        bool EstudioExists(int id);
        Estudio GetEstudioById(int id);
        Task<Estudio?> GetEstudioByIdAsync(int id);
        IEnumerable<Estudio> GetEstudios();
        Task<IEnumerable<Estudio>> GetEstudiosAsync();
        void CreateEstudio(Estudio estudio);
        Task CreateEstudioAsync(Estudio estudio);
        void UpdateEstudio(Estudio estudio);
        void DeleteEstudio(Estudio estudio);
        bool SaveChanges();
        Task<bool> ExistsAsync(int ccPer, int idProf);
    }
}
