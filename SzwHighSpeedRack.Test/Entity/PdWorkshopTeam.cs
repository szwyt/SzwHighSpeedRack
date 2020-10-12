namespace SzwHighSpeedRack.Test.Entity
{
    public partial class PdWorkshopTeam
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public string TeamName { get; set; }
        public string Code { get; set; }
        public string Leader { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}