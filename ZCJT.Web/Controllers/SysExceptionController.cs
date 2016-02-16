using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ZCJT.Common;
using ZCJT.IBLL;
using ZCJT.Models.Sys;
using Microsoft.Practices.Unity;

namespace ZCJT.Web.Controllers
{
    public class SysExceptionController : BaseController
    {
        [Dependency]
        public ISysExceptionBLL m_BLL { get; set; }
        ValidationErrors errors = new ValidationErrors();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager, string queryStr)
        {
            List<SysExceptionModel> list = m_BLL.GetList(ref pager, queryStr);
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        select new SysExceptionModel()
                        {

                            Id = r.Id,
                            HelpLink = r.HelpLink,
                            Message = r.Message,
                            Source = r.Source,
                            StackTrace = r.StackTrace,
                            TargetSite = r.TargetSite,
                            Data = r.Data,
                            CreateTime = r.CreateTime

                        }).ToArray()

            };

            return Json(json);
        }

        #region 创建
        [SupportFilter]
        public ActionResult Create()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Create(SysExceptionModel model)
        {
            model.Id = ResultHelper.NewId;
            model.CreateTime = ResultHelper.NowTime;
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Create(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",HelpLink" + model.Message, "成功", "创建", "SysException");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.InsertSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",HelpLink" + model.Message + "," + ErrorCol, "失败", "创建", "SysException");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.InsertFail));
            }
        }
        #endregion

        #region 修改
        [SupportFilter]
        public ActionResult Edit(string id)
        {
            ViewBag.Perm = GetPermission();
            SysExceptionModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [SupportFilter]
        public JsonResult Edit(SysExceptionModel model)
        {
            if (model != null && ModelState.IsValid)
            {

                if (m_BLL.Edit(ref errors, model))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",HelpLink" + model.Message, "成功", "修改", "SysException");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.EditSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + model.Id + ",HelpLink" + model.Message + "," + ErrorCol, "失败", "修改", "SysException");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.EditFail));
            }
        }
        #endregion

        #region 详细
        [SupportFilter]
        public ActionResult Details(string id)
        {
            ViewBag.Perm = GetPermission();
            SysExceptionModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        [SupportFilter]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(ref errors, id))
                {
                    LogHandler.WriteServiceLog(GetUserId(), "Id:" + id, "成功", "删除", "SysException");
                    return Json(JsonHandler.CreateMessage(1, Suggestion.DeleteSucceed));
                }
                else
                {
                    string ErrorCol = errors.Error;
                    LogHandler.WriteServiceLog(GetUserId(), "Id" + id + "," + ErrorCol, "失败", "删除", "SysException");
                    return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail + ErrorCol));
                }
            }
            else
            {
                return Json(JsonHandler.CreateMessage(0, Suggestion.DeleteFail));
            }


        }
        #endregion

        public ActionResult Error()
        {

            BaseException ex = new BaseException();
            return View(ex);
        }

    }
}
