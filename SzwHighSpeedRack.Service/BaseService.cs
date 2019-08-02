using System;
using System.Collections.Generic;
using System.Text;
using SzwHighSpeedRack.EntityFrameworkCore;

namespace SzwHighSpeedRack.Service
{
    public class BaseService
    {
        protected BaseContext db;

        public BaseService(IDbFactory dbFactory)
        {
            db = dbFactory.GetDbContext(DbEnum.DbType.MySql, "Server=118.24.60.212; Port=3306; Uid=root; Pwd=123456; Database=szwHighspeedrack;SslMode=None");
        }

        ~BaseService()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
    }
}
