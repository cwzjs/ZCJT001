using ZCJT.Models;
using System.Linq;
namespace ZCJT.IDAL
{
    public interface ISysRoleRepository
    {
        IQueryable<SysRole> GetList(DBContainer db);
        int Create(SysRole entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysRole entity);
        SysRole GetById(string id);
        bool IsExist(string id);

        IQueryable<SysUser> GetRefSysUser(DBContainer db, string id);
        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(DBContainer db, string roleId);
        void UpdateSysRoleSysUser(string roleId, string[] userIds);
    }
}