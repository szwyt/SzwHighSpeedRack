using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class BaseQualityStandard
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int MaterialId { get; set; }
        public int StandardId { get; set; }
        public string TargetName { get; set; }
        public string TargetNameEn { get; set; }
        public double? TargetMin { get; set; }
        public double? TargetMax { get; set; }
        public double? TargetMinInner { get; set; }
        public double? TargetMaxInner { get; set; }
        public string TargetNote { get; set; }
        public int? Status { get; set; }
        public int? TargetCategory { get; set; }
        public int? SampleType { get; set; }
        public short? IsRequired { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short? IsDeleted { get; set; }
    }
}
