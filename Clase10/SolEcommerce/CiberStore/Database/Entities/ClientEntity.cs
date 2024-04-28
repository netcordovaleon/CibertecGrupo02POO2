using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CiberStore.Database.Entities
{
    [Table("client")]
    public class ClientEntity
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityNumber { get; set; }
        public string DeliveryAddress { get; set; }
    }
}
