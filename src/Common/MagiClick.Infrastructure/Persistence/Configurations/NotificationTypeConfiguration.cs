using MagiClick.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MagiClick.Infrastructure.Persistence.Configurations
{
    public class NotificationTypeConfiguration : IEntityTypeConfiguration<NotificationType>
    {
        public void Configure(EntityTypeBuilder<NotificationType> builder)
        {

            builder.Property(t => t.Id)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
