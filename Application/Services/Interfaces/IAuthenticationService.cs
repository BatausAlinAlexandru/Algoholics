namespace Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(string email, string password);
        Task LogoutAsync(Guid userId);
        Task RegisterAsync(string email, string password);
    }
}
