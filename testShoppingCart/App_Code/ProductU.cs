using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


public class ProductU
    {
        public static List<Product2> GetAllproducts()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "select * from Products",
                Common.DBConnectionString);

            DataTable dt = new DataTable();

            da.Fill(dt);

            //方法一
            //List<Product> prodLIst = new List<Product>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    prodLIst.Add(new Product()
            //    {
            //        Id = Convert.ToInt32(row["id"]),
            //        Name = row["Name"].ToString(),
            //        Price = (int)row["Price"],
            //        Amount = (int)row["Amount"],
            //        ImageFileName = row["ImageFileName"] is DBNull ? "" : row["ImageFileName"].ToString()
            //    });
            //}

            //方法2 LINQ
            var query = from row in dt.AsEnumerable()
                        select new Product2()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Name = row["Name"].ToString(),
                            Price = (int)row["Price"],
                            Amount = (int)row["Amount"],
                            ImageFileName = row["ImageFileName"] is DBNull ? "" : row["ImageFileName"].ToString()
                        };
            List<Product2> prodList = query.ToList();
            return prodList;

        }


        public static List<Product2> GetAllproductsByName(string name)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "select * from Products where Name Like '%' + @Name + '%'",
                Common.DBConnectionString);

            da.SelectCommand.Parameters.AddWithValue("@Name", name);

            DataTable dt = new DataTable();

            da.Fill(dt);

            //方法一
            //List<Product> prodLIst = new List<Product>();
            //foreach (DataRow row in dt.Rows)
            //{
            //    prodLIst.Add(new Product()
            //    {
            //        Id = Convert.ToInt32(row["id"]),
            //        Name = row["Name"].ToString(),
            //        Price = (int)row["Price"],
            //        Amount = (int)row["Amount"],
            //        ImageFileName = row["ImageFileName"] is DBNull ? "" : row["ImageFileName"].ToString()
            //    });
            //}

            //方法2 LINQ
            var query = from row in dt.AsEnumerable()
                        select new Product2()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Name = row["Name"].ToString(),
                            Price = (int)row["Price"],
                            Amount = (int)row["Amount"],
                            ImageFileName = row["ImageFileName"] is DBNull ? "" : row["ImageFileName"].ToString()
                        };
            List<Product2> prodList = query.ToList();
            return prodList;

        }

        public static void InsertProduct(Product2 p)
        {
            SqlConnection cn = new SqlConnection(Common.DBConnectionString);
            SqlCommand cmd = new SqlCommand(
                "insert into Products (Name , Price , Amount , ImageFileName) values (@Name , @Price , @Amount , @ImageFileName)", cn);

            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Price", p.Price);
            cmd.Parameters.AddWithValue("@ImageFileName", p.ImageFileName);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();

        }
    }
