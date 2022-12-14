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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Departments = new HashSet<Department>();
            this.Projects = new HashSet<Project>();
            this.WorksOns = new HashSet<WorksOn>();
        }
    
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public System.DateTime DOB { get; set; }
        public string Sex { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<decimal> Hourly_rate { get; set; }
    
        public virtual Department Department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorksOn> WorksOns { get; set; }
    }
}
