using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SNGG.Models.Dto;

namespace SNGG.DataAccess.Configurations
{
    public class EntrySpeedPerUserDtoConfiguration : IEntityTypeConfiguration<EntrySpeedPerUserDto>
    {
        public void Configure(EntityTypeBuilder<EntrySpeedPerUserDto> builder)
        {
            builder.HasNoKey();
            builder.ToTable(nameof(EntrySpeedPerUserDto), t => t.ExcludeFromMigrations());
        }
    }
}