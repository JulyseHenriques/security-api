using Security.Infrastructure.Interfaces;
using Security.Domain.Entities;
using Security.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Security.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructors

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Queries

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        #endregion

        #region Persistence

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
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

