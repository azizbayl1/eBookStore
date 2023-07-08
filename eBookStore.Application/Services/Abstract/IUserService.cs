using eBookStore.Application.DTOs.User;
using eBookStore.Application.DTOs.UserRoleDTO;
using eBookStore.DTOs.User;
using eBookStore.DTOs.UserRoleDTO;

namespace eBookStore.Services.Abstract;

public interface IUserService
{
    Task<bool> AddRoleToUserAsync(UserRoleDTO userRoleDTO);
    Task<bool> AddRolesToUserAsync(int UserId, List<int> RoleIds);
    Task<bool> RemoveUserRoleAsync(UserRoleDTO userRoleDTO);
    Task<bool> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    Task<bool> ResetPassword(ResetPasswordDTO userChangePasswordDTO);
    Task<IList<UserRolesViewDTO>> UserRoles(int UserId);
}
