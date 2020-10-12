namespace SzwHighSpeedRack.Test.Entity
{
    public partial class PdProduct
    {
        public int Id { get; set; }
        public string BatCode { get; set; }
        public int ClassId { get; set; }
        public int MaterialId { get; set; }
        public int SpecId { get; set; }
        public int ShiftId { get; set; }
        public string BundleCode { get; set; }
        public double? Length { get; set; }
        public int? LengthType { get; set; }
        public double? MeterWeight { get; set; }
        public int? PieceCount { get; set; }
        public double? Weight { get; set; }
        public string RandomCode { get; set; }
        public string Adder { get; set; }
        public int? ProductDate { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
        public string Brand { get; set; }
        public int ClientId { get; set; }
        public int? IsCancelled { get; set; }
    }
}