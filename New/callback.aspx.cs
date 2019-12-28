using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace New
{
    public partial class callback : System.Web.UI.Page
    {
        public const string FaceBookAppKey = "9e1b5e048e846e04bded170cf9ac01fc";
        private char[] userInfo;
        public static string emaill = "";
        public static string namee = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["access_token"])) return; //ERROR! No token returned from Facebook!!
            string json = GetFacebookUserJSON(Request.QueryString["access_token"]);


            //and Deserialize the JSON response
            JavaScriptSerializer js = new JavaScriptSerializer();

            FacebookUser oUser = js.Deserialize<FacebookUser>(json);

            //let's send an http-request to facebook using the token            
            if (oUser != null)
            {
                Response.Write("Welcome, " + oUser.name);
                // Response.Write("<br />id, " + oUser.id);
                Response.Write("<br />Email : " + oUser.email);
                emaill = oUser.email;
                namee = oUser.name;
                Response.Write("<br />First_name: " + oUser.first_name);
                Response.Write("<br />Last_name: " + oUser.last_name);
                //Response.Write("<br />Gender: " + oUser.gender);
                //Response.Write("<br />Link: " + oUser.link);
                
            }

        }
        private static string GetFacebookUserJSON(string access_token)
        {
            string url = string.Format("https://graph.facebook.com/me?access_token={0}&fields=email,name,first_name,last_name,link,birthday,cover,devices,gender", access_token);

            WebClient wc = new WebClient();
            Stream data = wc.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            return s;
        }
       
      
        protected void Button1_Click(object sender, EventArgs e)
        {



            

            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select email from [User]", con);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
            
                if (emaill==dataSet.Tables[0].Rows[i]["email"].ToString())
                {
                   Server.Transfer("~/Main_Form.aspx");
                }
            }
            con.Close();

            Server.Transfer("~/Register_FaceBook.aspx");
        }
    }
}