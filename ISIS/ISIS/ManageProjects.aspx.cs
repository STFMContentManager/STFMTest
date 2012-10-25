using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ISIS
{
    public partial class ManageProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ISISLogic iLogic = new ISISLogic();

                List<Project> lProjs = iLogic.GetProjects();
                iLogic = null;

                ddlRenameProjectNames.DataSource = lProjs;
                ddlRenameProjectNames.DataBind();

                ddlRemoveProjectNames.DataSource = lProjs;
                ddlRemoveProjectNames.DataBind();
            }
        }

        protected void CreateProject(object sender, EventArgs e)
        {
            ResetLabelDisplay();
            string sType = ConfigurationManager.AppSettings["CreateValidate"];

            if (!ValidateText(sType))
            {
                return;
            }
            else
            {
                ProcessRequest(sType);
            }
        }

        protected void RemoveProject(object sender, EventArgs e)
        {
            ResetLabelDisplay();
            string sType = ConfigurationManager.AppSettings["RemoveValidate"];

            if (!ValidateDropDownSelection(sType))
            {
                return;
            }

            ProcessRequest(sType);
        }

        protected void RenameProject(object sender, EventArgs e)
        {
            ResetLabelDisplay();
            string sType = ConfigurationManager.AppSettings["RenameValidate"];

            if(!ValidateDropDownSelection(sType))
            {
                return;
            }
            if (!ValidateText(sType))
            {
                return;
            }

            ProcessRequest(sType);
        }

        protected void UnlockRenameTextBox(object sender, EventArgs e)
        {
            txtRenameProjectNewName.Enabled = true;
        }

        protected void GoHome(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    
        protected void GoManageProjects(object sender, EventArgs e)
        {
            Response.Redirect("ManageProjects.aspx");
        }

        protected void ViewInventoryReport(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }

        private void ResetLabelDisplay()
        {
            lblCreateProjectName.ForeColor = System.Drawing.Color.Black;
            lblRemoveProjectName.ForeColor = System.Drawing.Color.Black;
            lblRenameProjectName.ForeColor = System.Drawing.Color.Black;
            lblRenameProjectNewName.ForeColor = System.Drawing.Color.Black;
        }
        private bool ValidateText(string sValidate)
        {
            switch (sValidate)
            {
                case "Create":
                    {
                        if (txtCreateProjectName.Text.Trim() == "")
                        {
                            RegisterStartupScript("Msg", "<script language='javascript'>alert('You Must Type in a Project Name Before you can Create a Project');</script>");
                            lblCreateProjectName.ForeColor = System.Drawing.Color.Red;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    case "Rename":
                        {
                            if (txtRenameProjectNewName.Text.Trim() == "")
                            {
                                RegisterStartupScript("Msg", "<script language='javascript'>alert('You Must Enter a New Name to Use when Renaming a Project');</script>");
                                lblRenameProjectNewName.ForeColor = System.Drawing.Color.Red;
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                    default:
                        {
                            return false;
                        }
            }
        }

        private bool ValidateDropDownSelection(string sValidate)
        {
            switch (sValidate)
            {
                case "Remove":
                    {
                        if (ddlRemoveProjectNames.SelectedIndex == 0)
                        {
                            RegisterStartupScript("Msg", "<script language='javascript'>alert('You Must Choose a Project to Remove from the Dropdown List');</script>");
                            lblRemoveProjectName.ForeColor = System.Drawing.Color.Red;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                case "Rename":
                    {
                        if (ddlRenameProjectNames.SelectedIndex == 0)
                        {
                            RegisterStartupScript("Msg", "<script language='javascript'>alert('You Must Choose a Project to Rename from the Dropdown List');</script>");
                            lblRenameProjectName.ForeColor = System.Drawing.Color.Red;
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                default:
                    {
                        return false;
                    }
            }
        }
        
        private void ProcessRequest(string sRequestType)
        {
            ISISLogic iLogic = new ISISLogic();

            string sResult = "";
            string sMessage = "";

            switch (sRequestType)
            {
                case "Create":
                    {
                        string sProjectName = txtCreateProjectName.Text.Trim();
                        sResult = iLogic.CreateProject(sProjectName);
                        sMessage = ConfigurationManager.AppSettings["Success"] + ConfigurationManager.AppSettings["SuccessCreatedProjectMsg"]; 
                        break;
                    }
                case "Remove":
                    {
                        int iProjectId = Convert.ToInt32(ddlRemoveProjectNames.SelectedValue);
                        sResult = iLogic.RemoveProject(iProjectId);
                        sMessage = ConfigurationManager.AppSettings["Success"] + ConfigurationManager.AppSettings["SuccessRemovedProjectMsg"];
                        break;
                    }
                case "Rename":
                    {
                        int iProjectId = Convert.ToInt32(ddlRenameProjectNames.SelectedValue);
                        string sProjectNewName = txtRenameProjectNewName.Text.Trim();
                        sResult = iLogic.RenameProject(iProjectId, sProjectNewName);
                        sMessage = ConfigurationManager.AppSettings["Success"] + ConfigurationManager.AppSettings["SuccessRenamedProjectMsg"];
                        break;
                    }
            }

            if (sResult != "")
            {
                DisplayPopUpMsg(sResult);
            }
            else
            {
                DisplaySuccessMessage(sMessage);
            }

            iLogic = null;
        }

        private void DisplaySuccessMessage(string sMessage)
        {
            tabProjectCreate.Visible = false;
            tabProjectRename.Visible = false;
            tabProjectRemove.Visible = false;
            tabMessage.Visible = true;

            lblMessage.Text = sMessage;
        }

        private void DisplayPopUpMsg(string sMsg)
        {
            RegisterStartupScript("msg", "<script language='javascript'>alert('" + sMsg + "');</script>");
        }

    }
}