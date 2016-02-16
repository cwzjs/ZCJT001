using System;
using System.Linq;
using ZCJT.IDAL;
using ZCJT.Models;
using System.Data;
using System.Data.Entity;

namespace ZCJT.DAL
{
    public class SysExceptionRepository : ISysExceptionRepository, IDisposable
    {

        public IQueryable<SysException> GetList(DBContainer db)
        {
            IQueryable<SysException> list = db.SysException.AsQueryable();
            return list;
        }

        public int Create(SysException entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysException.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysException entity = db.SysException.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysException.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysException> collection = from f in db.SysException
                                                  where deleteCollection.Contains(f.Id)
                                                  select f;
            foreach (var deleteItem in collection)
            {
                db.SysException.Remove(deleteItem);
            }
        }

        public int Edit(SysException entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysException.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysException GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysException.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysException entity = GetById(id);
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
