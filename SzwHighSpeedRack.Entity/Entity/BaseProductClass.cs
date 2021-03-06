﻿namespace SzwHighSpeedRack.Entity
{
    public partial class BaseProductClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gbname { get; set; }
        public int? DeliveryType { get; set; }
        public int? Measurement { get; set; }
        public string Note { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? CreateTime { get; set; }
        public int? Sequence { get; set; }
        public short? IsDeleted { get; set; }
    }
}