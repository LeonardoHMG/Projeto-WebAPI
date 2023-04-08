using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Usuario.Model;

namespace Usuario.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(string id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        Task<bool> SaveChangesAsync();


    }
}