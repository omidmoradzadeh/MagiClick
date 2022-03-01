using MagiClick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagiClick.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
