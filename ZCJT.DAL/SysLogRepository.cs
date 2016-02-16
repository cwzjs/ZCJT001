using System;
using System.Linq;
using ZCJT.IDAL;
using ZCJT.Models;
using System.Data;
using System.Data.Entity;

namespace ZCJT.DAL
{
    public class SysLogRepository : ISysLogRepository, IDisposable
    {

        public IQueryable<SysLog> GetList(DBContainer db)
        {
            IQueryable<SysLog> list = db.SysLog.AsQueryable();
            return list;
        }

        public int Create(SysLog entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysLog.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysLog entity = db.SysLog.SingleOrDefault(a => a.Id == id);
                if (entity != null)
                {

                    db.SysLog.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysLog> collection = from f in db.SysLog
                                            where deleteCollection.Contains(f.Id)
                                            select f;
            foreach (var deleteItem in collection)
            {
                db.SysLog.Remove(deleteItem);
            }
        }

        public int Edit(SysLog entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysLog.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysLog GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysLog.SingleOrDefault(a => a.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysLog entity = GetById(id);
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
