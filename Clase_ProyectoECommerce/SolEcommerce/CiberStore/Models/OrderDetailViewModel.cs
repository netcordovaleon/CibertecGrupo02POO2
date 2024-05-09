namespace CiberStore.Models
{
    public class OrderDetailViewModel
    {
        public List<TemporalShoppingCarViewModel> ProductsToConfirm { get; set; }
        public ClientViewModel Client { get; set; }
        public OrderDetailViewModel()
        {
            this.ProductsToConfirm = new List<TemporalShoppingCarViewModel>();
            this.Client = new ClientViewModel();
        }
    }
}
