using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Viola.Application.Interface;
using Viola.Domain.Models;


namespace Viola.Infrastructure.Identity.Implement
{
    public class AuthenService : IAuthenService
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration configuration;

        public AuthenService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            this.configuration = configuration;
        }

        public async Task<(string, UserToken)> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Email or Password is empty");
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found");
            }
            // check account is locked
            if (await _userManager.IsLockedOutAsync(user))
            {
                throw new UnauthorizedAccessException("Account is locked");
            }
            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
            {
                var accessToken = await GenarateAccessToken(user);
                var refreshToken = await GenarateRefreshToken(user);
                return (accessToken, refreshToken);
            }
            throw new UnauthorizedAccessException("Login failed");
        }

        public async Task<string> Register(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Email or Password is empty");
            }

            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return user.Email;
            }
            throw new NotImplementedException();
        }

        public async Task<string> GenarateAccessToken(IdentityUser identityUser)
        {
            var authClaims = new List<Claim>() {
                new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var userRoles = await _userManager.GetRolesAsync(identityUser);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
             );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserToken> GenarateRefreshToken(IdentityUser identityUser)
        {
            var value = "";
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                var token = Convert.ToBase64String(randomNumber).Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
                value = token;
            }

            var refreshToken = new UserToken
            {
                UserId = identityUser.Id,
                LoginProvider = "Viola",
                Name = "RefreshToken",
                Value = value,
                IsRevoked = false,
                CreatedAt = DateTime.Now,
                ExpiresAt = DateTime.Now.AddDays(3)

            };
            return refreshToken;
        }
    }
}
