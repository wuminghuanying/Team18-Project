using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;

namespace Team18App.Controllers
{
        [Authorize]
    public class TopEmployeesController : Controller
    {
        int x;
        string y;
        public ActionResult getParamsTE()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getParamsTE(TopEmployeeFormModel tmp)
        {
            x = tmp.hoursWorked;
            y = tmp.departmentName;
            return RedirectToAction("Index");
        }
        // GET: TopEmployees
        public ActionResult Index()
        {
            var model = new List<TopEmployeeViewModel>();

            // create a connection
            SqlConnection con = new SqlConnection("Data Source=team18projectms-server.database.windows.net;Initial Catalog=team18db;Persist Security Info=True;User ID=team18projectms-server-admin;Password=C4734SM3F76MA575$;MultipleActiveResultSets=True;Application Name=EntityFramework");
            try
            {
                // open the conneciton
                con.Open();

                // prepare a command
                SqlCommand command = new SqlCommand("dbo.getTopEmployees", con);
                command.CommandType = CommandType.StoredProcedure;

                // add parameters if you need
                command.Parameters.AddWithValue("@hoursWorked", x);
                command.Parameters.AddWithValue("@deptName", y);
                // execute a reader with the command
                using (var reader = command.ExecuteReader())
                {
                    // loop in the result and fill the list
                    while (reader.Read())
                    {
                        // add items in the list
                        model.Add(new TopEmployeeViewModel()
                        {
                            EmployeeID = (int)reader["ID"],
                            FirstName = reader["First Name"].ToString(),
                            LastName = reader["Last Name"].ToString(),
                            HoursWorked = (int)reader["Total Hours Worked"]
                            // other properties
                        });
                    }
                }
            }
            catch
            {
            }
            finally
            {
                con.Close();
            }

            return View(model);
        }
    }
}
