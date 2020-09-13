using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Test.Entity
{
    public partial class PdBatCode
    {
        public int Id { get; set; }
        public string BatCode { get; set; }
        public int? SerialNo { get; set; }
        public int WorkshopId { get; set; }
        public int? BilletNumber { get; set; }
        public double? BilletPieceWeight { get; set; }
        public double? ProductRate { get; set; }
        public int ShiftId { get; set; }
        public int? Status { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
