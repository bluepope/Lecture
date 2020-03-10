using System;
using System.Collections.Generic;
using Lecture.Lib.Database;

namespace Lecture.DapperWebDemo.Models
{
    public class BoardModel
    {
        public bool isNew { get; set; }
        public bool isEdit { get; set; }
        public bool isDelete { get; set; }
        public decimal SEQ { get; set; }
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
