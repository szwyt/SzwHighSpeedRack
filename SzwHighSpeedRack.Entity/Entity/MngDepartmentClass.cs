using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class MngDepartmentClass
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int? ChildNum { get; set; }
        public int? Depth { get; set; }
        public int? ParId { get; set; }
        public string ParPath { get; set; }
        public short? IsBeLock { get; set; }
        public short? IsCanDelete { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short? IsDeleted { get; set; }
    }
}
