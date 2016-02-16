using System;
using System.Collections.Generic;
using System.Web;
using ZCJT.BLL;
using ZCJT.DAL;
using ZCJT.IBLL;
using ZCJT.IDAL;
using Microsoft.Practices.Unity;
using ZCJT.MIS.IDAL;
using ZCJT.MIS.DAL;
using ZCJT.MIS.IBLL;
using ZCJT.MIS.BLL;

namespace ZCJT.Core
{
    public class DependencyRegisterType
    {
        //系统注入
        public static void Container_Sys(ref UnityContainer container)
        {
            container.RegisterType<ISysSampleBLL, SysSampleBLL>();//样例
            container.RegisterType<ISysSampleRepository, SysSampleRepository>();

            container.RegisterType<IHomeBLL, HomeBLL>();
            container.RegisterType<IHomeRepository, HomeRepository>();

            container.RegisterType<IAccountBLL, AccountBLL>();
            container.RegisterType<IAccountRepository, AccountRepository>();

            container.RegisterType<ISysLogBLL, SysLogBLL>();
            container.RegisterType<ISysLogRepository, SysLogRepository>();

            container.RegisterType<ISysExceptionBLL, SysExceptionBLL>();
            container.RegisterType<ISysExceptionRepository, SysExceptionRepository>();

            container.RegisterType<ISysModuleBLL, SysModuleBLL>();
            container.RegisterType<ISysModuleRepository, SysModuleRepository>();

            container.RegisterType<ISysModuleOperateBLL, SysModuleOperateBLL>();
            container.RegisterType<ISysModuleOperateRepository, SysModuleOperateRepository>();

            container.RegisterType<ISysRoleBLL, SysRoleBLL>();
            container.RegisterType<ISysRoleRepository, SysRoleRepository>();

            container.RegisterType<ISysRightBLL, SysRightBLL>();
            container.RegisterType<ISysRightRepository, SysRightRepository>();

            container.RegisterType<ISysUserBLL, SysUserBLL>();
            container.RegisterType<ISysUserRepository, SysUserRepository>();

            //MIS
            container.RegisterType<IMIS_Article_CategoryBLL, MIS_Article_CategoryBLL>();
            container.RegisterType<IMIS_Article_CategoryRepository, MIS_Article_CategoryRepository>();

            container.RegisterType<IMIS_ArticleBLL, MIS_ArticleBLL>();
            container.RegisterType<IMIS_ArticleRepository, MIS_ArticleRepository>();
        }
    }
}