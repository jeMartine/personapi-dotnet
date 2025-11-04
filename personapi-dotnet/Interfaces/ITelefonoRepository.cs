using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface ITelefonoRepository
    {
        bool TelefonoExists(string id);
        Telefono GetTelefonoById(string id);
        Task<Telefono?> GetTelefonoByIdAsync(string id);
        IEnumerable<Telefono> GetTelefonos();
        Task<IEnumerable<Telefono>> GetTelefonosAsync();
        void CreateTelefono(Telefono telefono);
        Task CreateTelefonoAsync(Telefono telefono);
        void UpdateTelefono(Telefono telefono);
        void DeleteTelefono(Telefono telefono);
        bool SaveChanges();
    }
}
