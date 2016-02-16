using System.Collections.Generic;
using System.Linq;
using ZCJT.Common;
using ZCJT.Models;
using ZCJT.Models.Sys;
namespace ZCJT.IBLL
{
    public interface ISysUserBLL
    {
        List<SysUserModel> GetList(ref GridPager pager, string queryStr);
        bool Create(ref ValidationErrors errors, SysUserModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Delete(ref ValidationErrors errors, string[] deleteCollection);
        bool Edit(ref ValidationErrors errors, SysUserModel model);
        SysUserModel GetById(string id);
        bool IsExist(string id);

        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(ref GridPager pager, string userId);
        bool UpdateSysRoleSysUser(string userId, string[] roleIds);
    }
}
