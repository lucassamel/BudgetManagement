﻿using AutoMapper;
using BudgetManagement.Application.DTOs;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Delete(int id)
        {
            var user = await _userRepository.Delete(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Get(int id)
        {
            var user = await _userRepository.Get(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var users = await _userRepository.GetAll();

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> Insert(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepository.Insert(user);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userUpdated = _mapper.Map<User>(userDTO);
            await _userRepository.Update(userUpdated);

            return _mapper.Map<UserDTO>(userUpdated);
        }
    }
}