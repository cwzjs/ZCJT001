using System.Collections.Generic;
using System.Linq;
using ZCJT.Common;
using ZCJT.Models;
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysRoleBLL
    {
        List<SysRoleModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysRoleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysRoleModel model);
        SysRoleModel GetById(string id);
        bool IsExist(string id);

        string GetRefSysUser(string roleId);
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId);
        bool UpdateSysRoleSysUser(string roleId, string[] userIds);
    }
}
