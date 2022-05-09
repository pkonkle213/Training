namespace Things.Models
{
    public class Product
    {
        public Product(int id, int catId, string prodName, string color, decimal price)
        {
            ProductId = id;
            SubCategoryId = catId;
            ProductName = prodName;
            Color = color;
            Price = price;
        }

        public int ProductId { get; }
        public int SubCategoryId { get; }
        public string ProductName { get; }
        public string Color { get; }
        public decimal Price { get; }
    }
}
