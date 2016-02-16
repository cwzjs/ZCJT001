using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using ZCJT.Models;
using ZCJT.Common;
using System.Transactions;
using ZCJT.Models.Sys;
using ZCJT.IBLL;
using ZCJT.IDAL;
using ZCJT.BLL.Core;

namespace ZCJT.BLL
{
    public class SysExceptionBLL : BaseBLL, ISysExceptionBLL
    {
        [Dependency]
        public ISysExceptionRepository m_Rep { get; set; }

        public List<SysExceptionModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysException> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Message.Contains(queryStr) || a.Source.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<SysExceptionModel> CreateModelList(ref IQueryable<SysException> queryData)
        {

            List<SysExceptionModel> modelList = (from r in queryData
                                                 select new SysExceptionModel
                                                 {
                                                     Id = r.Id,
                                                     HelpLink = r.HelpLink,
                                                     Message = r.Message,
                                                     Source = r.Source,
                                                     StackTrace = r.StackTrace,
                                                     TargetSite = r.TargetSite,
                                                     Data = r.Data,
                                                     CreateTime = r.CreateTime
                                                 }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysExceptionModel model)
        {
            try
            {
                SysException entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysException();
                entity.Id = model.Id;
                entity.HelpLink = model.HelpLink;
                entity.Message = model.Message;
                entity.Source = model.Source;
                entity.StackTrace = model.StackTrace;
                entity.TargetSite = model.TargetSite;
                entity.Data = model.Data;
                entity.CreateTime = model.CreateTime;
                if (m_Rep.Create(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.InsertFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string id)
        {
            try
            {
                if (m_Rep.Delete(id) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool Delete(ref ValidationErrors errors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                {
                    using (TransactionScope transactionScope = new TransactionScope())
                    {
                        m_Rep.Delete(db, deleteCollection);
                        if (db.SaveChanges() == deleteCollection.Length)
                        {
                            transactionScope.Complete();
                            return true;
                        }
                        else
                        {
                            Transaction.Current.Rollback();
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }
        public bool Edit(ref ValidationErrors errors, SysExceptionModel model)
        {
            try
            {
                SysException entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.HelpLink = model.HelpLink;
                entity.Message = model.Message;
                entity.Source = model.Source;
                entity.StackTrace = model.StackTrace;
                entity.TargetSite = model.TargetSite;
                entity.Data = model.Data;
                entity.CreateTime = model.CreateTime;

                if (m_Rep.Edit(entity) == 1)
                {
                    return true;
                }
                else
                {
                    errors.Add(Suggestion.EditFail);
                    return false;
                }
            }
            catch (Exception ex)
            {
                errors.Add(ex.Message);
                ExceptionHander.WriteException(ex);
                return false;
            }
        }

        public bool IsExists(string id)
        {
            if (db.SysException.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public SysExceptionModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysException entity = m_Rep.GetById(id);
                SysExceptionModel model = new SysExceptionModel();
                model.Id = entity.Id;
                model.HelpLink = entity.HelpLink;
                model.Message = entity.Message;
                model.Source = entity.Source;
                model.StackTrace = entity.StackTrace;
                model.TargetSite = entity.TargetSite;
                model.Data = entity.Data;
                model.CreateTime = entity.CreateTime;
                return model;
            }
            else
            {
                return null;
            }
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }
    }
}
