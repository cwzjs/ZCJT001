using System;
using System.ComponentModel.DataAnnotations;
using ZCJT.Models;
namespace ZCJT.Models.Sys
{
    public class SysExceptionModel
    {

        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "帮助链接")]
        public string HelpLink { get; set; }

        [Display(Name = "异常信息")]
        public string Message { get; set; }

        [Display(Name = "来源")]
        public string Source { get; set; }

        [Display(Name = "堆栈")]
        public string StackTrace { get; set; }

        [Display(Name = "目标页")]
        public string TargetSite { get; set; }

        [Display(Name = "程序集")]
        public string Data { get; set; }

        [Display(Name = "发生时间")]
        public DateTime? CreateTime { get; set; }

    }
}
