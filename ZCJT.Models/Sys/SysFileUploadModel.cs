using System;
using System.ComponentModel.DataAnnotations;
using ZCJT.Models;
namespace ZCJT.Models.Sys
{
    public class SysFileUploadModel
    {
        [MaxWordsExpression(50)]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [MaxWordsExpression(10)]
        [Display(Name = "FileName")]
        public string FileName { get; set; }

        [MaxWordsExpression(10)]
        [Display(Name = "FileExtend")]
        public string FileExtend { get; set; }

        [MaxWordsExpression(50)]
        [Display(Name = "AttachmnetGUID")]
        public string AttachmentGUID { get; set; }

        [Display(Name = "AddTime")]
        public DateTime AddTime { get; set; }

        [MaxWordsExpression(20)]
        [Display(Name = "Editor")]
        public string Editor { get; set; }

        [MaxWordsExpression(50)]
        [Display(Name = "OwnerID")]
        public string OwnerID { get; set; }

        public byte[] FileData { get; set; }

        public int FileSize { get; set; }
    }
}
