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
    public class SysLogBLL : BaseBLL, ISysLogBLL
    {
        [Dependency]
        public ISysLogRepository m_Rep { get; set; }

        public List<SysLogModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysLog> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Operator.Contains(queryStr) || a.Message.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<SysLogModel> CreateModelList(ref IQueryable<SysLog> queryData)
        {

            List<SysLogModel> modelList = (from r in queryData
                                           select new SysLogModel
                                           {
                                               Id = r.Id,
                                               Operator = r.Operator,
                                               Message = r.Message,
                                               Result = r.Result,
                                               Type = r.Type,
                                               Module = r.Module,
                                               CreateTime = r.CreateTime
                                           }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysLogModel model)
        {
            try
            {
                SysLog entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysLog();
                entity.Id = model.Id;
                entity.Operator = model.Operator;
                entity.Message = model.Message;
                entity.Result = model.Result;
                entity.Type = model.Type;
                entity.Module = model.Module;
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
        public bool Edit(ref ValidationErrors errors, SysLogModel model)
        {
            try
            {
                SysLog entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.Operator = model.Operator;
                entity.Message = model.Message;
                entity.Result = model.Result;
                entity.Type = model.Type;
                entity.Module = model.Module;
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
            if (db.SysLog.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public SysLogModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysLog entity = m_Rep.GetById(id);
                SysLogModel model = new SysLogModel();
                model.Id = entity.Id;
                model.Operator = entity.Operator;
                model.Message = entity.Message;
                model.Result = entity.Result;
                model.Type = entity.Type;
                model.Module = entity.Module;
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
