using AutoMapper;
using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities.Account;
using BudgetManagement.Domain.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace BudgetManagement.Application.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

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

            if(userDTO.Password is not null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                byte[] passwordSalt = hmac.Key;

                user.ChangePassword(passwordHash, passwordSalt);
            }

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
