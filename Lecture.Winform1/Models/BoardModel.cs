using Lecture.Lib.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Winform1.Models
{

    public class BoardModel : ModelBase
    {        
        public int SEQ { get; set; }

        string _title;
        public string TITLE
        {
            get => _title;
            set => Set(ref _title, value);
        }
        
        string _contents;
        public string CONTENTS
        {
            get => _contents;
            set => Set(ref _contents, value);
        }

        public int REG_U_ID { get; set; }
        public string REG_NAME { get; set; }
        public DateTime REG_DATE { get; set; }
        public string STATUS { get; set; }
        public DateTime? UPDATE_DATE { get; set; }

        public static List<BoardModel> GetList(SqlDapperHelper db, string search)
        {
            if (string.IsNullOrWhiteSpace(search) == false)
            {
                search = search.Trim();
            }
            
            string sql = @"
SELECT
	A.SEQ
	,A.TITLE
	,A.CONTENTS
	,A.REG_U_ID
	,A.REG_NAME
	,A.REG_DATE
	,A.STATUS
	,A.UPDATE_DATE
FROM
	dbo.T_BOARD A
WHERE
	A.TITLE LIKE @search + '%'
";
            var list = db.Query<BoardModel>(sql, new { search = search });
            foreach(var item in list)
            {
                item.ChangedFlag = ChangedFlagEnum.None;
            }

            return list;
        }

        public int Insert(SqlDapperHelper db)
        {
            if (string.IsNullOrWhiteSpace(TITLE))
            {
                throw new Exception("제목은 빈값일 수 없습니다");
            }

            string sql = @"
INSERT INTO dbo.T_BOARD (
	SEQ
	,TITLE
	,CONTENTS
	,REG_U_ID
	,REG_NAME
	,REG_DATE
	,STATUS
)
SELECT
    ISNULL((SELECT MAX(SEQ)+1 FROM dbo.T_BOARD), 1)
	,@TITLE
	,@CONTENTS
	,@REG_U_ID
	,@REG_NAME
	,@REG_DATE
	,@STATUS
";
            return db.Execute(sql, this);
        }

        public int Update(SqlDapperHelper db)
        {
            if (string.IsNullOrWhiteSpace(TITLE))
            {
                throw new Exception("제목은 빈값일 수 없습니다");
            }

            string sql = @"
UPDATE dbo.T_BOARD
SET
	TITLE      = @TITLE
	,CONTENTS  = @CONTENTS
	,REG_U_ID  = @REG_U_ID
	,REG_NAME  = @REG_NAME
	,REG_DATE  = @REG_DATE
	,STATUS    = @STATUS
    ,UPDATE_DATE = getdate()
WHERE
    SEQ = @SEQ
";
            return db.Execute(sql, this);
        }
    }
}
