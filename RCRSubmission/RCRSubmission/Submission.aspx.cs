using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Drawing;
using System.IO;
using RCRLogicNS;
using RCRDataNS;
using RCRWrappers;

namespace RCRSubmission
{
    public partial class Submission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    FillDropDownLists();
                }
                catch (Exception ex)
                {
                    MakeLogEntry(ex.Message);
                    DisplayErrorMessage();
                }
            }
            else
            {
                try
                {
                    ResetAllDisplays(true);
                }
                catch (Exception ex)
                {
                    MakeLogEntry(ex.Message);
                    DisplayErrorMessage();
                }
            }
        }

        private void FillDropDownLists()
        {
            RCRLogic objLogic = new RCRLogic();
            List<DropDownValue> lDropDownValues = new List<DropDownValue>();
            
            lDropDownValues = objLogic.GetStates();

            ddlStates.DataSource = lDropDownValues;
            ddlStates.DataTextField = "Name";
            ddlStates.DataValueField = "Id";
            ddlStates.DataBind();

            lDropDownValues = objLogic.GetDegrees();
            
            ddlDegrees.DataSource = lDropDownValues;
            ddlDegrees.DataTextField = "Name";
            ddlDegrees.DataValueField = "Id";
            ddlDegrees.DataBind();

            ddlCA1Degrees.DataSource = lDropDownValues;
            ddlCA1Degrees.DataTextField = "Name";
            ddlCA1Degrees.DataValueField = "Id";
            ddlCA1Degrees.DataBind();

            ddlCA2Degrees.DataSource = lDropDownValues;
            ddlCA2Degrees.DataTextField = "Name";
            ddlCA2Degrees.DataValueField = "Id";
            ddlCA2Degrees.DataBind();

            lDropDownValues = objLogic.GetPrograms();

            ddlAffiliation.DataSource = lDropDownValues;
            ddlAffiliation.DataTextField = "Name";
            ddlAffiliation.DataValueField = "Id";
            ddlAffiliation.DataBind();

            ddlCA1Affiliation.DataSource = lDropDownValues;
            ddlCA1Affiliation.DataTextField = "Name";
            ddlCA1Affiliation.DataValueField = "Id";
            ddlCA1Affiliation.DataBind();

            ddlCA2Affiliation.DataSource = lDropDownValues;
            ddlCA2Affiliation.DataTextField = "Name";
            ddlCA2Affiliation.DataValueField = "Id";
            ddlCA2Affiliation.DataBind();

            lDropDownValues = objLogic.GetCoreTopics();

            ddlCoreTopics.DataSource = lDropDownValues;
            ddlCoreTopics.DataTextField = "Name";
            ddlCoreTopics.DataValueField = "Id";
            ddlCoreTopics.DataBind();

            lDropDownValues = null;
            objLogic = null;
        }

        public void FillTopicsDropDownList(object Sender, EventArgs e)
        {
            RCRLogic objLogic = new RCRLogic();
            List<DropDownValue> lDropDownValues = new List<DropDownValue>();

            int iSelectedCoreTopicsID = Convert.ToInt32(ddlCoreTopics.SelectedValue);

            lDropDownValues = objLogic.GetTopics(iSelectedCoreTopicsID);

            ddlTopics.DataSource = lDropDownValues;
            ddlTopics.DataTextField = "Name";
            ddlTopics.DataValueField = "Id";
            ddlTopics.DataBind();

            ddlTopics.Enabled = true;

            lDropDownValues = null;
            objLogic = null;
        }


        protected void VerifySubmission(object sender, EventArgs e)
        {
            Boolean bReset = true;
            ResetAllDisplays(bReset);

            Boolean bValidated;
            Boolean bError = false;

            bValidated = VerifyFormat();

            if (bValidated)
            {
                bValidated = VerifyText();
            }
            if (bValidated)
            {
                bValidated = VerifySelections();
            }
            if (bValidated)
            {
                bValidated = VerifyTextCounts();
            }

            if (bValidated)
            {
                int iMembership = DetermineMembershipSelection();

                try
                {
                    RCRSubmissionObject objSubmission = new RCRSubmissionObject();

                    objSubmission.FName = txtFirstName.Text.Trim();
                    objSubmission.MName = txtMiddleName.Text.Trim();
                    objSubmission.LName = txtLastName.Text.Trim();
                    objSubmission.Title = txtTitle.Text.Trim();
                    objSubmission.DegreeId = ddlDegrees.SelectedIndex == 0 ? -1 : Convert.ToInt32(ddlDegrees.SelectedValue);
                    objSubmission.Membership = iMembership;
                    objSubmission.AffiliationId = ddlAffiliation.SelectedIndex == 0 ? -1 : Convert.ToInt32(ddlAffiliation.SelectedValue);
                    objSubmission.Address1 = txtAddress1.Text.Trim();
                    objSubmission.Address2 = txtAddress2.Text.Trim();
                    objSubmission.Address3 = txtAddress3.Text.Trim();
                    objSubmission.City = txtCity.Text.Trim();
                    objSubmission.State = ddlStates.SelectedValue;
                    objSubmission.Zip = Convert.ToInt32(txtZipCode.Text.Trim());
                    objSubmission.Email = txtEmailAddress.Text.Trim();
                    objSubmission.Phone = txtPhoneNumber.Text.Trim();
                    objSubmission.CA1FName = txtCA1FirstName.Text.Trim();
                    objSubmission.CA1MName = txtCA1MiddleName.Text.Trim();
                    objSubmission.CA1LName = txtCA1LastName.Text.Trim();
                    objSubmission.CA1DegreeId = ddlCA1Degrees.SelectedIndex == 0 ? -1 : Convert.ToInt32(ddlCA1Degrees.SelectedValue);
                    objSubmission.CA1AffiliationId = ddlCA1Affiliation.SelectedIndex == 0 ? -1 : Convert.ToInt32(ddlCA1Affiliation.SelectedValue);
                    objSubmission.CA2FName = txtCA2FirstName.Text.Trim();
                    objSubmission.CA2MName = txtCA2MiddleName.Text.Trim();
                    objSubmission.CA2LName = txtCA2LastName.Text.Trim();
                    objSubmission.CA2DegreeId = ddlCA2Degrees.SelectedIndex == 0 ? -1 : Convert.ToInt32(ddlCA2Degrees.SelectedValue);
                    objSubmission.CA2AffiliationId = ddlCA2Affiliation.SelectedIndex == 0 ? -1 : Convert.ToInt32(ddlCA2Affiliation.SelectedValue);
                    objSubmission.AuthorsInterest = taAuthorsInterest.Text.Trim();
                    objSubmission.TopicId = Convert.ToInt32(ddlTopics.SelectedValue);
                    objSubmission.Biosketch = taBiosketch.Text.Trim();
                    objSubmission.LearningObjectives = taLearningObjectives.Text.Trim();
                    objSubmission.CurrDesc = taCurrDesc.Text.Trim();
                    objSubmission.SessionTypeId = rblSessionType.SelectedValue == "" ? -1 : Convert.ToInt32(rblSessionType.SelectedValue);
                    objSubmission.SessionTypeOther = txtSessionTypeOther.Text.Trim();
                    objSubmission.CurrFormat = txtCurrFormat.Text.Trim();
                    objSubmission.TeachingTools = taTeachingTools.Text.Trim();
                    objSubmission.TopicAssigned = Convert.ToInt32(rblTopicAssigned.SelectedValue);
                    objSubmission.UnderstandAttestation1 = Convert.ToInt32(chkUnderstandAttestation1.Checked);
                    objSubmission.UnderstandAttestation2 = Convert.ToInt32(chkUnderstandAttestation2.Checked);
                    objSubmission.UnderstandAttestation3 = Convert.ToInt32(chkUnderstandAttestation3.Checked);
                    objSubmission.DateCreated = DateTime.Now;

                    RCRData objData = new RCRData();

                    objData.SubmitSubmission(objSubmission);

                    objData = null;
                }
                catch (Exception ex)
                {
                    MakeLogEntry(ex.Message);
                    bError = true;
                }

                if (!bError)
                {
                    DisplayMessage();
                }
                else
                {
                    DisplayErrorMessage();
                }
            }
        }

        private Boolean VerifyText()
        {
            Boolean bOk = true;

            if (txtAddress1.Text.Trim() == "")
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["Address1TitleText"].ToString(), bOk);
                return bOk;
            }

            if (txtCity.Text.Trim() == "")
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["CityTitleText"].ToString(), bOk);
                return bOk;
            }

            if (txtZipCode.Text.Trim() == "")
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["ZipCodeTitleText"].ToString(), bOk);
                return bOk;
            }
            else
            {
                try
                {
                    Convert.ToInt32(txtZipCode.Text.Trim());
                }
                catch
                {
                    bOk = false;
                    SetDisplay(ConfigurationManager.AppSettings["ZipCodeTitleText"].ToString(), bOk);
                    return bOk;
                }
            }

            if (txtPhoneNumber.Text.Trim() == "")
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["PhoneTitleText"].ToString(), bOk);
                return bOk;
            }

            return bOk;
        }

        private Boolean VerifySelections()
        {
            Boolean bOk = true;

            if (ddlStates.SelectedIndex == 0)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["StateTitleText"].ToString(), bOk);
                return bOk;
            }

            if (ddlTopics.Enabled == false || ddlTopics.SelectedIndex == 0)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["TopicRequiredTitleText"].ToString(), bOk);
                return bOk;
            }

            if (rblTopicAssigned.SelectedValue == "")
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["TopicAssignedTitleText"].ToString(), bOk);
                return bOk;
            }

            if (chkUnderstandAttestation1.Checked == false)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["UnderstandAttestation1TitleText"].ToString(), bOk);
                return bOk;
            }

            if (chkUnderstandAttestation2.Checked == false)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["UnderstandAttestation2TitleText"].ToString(), bOk);
                return bOk;
            }

            if (chkUnderstandAttestation3.Checked == false)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["UnderstandAttestation3TitleText"].ToString(), bOk);
                return bOk;
            }

            return bOk;
        }

        private Boolean VerifyFormat()
        {
            string sFirstName = txtFirstName.Text.Trim();
            string sMiddleName = txtMiddleName.Text.Trim();
            string sLastName = txtLastName.Text.Trim();
            string sEmailAddress = txtEmailAddress.Text.Trim();

            Boolean bOk = true;

            Match objMatch;

            objMatch = Regex.Match(sFirstName, "^[a-zA-Z'-]");

            if (!objMatch.Success)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["FirstNameTitleText"].ToString(), bOk);
                return bOk;
            }

            objMatch = Regex.Match(sMiddleName, "^[a-zA-Z'-]");

            if (!objMatch.Success)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["MiddleNameTitleText"].ToString(), bOk);
                return bOk;
            }

            objMatch = Regex.Match(sLastName, "^[a-zA-Z'-]");

            if (!objMatch.Success)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["LastNameTitleText"].ToString(), bOk);
                return bOk;
            }

            objMatch = Regex.Match(sEmailAddress, "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");

            if (!objMatch.Success)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["EmailTitleText"].ToString(), bOk);
                return bOk;
            }

            return bOk;
        }

        private Boolean VerifyTextCounts()
        {
            Boolean bOk = true;

            //string[] sAuthorsInterestVals = taAuthorsInterest.Text.Trim().Split(' ');
            //int iAuthorsInterestLen = sAuthorsInterestVals.Count();

            if (taAuthorsInterest.Text == "")// || iAuthorsInterestLen > 125) // || taAuthorsInterest.Text.Length > 150)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["AuthorsInterestsTitleText"].ToString(), bOk);
                return bOk;
            }

            string[] sBiosketchVals = taBiosketch.Text.Trim().Split(' ');
            int iBiosketchLen = sBiosketchVals.Count();

            if (taBiosketch.Text == "" || iBiosketchLen > 125)// || taBiosketch.Text.Replace(" ", "").Length > 750)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["BioSketchTitleText"].ToString(), bOk);
                return bOk;
            }

            //string[] sLearningObjectivesVals = taLearningObjectives.Text.Trim().Split(' ');
            //int iLearningObjectivesLen = sLearningObjectivesVals.Count();

            if (taLearningObjectives.Text == "") // || iLearningObjectivesLen > 125)// || taLearningObjectives.Text.Length > 750)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["LearningObjectivesTitleText"].ToString(), bOk);
                return bOk;
            }

            string[] sCurrDescVals = taCurrDesc.Text.Trim().Split(' ');
            int iCurrDescLen = sCurrDescVals.Count();

            if (taCurrDesc.Text == "" || iCurrDescLen > 400) // || taCurrDesc.Text.Length > 2600)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["CurrDescTitleText"].ToString(), bOk);
                return bOk;
            }

            //string[] sTeachingToolsVals = taTeachingTools.Text.Trim().Split(' ');
            //int iTeachingToolsLen = sTeachingToolsVals.Count();

            if (taTeachingTools.Text == "") // || iTeachingToolsLen > 125) // || taTeachingTools.Text.Length > 150)
            {
                bOk = false;
                SetDisplay(ConfigurationManager.AppSettings["TeachingToolsTitleText"].ToString(), bOk);
                return bOk;
            }

            return bOk;
        }

        private int DetermineMembershipSelection()
        {
            if (cblMembership.Items[0].Selected && cblMembership.Items[1].Selected)
            {
                return 3;
            }
            else if (cblMembership.Items[0].Selected || cblMembership.Items[1].Selected)
            {
                return Convert.ToInt32(cblMembership.SelectedValue);
            }
            else
            {
                return -1;
            }
        }

        private void MakeLogEntry(string sEntry)
        {
            string sLogDirectory = HttpContext.Current.Server.MapPath("") + "\\LogFiles\\";
            string sLogFileName = DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Year.ToString() + ".log";
            string sLogFilePath = sLogDirectory + sLogFileName;

            string sLogContent = (DateTime.Now + " : " + sEntry + "\n");
            System.IO.File.AppendAllText(sLogFilePath, sLogContent);
        }

        private void DisplayMessage()
        {
            Response.Redirect("SubmissionMessage.aspx");
        }

        private void DisplayErrorMessage()
        {
            Response.Redirect("SubmissionErrorMessage.aspx");
        }

        public void CheckSessionType(object sender, EventArgs e)
        {
            RadioButtonList rblSession = (RadioButtonList)sender;
            string sSessionValue = rblSession.SelectedValue.ToString();

            if (sSessionValue == "5")
            {
                txtSessionTypeOther.Enabled = true;
            }
            else
            {
                txtSessionTypeOther.Enabled = false;
            }

            rblSession = null;
        }

        private void ResetAllDisplays(Boolean bReset)
        {
            lblMessage.Text = "";
            SetDisplay(ConfigurationManager.AppSettings["FirstNameTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["MiddleNameTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["LastNameTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["Address1TitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["CityTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["StateTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["ZipCodeTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["EmailTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["PhoneTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["TopicRequiredTitleText"].ToString(), bReset);

            SetDisplay(ConfigurationManager.AppSettings["AuthorsInterestsTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["BioSketchTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["LearningObjectivesTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["CurrDescTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["TeachingToolsTitleText"].ToString(), bReset);

            SetDisplay(ConfigurationManager.AppSettings["TopicAssignedTitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["UnderstandAttestation1TitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["UnderstandAttestation2TitleText"].ToString(), bReset);
            SetDisplay(ConfigurationManager.AppSettings["UnderstandAttestation3TitleText"].ToString(), bReset);
        }

        private void SetDisplay(string objName, Boolean bReset)
        {
            Color objColor = Color.Red;

            if (bReset)
            {
                objColor = Color.Black;
            }

            switch (objName)
            {
                case "First Name":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["FirstNameTitleText"].ToString() + ConfigurationManager.AppSettings["NameValidateText"].ToString();
                        lblFirstName.ForeColor = objColor;
                        lblFirstName.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            txtFirstName.Focus();
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Middle Name":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["MiddleNameTitleText"].ToString() + ConfigurationManager.AppSettings["NameValidateText"].ToString();
                        lblMiddleName.ForeColor = objColor;
                        lblMiddleName.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            txtMiddleName.Focus();
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Last Name":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["LastNameTitleText"].ToString() + ConfigurationManager.AppSettings["NameValidateText"].ToString();
                        lblLastName.ForeColor = objColor;
                        lblLastName.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            txtLastName.Focus();
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Mailing Address 1":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["Address1TitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        lblAddress1.ForeColor = objColor;
                        lblAddress1.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "City":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["CityTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        lblCity.ForeColor = objColor;
                        lblCity.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "State":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["StateTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        lblState.ForeColor = objColor;
                        lblState.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Zip Code":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["ZipCodeTitleText"].ToString() + ConfigurationManager.AppSettings["NumberValidateText"].ToString();
                        lblZipCode.ForeColor = objColor;
                        lblZipCode.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            txtZipCode.Focus();
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Email":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["EmailTitleText"].ToString() + ConfigurationManager.AppSettings["EmailAddressValidateText"].ToString();
                        lblEmailAddress.ForeColor = objColor;
                        lblEmailAddress.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Phone":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["PhoneTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        lblPhoneNumber.ForeColor = objColor;
                        lblPhoneNumber.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Topic Assigned":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["TopicAssignedValidateText"].ToString();
                        rblTopicAssigned.ForeColor = objColor;
                        rblTopicAssigned.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Disclosure":
                    {
                        //if (taAuthorsInterest.Text == "")
                        //{
                            lblMessage.Text = ConfigurationManager.AppSettings["AuthorsInterestsTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        //}
                        //else
                        //{
                        //    lblMessage.Text = ConfigurationManager.AppSettings["AuthorsInterestsTitleText"].ToString() + ConfigurationManager.AppSettings["AuthorsInterestsValidateText"].ToString();
                        //}
                        lblAuthorsInterest.ForeColor = objColor;
                        lblAuthorsInterest.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "BioSketch":
                    {
                        if (taBiosketch.Text == "")
                        {
                            lblMessage.Text = ConfigurationManager.AppSettings["BioSketchTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        }
                        else
                        {
                            lblMessage.Text = ConfigurationManager.AppSettings["BioSketchTitleText"].ToString() + ConfigurationManager.AppSettings["BioSketchValidateText"].ToString();
                        }
                        lblBiosketch.ForeColor = objColor;
                        lblBiosketch.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Learning Objectives":
                    {
                        //if (taLearningObjectives.Text == "")
                        //{
                            lblMessage.Text = ConfigurationManager.AppSettings["LearningObjectivesTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        //}
                        //else
                        //{
                        //    lblMessage.Text = ConfigurationManager.AppSettings["LearningObjectivesTitleText"].ToString() + ConfigurationManager.AppSettings["LearningObjectivesValidateText"].ToString();
                        //}
                        lblLearningObjectives.ForeColor = objColor;
                        lblLearningObjectives.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Curriculum Description":
                    {
                        if (taCurrDesc.Text == "")
                        {
                            lblMessage.Text = ConfigurationManager.AppSettings["CurrDescTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        }
                        else
                        {
                            lblMessage.Text = ConfigurationManager.AppSettings["CurrDescTitleText"].ToString() + ConfigurationManager.AppSettings["CurrDescValidateText"].ToString();
                        }
                        lblCurrDesc.ForeColor = objColor;
                        lblCurrDesc.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Teaching Tools":
                    {
                        //if (taTeachingTools.Text == "")
                        //{
                            lblMessage.Text = ConfigurationManager.AppSettings["TeachingToolsTitleText"].ToString() + ConfigurationManager.AppSettings["RequiredFieldValidateText"].ToString();
                        //}
                        //else
                        //{
                        //    lblMessage.Text = ConfigurationManager.AppSettings["TeachingToolsTitleText"].ToString() + ConfigurationManager.AppSettings["TeachingToolsValidateText"].ToString();
                        //}
                        lblTeachingTools.ForeColor = objColor;
                        lblTeachingTools.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Understand Attestation 1":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["UnderstandAttestationValidateText"].ToString();
                        lblUnderstandAttestation1.ForeColor = objColor;
                        lblUnderstandAttestation1.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Understand Attestation 2":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["UnderstandAttestationValidateText"].ToString();
                        lblUnderstandAttestation2.ForeColor = objColor;
                        lblUnderstandAttestation2.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Understand Attestation 3":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["UnderstandAttestationValidateText"].ToString();
                        lblUnderstandAttestation3.ForeColor = objColor;
                        lblUnderstandAttestation3.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
                case "Topic Required":
                    {
                        lblMessage.Text = ConfigurationManager.AppSettings["TopicRequiredValidateText"].ToString();
                        lblTopics.ForeColor = objColor;
                        lblTopics.Font.Bold = !bReset;
                        if (!bReset)
                        {
                            RegisterStartupScript("ErrorMessage", "<script language='javascript'>alert('" + lblMessage.Text + "');</script>");
                        }
                        break;
                    }
            }

            if (bReset)
            {
                lblMessage.Text = "";
            }
        }

    }
}