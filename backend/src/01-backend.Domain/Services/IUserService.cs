using System;
using System.Collections.Generic;
using backend.Domain.Entities;

namespace backend.Domain.Services
{
    public interface IUserService
    {
        User Add(User user);
        void Delete(Guid id);
        User Update(User user);
        IEnumerable<User> GetAll();
        User GetbyLogin(string login);
    }
}