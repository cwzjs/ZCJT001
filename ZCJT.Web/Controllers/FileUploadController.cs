using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZCJT.Models.Sys;

namespace ZCJT.Web.Controllers
{
    public class FileUploadController : BaseController
    {
[AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Upload(HttpPostedFileBase fileData, string guid, string folder)
        {
            if (fileData != null)
            {
                try
                {
                    ControllerContext.HttpContext.Request.ContentEncoding = Encoding.GetEncoding("UTF-8");
                    ControllerContext.HttpContext.Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
                    ControllerContext.HttpContext.Response.Charset = "UTF-8";

                    // 文件上传后的保存路径
                    string filePath = Server.MapPath("~/UploadFiles/");
                    //DirectoryUtil.AssertDirExist(filePath);

                    string fileName = Path.GetFileName(fileData.FileName);      //原始文件名称
                    string fileExtension = Path.GetExtension(fileName);         //文件扩展名
                    string saveName = Guid.NewGuid().ToString() + fileExtension; //保存文件名称

                    SysFileUploadModel info = new SysFileUploadModel();
                    info.FileData = ReadFileBytes(fileData);
                    if (info.FileData != null)
                    {
                        info.FileSize = info.FileData.Length;
                    }
                    //info.Category = folder;
                    info.FileName = fileName;
                    info.FileExtend = fileExtension;
                    info.AttachmentGUID = guid;
                    info.AddTime = DateTime.Now;
                    info.Editor = GetUserId();//登录人
                    //info.Owner_ID = OwerId;//所属主表记录ID

                    //CommonResult result = BLLFactory<FileUpload>.Instance.Upload(info);
                    //if (!result.Success)
                    //{
                    //    LogTextHelper.Error("上传文件失败:" + result.ErrorMessage);
                    //}
                    return Content("success");
                }
                catch (Exception ex)
                {
                    return Content("false");
                }
            }
            else
            {
                return Content("false");
            }
        }

        private byte[] ReadFileBytes(HttpPostedFileBase fileData)
        {
            byte[] data;
            using (Stream inputStream = fileData.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            return data;
        }

    }
}
