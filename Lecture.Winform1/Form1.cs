using Lecture.Lib.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lecture.Winform1.Models;

namespace Lecture.Winform1
{
    public partial class Form1 : Form
    {
        string _search;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new SqlDapperHelper())
            {
                dataGridView1.DataSource = new BindingList<BoardModel>(BoardModel.GetList(db, ""));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var list = dataGridView1.DataSource as BindingList<BoardModel>;

            list[0].TITLE = new Random().Next(10000).ToString();
            list[0].CONTENTS = new Random().Next(1000000).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var list = dataGridView1.DataSource as BindingList<BoardModel>;

            using (var db = new SqlDapperHelper())
            {
                db.BeginTransaction();
                try
                {
                    foreach(var item in list)
                    {
                        switch(item.ChangedFlag)
                        {
                            case ChangedFlagEnum.Inserted:
                                item.Insert(db);
                                break;
                            case ChangedFlagEnum.Updated:
                                item.Update(db);
                                break;
                        }
                    }
                    db.Commit();
                }
                catch(Exception ex)
                {
                    db.Rollback();
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
