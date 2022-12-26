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

namespace NewDesTasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlCommand query = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            DBHelper.openConnetion(ref DBHelper.sqlConnection);
            rigthFrameP.Dock = DockStyle.Fill;
            updateListPanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Now;
            query = new SqlCommand($"insert into lists (list_name, list_date) values (N'', '{date1.Day}.{date1.Month}.{date1.Year}')", DBHelper.sqlConnection);
            query.ExecuteNonQuery();
            query = new SqlCommand($"select id_list from lists where list_date = '{date1.Day}.{date1.Month}.{date1.Year}' and id_list = (select max(id_list) from lists)", DBHelper.sqlConnection);
            ind = Convert.ToInt32(query.ExecuteScalar());
            openNewTaskPanel();
            updateListPanel();
        }

        private void openNewTaskPanel()
        {
            query = new SqlCommand($"select max(id_list) from lists", DBHelper.sqlConnection);
            Array.Resize(ref indexes, indexes.Length + 1);
            indexes[indexes.Length - 1] = Convert.ToInt32(query.ExecuteScalar());
            ind = i;
            listNameTB.Text = "";
            label2.Visible = false;
            rigthFrameP.Visible = true;
            setLocForAdd();
        }

        Panel[] task2 = new Panel[0];
        CheckBox[] check = new CheckBox[0];
        TextBox[] name2 = new TextBox[0];
        Button[] del2 = new Button[0];
        int[] indexes2 = new int[0];

        int y = 0;

        private void openTaskListPanel()
        {
            query = new SqlCommand($"select list_name from lists where id_list = {indexes[ind]}", DBHelper.sqlConnection);
            listNameTB.Text = query.ExecuteScalar().ToString();
            label2.Visible = false;
            rigthFrameP.Visible = true;

            tasksOfListP.Controls.Clear();
            query = new SqlCommand($"select ID_task, name_task, check_task from listTasks where id_list = {indexes[ind]}", DBHelper.sqlConnection);
            reader = query.ExecuteReader();
            i = 0;
            y = 3;
            while (reader.Read())
            {
                Array.Resize(ref task2, task2.Length + 1);
                Array.Resize(ref check, check.Length + 1);
                Array.Resize(ref name2, name2.Length + 1);
                Array.Resize(ref del2, del2.Length + 1);
                Array.Resize(ref indexes2, indexes2.Length + 1);
                indexes2[i] = reader.GetInt32(0);
                task2[i] = new Panel { Location = new Point(3, y), Size = new Size(252, 50), Tag = i, BorderStyle = BorderStyle.FixedSingle };
                tasksOfListP.Controls.Add(task2[i]);
                check[i] = new CheckBox { Location = new Point(10, 16), Text = "", Size = new Size(18, 18), Checked = reader.GetBoolean(2), Tag = i };
                check[i].CheckedChanged += (obj, args) =>
                {
                    if (check[Convert.ToInt32((obj as CheckBox).Tag)].Checked)
                    {
                        query = new SqlCommand($"update listTasks set check_task = 1 where id_task = {indexes2[Convert.ToInt32((obj as CheckBox).Tag)]}", DBHelper.sqlConnection);
                    }
                    else
                    {
                        query = new SqlCommand($"update listTasks set check_task = 0 where id_task = {indexes2[Convert.ToInt32((obj as CheckBox).Tag)]}", DBHelper.sqlConnection);
                    }
                    query.ExecuteNonQuery();
                };
                task2[i].Controls.Add(check[i]);
                name2[i] = new TextBox { Size = new Size(170, 19), Location = new Point(40, 15), Tag = i, Text = reader.GetString(1) };
                task2[i].Controls.Add(name2[i]);
                name2[i].TextChanged += (obj, args) =>
                {
                    query = new SqlCommand($"update listTasks set name_task = N'{name2[Convert.ToInt32((obj as TextBox).Tag)].Text}' where id_task = {indexes2[Convert.ToInt32((obj as TextBox).Tag)]}", DBHelper.sqlConnection);
                    query.ExecuteNonQuery();
                };
                del2[i] = new Button { Size = new Size(17, 50), Location = new Point(235, -1), Tag = i, Text = "DEL" };
                task2[i].Controls.Add(del2[i]);
                del2[i].Click += (obj, args) =>
                {
                    var res = MessageBox.Show("Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        query = new SqlCommand($"delete from listTasks where id_task = {indexes2[Convert.ToInt32((obj as Button).Tag)]}", DBHelper.sqlConnection);
                        query.ExecuteNonQuery();
                        openTaskListPanel();
                    }
                };
                i++;
                y += 53;
            }
            reader.Close();
            setLocForAdd();
        }

        Panel panelWithAddP = null;
        Button add = null;

        private void setLocForAdd()
        {
            panelWithAddP = new Panel { Size = new Size(252, 50), Location = new Point(3, 3), };
            tasksOfListP.Controls.Add(panelWithAddP);
            add = new Button { Text = "Добавить", Location = new Point(88, 12), Size = new Size(76, 25) };
            panelWithAddP.Controls.Add(add);
            add.Click += (obj, args) =>
            {
                query = new SqlCommand($"insert into listTasks (id_list, name_task, check_task) values (@id_list, @name_task, @check_task)", DBHelper.sqlConnection);
                query.Parameters.AddWithValue("id_list", indexes[ind]);
                query.Parameters.AddWithValue("name_task", "");
                query.Parameters.AddWithValue("check_task", false);
                query.ExecuteNonQuery();
                openTaskListPanel();
            };
            query = new SqlCommand($"select count(*) from listTasks where id_list = {indexes[ind]}", DBHelper.sqlConnection);
            y = 53 * Convert.ToInt32(query.ExecuteScalar());
            panelWithAddP.Location = new Point(3, y);
        }

        private void closeTaskListPanel()
        {
            label2.Visible = true;
            rigthFrameP.Visible = false;
            tasksOfListP.Controls.Clear();
        }

        Panel funcPnl = new Panel { Size = new Size(216, 30), Visible = false, BorderStyle = BorderStyle.FixedSingle };
        Button open = null, delete = null, close = null;
        Panel[] task = new Panel[0];
        Label[] name = new Label[0];
        Button[] func = new Button[0];
        int[] indexes = new int[0];

        int ind = 0;

        SqlDataReader reader = null;

        private void button2_Click(object sender, EventArgs e)
        {
            closeTaskListPanel();
        }

        private void listNameTB_TextChanged(object sender, EventArgs e)
        {
            query = new SqlCommand($"update lists set list_name = @list_name where id_list = {indexes[ind]}", DBHelper.sqlConnection);
            query.Parameters.AddWithValue("list_name", listNameTB.Text);
            query.ExecuteNonQuery();
            updateListPanel();
        }

        int i = 0;

        private void updateListPanel()
        {
            int y = 0;
            panel3.Controls.Clear();
            Array.Resize(ref task, 0);
            Array.Resize(ref name, 0);
            Array.Resize(ref func, 0);
            Array.Resize(ref indexes, 0);
            funcPnl.Controls.Add(open = new Button { Text = "Открыть", Location = new Point(3, 3), Size = new Size(87, 23) });
            funcPnl.Controls.Add(delete = new Button { Text = "Удалить", Location = new Point(96, 3), Size = new Size(87, 23) });
            funcPnl.Controls.Add(close = new Button { Text = "X", Location = new Point(189, 3), Size = new Size(23, 23), TextAlign = ContentAlignment.MiddleRight });
            open.Click += (obj, args) =>
            {
                funcPnl.Visible = false;
                openTaskListPanel();
            };
            delete.Click += (obj, args) =>
            {
                var res = MessageBox.Show("Уверены, что хотите удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(res == DialogResult.Yes)
                {
                    query = new SqlCommand($"delete from listTasks where id_list = {indexes[ind]}", DBHelper.sqlConnection);
                    query.ExecuteNonQuery();
                    query = new SqlCommand($"delete from lists where id_list = {indexes[ind]}", DBHelper.sqlConnection);
                    query.ExecuteNonQuery();
                    funcPnl.Visible = false;
                    closeTaskListPanel();
                    updateListPanel();
                }
            };
            close.Click += (obj, args) =>
            {
                funcPnl.Visible = false;
            };
            panel3.Controls.Add(funcPnl);
            if (String.IsNullOrEmpty(searchTB.Text))
            {
                query = new SqlCommand($"select ID_list, list_name, list_date from lists", DBHelper.sqlConnection);
            }
            else
            {
                query = new SqlCommand($"select ID_list, list_name, list_date from lists where list_name like N'%{searchTB.Text}%'", DBHelper.sqlConnection);
            }
            reader = query.ExecuteReader();
            i = 0;
            while (reader.Read())
            {
                Array.Resize(ref task, task.Length + 1);
                Array.Resize(ref name, name.Length + 1);
                Array.Resize(ref func, func.Length + 1);
                Array.Resize(ref indexes, indexes.Length + 1);
                indexes[i] = reader.GetInt32(0);
                task[i] = new Panel { Location = new Point(0, y), Size = new Size(539, 50), BorderStyle = BorderStyle.FixedSingle, Tag = i };
                panel3.Controls.Add(task[i]);
                name[i] = new Label { Location = new Point(20, 18), Tag = i, Text = reader.GetString(1) };
                task[i].Controls.Add(name[i]);
                func[i] = new Button { Size = new Size(21, 54), Location = new Point(539 - 20, -3), Tag = i, Text = "+", };
                task[i].Controls.Add(func[i]);
                func[i].Click += (obj, args) =>
                {
                    ind = Convert.ToInt32((obj as Button).Tag);
                    query = new SqlCommand($"select id_list from lists where id_list like '{indexes[Convert.ToInt32((obj as Button).Tag)]}'", DBHelper.sqlConnection);
                    funcPnl.Location = new Point(task[Convert.ToInt32((obj as Button).Tag)].Location.X + task[Convert.ToInt32((obj as Button).Tag)].Width - 221, task[Convert.ToInt32((obj as Button).Tag)].Location.Y + task[Convert.ToInt32((obj as Button).Tag)].Height - 35);
                    funcPnl.Visible = true;
                };
                y += 53;
                i++;
            }
            reader.Close();
        }

        private void searchTB_TextChanged(object sender, EventArgs e)
        {
            updateListPanel();
        }
    }
}