namespace SzwHighSpeedRack.Test.Entity
{
    public partial class PdQuality
    {
        public int Id { get; set; }
        public string BatCode { get; set; }
        public string QualityInfos { get; set; }
        public string QualityInfosDynamics { get; set; }
        public int WorkshopId { get; set; }
        public int MaterialId { get; set; }
        public int SmeltId { get; set; }
        public int? IsPreset { get; set; }
        public string EntryPerson { get; set; }
        public string CheckPerson { get; set; }
        public string CheckNote { get; set; }
        public int CheckStatus { get; set; }
        public int CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}