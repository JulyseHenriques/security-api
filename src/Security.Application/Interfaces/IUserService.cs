using Security.Application.DTOs;

namespace Security.Application.Interfaces
{
    public interface IUserService
    {
        #region Queries

        UserDto GetUserById(Guid id);

        #endregion

        #region Persistence

        Task<Guid> CreateUserAsync(UserDto userDto);

        #endregion
    }
}
