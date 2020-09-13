using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class SiteCategory
    {
        public int Id { get; set; }
        public string ContentTitle { get; set; }
        public int? ModelId { get; set; }
        public int? HasModelContent { get; set; }
        public int? ParId { get; set; }
        public int? Sequence { get; set; }
        public int? Depth { get; set; }
    }
}
