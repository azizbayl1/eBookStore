using eBookStore.Application.DTOs.User;
using eBookStore.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using eBookStore.DTOs.UserRoleDTO;
using eBookStore.DTOs.User;

namespace eBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [Route("/AddRoleToUser")]
        [HttpPost]
        public async Task<IActionResult> AddRoleToUser(UserRoleDTO userRoleDTO)
        {
            // Add the role to the user
            var result = await _userService.AddRoleToUserAsync(userRoleDTO);
            if (result)
            {
                return Ok("Role added to user successfully");
            }
            else
            {
                return BadRequest("Failed to add role to user");
            }
        }

        [Route("/AddRolesToUser")]
        [HttpPost]
        public async Task<IActionResult> AddRolesToUser(int user, List<int> roles)
        {
            var result = await _userService.AddRolesToUserAsync(user, roles);
            if (result)
            {
                return Ok("Role added to user successfully");
            }
            else
            {
                return BadRequest("Failed to add role to user");
            }
        }

        [Route("/RemoveUserRole")]
        [HttpDelete]
        public async Task<IActionResult> RemoveUserRole(UserRoleDTO UserRoleDTO)
        {
            var result = await _userService.RemoveUserRoleAsync(UserRoleDTO);
            if (result)
            {
                return Ok("Role removed from user successfully");
            }
            else
            {
                return BadRequest("Failed to remove role from user");
            }
        }

        [Route("/ChangePassword")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var result = await _userService.ChangePasswordAsync(changePasswordDTO);
            if (result)
            {
                return Ok("Password changed successfully");
            }
            else
            {
                return BadRequest("Failed to change password");
            }
        }

        [Route("/ResetPassword")]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO userResetPasswordDTO)
        {
            var result = await _userService.ResetPassword(userResetPasswordDTO);
            if (result)
            {
                return Ok("Password reset successfully");
            }
            else
            {
                return BadRequest("Failed to reset password");
            }
        }

        [Route("/GetUserWithRoles")]
        [HttpGet]
        public IActionResult UserRoles(int id)
        {
            return Ok(_userService.UserRoles(id));
        }
    }
}
