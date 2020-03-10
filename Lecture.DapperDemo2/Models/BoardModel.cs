using System;
using System.Collections.Generic;
using Lecture.Lib.Database;

namespace Lecture.DapperDemo2.Models
{
    public class BoardModel : ModelBase
    {
        bool _isNew = false;
        public bool isNew { get => _isNew; set => SetProperty(value); }

        bool _isEdit = false;
        public bool isEdit { get => _isEdit; set => SetProperty(value); }

        bool _isDelete = false;
        public bool isDelete { get => _isDelete; set => SetProperty(value); }

        decimal _seq;
        public decimal SEQ { get => _seq; set => SetProperty(value); }
        public string TITLE { get; set; }
        public string CONTENTS { get; set; }
        public decimal REG_U_ID { get; set; }
        public string REG_NAME { get; set; }
        public DateTime REG_DATE { get; set; }
        public string STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }

        public static List<BoardModel> GetList(string search)
        {
            return SqlDapperHelper.Instance.Query<BoardModel>("SELECT * FROM T_BOARD", new { search = search });
        }
    }
}
