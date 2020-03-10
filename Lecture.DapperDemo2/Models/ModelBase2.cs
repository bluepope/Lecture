using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.DapperDemo2.Models
{
    public class ModelBase2 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, object> _storage = new Dictionary<string, object>();

        protected T GetProperty<T>([CallerMemberName] string propertyName = null)
        {
            if (_storage.ContainsKey(propertyName))
            {
                return (T)_storage[propertyName];
            }

            return (T)default;
        }

        protected bool SetProperty(object value, [CallerMemberName] string propertyName = null)
        {
            _storage[propertyName] = value;
            OnPropertyChanged();

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
