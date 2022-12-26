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
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        private void ToDoList_Load(object sender, EventArgs e)
        {
            DBHelper.dbOpenConnection(ref DBHelper.sqlConnection);
            updateListPanel();
        }

        Panel[] panels = new Panel[0];
        Label[] name = new Label[0];
        Label[] date = new Label[0];
        Button[] del = new Button[0];

        public static string index = null;

        tasks form = new tasks();

        public void updateListPanel()
        {
            
            Array.Resize(ref panels, 0);
            Array.Resize(ref name, 0);
            Array.Resize(ref date, 0);
            Array.Resize(ref del, 0);
            query = new SqlCommand("select ID_list, list_name, list_date from lists", DBHelper.sqlConnection);
            reader = query.ExecuteReader();
            int i = 0, x = 0, y = 0;
            panel1.Controls.Clear();
            while (reader.Read())
            {
                Array.Resize(ref panels, panels.Length + 1);
                Array.Resize(ref name, name.Length + 1);
                Array.Resize(ref date, date.Length + 1);
                Array.Resize(ref del, del.Length + 1);
                panels[i] = new Panel { Location = new Point(x, y), Size = new Size(panel1.Width - 17, 50), BorderStyle = BorderStyle.FixedSingle, Tag = reader.GetInt32(0) };
                panel1.Controls.Add(panels[i]);
                panels[i].MouseDoubleClick += (obj, args) =>
                {
                    MessageBox.Show((obj as Panel).Tag.ToString());
                };
                name[i] = new Label { Location = new Point(0, 0), Text = reader.GetString(1), Size = new Size(panels[i].Width / 2, panels[i].Height), TextAlign = ContentAlignment.MiddleLeft, Tag = reader.GetInt32(0) };
                panels[i].Controls.Add(name[i]);
                del[i] = new Button { Size = new Size(30, panels[i].Height - 1), BackColor = Color.Red, Location = new Point(panels[i].Width - 30, 0), FlatStyle = FlatStyle.Flat, Tag = reader.GetInt32(0) };
                panels[i].Controls.Add(del[i]);
                del[i].Click += (obj, args) =>
                {
                    index = (obj as Button).Tag.ToString();
                    form.Show();
                };
                form.FormClosing += (obj, args) =>
                {
                    updateListPanel();
                };
                y += 53;
                i++;
            }
            reader.Close();
        }

        SqlDataReader reader = null;
        SqlCommand query = null;

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date1 = DateTime.Now;
            query = new SqlCommand($"insert into lists (list_name, list_date) values (@list_name, @list_date)", DBHelper.sqlConnection);
            query.Parameters.AddWithValue("list_name", textBox1.Text);
            query.Parameters.AddWithValue("list_date", $"{date1.Day}.{date1.Month}.{date1.Year}");
            query.ExecuteNonQuery();
            updateListPanel();
        }
    }
}
