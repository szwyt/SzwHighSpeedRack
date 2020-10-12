namespace SzwHighSpeedRack.Entity
{
    public partial class BaseProductGbClass
    {
        public int Id { get; set; }
        public string GbName { get; set; }
        public string Note { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}