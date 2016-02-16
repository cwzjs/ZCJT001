using ZCJT.Models;
using System.Linq;
using System.Collections.Generic;
using ZCJT.Models.Sys;
namespace ZCJT.IDAL
{
    public interface ISysRightRepository
    {
        IQueryable<SysRight> GetList(DBContainer db);
        int Create(SysRight entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysRight entity);
        SysRight GetById(string id);
        bool IsExist(string id);

        List<PermModel> GetPermission(string accountid, string controller);

        //更新
        int UpdateRight(SysRightOperateModel model);
        //按选择的角色及模块加载模块的权限项
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);
    }
}