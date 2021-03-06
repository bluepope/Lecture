﻿using System;
using System.Collections.Generic;
using Lecture.Lib.Database;

namespace Lecture.DapperWebDemo.Models
{
    public class BoardModel
    {
        public int SEQ { get; set; }

        public string TITLE { get; set; }
        public string CONTENTS { get; set; }

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
