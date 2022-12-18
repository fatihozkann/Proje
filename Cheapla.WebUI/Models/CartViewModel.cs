namespace Cheapla.WebUI.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemsViewModel> CartItems { get; set; }
        public decimal TotalPrice()
        {
            return CartItems.Sum(i => i.UnitPrice.Value * i.Quantity);
        }
    }
    public class CartItemsViewModel
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}
