using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Usuario.Data;
using Usuario.Model;

namespace Usuario.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await _context.Users.
                    Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Update(User user)
        {
            _context.Update(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}