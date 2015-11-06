using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcfCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
    public class TestService : ITestService
    {

        public string InsertData(UserDetails user)
        {
            string message;
            string connectionString = ConfigurationManager.ConnectionStrings["employeeDBConn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query =
                "Insert Into EmployeeDB.dbo.UserDetails ([userName],[password],[country],[email]) values (@userName,@password,@country,@email)";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@userName", user.UserName);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@country", user.Country);
            command.Parameters.AddWithValue("@email", user.Email);

            if (command.ExecuteNonQuery() > 0)
            {
                message = user.UserName + " Details inserted succesfully";
            }
            else
            {
                message = user.UserName + " Details not-inserted succesfully";
            }
            conn.Close();
            return message;
        }
    }
}
