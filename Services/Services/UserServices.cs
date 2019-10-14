using AutoMapper;
using BusinessLayer.Contracts;
using BusinessLayer.Helpers;
using BusinessLayer.Services;
using DataAccess.Contracts;
using DomainModels.Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtGenerator;
        private readonly IMapper _mapper;

         

        public UserServices(IUserRepository userRepository, IJwtTokenGenerator jwtGenerator, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtGenerator = jwtGenerator;
            _mapper = mapper;
        }

        public UserViewModel Authenticate(string email, string password, out string token)
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
            var viewUser = _mapper.Map<UserViewModel>(user);
            return viewUser;

        }

        public void RegisterUser(RegisterUserViewModel user)
        {


            if (UserExists(user.Email))
            {
                throw new ArgumentException($"User with email: {user.Email} alredy exists");
            }

            string password = Hashing.sha256(user.Password);
            var dtoUser = _mapper.Map<User>(user);
            dtoUser.Password = password;
            dtoUser.Role = Roles.User;
            _userRepository.Insert(dtoUser);

        }

        //TODO:Fix the view models in controller and services;
        public void RegisterAdmin(RegisterUserViewModel admin)
        {
            if (UserExists(admin.Email))
            {
                throw new ArgumentException($"Admin with email: {admin.Email} alredy exists");
            }


            var dtoAdmin = _mapper.Map<User>(admin);
            dtoAdmin.Role = Roles.Admin;
            dtoAdmin.Orders = null;
            string password = Hashing.sha256(admin.Password);
            admin.Password = password;
            _userRepository.Insert(dtoAdmin);

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

        public List<UserViewModel> GetAllUser(string role)
        {

            List<User> users = _userRepository.GetAll().Where(u => u.Role == role).ToList();
            return _mapper.Map<List<UserViewModel>>(users);

        }

        public UserViewModel GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new ArgumentException($"User with id: {id} does not exists");
            }

            return _mapper.Map<UserViewModel>(user);

        }



        private bool UserExists(string email)
        {
            var user = _userRepository.GetByEmail(email);
            return user != null;
        }


    }
}
