using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team18App.Models;
using System.IO;

namespace Team18App.Controllers
{
    public class TaskInfoController : Controller
    {
        int x;

        public ActionResult getParamsTI()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult getParamsTI(TaskInfoFormModel tmp)
        {
            x = tmp.ProjectID;

            return RedirectToAction("getTaskInfoView", new { x = tmp.ProjectID });
        }
        // GET: gettaskInfo
        public ActionResult getTaskInfoView(SqlConnection con, int x)
        {
            var model = new List<TaskInfoViewModel>();

            // create a connection
            string ct = "Data Source=team18projectms-server.database.windows.net;Initial Catalog=team18db;Persist Security Info=True;User ID=team18projectms-server-admin;Password=C4734SM3F76MA575$;MultipleActiveResultSets=True;Application Name=EntityFramework";
            con = new SqlConnection(ct);
            try
            {
                con.Open();

                // prepare a command
                SqlCommand command = new SqlCommand("dbo.getTaskInfo", con);
                command.CommandType = CommandType.StoredProcedure;

                // add parameters if you need
                command.Parameters.AddWithValue("@projectCode", x);


                // execute a reader with the command
                using (var reader = command.ExecuteReader())
                {
                    // loop in the result and fill the list
                    while (reader.Read())
                    {
                        // add items in the list
                        model.Add(new TaskInfoViewModel()
                        {
                            TaskName = (string)reader["Task"],
                            TaskBudget = (decimal)reader["Budget"],
                            Deadline = (System.DateTime)reader["Deadline"],
                            ProjectName = (string)reader["Project Name"],
                            Department = (string)reader["Department Name"],
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
