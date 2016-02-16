using ZCJT.Models;
using System.Linq;
namespace ZCJT.IDAL
{
    public interface ISysModuleOperateRepository
    {
        IQueryable<SysModuleOperate> GetList(DBContainer db);
        int Create(SysModuleOperate entity);
        int Delete(string id);
        SysModuleOperate GetById(string id);
        bool IsExist(string id);
    }
}