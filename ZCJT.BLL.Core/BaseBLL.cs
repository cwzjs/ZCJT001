using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCJT.Models;

namespace ZCJT.BLL.Core
{
    public class BaseBLL : IDisposable
    {
        protected DBContainer db { get; set; }

        public BaseBLL()
        {
            db = new DBContainer();
        }

        public void Dispose()
        {
            
        }
    }
}
