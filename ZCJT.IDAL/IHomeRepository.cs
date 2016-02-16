using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCJT.Models;

namespace ZCJT.IDAL
{
    public interface IHomeRepository
    {
        List<SysModule> GetMenuByPersonId(string personId, string moduleId);

        List<SysModule> GetList(string parentId);
    }
}