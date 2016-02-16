using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCJT.Models;
using ZCJT.Common;
using ZCJT.Models.Sys;

namespace ZCJT.IBLL
{
    public interface ISysModuleBLL
    {
        List<SysModuleModel> GetList(string parentId);
        List<SysModule> GetModuleBySystem(string parentId);
        bool Create(ref ValidationErrors errors, SysModuleModel model);
        bool Delete(ref ValidationErrors errors, string id);
        bool Edit(ref ValidationErrors errors, SysModuleModel model);
        SysModuleModel GetById(string id);
        bool IsExist(string id);
    }
}