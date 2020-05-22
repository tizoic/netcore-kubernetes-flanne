using System;

namespace backend.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(Guid id, string name, string lastName, string login, string password)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Login = login;
            Password = password;
        }

        public User(string name, string lastName, string login, string password)
        {
            Name = name;
            LastName = lastName;
            Login = login;
            Password = password;
        }
    }   
}
