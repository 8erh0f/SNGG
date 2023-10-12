using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNGG.Models.Entities
{
    [Table("Players")]
    [Index(nameof(DateOfBirth), nameof(PlayerName), IsUnique = true)]
    public class Player : BaseEntity
    {
        [Required]
        [Column(TypeName = "date")]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "varchar"), MaxLength(64, ErrorMessage = "PlayerName is te lang")]
        public required string PlayerName { get; set; }
    }
}
