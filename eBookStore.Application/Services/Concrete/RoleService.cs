using eBookStore.Domain.Entities;
using eBookStore.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace eBookStore.Application.Services.Concrete;

public class RoleService : IRoleService
{
    private readonly RoleManager<BookStoreRole> _roleManager;

    public RoleService(RoleManager<BookStoreRole> roleManager)
    {
        _roleManager = roleManager;
    }

    
    public async Task<bool> AddRoleAsync(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return false;
        }

        var role = new BookStoreRole { Name = roleName };
        var result = await _roleManager.CreateAsync(role);

        return result.Succeeded;
    }

    public List<string> GetRoles()
    {
        return _roleManager.Roles.Select(r => r.Name).ToList();
    }
}
