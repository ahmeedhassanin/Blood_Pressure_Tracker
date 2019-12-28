using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace New
{
    public partial class add_bloodpressure : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        public static string pressure = "";
     


        public static int agee()
        {
            int age = 0;
            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql2 = new SqlCommand("select age from [User] where email=@email", con);
            con.Open();
            CmdSql2.CommandType = System.Data.CommandType.Text;
            if (Login_Form.emaill == "")
            {
                CmdSql2.Parameters.AddWithValue("@email", callback.emaill);
            }
            else
            {

                CmdSql2.Parameters.AddWithValue("@email", Login_Form.emaill);

            }

            SqlDataReader dr = CmdSql2.ExecuteReader();
            while (dr.Read())
            {
               age=int.Parse(dr[0].ToString());

            }
            con.Close();
            dr.Close();
            return age;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            pressure = TextBox1.Text;
            string sample = pressure;

            string[] temp = sample.Split('/');
            int high = int.Parse(temp[0]);
            int low = int.Parse(temp[1]);
            if (TextBox1.Text != "")
            {
                SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
                SqlCommand CmdSql = new SqlCommand("INSERT INTO [Blood] (Blood_pressure,Date,User_email,Diet_ID) VALUES (@Blood_pressure,@Date,@User_email,@Diet_ID)", con);
                //---------------------------------------------------------------------------------



                //----------------------------------------------------------------------------------
                con.Open();
                if (agee() >= 6 && agee() <= 29)
                {
                    if (high >= 109 && high <= 133 && low >= 76 && low <= 85)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 1);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is normal')</script>");
                    }
                    else if (high < 109 && low < 76)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 2);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is low')</script>");
                    }
                    else if (high > 133 && low > 85)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 3);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is high.You should go to the doctor to avoid Heartattack')</script>");
                    }



                }
                else if (agee() >= 30 && agee() <= 39)
                {
                    if (high >= 111 && high <= 135 && low >= 78 && low <= 86)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 4);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is normal')</script>");
                    }
                    else if (high < 111 && low < 78)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 1);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is low')</script>");
                    }
                    else if (high > 135 && low > 86)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 2);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is high.You should go to the doctor to avoid Heartattack')</script>");
                    }


                }
                else if (agee() >= 40)
                {
                    if (high >= 121 && high <= 147 && low >= 83 && low <= 91)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 3);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is normal')</script>");
                    }
                    else if (high < 121 && low < 83)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 4);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is low')</script>");
                    }
                    else if (high > 147 && low > 91)
                    {
                        CmdSql.Parameters.AddWithValue("@Diet_ID", 2);
                        CmdSql.Parameters.AddWithValue("@Blood_pressure", TextBox1.Text.ToString());
                        CmdSql.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                        if (Login_Form.emaill == "")
                        {
                            CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
                        }
                        else
                        {

                            CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

                        }
                        CmdSql.ExecuteNonQuery();
                        con.Close();
                        Response.Write("<script>alert('Your BloodPressure is high.You should go to the doctor to avoid Heartattack')</script>");
                    }


                }

            }
            else
            {
                Response.Write("<script>alert('please add your BLood pressure')</script>");
            }
            
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Main_Form.aspx");
        }
    }
}