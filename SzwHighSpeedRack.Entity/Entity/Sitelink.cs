using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class Sitelink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string PicLink { get; set; }
        public int? PicWidth { get; set; }
        public int? PicHeight { get; set; }
        public int? IsShow { get; set; }
        public int? Sequence { get; set; }
        public int Position { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public short? IsDeleted { get; set; }
        public int? LinkType { get; set; }
        public int? CreateTime { get; set; }
    }
}
