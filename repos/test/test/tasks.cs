using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test
{
    public partial class tasks : Form
    {
        public tasks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlCommand query = null;

        private void tasks_Load(object sender, EventArgs e)
        {
            query = new SqlCommand($"select list_name from lists where id_list = '{ToDoList.index}'", DBHelper.sqlConnection);
            listNameTB.Text = query.ExecuteScalar().ToString();
            updateTasks();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Уверены, что хотите удалить записи?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(res == DialogResult.Yes)
            {
                query = new SqlCommand($"delete from lists where id_list = '{ToDoList.index}'", DBHelper.sqlConnection);
                query.ExecuteNonQuery();
            }
        }

        int y = 3;

        SqlDataReader reader = null;

        Panel[] task = new Panel[0];
        CheckBox[] check = new CheckBox[0];
        TextBox[] name = new TextBox[0];
        Button[] del = new Button[0];
        int[] indexes = new int[0];

        private void updateTasks()
        {
            panel1.Controls.Clear();
            query = new SqlCommand($"select ID_task, name_task, check_task from listTasks where id_list = {ToDoList.index}", DBHelper.sqlConnection);
            reader = query.ExecuteReader();
            int i = 0, y = 3;
            while (reader.Read())
            {
                Array.Resize(ref task, task.Length + 1);
                Array.Resize(ref check, check.Length + 1);
                Array.Resize(ref name, name.Length + 1);
                Array.Resize(ref del, del.Length + 1);
                Array.Resize(ref indexes, indexes.Length + 1);
                indexes[i] = reader.GetInt32(0);
                task[i] = new Panel { Location = new Point(3, y), Size = new Size(315, 50), Tag = i, BorderStyle = BorderStyle.FixedSingle };
                panel1.Controls.Add(task[i]);
                check[i] = new CheckBox { Location = new Point(10, 16), Text = "", Size = new Size(18, 18), Checked = reader.GetBoolean(2), Tag = i };
                check[i].CheckedChanged += (obj, args) =>
                {
                    if (check[Convert.ToInt32((obj as CheckBox).Tag)].Checked)
                    {
                        query = new SqlCommand($"update listTasks set check_task = 1 where id_task = {indexes[Convert.ToInt32((obj as CheckBox).Tag)]}", DBHelper.sqlConnection);
                    }
                    else
                    {
                        query = new SqlCommand($"update listTasks set check_task = 0 where id_task = {indexes[Convert.ToInt32((obj as CheckBox).Tag)]}", DBHelper.sqlConnection);
                    }
                    query.ExecuteNonQuery();
                    updateTasks();
                };
                task[i].Controls.Add(check[i]);
                name[i] = new TextBox { Size = new Size(200, 19), Location = new Point(40, 15), Tag = i, Text = reader.GetString(1) };
                task[i].Controls.Add(name[i]);
                name[i].TextChanged += (obj, args) =>
                {
                    query = new SqlCommand($"update listTasks set name_task = N'{name[Convert.ToInt32((obj as TextBox).Tag)].Text}' where id_task = {indexes[Convert.ToInt32((obj as TextBox).Tag)]}", DBHelper.sqlConnection);
                    query.ExecuteNonQuery();
                };
                del[i] = new Button { Size = new Size(17, 50), Location = new Point(298, -1), Tag = i, Text = "DEL"};
                task[i].Controls.Add(del[i]);
                del[i].Click += (obj, args) =>
                {
                    var res = MessageBox.Show("Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(res == DialogResult.Yes)
                    {
                        query = new SqlCommand($"delete from listTasks where id_task = {indexes[Convert.ToInt32((obj as Button).Tag)]}", DBHelper.sqlConnection);
                        query.ExecuteNonQuery();
                        updateTasks();
                    }
                };
                i++;
                y += 53;
            }
            reader.Close();
            setLocForAdd();
        }
        Button add = null;

        private void setLocForAdd()
        {
            panelWithAddP = new Panel { Size = new Size(315, 50), Location = new Point(3, 3),  };
            panel1.Controls.Add(panelWithAddP);
            add = new Button { Text = "Добавить", Location = new Point(128, 12), Size = new Size(76, 25) };
            panelWithAddP.Controls.Add(add);
            add.Click += (obj, args) =>
            {
                button3_Click();
            };
            query = new SqlCommand($"select count(*) from listTasks where id_list = {ToDoList.index}", DBHelper.sqlConnection);
            y = 53 * Convert.ToInt32(query.ExecuteScalar());
            panelWithAddP.Location = new Point(3, y);
        }

        private void button3_Click()
        {
            query = new SqlCommand($"insert into listTasks (id_list, name_task, check_task) values (@id_list, @name_task, @check_task)", DBHelper.sqlConnection);
            query.Parameters.AddWithValue("id_list", ToDoList.index);
            query.Parameters.AddWithValue("name_task", "");
            query.Parameters.AddWithValue("check_task", false);
            query.ExecuteNonQuery();
            updateTasks();
        }

        private void listNameTB_TextChanged(object sender, EventArgs e)
        {
            query = new SqlCommand($"update lists set list_name = @list_name where id_list like '{ToDoList.index}'", DBHelper.sqlConnection);
            query.Parameters.AddWithValue("list_name", listNameTB.Text);
            query.ExecuteNonQuery();
        }
    }
}
