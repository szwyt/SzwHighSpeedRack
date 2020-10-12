namespace SzwHighSpeedRack.Test.Entity
{
    public partial class MngMenuClass
    {
        public int Id { get; set; }
        public int? ParId { get; set; }
        public string ClassName { get; set; }
        public string ClassNameEn { get; set; }
        public string Icon { get; set; }
        public int? Depth { get; set; }
        public int? ChildNum { get; set; }
        public string ParPath { get; set; }
        public int? PlatformType { get; set; }
        public int? PermissionType { get; set; }
        public string Url { get; set; }
        public int? TargetType { get; set; }
        public short? IsHideInMenu { get; set; }
        public short? IsCanDelete { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}