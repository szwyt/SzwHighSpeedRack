using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class SaleSellerAuth
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int StockOutId { get; set; }
        public string BatCode { get; set; }
        public int ClassId { get; set; }
        public int MaterialId { get; set; }
        public int SpecId { get; set; }
        public int? LengthType { get; set; }
        public int? Number { get; set; }
        public int ParentSellerId { get; set; }
        public int? ParentAuthId { get; set; }
        public string Lpn { get; set; }
        public int? AuthTime { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
