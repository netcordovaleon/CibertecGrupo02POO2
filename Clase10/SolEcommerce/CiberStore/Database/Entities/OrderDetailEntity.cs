using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiberStore.Database.Entities
{
    [Table("order_detail")]
    public class OrderDetailEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual OrderEntity Order { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}
