// <copyright file="BaseEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// 基类.
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [Key]
        public int Id { get; set; }
    }
}
