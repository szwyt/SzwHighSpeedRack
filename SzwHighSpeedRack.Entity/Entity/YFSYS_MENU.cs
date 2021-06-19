using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SzwHighSpeedRack.Entity
{
    /// <summary>
    /// 菜单表
    /// </summary>
    public class YFSYS_MENU
    {
        /// <summary>
        /// Id
        /// </summary>
        /// </summary>
        [Column("ID")]
        public decimal Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("CODE")]
        public string code { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("NAME")]
        public string name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("ICON")]
        public string icon { get; set; }

        /// <summary>
        /// sys系统 menu 菜单
        /// </summary>
        [Column("TYPE")]
        public string type { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("SEQ")]
        public decimal seq { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        [Column("PARENT_ID")]
        public decimal parent_id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("CREATE_ID")]
        public string create_id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Column("CREATE_DATE")]
        public DateTime create_date { get; set; }

        /// <summary>
        /// 系统代码
        /// </summary>
        [Column("SYS_CODE")]
        public string sys_code { get; set; }
    }
}