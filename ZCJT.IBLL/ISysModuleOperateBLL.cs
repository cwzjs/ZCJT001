using System.Collections.Generic;
using ZCJT.Common;
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysModuleOperateBLL
    {
        List<SysModuleOperateModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysModuleOperateModel model);
        bool Delete(ref ValidationErrors errors, string id);
        SysModuleOperateModel GetById(string id);
        bool IsExist(string id);
    }
}
