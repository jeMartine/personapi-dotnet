using personapi_dotnet.Interfaces;
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
        public ICollection<Estudio> GetEstudios()
        {
            return _context.Estudios.ToList();
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void UpdateEstudio(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
        }
    }
}
