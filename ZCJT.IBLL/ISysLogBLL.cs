using System.Collections.Generic;
using ZCJT.Common;
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysLogBLL
    {
        List<SysLogModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysLogModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysLogModel model);
        SysLogModel GetById(string id);
        bool IsExist(string id);
    }
}
