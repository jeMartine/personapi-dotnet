using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Data;
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

        // async
        public async Task CreatePersonaAsync(Persona persona)
        {
            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public void DeletePersona(Persona persona)
        {
            _context.Personas.Remove(persona);
        }

        public Persona GetPersonaById(int id)
        {
            return _context.Personas.FirstOrDefault(p => p.Cc == id)!;
        }

        // async
        public async Task<Persona?> GetPersonaByIdAsync(int id)
        {
            return await _context.Personas
                .Include(p => p.Estudios)
                .Include(p => p.Telefonos )
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Cc == id);
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        // async
        public async Task<IEnumerable<Persona>> GetPersonasAsync()
        {
            return await _context.Personas
                .Include(p => p.Estudios)
                .Include(p => p.Telefonos)
                .AsNoTracking()
                .ToListAsync();
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
