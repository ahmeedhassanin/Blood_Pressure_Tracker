using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class View_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ServiceReference2.Iwcf_serviceClient ser = new ServiceReference2.Iwcf_serviceClient();

            ServiceReference2.UserClass user = new ServiceReference2.UserClass();
            if (Login_Form.emaill == "")
            {
                user = ser.ViewProfile(callback.emaill);
               
            }
            else
            {

                user = ser.ViewProfile(Login_Form.emaill);
                

            }
                Label1.Text = user.email;
                Label2.Text = user.name;
                Label3.Text = (user.age).ToString();
                Label4.Text = (user.weight).ToString();
                Label5.Text = (user.gender).ToString();

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Main_Form.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}