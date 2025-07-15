using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTOs;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.Repositories.Interfaces;
using FluentValidation;

namespace BLL.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<CreateUserDto> _createUserValidator;
        private readonly IValidator<UpdateUserDto> _updateUserValidator;

        public UserService(
            IUserRepository userRepository,
            IValidator<CreateUserDto> createUserValidator,
            IValidator<UpdateUserDto> updateUserValidator)
        {
            _userRepository = userRepository;
            _createUserValidator = createUserValidator;
            _updateUserValidator = updateUserValidator;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            //var validationResult = await _createUserValidator.ValidateAsync(createUserDto);
            //if (!validationResult.IsValid)
            //{
            //    throw new ValidationException(validationResult.Errors);
            //}

            //var user = _mapper.Map<User>(createUserDto);
            //user.CreatedAt = DateTime.UtcNow;
            //user.UpdatedAt = DateTime.UtcNow;

            //var createdUser = await _userRepository.CreateAsync(user);
            //return _mapper.Map<UserDto>(createdUser);
            throw new NotImplementedException();
        }

        public async Task<UserDto?> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            //var validationResult = await _updateUserValidator.ValidateAsync(updateUserDto);
            //if (!validationResult.IsValid)
            //{
            //    throw new ValidationException(validationResult.Errors);
            //}

            //var existingUser = await _userRepository.GetByIdAsync(id);
            //if (existingUser == null)
            //    return null;

            //_mapper.Map(updateUserDto, existingUser);
            //existingUser.UpdatedAt = DateTime.UtcNow;

            //await _userRepository.UpdateAsync(existingUser);
            //return _mapper.Map<UserDto>(existingUser);
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            if (!await _userRepository.ExistsAsync(id))
                return false;

            await _userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email)
        {
            //var user = await _userRepository.GetByEmailAsync(email);
            //return user == null ? null : _mapper.Map<UserDto>(user);
            throw new NotImplementedException();
        }

        Task<UserDto?> IUserService.GetUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<UserDto>> IUserService.GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
