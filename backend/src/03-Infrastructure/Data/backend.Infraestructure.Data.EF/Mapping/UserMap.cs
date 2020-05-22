using backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Infraestructure.Data.EF.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.Property(p=> p.Name).IsRequired();
            builder.Property(p=> p.LastName);
            builder.HasIndex(p=> p.Login).IsUnique();            
            builder.Property(p=> p.Password).IsRequired();

            builder.ToTable("User");

        }
    }
}
