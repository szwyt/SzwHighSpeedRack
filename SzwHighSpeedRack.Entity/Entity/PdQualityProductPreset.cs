namespace SzwHighSpeedRack.Entity
{
    public partial class PdQualityProductPreset
    {
        public int Id { get; set; }
        public string BatCode { get; set; }
        public int MaterialId { get; set; }
        public int QualityId { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}