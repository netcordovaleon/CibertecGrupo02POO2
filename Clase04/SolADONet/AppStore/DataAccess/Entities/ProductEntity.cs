namespace AppStore.DataAccess.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
    }
}
