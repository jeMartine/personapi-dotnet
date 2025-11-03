using personapi_dotnet.Models.Entities;
namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository
    {
        bool EstudioExists(int id);
        Estudio GetEstudioById(int id);
        ICollection<Estudio> GetEstudios();
        void CreateEstudio(Estudio estudio);
        void UpdateEstudio(Estudio estudio);
        void DeleteEstudio(Estudio estudio);
        bool SaveChanges();

    }
}
