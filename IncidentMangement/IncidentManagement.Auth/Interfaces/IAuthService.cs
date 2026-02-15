using IncidentManagement.Auth.Models;

namespace IncidentManagement.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<string?> Register(string username, string password);
        Task<string?> Login(string username, string password);
    }
}