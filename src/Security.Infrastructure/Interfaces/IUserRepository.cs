using Security.Domain.Entities;

namespace Security.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        #region Queries

        Task<UserEntity> GetByIdAsync(Guid id);

        //Task<IEnumerable<UserEntity>> GetAllAsync();

        #endregion

        #region Persistence

        Task<UserEntity> AddAsync(UserEntity userEntity);
        Task UpdateAsync(UserEntity userEntity);
        Task DeleteAsync(Guid id);

        #endregion
    }
}

