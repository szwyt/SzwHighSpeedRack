namespace SzwHighSpeedRack.Test.Entity
{
    public partial class BaseTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int? CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? CreateTime { get; set; }
        public short IsDeleted { get; set; }
        public int? ApplyNumber { get; set; }
        public int? Sequence { get; set; }
        public string ImageUrl { get; set; }
    }
}