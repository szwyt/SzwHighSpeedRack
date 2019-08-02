// <copyright file="DbEnum.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.EntityFrameworkCore
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 数据库类.
    /// </summary>
    public class DbEnum
    {
        /// <summary>
        /// 数据库类型.
        /// </summary>
        public enum DbType
        {
            /// <summary>
            /// SqlLite.
            /// </summary>
            SqlLite,

            /// <summary>
            /// SqlLit.
            /// </summary>
            SqlLit,

            /// <summary>
            /// MySql.
            /// </summary>
            MySql,

            /// <summary>
            /// SqlServer.
            /// </summary>
            SqlServer,

            /// <summary>
            /// Oracle.
            /// </summary>
            Oracle,

            /// <summary>
            /// PostgreSQL.
            /// </summary>
            PostgreSQL,
        }
    }
}
