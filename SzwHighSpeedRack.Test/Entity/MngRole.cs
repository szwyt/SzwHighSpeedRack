namespace SzwHighSpeedRack.Test.Entity
{
    public partial class MngRole
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string GroupNameEn { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public short? IsLock { get; set; }
        public short? IsCanDelete { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}