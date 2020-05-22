
using System.Linq;
using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Infraestructure.Data.EF.Base;
using backend.Infraestructure.Data.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace backend.Infraestructure.Data.EF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserContext userContext) : base(userContext)
        {
        }

        public User GetByLogin(string login)
        {
            return dbSet.AsNoTracking().FirstOrDefault(p=> p.Login == login);
        }
    }
}
