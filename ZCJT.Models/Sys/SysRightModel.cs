using System;
using System.ComponentModel.DataAnnotations;
using ZCJT.Models;
namespace ZCJT.Models.Sys
{
    public class SysRightModel
    {
        
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "ModuleId")]
        public string ModuleId { get; set; }

        [Display(Name = "RoleId")]
        public string RoleId { get; set; }

        public bool Rightflag { get; set; }

    }
}
