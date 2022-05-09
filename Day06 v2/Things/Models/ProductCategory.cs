namespace Things.Models
{
    public class ProductCategory
    {
        public ProductCategory(int Id, string Name)
        {
            CategoryId = Id;
            CategoryName = Name;
        }

        public int CategoryId { get; }
        public string CategoryName { get; }
    }
}
