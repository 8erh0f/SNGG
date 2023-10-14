using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SNGG.Models.Dto;

namespace SNGG.DataAccess.Configurations
{
    public class GuessesPerDigitCountDtoConfiguration : IEntityTypeConfiguration<GuessesPerDigitCountDto>
    {
        public void Configure(EntityTypeBuilder<GuessesPerDigitCountDto> builder)
        {
            builder.HasNoKey();
            builder.ToTable(nameof(GuessesPerDigitCountDto), t => t.ExcludeFromMigrations());
        }
    }
}
