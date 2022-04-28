using System;
using System.Collections.Generic;
using System.Data;

namespace SzwHighSpeedRackT4
{
    [Serializable]
    public class TemplateModel
    {
        public TemplateModel(DataTable dt)
        {
            this.ClassName = dt.TableName.Replace("_", string.Empty).Replace("_", string.Empty);
            this.EntityName = dt.TableName.Replace("_", string.Empty).Replace("_", string.Empty);

            if (dt != null && dt.Columns.Count > 0)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    this.EntityList.Add(new EntityClassPropertyModel(dc));
                }
            }
        }

        public string ClassName
        {
            get;
            private set;
        }

        public string EntityName
        {
            get;
            private set;
        }

        public List<EntityClassPropertyModel> EntityList
        {
            get;
            private set;
        } = new List<EntityClassPropertyModel>();
    }
}