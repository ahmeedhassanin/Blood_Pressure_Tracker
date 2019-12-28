using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class All_DietPlans_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql = new SqlCommand("select * from [Blood] where User_email=@User_email", con);
            con.Open();
            CmdSql.CommandType = System.Data.CommandType.Text;
            if (Login_Form.emaill == "")
            {
                CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
            }
            else
            {

                CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

            }
            
            SqlDataReader dr = CmdSql.ExecuteReader();
            GridView2.DataSource = dr;
            GridView2.DataBind();
           // dr.Close();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Main_Form.aspx");
        }
    }
}