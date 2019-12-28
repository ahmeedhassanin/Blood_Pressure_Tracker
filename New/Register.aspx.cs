using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace New
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            ServiceReference2.Iwcf_serviceClient s = new ServiceReference2.Iwcf_serviceClient();


            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" && TextBox6.Text != "" && RadioButtonList1.Text != "")
            {
                if (TextBox4.Text == TextBox5.Text)
                {


                    s.Register(TextBox1.Text, int.Parse(TextBox3.Text.ToString())
                    , int.Parse((TextBox2.Text).ToString()), RadioButtonList1.SelectedItem.Text.ToString()
                    , TextBox6.Text, TextBox4.Text);
                    Server.Transfer("~/Login_Form.aspx");
                }
                else
                {
                    Response.Write("<script>alert('please enter the password right')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('please enter the empty boxes')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Login_Form.aspx");
        }
    }
}