using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace WebApplication1.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                    select EmployeeId,FirstName,LastName,E_mail,
                    Sex,Age,Hobby
                    from
                    dbo.Employee
                    ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["EmployeeAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);


        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"
                    insert into dbo.Employee values
                    (
                    '" + emp.FirstName + @"'
                    ,'" + emp.LastName + @"'
                    ,'" + emp.E_mail + @"'
                    ,'" + emp.Sex + @"'
                    ,'" + emp.Age + @"'
                    ,'" + emp.Hobby + @"'
                    )
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Add!!";
            }
        }

        public string Put(Employee emp)
        {
            try
            {
                string query = @"
                    update dbo.Employee set 
                    FirstName='" + emp.FirstName + @"'
                    ,LastName='" + emp.LastName + @"'
                    ,E_mail='" + emp.E_mail + @"'
                    ,Sex='" + emp.Sex + @"'
                    ,Age='" + emp.Age + @"'
                    ,Hobby='" + emp.Hobby + @"'
                    where EmployeeId=" + emp.PersonId + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Update!!";
            }
        }
        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from dbo.Employee
                    where EmployeeId=" + id + @"
                    ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["EmployeeAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception)
            {

                return "Failed to Delete!!";
            }
        }

        //    [Route("api/Employee/GetAllDepartmentNames")]
        //    [HttpGet]
        //    public HttpResponseMessage GetAllDepartmentNames()
        //    {
        //        string query = @"
        //                select DepartmentName from dbo.Department";
        // 
        //        DataTable table = new DataTable();
        //        using (var con = new SqlConnection(ConfigurationManager.
        //            ConnectionStrings["EmployeeAppDB"].ConnectionString))
        //        using (var cmd = new SqlCommand(query, con))
        //        using (var da = new SqlDataAdapter(cmd))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            da.Fill(table);
        //        }
        // 
        //        return Request.CreateResponse(HttpStatusCode.OK, table);
        //    }
        // 
        //    [Route("api/Employee/SaveFile")]
        //    public string SaveFile()
        //    {
        //        try
        //        {
        //            var httpRequest = HttpContext.Current.Request;
        //            var postedFile = httpRequest.Files[0];
        //            string filename = postedFile.FileName;
        //            var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);
        // 
        //            postedFile.SaveAs(physicalPath);
        // 
        //            return filename;
        //        }
        //        catch (Exception)
        //        {
        // 
        //            return "anonymous.png";
        //        }
        //    }
    }
}
