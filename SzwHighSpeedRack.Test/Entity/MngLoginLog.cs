namespace SzwHighSpeedRack.Test.Entity
{
    public partial class MngLoginLog
    {
        public int Id { get; set; }
        public int? LoginTime { get; set; }
        public string LoginIp { get; set; }
        public int LoginUserId { get; set; }
        public string LoginUserName { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}