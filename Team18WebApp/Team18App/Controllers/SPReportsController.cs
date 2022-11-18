
 using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Web;  
using System.Web.Mvc;  
using Team18App.Models;  
using System.Data.Objects;  
using System.Data;  
  
namespace Team18App.Controllers  
{  
    public class SPReportsController : Controller  
    {  
        //  
        // GET: /Student/  
  
        public ActionResult getProjectInfo()  // to get the Student Details  
        {  
            Entities _entity = new Entities();  
            return View(_entity.getProjectInfo(2));  //calling our entity imported function  
        }  
        public ActionResult getTaskInfo()  
        {  
            Entities _entity = new Entities(); //to Get the student details filtered with student city  
            return View(_entity.getTaskInfo(3)); //calling our entity imported function "Bangalore" is our input parameter  
        }  
        
        
        public ActionResult getParamsTE(int deptNum, int projNum, int HoursWorked) //to Get the student details filter with student city and age  
        {  
            Entities _entity = new Entities();
            int dp = deptNum;
            int pN = projNum;
            int hW = HoursWorked;
            return View(_entity.getTopEmployees(hW,dp,pN)); //calling our entity imported function "Bangalore" and 12 is our input parameters  
        }  
        /*public ActionResult getStudentsCountbyCity() //to get the count of student details filter with student city  
        {  
            Entities _entity = new Entities();  
            ObjectParameter returnId = new ObjectParameter("Count", typeof(int)); //Create Object parameter to receive a output value.It will behave like output parameter  
            var value = _entity.getStudentsCountbyCity("Bangalore", returnId).ToList(); //calling our entity imported function "Bangalore" is our input parameter, returnId is a output parameter, it will receive the output value   
            ViewBag.StudentsCount = Convert.ToInt32(returnId.Value); //set the out put value to StudentsCount ViewBag  
            return View();  
        }*/  
  
    }  
}