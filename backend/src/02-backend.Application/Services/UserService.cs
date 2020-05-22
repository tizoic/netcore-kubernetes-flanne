using System;
using System.Collections.Generic;
using backend.Domain.Entities;
using backend.Domain.Repositories;
using backend.Domain.Services;

namespace backend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public User Add(User user)
        {
            return _repository.Add(user);
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetbyLogin(string login)
        {
            return _repository.GetByLogin(login);
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }
    }
}