using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class SysMobileCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CodeType { get; set; }
        public short? IsValaid { get; set; }
        public string Mobile { get; set; }
        public int? SendTime { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
