using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DesignationGateway : BaseGateway
    {
        public List<DesignationModel> GetAllDesignations()
        {

            string query = "SELECT * FROM Designation";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<DesignationModel> designationModels = new List<DesignationModel>();

            while (Reader.Read())
            {
                DesignationModel designation = new DesignationModel();
                designation.Id = Convert.ToInt32(Reader["Id"]);
                designation.Designation = Reader["Designation"].ToString();


                designationModels.Add(designation);
            }
            Connection.Close();
            return designationModels;
        }
    }
}