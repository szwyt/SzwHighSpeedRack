using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class PdQrcodeAuth
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public int ClassId { get; set; }
        public int MaterialId { get; set; }
        public int SpecId { get; set; }
        public int Number { get; set; }
        public int AuthDate { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
