using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team18App.Models
{
    public class TaskInfoViewModel
    {
        public string TaskName { get; set; }
        public decimal TaskBudget { get; set; }
        public System.DateTime Deadline { get; set; }
        public string ProjectName { get; set; }

        public string Department { get; set; }
    }
}