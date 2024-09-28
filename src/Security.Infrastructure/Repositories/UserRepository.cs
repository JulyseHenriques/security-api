using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Security.Domain.Entities;
using Security.Infrastructure.Interfaces;
using Security.Infrastructure.Data;
using Security.Infrastructure.Models;

namespace Security.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly SecurityContext _context;

        #endregion

        #region Constructors

        public UserRepository(IMapper mapper, SecurityContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        #endregion

        #region Queries

        public async Task<UserEntity> GetByIdAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            return _mapper.Map<UserEntity>(user);
        }

        //public async Task<IEnumerable<UserEntity>> GetAllAsync()
        //{
        //    var users = await _context.Users.ToListAsync();

        //    return _mapper.Map<UserEntity>(users);
        //}

        #endregion

        #region Persistence

        public async Task<UserEntity> AddAsync(UserEntity userEntity)
        {
            var user = _mapper.Map<User>(userEntity);

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserEntity>(user);
        }

        public async Task UpdateAsync(UserEntity userEntity)
        {
            var user = _mapper.Map<User>(userEntity);

            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        #endregion
    }
}

