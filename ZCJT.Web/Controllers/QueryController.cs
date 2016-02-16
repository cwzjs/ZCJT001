using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using ZCJT.IBLL;
using ZCJT.Models.Sys;
using System.Web.Mvc;
using ZCJT.Common;
using ZCJT.Models;
using Microsoft.Practices.Unity;

namespace ZCJT.Web.Controllers
{
    public class QueryController : BaseController
    {
        //
        // GET: /Query/
    
        public ActionResult Index()
        {
            return View();
        }

   // [SupportFilter]
        public ActionResult DDCXTest()
        {
            ViewBag.perm = GetPermission();
            return View();
        }
        public ActionResult XSDDCX()
        {
            ViewBag.perm = GetPermission();
            return View();
        }

        public ActionResult XSDDCX_JG()
        {
            ViewBag.perm = GetPermission();
            return View();
        }


      //  [SupportFilter]
        public ActionResult SampleQuery()
        {
            ViewBag.Perm = GetPermission();
            return View();
        }

        [HttpPost]
        public JsonResult GetSampleList(GridPager pager, string startDate, string endDate, string name)
        {
            var db = new PetaPoco.Database("DBContainer");

            db.EnableAutoSelect = false;
            var sql = new StringBuilder();
            //sql.Append("exec P_Sys_QuerySample @name,@age");

            //var dataList = db.Query<SysSample>(sql.ToString(), new { name="",age=0}).ToList();

            var querysql = "select * from SysSample where 1=1 ";
          
            string tableName = "(" + querysql + ") as a";
            string reFieldsStr = "*";
            string orderString = "CreateTime";
            string whereString = "";
         
            int pageSize = pager.rows;
            int pageIndex = pager.page;


            var TotalRecord = new SqlParameter("TotalRecord", SqlDbType.Int);
            TotalRecord.Direction = System.Data.ParameterDirection.Output;
            TotalRecord.Value = 0;

            sql.Append("exec PROCE_PAGECHANGE @TableName,@ReFieldsStr,@OrderString,@WhereString,@PageSize,@PageIndex,@TotalRecord OUTPUT");

            var dataList = db.Query<SysSample>(sql.ToString(), new
            {
                TableName = tableName,
                ReFieldsStr = reFieldsStr,
                OrderString = orderString,
                WhereString = whereString,
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalRecord = TotalRecord
            }).ToList();
            var json = new
            {
                total = TotalRecord.Value,
                rows = dataList
            };

            return Json(json);
        }

        //[HttpPost]
        ////参数写法一
        //public JsonResult GetXSDDCX(GridPager pager, string date1,string date2,string ywy,string ddbh)
        //{ 
        //    //分页存储过程
        //    var db = new PetaPoco.Database("FlexFrameDB2");

        //    db.EnableAutoSelect = false;
        //    var sql = new StringBuilder(); 
        //    int pageSize = pager.rows;
        //    int pageIndex = pager.page;


        //    var TotalRecord = new SqlParameter("TotalRecord", SqlDbType.Int);
        //    TotalRecord.Direction = System.Data.ParameterDirection.Output;
        //    TotalRecord.Value = 0;

        //    sql.Append("exec xsddcx_fy  @date1,@date2,@ywy,@ddbh,@PageSize,@PageIndex,@TotalRecord OUTPUT");
   
        //    var dataList = db.Query<ZCJT.Models.Query.XSDDCXModel>(sql.ToString(), new
        //    { //设置存储过程参数，返回总行数 
        //        date1 = date1,
        //        date2 = date2,
        //        ywy =ywy ,
        //        ddbh =ddbh,
        //        PageSize = pageSize,
        //        PageIndex = pageIndex,
        //        TotalRecord = TotalRecord
        //    }).ToList();
        //    var json = new
        //    {
        //        total = TotalRecord.Value,
        //        rows = dataList
        //    };

        //    return Json(json);
        //}

        [HttpPost]
        //参数写法二，序列化传入
        public JsonResult GetXSDDCX(GridPager pager, FormCollection form)
        {
            //分页存储过程
            var db = new PetaPoco.Database("FlexFrameDB");

            db.EnableAutoSelect = false;
            var sql = new StringBuilder();
            int pageSize = pager.rows;
            int pageIndex = pager.page;

            //根据表单元素名取值
            string date1 = form.Get("date1") ?? "";//语法意思是：如果date1有值，就取date1值，否则，取“”
            string date2 = form.Get("date2") ?? "";
            string ywy = form.Get("ywy") ?? "";
            string ddbh = form.Get("ddbh") ?? "";

            var TotalRecord = new SqlParameter("TotalRecord", SqlDbType.Int);
            TotalRecord.Direction = System.Data.ParameterDirection.Output;
            TotalRecord.Value = 0;

            sql.Append("exec xsddcx_fy  @date1,@date2,@ywy,@ddbh,@PageSize,@PageIndex,@TotalRecord OUTPUT");

            var dataList = db.Query<ZCJT.Models.Query.XSDDCXModel>(sql.ToString(), new
            { //设置存储过程参数，返回总行数 
                date1 = date1,
                date2 = date2,
                ywy = ywy,
                ddbh = ddbh,
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalRecord = TotalRecord
            }).ToList();
            var json = new
            {
                total = TotalRecord.Value,
                rows = dataList
            };

            return Json(json);
        }

