using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IProfesionRepository
    {
        bool ProfesionExists(int id);
        Profesion GetProfesionById(int id);
        Task<Profesion?> GetProfesionByIdAsync(int id);
        IEnumerable<Profesion> GetProfesiones();
        Task<IEnumerable<Profesion>> GetProfesionesAsync();
        void CreateProfesion(Profesion profesion);
        Task CreateProfesionAsync(Profesion profesion);
        void UpdateProfesion(Profesion profesion);
        void DeleteProfesion(Profesion profesion);
        bool SaveChanges();
    }
}
