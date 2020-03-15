using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Winform1.Models
{
    public enum ChangedFlagEnum
    {
        None,
        Inserted,
        Updated,
        Deleted
    }

    public class ModelBase : INotifyPropertyChanged
    {
        public ChangedFlagEnum ChangedFlag { get; set; } = ChangedFlagEnum.None;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Set<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            backingField = value;
            this.ChangedFlag = ChangedFlagEnum.Updated;
            OnPropertyChanged(propertyName);
        }
    }
}
