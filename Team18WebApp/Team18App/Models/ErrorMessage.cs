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
    
    public partial class ErrorMessage
    {
        public int MessageID { get; set; }
        public int ProjectID { get; set; }
        public string ErrorDescription { get; set; }
    
        public virtual Project Project { get; set; }
    }
}
