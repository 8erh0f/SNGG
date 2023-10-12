using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SNGG.Models.Entities
{
    public class BaseEntity
    {
        [Bindable(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
