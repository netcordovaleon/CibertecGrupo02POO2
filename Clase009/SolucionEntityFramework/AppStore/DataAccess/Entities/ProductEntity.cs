using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace AppStore.DataAccess.Entities
{
    [Table("PRODUCT")]
    public class ProductEntity
    {
        [Column("PRODUCTID")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [MinLength(3, ErrorMessage = "Ingrese un nombre valido, mayor a 3 caracteres")]
        [Column("PRODUCTNAME")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, 100, ErrorMessage ="El stock debe estar entre los valores 1 y 100")]
        [Column("PRODUCTSTOCK")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Column("PRODUCTPRICE")]
        public decimal Price { get; set; }
        [Column("REGISTERDATE")]
        public DateTime RegisterDate { get; set; }
        [Column("RECORDSTATUS")]
        public bool Status { get; set; }
    }
    //int, string, double, boolean
}
