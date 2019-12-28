using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace New
{
    public partial class chart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetChartType();
                GetChartData();
            }
        }
        private void GetChartType()
        {
            foreach (int chartType in Enum.GetValues(typeof(SeriesChartType)))
            {
                ListItem li = new ListItem(Enum.GetName(typeof(SeriesChartType), chartType), chartType.ToString());
                DropDownList1.Items.Add(li);
            }
        }
        private void GetChartData()
        {
           



             //Login_Form.emaill;

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            SqlCommand CmdSql = new SqlCommand("select * from [Blood] where User_email=@User_email", con);
            if (Login_Form.emaill == "")
            {
                CmdSql.Parameters.AddWithValue("@User_email", callback.emaill);
            }
            else
            {

                CmdSql.Parameters.AddWithValue("@User_email", Login_Form.emaill);

            }
            Series series = Chart1.Series["Series1"];
            Series series2 = Chart1.Series["Series2"];
            con.Open();
            SqlDataReader dr = CmdSql.ExecuteReader();
            while (dr.Read())
            {
               


                string s=dr["Blood_Pressure"].ToString();
                string[] temp = s.Split('/');
                int first = int.Parse(temp[0]);
                int second = int.Parse(temp[1]);
                series.Points.AddXY( dr["Date"].ToString(), first);
                series2.Points.AddXY(dr["Date"].ToString(),second);
            }
            con.Close();
            dr.Close();
        }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChartData();
            Chart1.Series["Series1"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
            Chart1.Series["Series2"].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), DropDownList1.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Main_Form.aspx");
        }
    }
}
