using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface ITelefonoRepository
    {
        bool TelefonoExists(string id);
        Telefono GetTelefonoById(string id);
        ICollection<Telefono> GetTelefonos();
        void CreateTelefono(Telefono telefono);
        void UpdateTelefono(Telefono telefono);
        void DeleteTelefono(Telefono telefono);
        bool SaveChanges();
    }
}
