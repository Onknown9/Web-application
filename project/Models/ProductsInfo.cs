namespace project.Models
{
    public class ProductsInfo
    {
        public string Name { get; set; }  
        public int Cost { get; set; }
        public ProductsInfo(string name , int price)
        {
            Name = name;
            Cost = price;
        }
        public List<ProductsInfo> list = new List<ProductsInfo>();
        public void addToList(ProductsInfo a)
        {
            list.Add(a);
        }
    }
}
