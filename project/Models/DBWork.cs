using System.Data;
using System.Data.SqlClient;

namespace project.Models
{
    public class DBWork
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public DBWork()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-3796S3L;Initial Catalog=PetProject;Integrated Security=True";

            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
        }
        public List GetInfo()
        {
            List getlist = new List();
            cmd.CommandText = "SELECT * FROM Products";
            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ProductsInfo newProduct = new ProductsInfo((string)reader[0], (int)reader[1]);
                        getlist.addToList(newProduct);
                    }
                }
                reader.Close();
                return getlist;
            }
            catch
            {
                return getlist;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
        }
        public void SetInfo(string name, int cost)
        {
            cmd.CommandText = "INSERT INTO Products(name,cost) VALUES (@name , @cost)";
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar);
            cmd.Parameters["@Name"].Value = name;
            cmd.Parameters.Add("@Cost", SqlDbType.Int);
            cmd.Parameters["@Cost"].Value = cost;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
        }
        public void Delete(string name)
        {
            SqlCommand cmd = con.CreateCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.CommandText = "DELETE FROM Products WHERE Name = @name";
            cmd.Parameters.Add("@name",SqlDbType.NVarChar);
            cmd.Parameters["@name"].Value = name;
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
        }
        public void Update(string name,int cost)
        {
            SqlCommand cmd = con.CreateCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.CommandText = "UPDATE Products SET Cost=@cost WHERE Name=@name";
            cmd.Parameters.Add("@name", SqlDbType.NVarChar);
            cmd.Parameters["@name"].Value = name;
            cmd.Parameters.Add("@cost", SqlDbType.Int);
            cmd.Parameters["@cost"].Value = cost;
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
        }
    }
}
