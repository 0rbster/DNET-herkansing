//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UrenregistratieService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taak
    {
        public int TaakId { get; set; }
        public string Type { get; set; }
        public System.TimeSpan Uren { get; set; }
        public int UserUserId { get; set; }
        public int ProjectProjectId { get; set; }
    
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
    }
}
