using backend.Domain.Entities;
using backend.Infraestructure.Data.EF.Mapping;
using Microsoft.EntityFrameworkCore;

namespace backend.Infraestructure.Data.EF.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }   
}
