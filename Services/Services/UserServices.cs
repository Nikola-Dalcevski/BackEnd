using BusinessLayer.Contracts;
using BusinessLayer.Helpers;
using BusinessLayer.Services;
using DataAccess.Contracts;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtGenerator;
        public UserServices(IUserRepository userRepository, IJwtTokenGenerator jwtGenerator)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;

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

            token = _jwtGenerator.Generator(user);
            return user;
        }

        public void RegisterUser(User user)
        {
            if (UserExists(user.Email))
            {
                throw new ArgumentException($"User with email: {user.Email} alredy exists");
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
        //FINISHED-TODO: find way to implement in repositories find by email
        //cant change baseReposiotry because its inhering form entity that has only id.
        //try to implement in user and bicycle(bicycle name mesto mail)
      

        public void RemoveAdmin(int adminId)
        {
            var admin = _userRepository.GetById(adminId);
            if (admin == null)
            {
                throw new ArgumentException($"Admin with id: {adminId} does not exists");
            }

            _userRepository.Delete(adminId);

        }

        public List<User> GetAllUser(string role)
        {

            return _userRepository.GetAll().Where(u => u.Role == role).ToList();
        }

        public User GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentException($"User with id: {id} does not exists");
            }

            return user;
        }



        private bool UserExists(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user != null;
        }
    }
}
