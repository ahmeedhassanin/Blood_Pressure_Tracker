using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace New
{
    public class Mail
    {
        public static void SendEmail(string toAddress, string subject, string body, MailPriority priority, bool isHtml)//string toAddress
        {
            try
            {

                SmtpClient smtpClient = new SmtpClient();
                MailMessage message = new MailMessage();
                MailAddress fromAddress = new MailAddress("ahmedmohamed.ismaail@gmail.com");
                // You can specify the host name or ipaddress of your server
                smtpClient.Host = "smtp.gmail.com"; //you can also specify mail server IP address here
                smtpClient.Port = 587;

                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                NetworkCredential info = new NetworkCredential("ahmedmohamed.ismaail@gmail.com", "AMSAMSAMS");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
         
                smtpClient.Credentials = info;
                //From address will be given as a MailAddress Object
                message.From = fromAddress;
                message.Priority = priority;
            // To address collection of MailAddress
            string[] test;
            test = toAddress.Split(new char[] { ';' });
            
            string[] strArray = new string[test.Length];
            strArray = toAddress.Split(new char[] { ';' });
            if (strArray != null)
                foreach (string mailto in strArray)
                {
                    message.To.Add(mailto);
                }
         
                message.Subject = subject;
 
                //Body can be Html or text format
                //Specify true if it is html message
                message.IsBodyHtml = isHtml;

                // Message body content
                message.Body = body;


                // Send SMTP mail
                smtpClient.Send(message);
                
            }
            catch (Exception ee)
            {
                string str = ee.ToString();
            }
}
       public static void SendNotificatinMail()
        {
            
            string strSubject = "";
            strSubject = "Blood_pressure_tracker ";
            string strMailBody = "Hallo," + "<br/>"
            + "<br />" + "Wir hoffen, dass diese E-Mail Sie gut und bei guter Gesundheit findet";
            strMailBody += "<br/>" + "Vergessen Sie nicht, unsere Website zu öffnen, Ihren Blutdruck einzugeben und Ihren Diätplan zu kennen. " + "<br/>";
            strMailBody += "Freundliche Grüße," + "<br/>";
            strMailBody += "Manager." + "<br/>";

            SendEmail(getArrayOfEmails(),  strSubject, strMailBody, MailPriority.High, true);
        }
        
        public static string getArrayOfEmails()
        {
            string emails = "";  

            SqlConnection con = new SqlConnection($"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\project archi\\New folder\\Blood\\Blood\\App_Data\\DBnew.mdf\";Integrated Security=True;");
            con.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select email from [User]", con);
          //  SqlDataAdapter adapter = new SqlDataAdapter("select User_email from [Blood] where Date >=GetDate()+30 ", con);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                emails += dataSet.Tables[0].Rows[i]["email"].ToString();
                if(i < dataSet.Tables[0].Rows.Count - 1)
                {
                    emails += ";";
                   
                   
                }
            }
            
            
            // dr.Close();
            con.Close();
            return emails;
        }
     

    }
}