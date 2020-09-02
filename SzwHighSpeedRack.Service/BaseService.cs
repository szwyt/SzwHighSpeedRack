using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using SzwHighSpeedRack.Aop;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Service
{
    public class BaseService
    {
        public BaseContext baseContext { get; set; }

        public BaseService(IDbFactory dbFactory)
        {
            //baseContext = dbFactory.GetDbContext(DbEnum.DbType.MySql, "Server=118.24.60.212; Port=3306; Uid=root; Pwd=123456; Database=szwHighspeedrack;SslMode=None");
        }

        ~BaseService()
        {
            if (baseContext != null)
            {
                baseContext.Dispose();
            }
        }
    }
}
