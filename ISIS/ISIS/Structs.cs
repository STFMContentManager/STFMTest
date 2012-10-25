using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISIS
{
    public struct Project
    {
        private int iId;
        private string sProjectName;
        private int iStaffTime;
        private string sStaffTime;
        private string sNumPartsPrevious;
        private string sNumPartsCurrent;
        private string sNumPartsNext;
        private int iNetProfitPreviousQ1;
        private int iNetProfitPreviousQ2;
        private int iNetProfitPreviousQ3;
        private int iNetProfitPreviousQ4;
        private int iNetProfitCurrentQ1;
        private int iNetProfitCurrentQ2;
        private int iNetProfitCurrentQ3;
        private int iNetProfitCurrentQ4;
        private int iNetProfitNextQ1;
        private int iNetProfitNextQ2;
        private int iNetProfitNextQ3;
        private int iNetProfitNextQ4;
        private string sImpact;
        private string sComments;

        private int iPreviousYear;
        private int iCurrentYear;
        private int iNextYear;

        public int Id
        {
            get { return iId; }
            set { iId = value; }
        }

        public string ProjectName
        {
            get { return sProjectName; }
            set { sProjectName = value; }
        }

        public int StaffTime
        {
            get { return iStaffTime; }
            set { iStaffTime = value; }
        }

        public string StaffTimeDisplay
        {
            get { return sStaffTime; }
            set { sStaffTime = value; }
        }

        public string NumPartsPrevious
        {
            get { return sNumPartsPrevious; }
            set { sNumPartsPrevious = value; }
        }

        public string NumPartsCurrent
        {
            get { return sNumPartsCurrent; }
            set { sNumPartsCurrent = value; }
        }

        public string NumPartsNext
        {
            get { return sNumPartsNext; }
            set { sNumPartsNext = value; }
        }

        public int NetProfitPreviousQ1
        {
            get { return iNetProfitPreviousQ1; }
            set { iNetProfitPreviousQ1 = value; }
        }

        public int NetProfitPreviousQ2
        {
            get { return iNetProfitPreviousQ2; }
            set { iNetProfitPreviousQ2 = value; }
        }

        public int NetProfitPreviousQ3
        {
            get { return iNetProfitPreviousQ3; }
            set { iNetProfitPreviousQ3 = value; }
        }

        public int NetProfitPreviousQ4
        {
            get { return iNetProfitPreviousQ4; }
            set { iNetProfitPreviousQ4 = value; }
        }

        public int NetProfitCurrentQ1
        {
            get { return iNetProfitCurrentQ1; }
            set { iNetProfitCurrentQ1 = value; }
        }

        public int NetProfitCurrentQ2
        {
            get { return iNetProfitCurrentQ2; }
            set { iNetProfitCurrentQ2 = value; }
        }

        public int NetProfitCurrentQ3
        {
            get { return iNetProfitCurrentQ3; }
            set { iNetProfitCurrentQ3 = value; }
        }

        public int NetProfitCurrentQ4
        {
            get { return iNetProfitCurrentQ4; }
            set { iNetProfitCurrentQ4 = value; }
        }

        public int NetProfitNextQ1
        {
            get { return iNetProfitNextQ1; }
            set { iNetProfitNextQ1 = value; }
        }

        public int NetProfitNextQ2
        {
            get { return iNetProfitNextQ2; }
            set { iNetProfitNextQ2 = value; }
        }

        public int NetProfitNextQ3
        {
            get { return iNetProfitNextQ3; }
            set { iNetProfitNextQ3 = value; }
        }

        public int NetProfitNextQ4
        {
            get { return iNetProfitNextQ4; }
            set { iNetProfitNextQ4 = value; }
        }

        public string Impact
        {
            get { return sImpact; }
            set { sImpact = value; }
        }

        public string Comments
        {
            get { return sComments; }
            set { sComments = value; }
        }

        public int PreviousYear
        {
            get { return iPreviousYear; }
            set { iPreviousYear = value; }
        }

        public int CurrentYear
        {
            get { return iCurrentYear; }
            set { iCurrentYear = value; }
        }

        public int NextYear
        {
            get { return iNextYear; }
            set { iNextYear = value; }
        }

    }
}