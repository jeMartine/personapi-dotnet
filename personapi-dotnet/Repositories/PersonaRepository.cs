using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly persona_dbContext _context;

        public PersonaRepository(persona_dbContext context)
        {
            _context = context;
        }
        public void CreatePersona(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        public void DeletePersona(Persona persona)
        {
            _context.Personas.Remove(persona);
        }

        public Persona GetPersonaById(int id)
        {
            return _context.Personas.FirstOrDefault(p => p.Cc == id)!;
        }

        public ICollection<Persona> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        public bool PersonaExists(int id)
        {
            return _context.Personas.Any(p => p.Cc == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePersona(Persona persona)
        {
            _context.Personas.Update(persona);
        }
    }
}
