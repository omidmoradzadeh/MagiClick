using MagiClick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagiClick.Infrastructure.Persistence.Configurations
{
    public class PersonNotificationConfiguration : IEntityTypeConfiguration<PersonNotification>
    {
        public void Configure(EntityTypeBuilder<PersonNotification> builder)
        {

            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.PersonId)
                .IsRequired();

            builder.Property(t => t.NotificationTypeId)
                .IsRequired();

        }
    }
}
