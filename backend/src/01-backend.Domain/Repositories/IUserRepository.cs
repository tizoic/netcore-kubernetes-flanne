using backend.Domain.Entities;
using backend.Domain.Repositories.Base;

namespace backend.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string login);
    }
}
