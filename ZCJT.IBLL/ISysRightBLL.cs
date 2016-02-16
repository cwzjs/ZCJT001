using System.Collections.Generic;
using ZCJT.Common;
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysRightBLL
    {
        List<SysRightModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysRightModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysRightModel model);
        SysRightModel GetById(string id);
        bool IsExist(string id);
        //更新
        int UpdateRight(SysRightOperateModel model);
        //按选择的角色及模块加载模块的权限项
        List<SysRightModelByRoleAndModuleModel> GetRightByRoleAndModule(string roleId, string moduleId);
    }
}
