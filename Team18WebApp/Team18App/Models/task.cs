//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Team18App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public decimal TaskBudget { get; set; }
        public string TaskName { get; set; }
        public System.DateTime TaskDeadline { get; set; }
        public int TaskStatus { get; set; }
        public decimal TaskExpenses { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual Status Status { get; set; }
    }
}
