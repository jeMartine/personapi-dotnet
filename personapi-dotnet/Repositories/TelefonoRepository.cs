using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Data;
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

        // async
        public async Task CreateTelefonoAsync(Telefono telefono)
        {
            await _context.Telefonos.AddAsync(telefono);
            await _context.SaveChangesAsync();
        }

        public void DeleteTelefono(Telefono telefono)
        {
            _context.Telefonos.Remove(telefono);
        }

        public Telefono GetTelefonoById(string id)
        {
            return _context.Telefonos.FirstOrDefault(t => t.Num.Equals(id))!;
        }

        // async
        public async Task<Telefono?> GetTelefonoByIdAsync(string id)
        {
            return await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Num.Equals(id));
        }

        public IEnumerable<Telefono> GetTelefonos()
        {
            return _context.Telefonos.ToList();
        }

        // async
        public async Task<IEnumerable<Telefono>> GetTelefonosAsync()
        {
            return await _context.Telefonos
                .Include(t => t.DuenioNavigation)
                .AsNoTracking()
                .ToListAsync();
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
