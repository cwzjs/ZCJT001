//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZCJT.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SysRole
    {
        public SysRole()
        {
            this.SysRight = new HashSet<SysRight>();
            this.SysUser = new HashSet<SysUser>();
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateTime { get; set; }
        public string CreatePerson { get; set; }
    
        public virtual ICollection<SysRight> SysRight { get; set; }
        public virtual ICollection<SysUser> SysUser { get; set; }
    }
}
