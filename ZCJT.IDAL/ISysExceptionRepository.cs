using ZCJT.Models;
using System.Linq;
namespace ZCJT.IDAL
{
    public interface ISysExceptionRepository
    {
        IQueryable<SysException> GetList(DBContainer db);
        int Create(SysException entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysException entity);
        SysException GetById(string id);
        bool IsExist(string id);
    }
}