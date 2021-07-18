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
            textBox1.Visible = false;
        }
    }
}

