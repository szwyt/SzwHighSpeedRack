using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class SalePrintLog
    {
        public int Id { get; set; }
        public string Consignor { get; set; }
        public string PrintNo { get; set; }
        public int? SignetAngle { get; set; }
        public int? Status { get; set; }
        public string CheckCode { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
        public string Brand { get; set; }
        public int? ClientId { get; set; }
    }
}
