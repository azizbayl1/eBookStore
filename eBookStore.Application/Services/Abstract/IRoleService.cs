namespace eBookStore.Services.Abstract;

public interface IRoleService
{
    Task<bool> AddRoleAsync(string roleName);
    List<string> GetRoles();
}
