using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SNGG.Models.Entities
{
    [Table("Games")]
    public class Game : BaseEntity
    {
        [Required]
        public int NrOfDigits { get; set; }

        [Required]
        public int PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        [JsonIgnore]
        public virtual Player Player { get; set; }
    }
}
