using AutoMapper;
using Security.Application.DTOs;
using Security.Application.Interfaces;
using Security.Domain.Entities;
using Security.Infrastructure.Interfaces;

namespace Security.Application.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Constructors

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        #endregion

        #region Queries

        public UserDto GetUserById(Guid id)
        {
            var user = _userRepository.GetByIdAsync(id).Result;
            var userDto = user != null ? _mapper.Map<UserDto>(user) : new UserDto();
            return userDto;
        }

        #endregion

        #region Persistence

        public async Task<Guid> CreateUserAsync(UserDto userDto)
        {
            var userEntity = _mapper.Map<UserEntity>(userDto);
            await _userRepository.AddAsync(userEntity);
            return userEntity.Id;
        }

        #endregion
    }
}
