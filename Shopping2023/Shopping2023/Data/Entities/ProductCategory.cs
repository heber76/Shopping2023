namespace Shopping2023.Data.Entities
{
    public class ProductCategory
    {

        public int Id { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }

    }
}
