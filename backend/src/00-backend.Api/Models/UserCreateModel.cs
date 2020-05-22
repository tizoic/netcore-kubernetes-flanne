using System;

namespace backend.Api.Models
{
    public class UserCreateModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}