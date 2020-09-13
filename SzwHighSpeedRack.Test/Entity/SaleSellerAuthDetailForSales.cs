using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class SaleSellerAuthDetailForSales
    {
        public int Id { get; set; }
        public int AuthId { get; set; }
        public int ProductId { get; set; }
        public string ClassName { get; set; }
        public string MaterialName { get; set; }
        public string SpecName { get; set; }
        public double? Length { get; set; }
        public string BatCode { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
        public int? DataSourceType { get; set; }
    }
}
