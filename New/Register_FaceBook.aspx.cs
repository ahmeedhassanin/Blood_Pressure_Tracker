using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class Register_FaceBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference2.Iwcf_serviceClient s = new ServiceReference2.Iwcf_serviceClient();

            string pass = "0";
            //ServiceReference1.WebService1SoapClient obj = new ServiceReference1.WebService1SoapClient();

            s.Register(callback.namee,int.Parse(TextBox3.Text),int.Parse(TextBox2.Text),RadioButtonList1.SelectedItem.Text.ToString(),callback.emaill,pass);
            Server.Transfer("~/Main_Form.aspx");
        }
    }
}