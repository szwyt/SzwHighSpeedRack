using System;
using System.Collections.Generic;

namespace SzwHighSpeedRack.Entity
{
    public partial class MngSystemSetting
    {
        public int Id { get; set; }
        public string SettingCode { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public int? ValueType { get; set; }
        public int? ValueLength { get; set; }
        public string SettingDesc { get; set; }
        public int? CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public int? Sequence { get; set; }
        public short IsDeleted { get; set; }
    }
}
