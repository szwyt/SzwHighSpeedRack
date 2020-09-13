using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class PdWorkshop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Manager { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
