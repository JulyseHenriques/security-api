using Security.Application.DTOs;

namespace Security.Application.Interfaces
{
    public interface IUserService
    {
        UserDto GetUserById(int id);
        Task<int> CreateUserAsync(UserDto userDto);
    }
}
