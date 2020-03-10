using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Lecture.Lib.Database;

namespace Lecture.DapperDemo2.Models
{
    public class BoardModel : INotifyPropertyChanged
    {
        bool _isNew = false;
        public bool isNew { get => _isNew; set => SetProperty(value); }

        bool _isEdit = false;
        public bool isEdit { get => _isEdit; set => SetProperty(value); }
        public bool isDelete { get; set; }

        public decimal SEQ { get; set; }
        public string TITLE { get; set; }
        public string CONTENTS { get; set; }
        public decimal REG_U_ID { get; set; }
        public string REG_NAME { get; set; }
        public DateTime REG_DATE { get; set; }
        public string STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty(object value, [CallerMemberName] string propertyName = null)
        {
            this.GetType().GetField($"_{propertyName}", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(this, value);
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<BoardModel> GetList(string search)
        {
            return SqlDapperHelper.Instance.Query<BoardModel>("SELECT * FROM T_BOARD", new { search = search });
        }
    }
}
