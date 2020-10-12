namespace SzwHighSpeedRack.Test.Entity
{
    public partial class SalePrintLogDetail
    {
        public int Id { get; set; }
        public int PrintId { get; set; }
        public int AuthId { get; set; }
        public int? Number { get; set; }
        public int? PrintNumber { get; set; }
        public int? BuildType { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}