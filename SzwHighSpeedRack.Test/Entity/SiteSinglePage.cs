namespace SzwHighSpeedRack.Test.Entity
{
    public partial class SiteSinglePage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int? ReleaseTime { get; set; }
        public string Descrption { get; set; }
        public string Title { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public short? IsDeleted { get; set; }
        public int? Sequence { get; set; }
        public int? CreateTime { get; set; }
    }
}