using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class MngAdmin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RealName { get; set; }
        public string FirstChar { get; set; }
        public int? Sex { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string MobilePhone { get; set; }
        public string Pic { get; set; }
        public string Qq { get; set; }
        public short? InJob { get; set; }
        public short? IsCanDelete { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
