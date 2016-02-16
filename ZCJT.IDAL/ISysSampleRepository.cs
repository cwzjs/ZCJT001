using ZCJT.Models;
using System.Linq;
namespace ZCJT.IDAL
{
    public interface ISysSampleRepository
    {
        IQueryable<SysSample> GetList(DBContainer db);
        int Create(SysSample entity);
        int Delete(string id);
        void Delete(DBContainer db, string[] deleteCollection);
        int Edit(SysSample entity);
        SysSample GetById(string id);
        bool IsExist(string id);
    }
}