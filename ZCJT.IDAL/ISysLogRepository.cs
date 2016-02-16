using ZCJT.Models;
using System.Linq;
namespace ZCJT.IDAL
{
    public interface ISysLogRepository
    {
        IQueryable<SysLog> GetList(DBContainer db);
        int Create(SysLog entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysLog entity);
        SysLog GetById(string id);
        bool IsExist(string id);
    }
}