using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class PdWorkshopTeamLog
    {
        public int Id { get; set; }
        public string BatCode { get; set; }
        public int TeamId { get; set; }
        public int WorkshopId { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
