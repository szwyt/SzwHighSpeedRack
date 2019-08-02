// <copyright file="SiteCategory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    /// <summary>
    /// 表.
    /// </summary>
    public partial class SiteCategory : BaseModel
    {
        /// <summary>
        /// Gets or sets ContentTitle.
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string ContentTitle { get; set; }

        /// <summary>
        /// Gets or sets ModelId.
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// Gets or sets HasModelContent.
        /// </summary>
        public int HasModelContent { get; set; }

        /// <summary>
        /// Gets or sets ParId.
        /// </summary>
        public int? ParId { get; set; }

        /// <summary>
        /// Gets or sets Sequence.
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Gets or sets Depth.
        /// </summary>
        public int? Depth { get; set; }
    }
}
