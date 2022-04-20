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

namespace bank
{
    public partial class securityForm : Form
    {
        public securityForm()
        {
            InitializeComponent();
        }

        public int id = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = DB.Getconn();  
                SqlCommand cmd = new SqlCommand("select count(*) from users where id=" + Convert.ToInt32(textBox1.Text) + " and password='" + textBox2.Text + "'", con);
                int i = Convert.ToInt32(cmd.ExecuteScalar());
                if (i > 0)
                {
                    if(textBox3.Text.Equals(textBox4.Text))
                    {
                        string sql = "update users set password ='" + textBox3.Text + "' where id= " + Convert.ToInt32(textBox1.Text);
                        SqlCommand cmd1 = new SqlCommand(sql, con);
                        cmd1.ExecuteNonQuery();

                        MessageBox.Show("修改成功！");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入");
                    }
                }
                else
                { MessageBox.Show("对不起，用户名或密码错误！"); }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息：" + ex.ToString());
            }
        }

        private void securityForm_Load(object sender, EventArgs e)
        {
            if (id != 0)
                textBox1.Text = id.ToString();
        }
    }
}
