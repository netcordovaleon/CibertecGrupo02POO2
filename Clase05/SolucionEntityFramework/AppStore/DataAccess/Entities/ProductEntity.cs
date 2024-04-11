using System.ComponentModel.DataAnnotations.Schema;

namespace AppStore.DataAccess.Entities
{
    [Table("PRODUCT")]
    public class ProductEntity
    {
        [Column("PRODUCTID")]
        public int Id { get; set; }
        [Column("PRODUCTNAME")]
        public string Name { get; set; }
        [Column("PRODUCTSTOCK")]
        public int Stock { get; set; }
        [Column("PRODUCTPRICE")]
        public decimal Price { get; set; }
        [Column("REGISTERDATE")]
        public DateTime RegisterDate { get; set; }
        [Column("RECORDSTATUS")]
        public bool Status { get; set; }
    }
}
