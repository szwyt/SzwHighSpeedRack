﻿namespace SzwHighSpeedRack.Entity
{
    public partial class PdStockOutDetail
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StockOutId { get; set; }
        public string BatCode { get; set; }
        public string MaterialName { get; set; }
        public string SpecName { get; set; }
        public string ClassName { get; set; }
        public double? Length { get; set; }
        public int CreateUserId { get; set; }
        public int? CreateTime { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
        public string CreateUserName { get; set; }
    }
}