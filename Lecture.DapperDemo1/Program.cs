using Dapper;
using Lecture.DapperDemo1.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Lecture.DapperDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            #region DataTable 예제
            var dt = new DataTable();

            using (var db = new SqlConnection("Server=192.168.0.200;Database=lecture;User Id=study;Password=study2020!!;"))
            {
                db.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = db;
                    cmd.CommandText = insertSql;
                    cmd.Parameters.AddWithValue("U_ID", "redpope");
                    cmd.Parameters.AddWithValue("U_NAME", "레드");
                    cmd.Parameters.AddWithValue("U_PW", "4321");
                    cmd.Parameters.AddWithValue("JOIN_DATE", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = db;
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("search", "레");

                    dt.Load(cmd.ExecuteReader());
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["U_SEQ"] as long?);
                Console.WriteLine(row["U_NAME"] as string);
            }
            #endregion
            */

            using (var db = new SqlConnection("Server=192.168.0.200;Database=lecture;User Id=study;Password=study2020!!;"))
            {
                db.Open();

                var tran = db.BeginTransaction();

                try
                {
                    var model = new UserModel();
                    model.U_ID = "white";
                    model.U_NAME = "화이트";
                    model.U_PW = "555";
                    model.JOIN_DATE = DateTime.Now;
                    model.Insert(db, tran);

                    tran.Commit();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                }

                var list = UserModel.GetList(db, "");

                foreach (var item in list)
                {
                    Console.WriteLine($"{item.U_ID} {item.U_NAME}");
                }

            }
        }
    }
}
