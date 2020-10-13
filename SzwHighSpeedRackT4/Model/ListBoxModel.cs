using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzwHighSpeedRackT4
{
    public class ListBoxModel : INotifyPropertyChanged
    {
        private bool isCheck;

        public bool IsCheck
        {
            get { return isCheck; }
            set
            {
                isCheck = value;
                OnPropertyChanged(nameof(IsCheck));
            }
        }

        /// <summary>
        /// 当属性发生更改时触发的事件
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 触发属性更改的事件
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string TableName { get; set; }
    }
}