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
using System.IO;

namespace WindowsFormsApp3
{
    public partial class ComboBoxForm : Form
    {
        private String connectionString;
        public ComboBoxForm()
        {
            using(StreamReader sr = new StreamReader(@"..\..\paths\connectionString.txt"))
            {
                connectionString = sr.ReadLine();
            }
            InitializeComponent();
            ComboBoxForm_Load();
        }
        
        // 用于给combo box添加从数据库抓取的数据的辅助函数
        private void comboBoxAdder(String connection_string, String queryString, ComboBox comboBox)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection_string))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection);
                using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        comboBox1.Items.Add(dataReader[0]);
                    }
                }
            }
        }
        // 正常人当然写注释
        private void ComboBoxForm_Load()
        {
            string connection_string = connectionString;
            string queryString = "SELECT [GX_NAME] FROM[NCMR].[dbo].[T1_GX]";
            comboBoxAdder(connection_string, queryString, comboBox1);
        }
        // 正常人谁注释啊（破真）
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //当组合框中选择的值发生变化时弹出消息框显示当前组合框中选择的值
            MessageBox.Show("您选择的专业是：" + comboBox1.Text, "提示");
        }
        //“添加”按钮的单击事件，用于向组合框中添加文本框中的值
        private void button1_Click(object sender, EventArgs e)
        {
            //判断文本框中是否为空，不为空则将其添加到组合框中
            if (textBox1.Text != "")
            {
                //判断文本框中的值是否与组合框中的的值重复
                if (comboBox1.Items.Contains(textBox1.Text))
                {
                    MessageBox.Show("该专业已存在！");
                }
                else
                {
                    comboBox1.Items.Add(textBox1.Text);
                }
            }
            else
            {
                MessageBox.Show("请输入专业！", "提示");
            }
        }
        //“删除按钮的单击事件，用于删除文本框中输入的值”
        private void button2_Click(object sender, EventArgs e)
        {
            //判断文本框是否为空
            if (textBox1.Text != "")
            {
                //判断组合框中是否存在文本框中输入的值
                if (comboBox1.Items.Contains(textBox1.Text))
                {
                    comboBox1.Items.Remove(textBox1.Text);
                }
                else
                {
                    MessageBox.Show("您输入的专业不存在", "提示");
                }
            }
            else
            {
                MessageBox.Show("请输入要删除的专业", "提示");
            }
        }
    }
}

