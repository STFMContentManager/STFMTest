using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ISIS
{
    public class ISISLogic
    {
        public List<Project> GetProjects()
        {
            ISISData iData = new ISISData();
            List<Project> lstProjects = iData.GetProjects();
            iData = null;

            return lstProjects;
        }

        public List<Project> GetAllProjects()
        {
            ISISData iData = new ISISData();
            List<Project> lstProjects = iData.GetAllProjects();
            iData = null;

            return lstProjects;
        }

        public Project GetProject(int iId)
        {
            ISISData iData = new ISISData();
            Project objProject = iData.GetProject(iId);
            iData = null;

            return objProject;
        }

        public string CreateProject(string sProjectName)
        {
            ISISData iData = new ISISData();
            string sReturnMessage = iData.CreateProject(sProjectName);
            iData = null;
            return sReturnMessage;
        }

        public string RemoveProject(int iProjectId)
        {
            ISISData iData = new ISISData();
            string sReturnMessage = iData.RemoveProject(iProjectId);
            iData = null;
            return sReturnMessage;
        }

        public string RenameProject(int iProjectId, string sProjectNewName)
        {
            ISISData iData = new ISISData();
            string sReturnMessage = iData.RenameProject(iProjectId, sProjectNewName);
            iData = null;
            return sReturnMessage;
        }

        public string GetYearValue(int iYearIndicator)
        {
            return (DateTime.Now.Year + iYearIndicator).ToString();
        }

        public void SaveProject(Project objProject)
        {
            ISISData iData = new ISISData();
            iData.SaveProject(objProject);
            iData = null;
        }
    }
}