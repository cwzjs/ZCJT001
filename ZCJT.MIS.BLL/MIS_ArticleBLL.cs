using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using ZCJT.Models;
using ZCJT.Common;
using System.Transactions;
using ZCJT.Models.MIS;
using ZCJT.MIS.IBLL;
using ZCJT.MIS.IDAL;
using ZCJT.BLL.Core;

namespace ZCJT.MIS.BLL
{
    public class MIS_ArticleBLL : BaseBLL, IMIS_ArticleBLL
    {
        [Dependency]
        public IMIS_ArticleRepository m_Rep { get; set; }

        public List<MIS_ArticleModel> GetList(ref GridPager pager, string queryStr)
        {

            IQueryable<MIS_Article> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(db).Where(a => a.Title.Contains(queryStr) || a.BodyContent.Contains(queryStr));
            }
            else
            {
                queryData = m_Rep.GetList(db);
            }
            pager.totalRows = queryData.Count();
            queryData = LinqHelper.SortingAndPaging(queryData, pager.sort, pager.order, pager.page, pager.rows);
            return CreateModelList(ref queryData);
        }
        private List<MIS_ArticleModel> CreateModelList(ref IQueryable<MIS_Article> queryData)
        {

            List<MIS_ArticleModel> modelList = (from r in queryData
                                                select new MIS_ArticleModel
                                                {
                                                    Id = r.Id,
                                                    ChannelId = r.ChannelId,
                                                    CategoryId = r.CategoryId,
                                                    Title = r.Title,
                                                    ImgUrl = r.ImgUrl,
                                                    BodyContent = r.BodyContent,
                                                    Sort = r.Sort,
                                                    Click = r.Click,
                                                    CheckFlag = r.CheckFlag,
                                                    Checker = r.Checker,
                                                    CheckDateTime = r.CheckDateTime,
                                                    Creater = r.Creater,
                                                    CreateTime = r.CreateTime
                                                }).ToList();
            return modelList;
        }

        public bool Create(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity != null)
                {
                    errors.Add(Suggestion.PrimaryRepeat);
                    return false;
                }
                entity = new MIS_Article();
                entity.Id = model.Id;
                entity.ChannelId = model.ChannelId;
                entity.CategoryId = model.CategoryId;
                entity.Title = model.Title;
                entity.ImgUrl = model.ImgUrl;
                entity.BodyContent = model.BodyContent;
                entity.Sort = model.Sort;
                entity.Click = model.Click;
                entity.CheckFlag = model.CheckFlag;
                entity.Checker = model.Checker;
                entity.CheckDateTime = model.CheckDateTime;
                entity.Creater = model.Creater;
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
        public bool Edit(ref ValidationErrors errors, MIS_ArticleModel model)
        {
            try
            {
                MIS_Article entity = m_Rep.GetById(model.Id);
                if (entity == null)
                {
                    errors.Add(Suggestion.Disable);
                    return false;
                }
                entity.Id = model.Id;
                entity.ChannelId = model.ChannelId;
                entity.CategoryId = model.CategoryId;
                entity.Title = model.Title;
                entity.ImgUrl = model.ImgUrl;
                entity.BodyContent = model.BodyContent;
                entity.Sort = model.Sort;
                entity.Click = model.Click;
                entity.CheckFlag = model.CheckFlag;
                entity.Checker = model.Checker;
                entity.CheckDateTime = model.CheckDateTime;
                entity.Creater = model.Creater;
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
            if (db.MIS_Article.SingleOrDefault(a => a.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public MIS_ArticleModel GetById(string id)
        {
            if (IsExist(id))
            {
                MIS_Article entity = m_Rep.GetById(id);
                MIS_ArticleModel model = new MIS_ArticleModel();
                model.Id = entity.Id;
                model.ChannelId = entity.ChannelId;
                model.CategoryId = entity.CategoryId;
                model.Title = entity.Title;
                model.ImgUrl = entity.ImgUrl;
                model.BodyContent = entity.BodyContent;
                model.Sort = entity.Sort;
                model.Click = entity.Click;
                model.CheckFlag = entity.CheckFlag;
                model.Checker = entity.Checker;
                model.CheckDateTime = entity.CheckDateTime;
                model.Creater = entity.Creater;
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
