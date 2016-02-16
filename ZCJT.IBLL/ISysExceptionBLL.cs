using System.Collections.Generic;
using ZCJT.Common;
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysExceptionBLL
    {
        List<SysExceptionModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysExceptionModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysExceptionModel model);
        SysExceptionModel GetById(string id);
        bool IsExist(string id);
    }
}
