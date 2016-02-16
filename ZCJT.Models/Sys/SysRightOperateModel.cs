using System;
using System.ComponentModel.DataAnnotations;
using ZCJT.Models;
namespace ZCJT.Models.Sys
{
    public class SysRightOperateModel
    {
        
        [Display(Name = "Id")]
        public string Id { get; set; }

        
        [Display(Name = "RightId")]
        public string RightId { get; set; }

        
        [Display(Name = "KeyCode")]
        public string KeyCode { get; set; }

        [Display(Name = "IsValid")]
        public bool IsValid { get; set; }

    }
}
