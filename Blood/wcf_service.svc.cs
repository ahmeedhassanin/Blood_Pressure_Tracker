using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Blood
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "wcf_service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select wcf_service.svc or wcf_service.svc.cs at the Solution Explorer and start debugging.
    public class wcf_service : Iwcf_service
    {
        public UserClass ViewProfile(string email)
        {
            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True");
            SqlCommand CmdSql = new SqlCommand("select * from [User] where email=@email", con);
            con.Open();
            CmdSql.CommandType = System.Data.CommandType.Text;
            CmdSql.Parameters.AddWithValue("@email", email);
            SqlDataReader dr = CmdSql.ExecuteReader();

            UserClass user = new UserClass();

            if (dr.Read())
            {

                user.email = dr[0].ToString();
                user.name = dr[1].ToString();
                user.age = int.Parse(dr[2].ToString());
                user.weight = int.Parse(dr[3].ToString());
                user.gender = dr[4].ToString();
                user.password = dr[5].ToString();
            }
            dr.Close();
            con.Close();
            return user;
        }
        public void Register(string name, int age, int weight, string gender
                               , string email, string password)
        {
            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql = new SqlCommand("INSERT INTO [User] (email,name,age,weight,gender,password) VALUES (@email, @name, @age, @weight, @gender, @password)", con);
            con.Open();
            CmdSql.Parameters.AddWithValue("@email", email);
            CmdSql.Parameters.AddWithValue("@name", name);
            CmdSql.Parameters.AddWithValue("@age", age);
            CmdSql.Parameters.AddWithValue("@weight", weight);
            CmdSql.Parameters.AddWithValue("@gender", gender);
            CmdSql.Parameters.AddWithValue("@password", password);
            CmdSql.ExecuteNonQuery();
            con.Close();
        }
    }
}
