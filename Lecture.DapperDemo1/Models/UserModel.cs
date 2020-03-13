using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Lecture.DapperDemo1.Models
{
    public class UserModel
    {
        public long U_SEQ { get; set; }
        public string U_ID { get; set; }
        public string U_NAME { get; set; }
        public string U_PW { get; set; }
        public DateTime JOIN_DATE { get; set; }

        public static List<UserModel> GetList(IDbConnection db, string search)
        {
            string sql = @"
SELECT
    U_SEQ
    ,U_ID
    ,U_NAME
    ,U_PW
    ,JOIN_DATE
FROM
    T_USER
WHERE
    U_NAME LIKE @search + '%'";

            return SqlMapper.Query<UserModel>(db, sql, new { search = "" }).ToList();
        }

        public int Insert(IDbConnection db, IDbTransaction trans)
        {
            string insertSql = @"
INSERT INTO T_USER(
    U_ID
    ,U_NAME
    ,U_PW
    ,JOIN_DATE
)
VALUES(
    @U_ID
    ,@U_NAME
    ,@U_PW
    ,@JOIN_DATE
)";

            return SqlMapper.Execute(db, insertSql, this, trans);
        }
    }
}
