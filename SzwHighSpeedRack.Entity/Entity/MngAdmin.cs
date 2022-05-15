using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SzwHighSpeedRack.Entity
{
    public partial class MngAdmin
    {
		public Int32 Id { get; set; }
		public String Address { get; set; }
		public Int32? DepartId { get; set; }
		public String FirstChar { get; set; }
		public UInt64? InJob { get; set; }
		public UInt64 IsCanDelete { get; set; }
		public String LoginIp { get; set; }
		public DateTime? LoginTime { get; set; }
		public Int32? LoginTimes { get; set; }
		public String Mail { get; set; }
		public String Password { get; set; }
		public String Pic { get; set; }
		public String QQ { get; set; }
		public String RealName { get; set; }
		public UInt64? Sex { get; set; }
		public String UserName { get; set; }

        /// <summary>
        /// Gets or sets 权限组
        /// </summary>
        public virtual List<int> GroupManage { get; set; }

        /// <summary>
        /// Gets or sets 移动电话
        /// </summary>
        public virtual List<string> MobilePhone { get; set; }
    }
}