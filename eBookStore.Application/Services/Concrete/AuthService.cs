using AutoMapper;
using eBookStore.Domain.Entities;
using eBookStore.DTOs.Authentication;
using eBookStore.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBookStore.Application.Services.Concrete;
public class AuthService : IAuthService
{
    private readonly UserManager<BookStoreUser> _userManager;
    private readonly RoleManager<BookStoreRole> _roleManager;
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public AuthService(
        UserManager<BookStoreUser> userManager,
        RoleManager<BookStoreRole> roleManager,
        IConfiguration config,
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
        _mapper = mapper;
    }

    public async Task<string> GenerateTokenAsync(BookStoreUser user, List<string> roles)
    {
        var claims = new List<Claim>();

        claims.Add(new Claim(ClaimTypes.Email, user.Email));

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }


        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
        _config["Jwt:Issuer"],
        _config["Jwt:Audience"],
        claims,
        expires: DateTime.Now.AddMinutes(15),
        signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> Login(LoginDTO login)
    {
        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
        {
            var roles = await _userManager.GetRolesAsync(user);
            return await GenerateTokenAsync(user, roles.ToList());
        }
        else
        {
            return "Invalid email or password.";
        }
    }

    public async Task<string> Registration(RegistrationDTO registrationDTO)
    {
        var user = _mapper.Map<BookStoreUser>(registrationDTO);

        var result = await _userManager.CreateAsync(user, registrationDTO.Password);

        if (result.Succeeded)
        {
            return "User registration successful.";
        }
        else
        {
            var errors = result.Errors.Select(e => e.Description).ToList();
            return "User registration failed. Errors: " + string.Join(", ", errors);
        }
    }
}

