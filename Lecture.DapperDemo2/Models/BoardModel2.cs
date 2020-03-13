using System;
using System.Collections.Generic;
using Lecture.Lib.Database;

namespace Lecture.DapperDemo2.Models
{
    public class BoardModel2 : ModelBase2
    {
        public bool isNew { get => GetProperty<bool>(); set => SetProperty(value); }
        public bool isEdit { get => GetProperty<bool>(); set => SetProperty(value); }
        public bool isDelete { get => GetProperty<bool>(); set => SetProperty(value); }

        public decimal SEQ { get => GetProperty<decimal>(); set => SetProperty(value); }
        public string TITLE { get => GetProperty<string>(); set => SetProperty(value); }
        public string CONTENTS { get; set; }
        public decimal REG_U_ID { get; set; }
        public string REG_NAME { get; set; }
        public DateTime REG_DATE { get; set; }
        public string STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }

        public static List<BoardModel2> GetList(string search)
        {
            return SqlDapperHelper.Instance.Query<BoardModel2>("SELECT * FROM T_BOARD", new { search = search });
        }
    }
}
