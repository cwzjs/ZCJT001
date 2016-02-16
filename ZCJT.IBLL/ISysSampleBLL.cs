using ZCJT.Common;
using System.Collections.Generic; 
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysSampleBLL
    {
        List<SysSampleModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysSampleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysSampleModel model);
        SysSampleModel GetById(string id);
        bool IsExist(string id);
    }
}
