namespace SzwHighSpeedRack.Entity
{
    public partial class MngSystemInfo
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string ClientEn { get; set; }
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public string NameEn { get; set; }
        public string SecretKey { get; set; }
        public string ProductRegistrationNumber { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}