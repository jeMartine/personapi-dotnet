using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IPersonaRepository
    {
        bool PersonaExists(int id);
        Persona GetPersonaById(int id);
        Task<Persona?> GetPersonaByIdAsync(int id);
        IEnumerable<Persona> GetPersonas();
        Task<IEnumerable<Persona>> GetPersonasAsync();
        void CreatePersona(Persona persona);
        Task CreatePersonaAsync(Persona persona);
        void UpdatePersona(Persona persona);
        void DeletePersona(Persona persona);
        bool SaveChanges();
    }
}
