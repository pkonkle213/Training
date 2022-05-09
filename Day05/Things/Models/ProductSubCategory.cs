namespace Things.Models
{
    public class ProductSubCategory
    {
        public ProductSubCategory(int subId,int categoryId, string categoryName)
        {
            SubCategoryId = subId;
            CategoryId = categoryId;
            SubCategoryName = categoryName;
        }

        public int SubCategoryId { get; }
        public int CategoryId { get; }
        public string SubCategoryName { get; }
    }
}
