using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly persona_dbContext _context;
        public TelefonoRepository(persona_dbContext context)
        {
            _context = context;
        }
        public void CreateTelefono(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
        }

        public void DeleteTelefono(Telefono telefono)
        {
            _context.Telefonos.Remove(telefono);
        }

        public Telefono GetTelefonoById(string id)
        {
            return _context.Telefonos.FirstOrDefault(t => t.Num.Equals(id))!;
        }

        public ICollection<Telefono> GetTelefonos()
        {
            return _context.Telefonos.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool TelefonoExists(string id)
        {
            return _context.Telefonos.Any(t => t.Num.Equals(id));
        }

        public void UpdateTelefono(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
        }
    }
}
