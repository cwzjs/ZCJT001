using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ZCJT.Common;
using ZCJT.Models.Sys;

namespace ZCJT.Web
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 当前登陆的用户属性
        /// </summary>
        public AccountModel CurrentAccount { get; set; }

        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //得到用户登录的信息
            CurrentAccount = Session["Account"] as AccountModel;

            //判断用户是否为空
            if (CurrentAccount == null)
            {
                Response.Redirect("/Account/Index");
            }
        }

        /// <summary>
        /// 获取当前用户Id
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = (AccountModel)Session["Account"];
                return info.Id;
            }
            else
            {

                return "";
            }
        }
        /// <summary>
        /// 获取当前用户Name
        /// </summary>
        /// <returns></returns>
        public string GetUserTrueName()
        {
            if (Session["Account"] != null)
            {
                AccountModel info = (AccountModel)Session["Account"];
                return info.TrueName;
            }
            else
            {
                return "";
            }
        }
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns>用户信息</returns>
        public AccountModel GetAccount()
        {
            if (Session["Account"] != null)
            {
                return (AccountModel)Session["Account"];
            }
            return null;
        }

        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ToJsonResult
            {
                Data = data,
                ContentEncoding = contentEncoding,
                ContentType = contentType,
                JsonRequestBehavior = behavior,
                FormateStr = "yyyy-MM-dd HH:mm:ss"
            };
        }
        /// <summary>
        /// 返回JsonResult.24         /// </summary>
        /// <param name="data">数据</param>
        /// <param name="behavior">行为</param>
        /// <param name="format">json中dateTime类型的格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, JsonRequestBehavior behavior, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                JsonRequestBehavior = behavior,
                FormateStr = format
            };
        }
        /// <summary>
        /// 返回JsonResult42         /// </summary>
        /// <param name="data">数据</param>
        /// <param name="format">数据格式</param>
        /// <returns>Json</returns>
        protected JsonResult MyJson(object data, string format)
        {
            return new ToJsonResult
            {
                Data = data,
                FormateStr = format
            };
        }
        /// <summary>
        /// 检查SQL语句合法性
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ValidateSQL(string sql, ref string msg)
        {
            if (sql.ToLower().IndexOf("delete") > 0)
            {
                msg = "查询参数中含有非法语句DELETE";
                return false;
            }
            if (sql.ToLower().IndexOf("update") > 0)
            {
                msg = "查询参数中含有非法语句UPDATE";
                return false;
            }

            if (sql.ToLower().IndexOf("insert") > 0)
            {
                msg = "查询参数中含有非法语句INSERT";
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取当前页或操作访问权限
        /// </summary>
        /// <returns>权限列表</returns>
        public List<PermModel> GetPermission()
        {
            string filePath = HttpContext.Request.FilePath;

            List<PermModel> perm = (List<PermModel>)Session[filePath];
            return perm;
        }

    }
}