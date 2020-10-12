namespace SzwHighSpeedRack.Entity
{
    public partial class PdQualityHighCode
    {
        public int Id { get; set; }
        public string HighCode { get; set; }
        public string Quality { get; set; }
        public int MaterialId { get; set; }
        public int WorkshopId { get; set; }
        public int? Status { get; set; }
        public string EntryPerson { get; set; }
        public int? LastUpdatetime { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}