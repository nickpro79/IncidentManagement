using IncidentManagement.Auth.Models;

namespace IncidentManagement.Auth.Interfaces
{
    public interface IAuthService
    {
        Task<string?> Register(string username, string password, string? role);
        Task<string?> Login(string username, string password);
    }
}