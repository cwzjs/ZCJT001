using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCJT.Models;
using ZCJT.Models.Sys;

namespace ZCJT.IBLL
{
    public interface IHomeBLL
    {
        List<SysModuleModel> GetMenuByPersonId(string personId, string moduleId);

        List<SysModuleModel> GetList(string parentId);
    }
}