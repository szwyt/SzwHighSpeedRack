namespace SzwHighSpeedRack.Entity
{
    public partial class BaseSpecifications
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int MaterialId { get; set; }
        public string SpecName { get; set; }
        public string CallName { get; set; }
        public double? ReferLength { get; set; }
        public double? ReferMeterWeight { get; set; }
        public double? ReferPieceCount { get; set; }
        public double? ReferPieceWeight { get; set; }
        public double? ColdRatio { get; set; }
        public double? ReverseRatio { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}