using personapi_dotnet.Interfaces;
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

        public void DeleteProfesion(Profesion profesion)
        {
            _context.Profesions.Remove(profesion);
        }

        public Profesion GetProfesionById(int id)
        {
            return _context.Profesions.FirstOrDefault(p => p.Id == id)!;
        }

        public ICollection<Profesion> GetProfesiones()
        {
            return _context.Profesions.ToList();
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
