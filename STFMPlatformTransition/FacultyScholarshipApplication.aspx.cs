using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace STFMPlatformTransition
{
    public partial class FacultyScholarshipApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblThankYouMessage.Visible = false;
                GetStates();
                //GetApplication();
            }
        }

        private void GetStates()
        {
            SqlConnection conn = new SqlConnection(WebConfigurationManager.AppSettings["ISISConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetStates", conn);

            ddlStates.DataValueField = "ST";
            ddlStates.DataTextField = "Name";

            ddlStates.DataSource = cmd.ExecuteReader();
            ddlStates.DataBind();

            conn.Close();

            cmd = null;
            conn = null;
        }

        public void SubmitApplication(object sender, EventArgs e)
        {
            string FirstName = txtFirstName.Text.Trim();
            string LastName = txtLastName.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Phone = txtPhone.Text.Trim();
            string Institution = txtInstitution.Text.Trim();
            string City = txtCity.Text.Trim();
            string State = ddlStates.SelectedValue.ToString();
            int Zip = Convert.ToInt32(txtZip.Text.Trim());
            int AttendConference = Convert.ToInt32(rblAttendConference.SelectedValue);
            int AdvocacyCompleted = Convert.ToInt32(rblCompletedAdvocacyCourse.SelectedValue);

            int length = 0;
            FileStream newFile;
    
            length = inptCVDocument.PostedFile.ContentLength;
            byte[] CVDocument = new byte[length];
            inptCVDocument.PostedFile.InputStream.Read(CVDocument, 0, length);
            string[] CVDocumenFileNameVals = inptCVDocument.Value.Split('\\');
            string CVDocumentFileName = CVDocumenFileNameVals[CVDocumenFileNameVals.Length - 1].ToString();
            //newFile = new FileStream("C:\\SavedFile.doc", FileMode.Create);
            //newFile.Write(CVDocument, 0, CVDocument.Length);
            //newFile.Close();

            length = inptWhyAttendDocument.PostedFile.ContentLength;
            byte[] WhyAttendDocument = new byte[length];
            inptWhyAttendDocument.PostedFile.InputStream.Read(WhyAttendDocument, 0, length);
            string[] WhyAttendDocumenFileNameVals = inptWhyAttendDocument.Value.Split('\\');
            string WhyAttendDocumentFileName = WhyAttendDocumenFileNameVals[WhyAttendDocumenFileNameVals.Length - 1].ToString();
            //newFile = new FileStream("C:\\SavedFile.doc", FileMode.Create);
            //newFile.Write(WhyAttendDocument, 0, WhyAttendDocument.Length);
            //newFile.Close();

            length = inptDirLORDocument.PostedFile.ContentLength;
            byte[] DirLORDocument = new byte[length];
            inptDirLORDocument.PostedFile.InputStream.Read(DirLORDocument, 0, length);
            string[] DirLorDocumenFileNameVals = inptDirLORDocument.Value.Split('\\');
            string DirLORDocumentFileName = DirLorDocumenFileNameVals[DirLorDocumenFileNameVals.Length - 1].ToString();
            //newFile = new FileStream("C:\\SavedFile.doc", FileMode.Create);
            //newFile.Write(DirLORDocument, 0, DirLORDocument.Length);
            //newFile.Close();

            length = inptAdvExpDocument.PostedFile.ContentLength;
            byte[] AdvExpDocument = new byte[length];
            inptAdvExpDocument.PostedFile.InputStream.Read(AdvExpDocument, 0, length);
            string[] AdvExpDocumenFileNameVals = inptAdvExpDocument.Value.Split('\\');
            string AdvExpDocumentFileName = AdvExpDocumenFileNameVals[AdvExpDocumenFileNameVals.Length - 1].ToString();
            //newFile = new FileStream("C:\\SavedFile.doc", FileMode.Create);
            //newFile.Write(AdvExpDocument, 0, AdvExpDocument.Length);
            //newFile.Close();

            SqlConnection conn = new SqlConnection(WebConfigurationManager.AppSettings["ISISConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertFMCCApplication";

            SqlParameter param = null;

            param = cmd.Parameters.Add("@FName", System.Data.SqlDbType.VarChar);
            param.Value = FirstName;
            param = cmd.Parameters.Add("@LName", System.Data.SqlDbType.VarChar);
            param.Value = LastName;
            param = cmd.Parameters.Add("@Email", System.Data.SqlDbType.VarChar);
            param.Value = Email;
            param = cmd.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar);
            param.Value = Phone;
            param = cmd.Parameters.Add("@Institution", System.Data.SqlDbType.VarChar);
            param.Value = Institution;
            param = cmd.Parameters.Add("@City", System.Data.SqlDbType.VarChar);
            param.Value = City;
            param = cmd.Parameters.Add("@State", System.Data.SqlDbType.VarChar);
            param.Value = State;
            param = cmd.Parameters.Add("@Zip", System.Data.SqlDbType.Int);
            param.Value = Zip;
            param = cmd.Parameters.Add("@AttendConference", System.Data.SqlDbType.Bit);
            param.Value = AttendConference;
            param = cmd.Parameters.Add("@AdvocacyCompleted", System.Data.SqlDbType.Bit);
            param.Value = AdvocacyCompleted;
            param = cmd.Parameters.Add("@CVDocument", System.Data.SqlDbType.VarBinary);
            param.Value = CVDocument;
            param = cmd.Parameters.Add("@CVDocumentFileName", System.Data.SqlDbType.VarChar);
            param.Value = CVDocumentFileName;
            param = cmd.Parameters.Add("@WhyAttendDocument", System.Data.SqlDbType.VarBinary);
            param.Value = WhyAttendDocument;
            param = cmd.Parameters.Add("@WhyAttendDocumentFileName", System.Data.SqlDbType.VarChar);
            param.Value = WhyAttendDocumentFileName;
            param = cmd.Parameters.Add("@DirLORDocument", System.Data.SqlDbType.VarBinary);
            param.Value = DirLORDocument;
            param = cmd.Parameters.Add("@DirLORDocumentFileName", System.Data.SqlDbType.VarChar);
            param.Value = DirLORDocumentFileName;
            param = cmd.Parameters.Add("@AdvExpDocument", System.Data.SqlDbType.VarBinary);
            param.Value = AdvExpDocument;
            param = cmd.Parameters.Add("@AdvExpDocumentFileName", System.Data.SqlDbType.VarChar);
            param.Value = AdvExpDocumentFileName;
            param = cmd.Parameters.Add("@DateCreated", System.Data.SqlDbType.DateTime);
            param.Value = DateTime.Now.ToString();

            cmd.ExecuteNonQuery();

            conn.Close();

            cmd = null;
            conn = null;

            MailMessage mail = new MailMessage();

            mail.To.Add("hwittenberg@stfm.org");
            mail.Bcc.Add("grichards@stfm.org");
            mail.Subject = "A FMCC Application has been submitted";
            mail.From = new MailAddress("grichards@stfm.org");

            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + FirstName + " " + LastName);
            sb.AppendLine();
            sb.Append("Email: " + Email);
            sb.AppendLine();
            sb.Append("Phone: " + Phone);
            sb.AppendLine();
            sb.Append("Institution: " + Institution);
            sb.AppendLine();
            sb.Append("City: " + City);
            sb.AppendLine();
            sb.Append("State: " + State);
            sb.AppendLine();
            sb.Append("Zip: " + Zip);
            sb.AppendLine();
            sb.Append("Will you attend the May 14-15, 2013 conference in Washington, DC: " + (AttendConference == 1 ? "Yes" : "No"));
            sb.AppendLine();
            sb.Append("Have you completed the online advocacy course: " + (AdvocacyCompleted == 1 ? "Yes" : "No"));
            sb.AppendLine();

            mail.Body = sb.ToString();

            HttpPostedFile pfCVDoc;
            HttpPostedFile pfWhyAttendDoc;
            HttpPostedFile pfDirLORDoc;
            HttpPostedFile pfAdvExpDoc;

            if (inptCVDocument.Value.ToString().Trim() != "")
            {
                pfCVDoc = inptCVDocument.PostedFile;
                pfCVDoc.SaveAs(Server.MapPath("FMCCApplicationDocuments/" + pfCVDoc.FileName.Replace(" ", "")));
                mail.Attachments.Add(new Attachment(Server.MapPath("FMCCApplicationDocuments/" + pfCVDoc.FileName.Replace(" ", ""))));
            }

            if (inptWhyAttendDocument.Value.ToString().Trim() != "")
            {
                pfWhyAttendDoc = inptWhyAttendDocument.PostedFile;
                pfWhyAttendDoc.SaveAs(Server.MapPath("FMCCApplicationDocuments/" + pfWhyAttendDoc.FileName.Replace(" ", "")));
                mail.Attachments.Add(new Attachment(Server.MapPath("FMCCApplicationDocuments/" + pfWhyAttendDoc.FileName.Replace(" ", ""))));
            }

            if (inptDirLORDocument.Value.ToString().Trim() != "")
            {
                pfDirLORDoc = inptDirLORDocument.PostedFile;
                pfDirLORDoc.SaveAs(Server.MapPath("FMCCApplicationDocuments/" + pfDirLORDoc.FileName.Replace(" ", "")));
                mail.Attachments.Add(new Attachment(Server.MapPath("FMCCApplicationDocuments/" + pfDirLORDoc.FileName.Replace(" ", ""))));
            }

            if (inptAdvExpDocument.Value.ToString().Trim() != "")
            {
                pfAdvExpDoc = inptAdvExpDocument.PostedFile;
                pfAdvExpDoc.SaveAs(Server.MapPath("FMCCApplicationDocuments/" + pfAdvExpDoc.FileName.Replace(" ", "")));
                mail.Attachments.Add(new Attachment(Server.MapPath("FMCCApplicationDocuments/" + pfAdvExpDoc.FileName.Replace(" ", ""))));
            }

            //mail.Attachments.Add(new Attachment(pfCVDoc));
            //mail.Attachments.Add(new Attachment(pfWhyAttendDocument.Value.ToString()));
            //mail.Attachments.Add(new Attachment(pfDirLORDocument.Value.ToString()));
            //mail.Attachments.Add(new Attachment(pfAdvExpDocument.Value.ToString()));

            NetworkCredential nc = new NetworkCredential("AdminEmail@IONPG.com", "AdminEmailPass1");
            SmtpClient client = new System.Net.Mail.SmtpClient("smtpout.asia.secureserver.net");

            client.UseDefaultCredentials = false;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 80;
            client.Credentials = nc;
            //client.EnableSsl = true;

            client.Send(mail);

            nc = null;
            client = null;
            mail = null;

            form1.Visible = false;
            lblThankYouMessage.Visible = true;
        }

        public void GetApplication()
        {
            string FirstName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Institution = "";
            string City = "";
            string State = "";
            int Zip = 0;
            int AttendConference = 0;
            int AdvocacyCompleted = 0;
            byte[] CVDocument;
            string CVDocumentFileName;
            byte[] WhyAttendDocument;
            string WhyAttendDocumentFileName;
            byte[] DirLORDocument;
            string DirLORDocumentFileName;
            byte[] AdvExpDocument;
            string AdvExpDocumentFileName;

            SqlConnection conn = new SqlConnection(WebConfigurationManager.AppSettings["ISISConnection"].ToString());
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandType = System.Data.CommandType.Text; //.StoredProcedure;
            cmd.CommandText = "select * from FMCCApplication";

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                FirstName = rdr["FName"].ToString();
                LastName = rdr["LName"].ToString();
                Email = rdr["Email"].ToString();
                Phone = rdr["Phone"].ToString();
                Institution = rdr["Institution"].ToString();
                City = rdr["City"].ToString();
                State = rdr["State"].ToString();
                Zip = Convert.ToInt32(rdr["Zip"].ToString());
                AttendConference = Convert.ToInt32(rdr["AttendConference"].ToString() == "true" ? 1 : 0);
                AdvocacyCompleted = Convert.ToInt32(rdr["AdvocacyCompleted"].ToString() == "true" ? 1 : 0);

                FileStream newFile;

                CVDocument = (byte[])rdr["CVDocument"];
                CVDocumentFileName = Server.MapPath("") + "\\FMCCApplicationDocuments\\" + FirstName + "_" + LastName + "_" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace(" ", "") + rdr["CVDocumentFileName"].ToString();
                newFile = new FileStream(CVDocumentFileName, FileMode.Create);
                newFile.Write(CVDocument, 0, CVDocument.Length);
                newFile.Close();
                
                WhyAttendDocument = (byte[])rdr["WhyAttendDocument"];
                WhyAttendDocumentFileName = Server.MapPath("") + "\\FMCCApplicationDocuments\\" + FirstName + "_" + LastName + "_" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace(" ", "") + rdr["WhyAttendDocumentFileName"].ToString();
                newFile = new FileStream(WhyAttendDocumentFileName, FileMode.Create);
                newFile.Write(WhyAttendDocument, 0, WhyAttendDocument.Length);
                newFile.Close();

                DirLORDocument = (byte[])rdr["DirLORDocument"];
                DirLORDocumentFileName = Server.MapPath("") + "\\FMCCApplicationDocuments\\" + FirstName + "_" + LastName + "_" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace(" ", "") + rdr["DirLORDocumentFileName"].ToString();
                newFile = new FileStream(DirLORDocumentFileName, FileMode.Create);
                newFile.Write(DirLORDocument, 0, DirLORDocument.Length);
                newFile.Close();

                AdvExpDocument = (byte[])rdr["AdvExpDocument"];
                AdvExpDocumentFileName = Server.MapPath("") + "\\FMCCApplicationDocuments\\" + FirstName + "_" + LastName + "_" + DateTime.Now.ToLongTimeString().Replace(":", "").Replace(" ", "") + rdr["AdvExpDocumentFileName"].ToString();
                newFile = new FileStream(AdvExpDocumentFileName, FileMode.Create);
                newFile.Write(AdvExpDocument, 0, AdvExpDocument.Length);
                newFile.Close();

            }

            rdr.Close();
            conn.Close();

            cmd = null;
            rdr = null;
            conn = null;

        }
    
    }
}