using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISIS
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ISISLogic iLogic = new ISISLogic();

                ddlProjectActNames.DataSource = iLogic.GetProjects();
                ddlProjectActNames.DataBind();

                lblYearPrevious.Text = iLogic.GetYearValue(-1);
                lblYearCurrent.Text = iLogic.GetYearValue(0);
                lblYearNext.Text = iLogic.GetYearValue(1);

                iLogic = null;
            }
        }

        protected void GetProject(object sender, EventArgs e)
        {
            ISISLogic iLogic = new ISISLogic();

            int iId = Convert.ToInt32(((DropDownList)sender).SelectedValue.ToString());
            Project objProject = iLogic.GetProject(iId);

            int iIndex = objProject.StaffTime == 0 ? 0 : (objProject.StaffTime - 1);

            rblStaffTime.Items[(iIndex)].Selected = true;

            txtNumPartsPrevious.Text = objProject.NumPartsPrevious.ToString();
            txtNetProfitPreviousQ1.Text = objProject.NetProfitPreviousQ1.ToString();
            txtNetProfitPreviousQ2.Text = objProject.NetProfitPreviousQ2.ToString();
            txtNetProfitPreviousQ3.Text = objProject.NetProfitPreviousQ3.ToString();
            txtNetProfitPreviousQ4.Text = objProject.NetProfitPreviousQ4.ToString();

            txtNumPartsCurrent.Text = objProject.NumPartsCurrent.ToString();
            txtNetProfitCurrentQ1.Text = objProject.NetProfitCurrentQ1.ToString();
            txtNetProfitCurrentQ2.Text = objProject.NetProfitCurrentQ2.ToString();
            txtNetProfitCurrentQ3.Text = objProject.NetProfitCurrentQ3.ToString();
            txtNetProfitCurrentQ4.Text = objProject.NetProfitCurrentQ4.ToString();

            txtNumPartsNext.Text = objProject.NumPartsNext.ToString();
            txtNetProfitNextQ1.Text = objProject.NetProfitNextQ1.ToString();
            txtNetProfitNextQ2.Text = objProject.NetProfitNextQ2.ToString();
            txtNetProfitNextQ3.Text = objProject.NetProfitNextQ3.ToString();
            txtNetProfitNextQ4.Text = objProject.NetProfitNextQ4.ToString();

            taImpact.Value = objProject.Impact.ToString();
            taComments.Value = objProject.Comments.ToString();

            iLogic = null;
        }

        protected void SaveChanges(object sender, EventArgs e)
        {
            if (ddlProjectActNames.SelectedIndex == 0)
            {
                RegisterStartupScript("msg", "<script language='javascript'>alert('You must choose a Project to edit')</script>");
            }
            else if(rblStaffTime.SelectedValue == "")
            {
                RegisterStartupScript("msg", "<script language='javascript'>alert('You must choose an option for Staff Time')</script>");
            }
            else {

                Project sProjectValues = new Project();

                sProjectValues = new Project();
                sProjectValues.Id = Convert.ToInt32(ddlProjectActNames.SelectedValue.ToString());
                sProjectValues.ProjectName = ddlProjectActNames.SelectedItem.Text.ToString();
                sProjectValues.StaffTime = Convert.ToInt32(rblStaffTime.SelectedValue.ToString());
                sProjectValues.NumPartsPrevious = txtNumPartsPrevious.Text.ToString();
                sProjectValues.NumPartsCurrent = txtNumPartsCurrent.Text.ToString();
                sProjectValues.NumPartsNext = txtNumPartsNext.Text.ToString();
                sProjectValues.NetProfitPreviousQ1 = Convert.ToInt32(txtNetProfitPreviousQ1.Text.ToString() == "" ? "0" : txtNetProfitPreviousQ1.Text.ToString());
                sProjectValues.NetProfitPreviousQ2 = Convert.ToInt32(txtNetProfitPreviousQ2.Text.ToString() == "" ? "0" : txtNetProfitPreviousQ2.Text.ToString());
                sProjectValues.NetProfitPreviousQ3 = Convert.ToInt32(txtNetProfitPreviousQ3.Text.ToString() == "" ? "0" : txtNetProfitPreviousQ3.Text.ToString());
                sProjectValues.NetProfitPreviousQ4 = Convert.ToInt32(txtNetProfitPreviousQ4.Text.ToString() == "" ? "0" : txtNetProfitPreviousQ4.Text.ToString());
                sProjectValues.NetProfitCurrentQ1 = Convert.ToInt32(txtNetProfitCurrentQ1.Text.ToString() == "" ? "0" : txtNetProfitCurrentQ1.Text.ToString());
                sProjectValues.NetProfitCurrentQ2 = Convert.ToInt32(txtNetProfitCurrentQ2.Text.ToString() == "" ? "0" : txtNetProfitCurrentQ2.Text.ToString());
                sProjectValues.NetProfitCurrentQ3 = Convert.ToInt32(txtNetProfitCurrentQ3.Text.ToString() == "" ? "0" : txtNetProfitCurrentQ3.Text.ToString());
                sProjectValues.NetProfitCurrentQ4 = Convert.ToInt32(txtNetProfitCurrentQ4.Text.ToString() == "" ? "0" : txtNetProfitCurrentQ4.Text.ToString());
                sProjectValues.NetProfitNextQ1 = Convert.ToInt32(txtNetProfitNextQ1.Text.ToString() == "" ? "0" : txtNetProfitNextQ1.Text.ToString());
                sProjectValues.NetProfitNextQ2 = Convert.ToInt32(txtNetProfitNextQ2.Text.ToString() == "" ? "0" : txtNetProfitNextQ2.Text.ToString());
                sProjectValues.NetProfitNextQ3 = Convert.ToInt32(txtNetProfitNextQ3.Text.ToString() == "" ? "0" : txtNetProfitNextQ3.Text.ToString());
                sProjectValues.NetProfitNextQ4 = Convert.ToInt32(txtNetProfitNextQ4.Text.ToString() == "" ? "0" : txtNetProfitNextQ4.Text.ToString());
                sProjectValues.Impact = taImpact.Value.ToString();
                sProjectValues.Comments = taComments.Value.ToString();

                ISISLogic iLogic = new ISISLogic();
                iLogic.SaveProject(sProjectValues);
                iLogic = null;

                Response.Redirect("Default.aspx");
            }
        }

        protected void ManageProjects(object sender, EventArgs e)
        {
            Response.Redirect("ManageProjects.aspx");
        }

        protected void ViewInventoryReport(object sender, EventArgs e)
        {
            Response.Redirect("Report.aspx");
        }

    }
}