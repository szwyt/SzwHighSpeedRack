using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class SiteModel
    {
        public int Id { get; set; }
        public string BaseManageId { get; set; }
        public int CheckStatusManageModel { get; set; }
        public int? CreateTime { get; set; }
        public string Description { get; set; }
        public int? Uid { get; set; }
        public int? Sequence { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public short? IsDeleted { get; set; }
    }
}