        [HttpPost]
        //参数写法二，序列化传入
        public JsonResult GetXSDDCX_JG(GridPager pager, FormCollection form)
        {
            //分页存储过程
            var db = new PetaPoco.Database("FlexFrameDB");

            db.EnableAutoSelect = false;
            var sql = new StringBuilder();
            int pageSize = pager.rows;
            int pageIndex = pager.page;

            //根据表单元素名取值
            string date1 = form.Get("date1") ?? "";//语法意思是：如果date1有值，就取date1值，否则，取“”
            string date2 = form.Get("date2") ?? "";
            string khbh = form.Get("khbh") ?? "";
            string ddbh = form.Get("ddbh") ?? "";
            string wlmc = form.Get("wlmc") ?? "";
            string flag = form.Get("flag") ?? "";
            string UserId = CurrentAccount.Id;

            var TotalRecord = new SqlParameter("TotalRecord", SqlDbType.Int);
            TotalRecord.Direction = System.Data.ParameterDirection.Output;
            TotalRecord.Value = 0;

            sql.Append("exec XSDDCX_WEB  @date1,@date2,@khbh,@ddbh,@wlmc,@flag,@UserId,@PageSize,@PageIndex,@TotalRecord OUTPUT");

            var dataList = db.Query<ZCJT.Models.Query.XSDDCX_JG_Model>(sql.ToString(), new
            { //设置存储过程参数，返回总行数 
                date1 = date1,
                date2 = date2,
                khbh = khbh,
                ddbh = ddbh,
                wlmc =wlmc,
                flag =flag,
                UserId=UserId,
                PageSize = pageSize,
                PageIndex = pageIndex,
                TotalRecord = TotalRecord
            }).ToList();
            var json = new
            {
                total = TotalRecord.Value,
                rows = dataList
            };

            return Json(json);
        }

        public JsonResult GetComboxZWzgzd(string vsWhere)
        {//获取当前用户ID，职工字典加载存储过程
            string userBH = CurrentAccount.Id ;
            var db = new PetaPoco.Database("FlexFrameDB");
            db.EnableAutoSelect = false;
            var sql = new StringBuilder();

            //用户id传进存储过程，当数据权限
            sql.Append("exec pro_zwzgzd @id "); 
            var sysZwzgzd = db.Query<ZCJT.Models.Dict.DictZWZGZD>(sql.ToString(), new { id = userBH  }).ToList();

            var json = new
            {
                total = sysZwzgzd.Count(),
                rows = sysZwzgzd
            };

            return Json(json, JsonRequestBehavior.AllowGet);

        }
        //GetComboxZwwldw

        public JsonResult GetComboxZwwldw(string vsWhere)
        {//获取当前用户ID，往来单位和用户表有对应关系
            string userBH = CurrentAccount.Id;
            var db = new PetaPoco.Database("FlexFrameDB");
            db.EnableAutoSelect = false;
            var sql = new StringBuilder();

            //用户id传进存储过程，当数据权限
            sql.Append("exec pro_zwwldw @id ");
            var sysZwwldw = db.Query<ZCJT.Models.Dict.DictZWZGZD>(sql.ToString(), new { id = userBH }).ToList();
            
            var json = new
            {
                total = sysZwwldw.Count(),
                rows = sysZwwldw
            };

            return Json(json, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetNameComboxData()
        {//例子
            var db = new PetaPoco.Database("FlexFrameDB");
            var sql = "select distinct Name,Age from syssample";
            var sysSamples = db.Query<SysSample>(sql, "").ToList();

            var json = new
            {
                total = sysSamples.Count(),
                rows = sysSamples
            };

            return Json(json, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetWLZD(GridPager pager, string queryStr)
        {
            var db = new PetaPoco.Database("FlexFrameDB");//数据库连接webconfig
            db.EnableAutoSelect = false;
            var sql = new StringBuilder();
            sql.Append("exec wlzd_cx @wlbh ,@lbbh");

            // var dataList = db.Query<WLZDModel>(sql.ToString(), "", 0).ToList();
            var dataList = db.Query<ZCJT.Models.Query.WLZDModel>(sql.ToString(), new { wlbh = "", lbbh = "" }).ToList();
            var json = new
            {
                total = pager.totalRows,
                rows = dataList
            };

            return Json(json);
        }

    }
}
