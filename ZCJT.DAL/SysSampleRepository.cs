using System;
using System.Linq;
using ZCJT.Models;
using System.Data;
using ZCJT.IDAL;
using System.Data.Entity;

namespace ZCJT.DAL
{
    public class SysSampleRepository : ISysSampleRepository, IDisposable
    {

        public IQueryable<SysSample> GetList(DBContainer db)
        {
            IQueryable<SysSample> list = db.SysSample.AsQueryable();
            return list;
        }

        public int Create(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysSample.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = db.SysSample.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysSample.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysSample> collection = from f in db.SysSample
                                               where deleteCollection.Contains(f.Id)
                                               select f;
            foreach (var deleteItem in collection)
            {
                db.SysSample.Remove(deleteItem);
            }
        }

        public int Edit(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysSample.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysSample GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysSample.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = GetById(id);
                if (entity != null)
                    return true;
                return false;
            }
        }
        public void Dispose()
        {

        }
    }
}
