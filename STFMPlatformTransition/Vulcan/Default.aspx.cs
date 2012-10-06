using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace STFMPlatformTransition
{
    public partial class Vulcan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            txtUserID.Focus();
        }

        protected void CheckLoginCredentials(object sender, EventArgs e)
        {
            bool IsAdmin = false;
            Session["IsLoggedIn"] = "false";
            Session["ViewMode"] = "Normal";

            try
            {
                SqlConnection conn;
                conn = new SqlConnection(ConfigurationManager.AppSettings["CMSConnection"].ToString());
                conn.Open();

                string strSql = "";
                strSql = "select * from users where userid = '" + txtUserID.Text.Trim() + "' and password = '" + txtPassword.Text.Trim() + "'";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Session["IsLoggedIn"] = "true";
                    Session["UserID"] = txtUserID.Text.Trim();
                    
                    IsAdmin = (dr["IsAdmin"] != null && dr["IsAdmin"].ToString() != "") ? Convert.ToBoolean(dr["IsAdmin"]) : false;

                    Session["IsAdmin"] = IsAdmin.ToString();

                    cmd = null;
                    dr.Close();
                    dr = null;

                    conn.Close();
                    conn = null;
                }
                else
                {
                    lblMessage.Text = "Userid and password is not correct";

                    dr = null;
                    cmd = null;

                    conn.Close();
                    conn = null;
                }

            
                string sLogEntry = "SUCCESS - " + DateTime.Now.ToString() + " Method: CheckLoginCredentials. " + User + " successfully authenticated: " + DateTime.Now.ToString();
                MakeLogEntry(sLogEntry);
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message.ToString();

                string sLogEntry = "ERROR - " + DateTime.Now.ToString() + " Method: CheckLoginCredentials. " + User + " failed: " + DateTime.Now.ToString() + " Error: " + ex.Message.ToString();
                MakeLogEntry(sLogEntry);
            }

            if (IsAdmin == true)
            {
                Response.Redirect("Forge.aspx");
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
        }

        private void MakeLogEntry(string sEntry)
        {
            string sLogDirectory = HttpContext.Current.Server.MapPath("../") + "\\LogFiles\\";
            string sLogFileName = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Year.ToString() + ".log";
            string sLogFilePath = sLogDirectory + sLogFileName;

            string sLogContent = (sEntry + "\n");
            System.IO.File.AppendAllText(sLogFilePath, sLogContent);
        }


    }
}