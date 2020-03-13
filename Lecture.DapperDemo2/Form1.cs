using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lecture.DapperDemo2.Models;
using System.Collections.ObjectModel;

namespace Lecture.DapperDemo2
{
    public partial class Form1 : Form
    {
        BindingList<BoardModel2> _list = new BindingList<BoardModel2>();

        public Form1()
        {
            InitializeComponent();

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var item = (sender as DataGridView).Rows[e.RowIndex].DataBoundItem as BoardModel2;
            if ((item.isNew || item.isEdit) == false)
                item.isEdit = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _list = new BindingList<BoardModel2>(BoardModel2.GetList(""));
            dataGridView1.DataSource = _list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(var item in _list)
            {
                /*
                if (item.isNew) item.Insert();
                else if (item.isDelete) item.Delete();
                else if (item.isEdit) item.Update();
                */
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _list.Add(new BoardModel2() { isNew = true });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var deleteList = new List<BoardModel2>();

            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var model = row.DataBoundItem as BoardModel2;

                row.Selected = false;

                if (model.isNew)
                {
                    deleteList.Add(model);
                }
                else
                {
                    model.isDelete = true;
                    row.Visible = false;
                }
            }

            foreach (var item in deleteList)
                _list.Remove(item);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _ = Task.Run(async () => {
                for(int i=0; i < 5; i++)
                {
                    var r = new Random().Next(_list.Count() - 1);

                    _list[r].TITLE = new Random().Next(10000000).ToString();
                    await Task.Delay(1000);
                }
            });
        }
    }
}
