using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Net;

namespace Blood
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
       
       
        
        string varemail;
        void setEmail(string s)
        {
            varemail = s;
        }
        string getEmail()
        {
            return varemail;
        }

        [WebMethod]
        public bool LoginFunc(string email, string password)
        {

            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql = new SqlCommand("select password from [User] where email=@email", con);
            con.Open();
            CmdSql.CommandType = System.Data.CommandType.Text;
            CmdSql.Parameters.AddWithValue("@email", email);
            SqlDataReader dr = CmdSql.ExecuteReader();
            setEmail(email);
            string enteredPassword = password;
            string s = "";
            if (dr.Read())
            {
                s = dr[0].ToString();
                if (enteredPassword == s)
                {
                    return true;
                }
            }
            dr.Close();
            con.Close();

            return false;
        }
        [WebMethod]
        public DietPlanClass ViewDietPlan(string type)
        {

            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql = new SqlCommand("select * from [DietPlan] where Type=@type", con);
            con.Open();
            CmdSql.CommandType = System.Data.CommandType.Text;
            CmdSql.Parameters.AddWithValue("@type", type);
            SqlDataReader dr = CmdSql.ExecuteReader();

            DietPlanClass plan = new DietPlanClass();

            if (dr.Read())
            {
                plan.id = int.Parse(dr[0].ToString());
                plan.type = dr[1].ToString();
                plan.veges = dr[2].ToString();
                plan.fruit = dr[3].ToString();
                plan.meat = dr[4].ToString();
                plan.drinks = dr[5].ToString();
                plan.milk = dr[6].ToString();
            }
            dr.Close();
            con.Close();
            return plan;
        }

      

    }

}

