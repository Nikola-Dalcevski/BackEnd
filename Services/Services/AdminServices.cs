using BusinessLayer.Contracts;
using BusinessLayer.Helpers;
using DataAccess.Contracts;
using DomainModels.Models;
using DomainModels.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Services
{
    class AdminServices : IAdminServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IBicycleRepository _bicycleRepository;
        private readonly JwtSettings _jwtSettings;

        public AdminServices(IUserRepository userRepository, IBicycleRepository bicycleRepository, IOptions<JwtSettings> options)
        {
            _userRepository = userRepository;
            _bicycleRepository = bicycleRepository;
            _jwtSettings = options.Value;
        }

        public int AddAdmin(User admin)
        {
            if (UserExists(admin.Email))
            {
                throw new ArgumentException($"Admin with email: {admin.Email} alredy exists");
            }
            
            string password = Hashing.sha256(admin.Password);
            admin.Password = password;
            admin.Role = Roles.Admin;
            _userRepository.Insert(admin);
            return admin.Id;
        }


        public int AddBicycle(Bicycle bicycle)
        {
            _bicycleRepository.Insert(bicycle);
            return bicycle.Id;
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

        public int Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public int EditBicycle(Bicycle bicycle)
        {
            throw new NotImplementedException();
        }

        public int GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        public int RemoveBicycle(Bicycle bicycle)
        {
            throw new NotImplementedException();
        }

        public int RemoveBicycle(int bicycleId)
        {
            throw new NotImplementedException();
        }

        public int RemuveAdmin(int adminId)
        {
            throw new NotImplementedException();
        }

       private bool UserExists(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user != null;

        }
    }
}
