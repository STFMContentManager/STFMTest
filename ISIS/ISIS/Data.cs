using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ISIS
{
    public class ISISData
    {

        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader rdr = null;

        public List<Project> GetProjects()
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());
            conn.Open();

            cmd = new SqlCommand("GetProjects", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            rdr = cmd.ExecuteReader();

            List<Project> lstProjectNames = new List<Project>();

            Project sProjectValues = new Project();

            sProjectValues.Id = 0;
            sProjectValues.ProjectName = "";

            lstProjectNames.Add(sProjectValues);

            while (rdr.Read())
            {
                sProjectValues = new Project();
                sProjectValues.Id = Convert.ToInt32(rdr["Id"].ToString());
                sProjectValues.ProjectName = rdr["ProjectName"].ToString();
                lstProjectNames.Add(sProjectValues);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lstProjectNames;
        }

        public List<Project> GetAllProjects()
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());
            conn.Open();

            cmd = new SqlCommand("GetAllProjects", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            rdr = cmd.ExecuteReader();

            List<Project> lstProjectNames = new List<Project>();

            Project sProjectValues;

            while (rdr.Read())
            {
                sProjectValues = new Project();
                sProjectValues.Id = Convert.ToInt32(rdr["Id"].ToString());
                sProjectValues.ProjectName = rdr["ProjectName"].ToString();

                string sStaffTime = "";

                switch (rdr["StaffTime"].ToString())
                {
                    case "1":
                        sStaffTime = "Low";
                        break;
                    case "2":
                        sStaffTime = "Mod";
                        break;
                    case "3":
                        sStaffTime = "High";
                        break;
                }


                sProjectValues.StaffTimeDisplay = sStaffTime;
                sProjectValues.PreviousYear = (DateTime.Now.Year - 1);
                sProjectValues.CurrentYear = (DateTime.Now.Year);
                sProjectValues.NextYear = (DateTime.Now.Year + 1);
                sProjectValues.NumPartsPrevious = rdr["NumPartsPrevious"].ToString();
                sProjectValues.NumPartsCurrent = rdr["NumPartsCurrent"].ToString();
                sProjectValues.NumPartsNext = rdr["NumPartsNext"].ToString();
                sProjectValues.NetProfitPreviousQ1 = Convert.ToInt32(rdr["NetProfitPreviousQ1"].ToString() == "" ? "0" : rdr["NetProfitPreviousQ1"].ToString());
                sProjectValues.NetProfitPreviousQ2 = Convert.ToInt32(rdr["NetProfitPreviousQ2"].ToString() == "" ? "0" : rdr["NetProfitPreviousQ2"].ToString());
                sProjectValues.NetProfitPreviousQ3 = Convert.ToInt32(rdr["NetProfitPreviousQ3"].ToString() == "" ? "0" : rdr["NetProfitPreviousQ3"].ToString());
                sProjectValues.NetProfitPreviousQ4 = Convert.ToInt32(rdr["NetProfitPreviousQ4"].ToString() == "" ? "0" : rdr["NetProfitPreviousQ4"].ToString());
                sProjectValues.NetProfitCurrentQ1 = Convert.ToInt32(rdr["NetProfitCurrentQ1"].ToString() == "" ? "0" : rdr["NetProfitCurrentQ1"].ToString());
                sProjectValues.NetProfitCurrentQ2 = Convert.ToInt32(rdr["NetProfitCurrentQ2"].ToString() == "" ? "0" : rdr["NetProfitCurrentQ2"].ToString());
                sProjectValues.NetProfitCurrentQ3 = Convert.ToInt32(rdr["NetProfitCurrentQ3"].ToString() == "" ? "0" : rdr["NetProfitCurrentQ3"].ToString());
                sProjectValues.NetProfitCurrentQ4 = Convert.ToInt32(rdr["NetProfitCurrentQ4"].ToString() == "" ? "0" : rdr["NetProfitCurrentQ4"].ToString());
                sProjectValues.NetProfitNextQ1 = Convert.ToInt32(rdr["NetProfitNextQ1"].ToString() == "" ? "0" : rdr["NetProfitNextQ1"].ToString());
                sProjectValues.NetProfitNextQ2 = Convert.ToInt32(rdr["NetProfitNextQ2"].ToString() == "" ? "0" : rdr["NetProfitNextQ2"].ToString());
                sProjectValues.NetProfitNextQ3 = Convert.ToInt32(rdr["NetProfitNextQ3"].ToString() == "" ? "0" : rdr["NetProfitNextQ3"].ToString());
                sProjectValues.NetProfitNextQ4 = Convert.ToInt32(rdr["NetProfitNextQ4"].ToString() == "" ? "0" : rdr["NetProfitNextQ4"].ToString());
                sProjectValues.Impact = rdr["Impact"].ToString();
                sProjectValues.Comments = rdr["Comments"].ToString();
                lstProjectNames.Add(sProjectValues);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return lstProjectNames;
        }

        public Project GetProject(int iId)
        {
            conn = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());
            conn.Open();

            cmd = new SqlCommand("GetProject", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", iId));

            rdr = cmd.ExecuteReader();

            List<Project> lstProjectNames = new List<Project>();

            Project sProjectValues = new Project();

            //sProjectValues.Id = 0;
            //sProjectValues.ProjectName = "";

            //lstProjectNames.Add(sProjectValues);

            while (rdr.Read())
            {
                sProjectValues = new Project();
                sProjectValues.Id = Convert.ToInt32(rdr["Id"].ToString());
                sProjectValues.ProjectName = rdr["ProjectName"].ToString();
                sProjectValues.StaffTime = Convert.ToInt32(rdr["StaffTime"].ToString() == "" ? "0" : rdr["StaffTime"].ToString());
                sProjectValues.NumPartsPrevious = rdr["NumPartsPrevious"].ToString();
                sProjectValues.NumPartsCurrent = rdr["NumPartsCurrent"].ToString();
                sProjectValues.NumPartsNext = rdr["NumPartsNext"].ToString();
                sProjectValues.NetProfitPreviousQ1 = rdr["NetProfitPreviousQ1"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitPreviousQ1"].ToString());
                sProjectValues.NetProfitPreviousQ2 = rdr["NetProfitPreviousQ2"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitPreviousQ2"].ToString());
                sProjectValues.NetProfitPreviousQ3 = rdr["NetProfitPreviousQ3"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitPreviousQ3"].ToString());
                sProjectValues.NetProfitPreviousQ4 = rdr["NetProfitPreviousQ4"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitPreviousQ4"].ToString());
                sProjectValues.NetProfitCurrentQ1 = rdr["NetProfitCurrentQ1"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitCurrentQ1"].ToString());
                sProjectValues.NetProfitCurrentQ2 = rdr["NetProfitCurrentQ2"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitCurrentQ2"].ToString());
                sProjectValues.NetProfitCurrentQ3 = rdr["NetProfitCurrentQ3"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitCurrentQ3"].ToString());
                sProjectValues.NetProfitCurrentQ4 = rdr["NetProfitCurrentQ4"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitCurrentQ4"].ToString());
                sProjectValues.NetProfitNextQ1 = rdr["NetProfitNextQ1"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitNextQ1"].ToString());
                sProjectValues.NetProfitNextQ2 = rdr["NetProfitNextQ2"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitNextQ2"].ToString());
                sProjectValues.NetProfitNextQ3 = rdr["NetProfitNextQ3"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitNextQ3"].ToString());
                sProjectValues.NetProfitNextQ4 = rdr["NetProfitNextQ4"].ToString() == "" ? 0 : Convert.ToInt32(rdr["NetProfitNextQ4"].ToString());
                sProjectValues.Impact = rdr["Impact"].ToString();
                sProjectValues.Comments = rdr["Comments"].ToString();
                //lstProjectNames.Add(sProjectValues);
            }

            rdr.Close();
            conn.Close();

            conn.Dispose();
            cmd.Dispose();
            rdr.Dispose();

            conn = null;
            cmd = null;
            rdr = null;

            return sProjectValues; // lstProjectNames;
        }

        public string SaveProject(Project objProject)
        {
            try
            {
                string sAllocate = Allocate("STFMProjectInventorySaveProject");

                if (sAllocate == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", objProject.Id));
                    cmd.Parameters.Add(new SqlParameter("@ProjectName", objProject.ProjectName));
                    cmd.Parameters.Add(new SqlParameter("@StaffTime", objProject.StaffTime));
                    cmd.Parameters.Add(new SqlParameter("@NumPartsPrevious", objProject.NumPartsPrevious));
                    cmd.Parameters.Add(new SqlParameter("@NumPartsCurrent", objProject.NumPartsCurrent));
                    cmd.Parameters.Add(new SqlParameter("@NumPartsNext", objProject.NumPartsNext));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitPreviousQ1", objProject.NetProfitPreviousQ1));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitPreviousQ2", objProject.NetProfitPreviousQ2));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitPreviousQ3", objProject.NetProfitPreviousQ3));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitPreviousQ4", objProject.NetProfitPreviousQ4));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitCurrentQ1", objProject.NetProfitCurrentQ1));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitCurrentQ2", objProject.NetProfitCurrentQ2));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitCurrentQ3", objProject.NetProfitCurrentQ3));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitCurrentQ4", objProject.NetProfitCurrentQ4));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitNextQ1", objProject.NetProfitNextQ1));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitNextQ2", objProject.NetProfitNextQ2));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitNextQ3", objProject.NetProfitNextQ3));
                    cmd.Parameters.Add(new SqlParameter("@NetProfitNextQ4", objProject.NetProfitNextQ4));
                    cmd.Parameters.Add(new SqlParameter("@Impact", objProject.Impact));
                    cmd.Parameters.Add(new SqlParameter("@Comments", objProject.Comments));
                    
                    cmd.ExecuteNonQuery();

                    Deallocate();
                    return "";
                }
                else
                {
                    Deallocate();
                    return sAllocate;
                }


            }
            catch (Exception ex)
            {
                Deallocate();
                return ex.Message.ToString();
            }
        }

        public string CreateProject(string sProjectName)
        {
            try
            {
                string sAllocate = Allocate("STFMProjectInventoryCreateProject");

                if (sAllocate == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@ProjectName", sProjectName));
                    cmd.ExecuteNonQuery();

                    Deallocate();
                    return "";
                }
                else
                {
                    Deallocate();
                    return sAllocate;
                }


            }
            catch (Exception ex)
            {
                Deallocate();
                return ex.Message.ToString();
            }
        }

        public string RemoveProject(int iProjectId)
        {
            try
            {
                string sAllocate = Allocate("STFMProjectInventoryRemoveProject");

                if (sAllocate == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@ProjectId", iProjectId));
                    cmd.ExecuteNonQuery();

                    Deallocate();
                    return "";
                }
                else
                {
                    Deallocate();
                    return sAllocate;
                }


            }
            catch (Exception ex)
            {
                Deallocate();
                return ex.Message.ToString();
            }
        }

        public string RenameProject(int iProjectId, string sProjectNewName)
        {
            try
            {
                string sAllocate = Allocate("STFMProjectInventoryRenameProject");
                
                if (sAllocate == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@ProjectId", iProjectId));
                    cmd.Parameters.Add(new SqlParameter("@ProjectName", sProjectNewName));
                    cmd.ExecuteNonQuery();

                    Deallocate();
                    return "";
                }
                else
                {
                    Deallocate();
                    return sAllocate;
                }


            }
            catch (Exception ex)
            {
                Deallocate();
                return ex.Message.ToString();
            }
        }

        private string Allocate(string sSP)
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.AppSettings["ISISConnection"].ToString());
                conn.Open();

                if (sSP != "" && sSP != null)
                {
                    cmd = new SqlCommand(sSP, conn);
                }

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void Deallocate()
        {
            if (conn != null)
            {
                try
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
                catch
                {
                    conn = null;
                }
            }

            if (cmd != null)
            {
                try
                {
                    cmd.Dispose();
                    cmd = null;
                }
                catch
                {
                    cmd = null;
                }
            }
        }

    }
}