using System.Linq;
using System.Text;
using ZCJT.IBLL;
using ZCJT.BLL.Core;
using Microsoft.Practices.Unity;
using ZCJT.IDAL;
using ZCJT.Models;
using ZCJT.Common;
namespace ZCJT.BLL
{
    public class AccountBLL:BaseBLL,IAccountBLL
    {
        [Dependency]
        public IAccountRepository accountRepository { get; set; }
        public SysUser Login(string username, string pwd)
        {
            return accountRepository.Login(username, pwd);
        }
    }
}
