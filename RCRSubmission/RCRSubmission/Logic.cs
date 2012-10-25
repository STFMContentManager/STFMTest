using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using RCRDataNS;
using RCRWrappers;

namespace RCRLogicNS
{
    public class RCRLogic : RCRData
    {
        public List<DropDownValue> GetStates()
        {
            return GetDropDownValuesFromDB(ConfigurationManager.AppSettings["StatesTable"].ToString());
        }

        public List<DropDownValue> GetDegrees()
        {
            return GetDropDownValuesFromDB(ConfigurationManager.AppSettings["DegreesTable"].ToString());
        }

        public List<DropDownValue> GetPrograms()
        {
            return GetDropDownValuesFromDB(ConfigurationManager.AppSettings["ProgramsTable"].ToString());
        }

        public List<DropDownValue> GetCoreTopics()
        {
            return GetDropDownValuesFromDB(ConfigurationManager.AppSettings["CoreTopicsTable"].ToString());
        }

        public List<DropDownValue> GetTopics(int iDropDownCoreTopicID)
        {
            return GetDropDownValuesFromDB(ConfigurationManager.AppSettings["TopicsTable"].ToString(), iDropDownCoreTopicID);
        }
    }

    public class RCRSubmissionObject
    {
        int iID;
        string sFName;
        string sMName;
        string sLName;
        string sTitle;
        int iDegreeId;
        int iMembership;
        int iAffiliationId;
        string sAddress1;
        string sAddress2;
        string sAddress3;
        string sCity;
        string sState;
        int iZip;
        string sEmail;
        string sPhone;
        string sCA1FName;
        string sCA1MName;
        string sCA1LName;
        int iCA1DegreeId;
        int iCA1AffiliationId;
        string sCA2FName;
        string sCA2MName;
        string sCA2LName;
        int iCA2DegreeId;
        int iCA2AffiliationId;
        string sAuthorsInterest;
        int iTopicId;
        string sBiosketch;
        string sLearningObjectives;
        string sCurrDesc;
        int iSessionTypeId;
        string sSessionTypeOther;
        string sCurrFormat;
        string sTeachingTools;
        int iTopicAssigned;
        int iUnderstandAttestation1;
        int iUnderstandAttestation2;
        int iUnderstandAttestation3;
        DateTime dtDateCreated;

        public int Id
        {
            get { return iID; }
            set { iID = value; }
        }

        public string FName
        {
            get { return sFName; }
            set { sFName = value; }
        }
        public string MName
        {
            get { return sMName; }
            set { sMName = value; }
        }
        public string LName
        {
            get { return sLName; }
            set { sLName = value; }
        }
        public string Title
        {
            get { return sTitle; }
            set { sTitle = value; }
        }
        public int DegreeId
        {
            get { return iDegreeId; }
            set { iDegreeId = value; }
        }
        public int Membership
        {
            get { return iMembership; }
            set { iMembership = value; }
        }
        public int AffiliationId
        {
            get { return iAffiliationId; }
            set { iAffiliationId = value; }
        }
        public string Address1
        {
            get { return sAddress1; }
            set { sAddress1 = value; }
        }
        public string Address2
        {
            get { return sAddress2; }
            set { sAddress2 = value; }
        }
        public string Address3
        {
            get { return sAddress3; }
            set { sAddress3 = value; }
        }
        public string City
        {
            get { return sCity; }
            set { sCity = value; }
        }
        public string State
        {
            get { return sState; }
            set { sState = value; }
        }
        public int Zip
        {
            get { return iZip; }
            set { iZip = value; }
        }
        public string Email
        {
            get { return sEmail; }
            set { sEmail = value; }
        }
        public string Phone
        {
            get { return sPhone; }
            set { sPhone = value; }
        }
        public string CA1FName
        {
            get { return sCA1FName; }
            set { sCA1FName = value; }
        }
        public string CA1MName
        {
            get { return sCA1MName; }
            set { sCA1MName = value; }
        }
        public string CA1LName
        {
            get { return sCA1LName; }
            set { sCA1LName = value; }
        }
        public int CA1DegreeId
        {
            get { return iCA1DegreeId; }
            set { iCA1DegreeId = value; }
        }
        public int CA1AffiliationId
        {
            get { return iCA1AffiliationId; }
            set { iCA1AffiliationId = value; }
        }
        public string CA2FName
        {
            get { return sCA2FName; }
            set { sCA2FName = value; }
        }
        public string CA2MName
        {
            get { return sCA2MName; }
            set { sCA2MName = value; }
        }
        public string CA2LName
        {
            get { return sCA2LName; }
            set { sCA2LName = value; }
        }
        public int CA2DegreeId
        {
            get { return iCA2DegreeId; }
            set { iCA2DegreeId = value; }
        }
        public int CA2AffiliationId
        {
            get { return iCA2AffiliationId; }
            set { iCA2AffiliationId = value; }
        }
        public string AuthorsInterest
        {
            get { return sAuthorsInterest; }
            set { sAuthorsInterest = value; }
        }
        public int TopicId
        {
            get { return iTopicId; }
            set { iTopicId = value; }
        }
        public string Biosketch
        {
            get { return sBiosketch; }
            set { sBiosketch = value; }
        }
        public string LearningObjectives
        {
            get { return sLearningObjectives; }
            set { sLearningObjectives = value; }
        }
        public string CurrDesc
        {
            get { return sCurrDesc; }
            set { sCurrDesc = value; }
        }
        public int SessionTypeId
        {
            get { return iSessionTypeId; }
            set { iSessionTypeId = value; }
        }
        public string SessionTypeOther
        {
            get { return sSessionTypeOther; }
            set { sSessionTypeOther = value; }
        }
        public string CurrFormat
        {
            get { return sCurrFormat; }
            set { sCurrFormat = value; }
        }
        public string TeachingTools
        {
            get { return sTeachingTools; }
            set { sTeachingTools = value; }
        }
        public int TopicAssigned
        {
            get { return iTopicAssigned; }
            set { iTopicAssigned = value; }
        }
        public int UnderstandAttestation1
        {
            get { return iUnderstandAttestation1; }
            set { iUnderstandAttestation1 = value; }
        }
        public int UnderstandAttestation2
        {
            get { return iUnderstandAttestation2; }
            set { iUnderstandAttestation2 = value; }
        }
        public int UnderstandAttestation3
        {
            get { return iUnderstandAttestation3; }
            set { iUnderstandAttestation3 = value; }
        }
        public DateTime DateCreated
        {
            get { return dtDateCreated; }
            set { dtDateCreated = value; }
        }

    }
}