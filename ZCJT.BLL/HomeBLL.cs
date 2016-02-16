using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using ZCJT.IBLL;
using ZCJT.Models;
using ZCJT.IDAL;
using ZCJT.Models.Sys;
namespace ZCJT.BLL
{
   
    public class HomeBLL:IHomeBLL
    {
        [Dependency]
        public IHomeRepository HomeRepository { get; set; }

        public List<SysModuleModel> GetMenuByPersonId(string personId, string moduleId)
        {
            List<SysModule> listSysModule = HomeRepository.GetMenuByPersonId(personId, moduleId);

            return listSysModule.Select(sysModule => new SysModuleModel()
            {
                Id = sysModule.Id, Name = sysModule.Name, EnglishName = sysModule.EnglishName, ParentId = sysModule.ParentId, Url = sysModule.Url, Iconic = sysModule.Iconic, Sort = sysModule.Sort, Remark = sysModule.Remark, Enable = sysModule.Enable, CreatePerson = sysModule.CreatePerson, CreateTime = sysModule.CreateTime, IsLast = sysModule.IsLast
            }).ToList();
        }

        public List<SysModuleModel> GetList(string parentId)
        {
            List<SysModule> listSysModule = HomeRepository.GetList(parentId);

            return listSysModule.Select(p => new SysModuleModel()
            {
                Id = p.Id,
                Name = p.Name,
                EnglishName = p.EnglishName,
                ParentId = p.ParentId,
                Url = p.Url,
                Iconic = p.Iconic,
                Sort = p.Sort,
                Remark = p.Remark,
                Enable = p.Enable,
                CreatePerson = p.CreatePerson,
                CreateTime = p.CreateTime,
                IsLast = p.IsLast
            }).ToList();
        }
    }
}