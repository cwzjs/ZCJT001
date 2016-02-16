using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCJT.Models;

namespace ZCJT.IBLL
{
    public interface IAccountBLL
    {
        SysUser Login(string username, string pwd);
    }
}