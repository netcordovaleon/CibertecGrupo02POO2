using AppStore.DataAccess.Entities;
using System.Data.SqlClient;
using System.Data;
namespace AppStore.DataAccess
{
    public class ProductDAO
    {

        public List<ProductEntity> GetAllProducts()
        {

            var productList = new List<ProductEntity>();
            SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=BD_STORE;Integrated Security=true;");
            con.Open();
            SqlCommand cmd = new SqlCommand("USP_GETALLPRODUCTS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ProductEntity item = new ProductEntity();
                item.Id = Convert.ToInt32(reader["PRODUCTID"]);
                item.Name = reader["PRODUCTNAME"].ToString();
                item.Stock = Convert.ToInt32(reader["PRODUCTSTOCK"]);
                item.Price = Convert.ToDouble(reader["PRODUCTPRICE"]);
                item.RegisterDate = Convert.ToDateTime(reader["REGISTERDATE"]);
                item.Status = Convert.ToBoolean(reader["RECORDSTATUS"]);
                productList.Add(item);
            }
            con.Close();
            return productList;
        }

        public List<ProductEntity> GetAllProductsTryCatch()
        {
            SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=BD_STORE;Integrated Security=true;");
            try
            {
                var productList = new List<ProductEntity>();
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_GETALLPRODUCTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductEntity item = new ProductEntity();
                    item.Id = Convert.ToInt32(reader["PRODUCTID"]);
                    item.Name = reader["PRODUCTNAME"].ToString();
                    item.Stock = Convert.ToInt32(reader["PRODUCTSTOCK"]);
                    item.Price = Convert.ToDouble(reader["PRODUCTPRICE"]);
                    item.RegisterDate = Convert.ToDateTime(reader["REGISTERDATE"]);
                    item.Status = Convert.ToBoolean(reader["RECORDSTATUS"]);
                    productList.Add(item);
                }
                con.Close();
                return productList;
            }
            catch (Exception)
            {
                //Guardar Logs
                //Envio correo
                return null;
            }
            finally
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public List<ProductEntity> GetAllProductsUsing()
        {

            var productList = new List<ProductEntity>();
            using (SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=BD_STORE;Integrated Security=true;"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("USP_GETALLPRODUCTS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ProductEntity item = new ProductEntity();
                    item.Id = Convert.ToInt32(reader["PRODUCTID"]);
                    item.Name = reader["PRODUCTNAME"].ToString();
                    item.Stock = Convert.ToInt32(reader["PRODUCTSTOCK"]);
                    item.Price = Convert.ToDouble(reader["PRODUCTPRICE"]);
                    item.RegisterDate = Convert.ToDateTime(reader["REGISTERDATE"]);
                    item.Status = Convert.ToBoolean(reader["RECORDSTATUS"]);
                    productList.Add(item);
                }
            }
            return productList;
        }
    }
}
