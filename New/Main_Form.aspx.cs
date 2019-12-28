using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class Main_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/chart.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/add_bloodpressure.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/View_Profile.aspx");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Update_Profile.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (add_bloodpressure.pressure == "")
            {
                Response.Write("<script>alert('please enter your blood_Pressure first')</script>");
            }
            else
            {
                Server.Transfer("~/View_DietPlan.aspx");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/All_DietPlans_Form.aspx");
        }
    }
}