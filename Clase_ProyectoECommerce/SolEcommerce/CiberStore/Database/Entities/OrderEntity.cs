using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiberStore.Database.Entities
{
    [Table("order")]
    public class OrderEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual ClientEntity? Client { get; set; } = null;
        public DateTime registerDate { get; set; }
    }
}
