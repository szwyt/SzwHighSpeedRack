using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class BaseProductMaterial
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int? StandardStrength { get; set; }
        public short? AntiEarthquake { get; set; }
        public string Note { get; set; }
        public string TemplateName { get; set; }
        public int? IsCancel { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short? IsDeleted { get; set; }
    }
}
