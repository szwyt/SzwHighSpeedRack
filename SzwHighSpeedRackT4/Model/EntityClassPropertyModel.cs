﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzwHighSpeedRackT4
{
    [Serializable]
    public class EntityClassPropertyModel
    {
        public EntityClassPropertyModel(DataColumn dcol)
        {
            this.PropertyName = dcol.ColumnName;
            this.PropertyType = dcol.DataType.Name;
            this.IsValueType = false;
            if (dcol.DataType.IsValueType)
            {
                if (dcol.AllowDBNull)
                {
                    this.PropertyType = this.PropertyType + "?";
                }
                this.IsValueType = true;
            }
        }

        public string PropertyName
        {
            get;
            private set;
        }

        public string PropertyType
        {
            get;
            private set;
        }

        public bool IsValueType
        {
            get;
            private set;
        }
    }
}