using eBookStore.Domain.Entities;
using eBookStore.DTOs.Authentication;

namespace eBookStore.Services.Abstract;

public interface IAuthService
{
    Task<string> Login(LoginDTO login);
    Task<string> GenerateTokenAsync(BookStoreUser user, List<string> roles);
    Task<string> Registration(RegistrationDTO registration);
}
