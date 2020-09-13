using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class SiteModelColumn
    {
        public int Id { get; set; }
        public string FildDescription { get; set; }
        public int? FildIsNull { get; set; }
        public int? FildLength { get; set; }
        public string FildName { get; set; }
        public int FildType { get; set; }
        public int PageShowType { get; set; }
        public string FildValue { get; set; }
        public int? FildWeight { get; set; }
        public int? Sequence { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public short? IsDeleted { get; set; }
        public int? CreateTime { get; set; }
    }
}
