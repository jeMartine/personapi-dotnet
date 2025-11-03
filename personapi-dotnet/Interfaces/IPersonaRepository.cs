using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IPersonaRepository
    {
        bool PersonaExists(int id);
        Persona GetPersonaById(int id);
        ICollection<Persona> GetPersonas();
        void CreatePersona(Persona persona);
        void UpdatePersona(Persona persona);
        void DeletePersona(Persona persona);
        bool SaveChanges();
    }
}
