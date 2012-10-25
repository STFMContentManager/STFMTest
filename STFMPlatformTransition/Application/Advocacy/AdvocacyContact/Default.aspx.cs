using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace STFMAdvocacy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitForm(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();

            mail.To.Add("jpratt@stfm.org");
            mail.Subject = tbfname.Text + " " + tblname.Text + " has Advocated for Family Medicine";
            mail.From = new MailAddress("jpratt@stfm.org");

            StringBuilder body = new StringBuilder();

            body.Append("Name: " + ddltitle.SelectedItem.Text + " " + tbfname.Text + " " + tbmname.Text + " " + tblname.Text);
            body.AppendLine();
            body.Append("Email: " + tbemail.Text);
            body.AppendLine();
            body.Append("Address1: " + tbaddr1.Text);
            body.AppendLine();

            if (string.IsNullOrEmpty(tbaddr2.Text) == false)
            {
                body.Append("Address2: " + tbaddr2.Text);
                body.AppendLine();
            }

            body.Append("City: " + tbaddrcity.Text);
            body.AppendLine();
            body.Append("State: " + ddladdrstate.SelectedItem.Text);
            body.AppendLine();
            body.Append("Zip Code: " + tbaddrzip.Text);
            body.AppendLine();
            body.Append("Legislator Name: " + tblegislatorname.Text);
            body.AppendLine();
            body.Append("How contacted: " + ddlcontact.SelectedItem.Text);
            body.AppendLine();
            body.Append("Date Contacted: " + tbcontactdate.Text);
            body.AppendLine();
            body.Append("Issue Discussed: " + tbdiscuss.Text);
            body.AppendLine();
            body.Append("Did the legislator follow up? " + ddlfollowup.SelectedItem.Text);
            body.AppendLine();
            body.Append("Description: " + tbdescribe.Text);
            body.AppendLine();

            mail.Body = body.ToString();

            try
            {

                NetworkCredential nc = new NetworkCredential("AdminEmail@IONPG.com", "AdminEmailPass1");
                SmtpClient client = new System.Net.Mail.SmtpClient("smtpout.asia.secureserver.net");

                client.UseDefaultCredentials = false;
                client.Port = 80;
                client.Credentials = nc;

                client.Send(mail);

                nc = null;
                client = null;
            }
            catch
            {
            }

            
            mail = null;
            body = null;
            
        }
    }
}