using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class Update_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetData();

        }
        private void GetData()
        {
            ServiceReference2.Iwcf_serviceClient s = new ServiceReference2.Iwcf_serviceClient();
            //ServiceReference2.WCFServiceClient s = new WcfService.WCFServiceClient();

            ServiceReference2.UserClass user = new ServiceReference2.UserClass();
            if (Login_Form.emaill == "")
            {
                user = s.ViewProfile(callback.emaill);

            }
            else
            {

                user = s.ViewProfile(Login_Form.emaill);


            }
          
            TextBox_email.Text = user.email;
            TextBox_Name.Text = user.name;
            TextBox_age.Text = (user.age).ToString();
            TextBox_weight.Text = (user.weight).ToString();
            TextBox_Gender.Text = (user.gender).ToString();
            TextBox_pass.Text = (user.password).ToString();
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            Server.Transfer("~/Main_Form.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            

            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql = new SqlCommand($"UPDATE [User] set  name=@name, age=@age, weight=@weight," +
                                            $"gender=@gender, password=@password where email=@email", con);
            con.Open();


            CmdSql.Parameters.AddWithValue("@email", TextBox_email.Text);
            if(TextBox1.Text=="")
            {
               CmdSql.Parameters.AddWithValue("@name", TextBox_Name.Text);

            }
            else
            {
                CmdSql.Parameters.AddWithValue("@name", TextBox1.Text);
            }
            if(TextBox3.Text=="")
            {
                CmdSql.Parameters.AddWithValue("@age", int.Parse(TextBox_age.Text));
            }
            else
            {
                CmdSql.Parameters.AddWithValue("@age", int.Parse(TextBox3.Text));
            }
            if (TextBox5.Text == "")
            {
                CmdSql.Parameters.AddWithValue("@weight", int.Parse(TextBox_weight.Text));
            }
            else
            {
                CmdSql.Parameters.AddWithValue("@weight", int.Parse(TextBox5.Text));
            }
            if (TextBox6.Text == "")
            {
                CmdSql.Parameters.AddWithValue("@gender", TextBox_Gender.Text);
            }
            else
            {
                CmdSql.Parameters.AddWithValue("@gender", TextBox6.Text);
            }
            if (TextBox4.Text == "")
            {
                CmdSql.Parameters.AddWithValue("@password", TextBox_pass.Text);
            }
            else
            {
                CmdSql.Parameters.AddWithValue("@password", TextBox4.Text);
            }

           
            CmdSql.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('updated')</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            
        }
    }
}