using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IProfesionRepository
    {
        bool ProfesionExists(int id);
        Profesion GetProfesionById(int id);
        ICollection<Profesion> GetProfesiones();
        void CreateProfesion(Profesion profesion);
        void UpdateProfesion(Profesion profesion);
        void DeleteProfesion(Profesion profesion);
        bool SaveChanges();
    }
}
