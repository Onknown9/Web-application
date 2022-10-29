using project.Models;

namespace project.Models
{
    public class List
    {

        public List<ProductsInfo> list = new List<ProductsInfo>();
        public void addToList(ProductsInfo a)
        {
            list.Add(a);
        }
    }
}
