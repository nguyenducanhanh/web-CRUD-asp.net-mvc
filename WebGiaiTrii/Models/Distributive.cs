//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebGiaiTrii.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Distributive
    {
        public int idAccount { get; set; }
        public int idFunction { get; set; }
        public string Note { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Function Function { get; set; }
    }
}
