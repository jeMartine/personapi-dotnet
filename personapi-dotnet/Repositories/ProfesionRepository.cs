using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Data;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly persona_dbContext _context;
        public ProfesionRepository(persona_dbContext context)
        {
            _context = context;
        }
        public void CreateProfesion(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
        }

        // async
        public async Task CreateProfesionAsync(Profesion profesion)
        {
            await _context.Profesions.AddAsync(profesion);
            await _context.SaveChangesAsync();
        }

        public void DeleteProfesion(Profesion profesion)
        {
            _context.Profesions.Remove(profesion);
        }

        public Profesion GetProfesionById(int id)
        {
            return _context.Profesions.FirstOrDefault(p => p.Id == id)!;
        }

        // async
        public async Task<Profesion?> GetProfesionByIdAsync(int id)
        {
            return await _context.Profesions
                .Include(p => p.Estudios)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public IEnumerable<Profesion> GetProfesiones()
        {
            return _context.Profesions.ToList();
        }

        // async
        public async Task<IEnumerable<Profesion>> GetProfesionesAsync()
        {
            return await _context.Profesions
                .Include(p => p.Estudios)
                .AsNoTracking()
                .ToListAsync();
        }

        public bool ProfesionExists(int id)
        {
            return _context.Profesions.Any(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProfesion(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
        }
    }
}
