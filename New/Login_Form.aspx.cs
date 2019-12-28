using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class Login_Form : System.Web.UI.Page
    {
        



        protected void Page_Load(object sender, EventArgs e)
        {
            Mail.SendNotificatinMail();


        }
        public static string emaill = "";

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient ser = new ServiceReference1.WebService1SoapClient();

                emaill= TextBox1.Text;
            if (ser.LoginFunc(TextBox1.Text, TextBox2.Text))
            {
                Server.Transfer("~/Main_Form.aspx");
            }

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Server.Transfer("~/Register.aspx");
        }
        public string email
        {
            get
            {
                return TextBox1.Text;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Facebook.aspx");
        }
    }
}