using System;
using System.ComponentModel.DataAnnotations;
using ZCJT.Models;
namespace ZCJT.Models.Sys
{
    public class SysSampleModel
    {
        
        [Display(Name = "Id")]
        public string Id { get; set; }

        
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Age")]
        public int? Age { get; set; }

        [Display(Name = "Bir")]
        public DateTime? Bir { get; set; }

        
        [Display(Name = "Photo")]
        public string Photo { get; set; }

        
        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "CreateTime")]
        public DateTime? CreateTime { get; set; }

    }
}
