using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class PdStockOut
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string Consignor { get; set; }
        public string Lpn { get; set; }
        public string DriverName { get; set; }
        public string DriverIdCard { get; set; }
        public int? CreateTime { get; set; }
        public int? PrintTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
