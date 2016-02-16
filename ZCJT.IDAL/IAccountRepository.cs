using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZCJT.Models;

namespace ZCJT.IDAL
{
    public interface IAccountRepository
    {
        SysUser Login(string username, string pwd);
    }
}