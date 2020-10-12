namespace SzwHighSpeedRack.Entity
{
    public partial class MngRoleAdmin
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int RoleId { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}