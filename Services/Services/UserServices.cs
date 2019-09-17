using BusinessLayer.Helpers;
using BusinessLayer.Services;
using DataAccess.Contracts;
using DomainModels.Models;
using DomainModels.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;
        public UserServices(IUserRepository userRepository, IOptions<JwtSettings> options)
        {
            _userRepository = userRepository;
            _jwtSettings = options.Value;

        }

        public User Authenticate(string email, string password, out string token)
        {
            var user = _userRepository.GetByEmail(email);
            if (user == null)
            {
                throw new ArgumentException($"No user with email: {email}");
            }

            var hasPassword = Hashing.sha256(password);
            if (user.Password != hasPassword)
            {
                token = null;
                return null;
            }

            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            token = tokenHandler.WriteToken(securityToken);


            return user;
        }

        public void RegisterUser(User user)
        {
            if (UserExists(user.Email))
            {
                throw new Exception($"User with email: {user.Email} alredy exists");
            }

            _userRepository.Insert(user);
            
        }

        public void RegisterAdmin(User admin)
        {
            if (UserExists(admin.Email))
            {
                throw new ArgumentException($"Admin with email: {admin.Email} alredy exists");
            }

            admin.Role = Roles.Admin;
            string password = Hashing.sha256(admin.Password);
            admin.Password = password;
            _userRepository.Insert(admin);
            
        }
        //TODO: find way to implement in repositories find by email
        //cant change baseReposiotry because its inhering form entity that has only id.
        //try to implement in user and bicycle(bicycle name mesto mail)
        private bool UserExists(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user != null;
        }
    }
}
