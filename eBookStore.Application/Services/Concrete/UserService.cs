using eBookStore.Application.DTOs.User;
using eBookStore.Application.DTOs.UserRoleDTO;
using eBookStore.Domain.Entities;
using eBookStore.Domain.Enums;
using eBookStore.DTOs.User;
using eBookStore.DTOs.UserRoleDTO;
using eBookStore.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace eBookStore.Application.Services.Concrete;
public class UserService : IUserService
{
    private readonly UserManager<BookStoreUser> _userManager;
    private readonly RoleManager<BookStoreRole> _roleManager;

    public UserService(
        UserManager<BookStoreUser> userManager,
        RoleManager<BookStoreRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<bool> AddRoleToUserAsync(UserRoleDTO userRoleDTO)
    {
        var user = await _userManager.FindByIdAsync(userRoleDTO.UserId.ToString());
        var role = await _roleManager.FindByIdAsync(userRoleDTO.RoleId.ToString());

        if (user == null || role == null)
        {
            return false;
        }

        var result = await _userManager.AddToRoleAsync(user, role.Name);

        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> RemoveUserRoleAsync(UserRoleDTO userRoleDTO)
    {
        var user = await _userManager.FindByIdAsync(userRoleDTO.UserId.ToString());
        if (user == null)
        {
            return false;
        }

        var roleName = _roleManager.Roles.FirstOrDefault(role => role.Id == userRoleDTO.RoleId)?.Name;
        var userRoles = await _userManager.GetRolesAsync(user);

        if (roleName == null || !roleName.Contains(roleName))
        {
            return false;
        }

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);

        return result.Succeeded;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO)
    {
        var user = await _userManager.FindByEmailAsync(changePasswordDTO.Email);
        if (user == null)
        {
            return false;
        }

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, changePasswordDTO.CurrentPassword);
        if (!isPasswordValid)
        {
            return false;
        }

        var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);

        return result.Succeeded;
    }

    public async Task<bool> ResetPassword(ResetPasswordDTO userChangePasswordDTO)
    {
        BookStoreUser user = _userManager.Users.SingleOrDefault(u => u.Id == userChangePasswordDTO.UserId);
        if (user == null)
        {
            return false;
        }
        string passResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, passResetToken, userChangePasswordDTO.NewPassword);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> AddRolesToUserAsync(int UserId, List<int> RoleIds)
    {
        BookStoreUser user = _userManager.Users.SingleOrDefault(u => u.Id == UserId);
        List<BookStoreRole> rolesInApp = _roleManager.Roles.Where(x => RoleIds.Contains(x.Id)).ToList();
        if (user is null || rolesInApp is null || rolesInApp.Count == 0)
        {
            return false;
        }
        List<string> roleNames = rolesInApp.Select(n => n.Name).ToList();
        IList<string> userRoles = await _userManager.GetRolesAsync(user);
        List<string> newRolesForUser = new List<string>();
        foreach (string role in roleNames)
        {
            if (!userRoles.Contains(role))
            {
                newRolesForUser.Add(role);
            }
        }
        var result = await _userManager.AddToRolesAsync(user, newRolesForUser);
        if (result.Succeeded == false)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> DeActivateUser(int UserId)
    {
        BookStoreUser user = _userManager.Users.SingleOrDefault(u => u.Id == UserId && u.Status == EntityStatus.Active);
        if (user == null)
        {
            return false;
        }
        user.Status = EntityStatus.Deactive;
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            return false;
        }
        return true;
    }
    public Task<IList<UserRolesViewDTO>> UserRoles(int UserId)
    {
        throw new NotImplementedException();
        //BookStoreUser user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == UserId);
        //    if (user is null)
        //    {
        //        return null;
        //    }
        //    IList<string> currentUserRoles = await _userManager.GetRolesAsync(user);
        //    List<UserRolesViewDTO> rolesDTO = _roleManager.Roles.Where(rl => currentUserRoles.Contains(rl.Name)).Select(value => new UserRolesViewDTO { RoleId = value.Id, UserId = UserId, RoleName = value.Name }).ToList();
        //    if (currentUserRoles.Count == 0)
        //    {
        //        return null;
        //    }
        //    return rolesDTO;
    }
}
