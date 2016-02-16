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
    public class SysRightBLL : BaseBLL, ISysRightBLL
    {
        [Dependency]
        public ISysRightRepository m_Rep { get; set; }

        public List<SysRightModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<SysRight> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.RoleId.Contains(queryStr) || a.RoleId.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<SysRightModel> CreateModelList(ref IQueryable<SysRight> queryData)
        {

            List<SysRightModel> modelList = (from r in queryData
                                             select new SysRightModel
                                             {
                                                 Id = r.Id,
                                                 ModuleId = r.ModuleId,
                                                 RoleId = r.RoleId,
                                                 Rightflag = r.Rightflag
                                             }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, SysRightModel model)
        {
            try
            {
                SysRight entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new SysRight();
                entity.Id = model.Id;
                entity.ModuleId = model.ModuleId;
                entity.RoleId = model.RoleId;
                entity.Rightflag = model.Rightflag;
                //设置角色组权限
                if (m_Rep.Create(entity) == 1)
                {
                   //db.P_Sys_InsertSysRight();
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
        public bool Edit(ref ValidationErrors errors, SysRightModel model)
        {
            try
            {
                SysRight entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.ModuleId = model.ModuleId;
                entity.RoleId = model.RoleId;
                entity.Rightflag = model.Rightflag;

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
            if (db.SysRight.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public SysRightModel GetById(string id)
        {
            if (IsExist(id))
            {
                SysRight entity = m_Rep.GetById(id);
                SysRightModel model = new SysRightModel();
                model.Id = entity.Id;
                model.ModuleId = entity.ModuleId;
                model.RoleId = entity.RoleId;
                model.Rightflag = entity.Rightflag;
                return model;
            }
            else
            {
                return null;
            }
        }

        public List<PermModel> GetPermission(string accountid, string controller)
        {
            return m_Rep.GetPermission(accountid, controller);
        }

        public bool IsExist(string id)
        {
            return m_Rep.IsExist(id);
        }

        public int UpdateRight(SysRightOperateModel model)
        {
            return m_Rep.UpdateRight(model);
        }

        public List<SysRightModelByRoleAndModuleModel> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<P_Sys_GetRightByRoleAndModule_Result> queryData 
                                            = m_Rep.GetRightByRoleAndModule(roleId, moduleId);
            List<SysRightModelByRoleAndModuleModel> modellist = 
                (from r in queryData
                 select new SysRightModelByRoleAndModuleModel
                 {
                     Ids = r.Id,
                     Name = r.Name,
                     KeyCode = r.KeyCode,
                     IsValid = r.isvalid,
                     RightId = r.RightId
                 }).ToList();
           
            return modellist;
        }
    }
}
