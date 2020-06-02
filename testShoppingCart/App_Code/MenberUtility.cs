using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// MenberUtility 的摘要描述
/// </summary>
public class MenberUtility
{
    public static List<Member> GetAllMenbers()
    {
        SqlDataAdapter da = new SqlDataAdapter(
            "select * from Members",
            Common.DBConnectionString);

        DataTable dt = new DataTable();

        da.Fill(dt);

        //方法2 LINQ
        var query = from row in dt.AsEnumerable()
                    select new Member()
                    {
                        Id = Convert.ToInt32(row["id"]),
                        UserName = row["UserName"].ToString(),
                        Password = row["Password"].ToString(),
                        ImageFileName = row["ImageFileName"] is DBNull ? "" : row["ImageFileName"].ToString()
                    };
        List<Member> memberList = query.ToList();
        return memberList;

    }

    public static void InsertMembers(Member m)
    {
        SqlConnection cn = new SqlConnection(Common.DBConnectionString);
        SqlCommand cmd = new SqlCommand(
            "insert into Members (UserName , Password , ImageFileName) values (@UserName , @Password , @ImageFileName)", cn);

        cmd.Parameters.AddWithValue("@UserName", m.UserName);
        cmd.Parameters.AddWithValue("@Password", m.Password);
        cmd.Parameters.AddWithValue("@ImageFileName", m.ImageFileName);

        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();

    }
}