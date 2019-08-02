// -----------------------------------------------------------------------
// <copyright file="BooleanExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2014:07:04 8:01</last-date>
// -----------------------------------------------------------------------

namespace SzwHighSpeedRack.Utility
{
    using System;

    public static class BooleanExtensions
    {
        /// <summary>
        /// book
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>string</returns>
        public static string ToLower(this bool value)
        {
            return value.ToString().ToLower();
        }
    }
}