using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Data;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly persona_dbContext _context;

        public EstudioRepository(persona_dbContext context)
        {
            _context = context;
        }

        public void CreateEstudio(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
        }

        // async
        public async Task CreateEstudioAsync(Estudio estudio)
        {
            await _context.Estudios.AddAsync(estudio);
            await _context.SaveChangesAsync();
        }

        public void DeleteEstudio(Estudio estudio)
        {
            _context.Estudios.Remove(estudio);
        }

        public bool EstudioExists(int id)
        {
            return _context.Estudios.Any(e => e.IdProf == id);
        }

        public Estudio GetEstudioById(int id)
        {
            return _context.Estudios.FirstOrDefault(e => e.IdProf == id)!;
        }

        // async
        public async Task<Estudio?> GetEstudioByIdAsync(int id)
        {
            return await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.IdProf == id);
        }

        public IEnumerable<Estudio> GetEstudios()
        {
            return _context.Estudios.ToList();
        }

        // async
        public async Task<IEnumerable<Estudio>> GetEstudiosAsync()
        {
            return await _context.Estudios
                .Include(e => e.CcPerNavigation)
                .Include(e => e.IdProfNavigation)
                .AsNoTracking()
                .ToListAsync();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateEstudio(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
        }

        public async Task<bool> ExistsAsync(int ccPer, int idProf)
        {
            return await _context.Estudios.AnyAsync(e => e.CcPer == ccPer && e.IdProf == idProf);
        }

    }
}
