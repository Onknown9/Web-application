using System.Data.SqlTypes;

namespace project.Models
{
    public class NewProductForDB
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Answer { get; set; }
        public void addToDB()
        {
            DBWork storage = new DBWork();
            storage.SetInfo(this.Name, this.Cost);
        }
        public void RemoveFromDB()
        {
            DBWork storage = new DBWork();
            storage.Delete(this.Name);
        }
        public void Update()
        {
            DBWork storage = new DBWork();
            storage.Update(this.Name,this.Cost);
        }
    }
}
