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
    public partial class addForm : Form
    {   
        public addForm()
        {
            InitializeComponent();
            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    try { textBox7.BeginInvoke(new MethodInvoker(() => textBox7.Text = DateTime.Now.ToString())); }
                    catch { }
                    System.Threading.Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sex = "女";
            if (radioButton1.Checked)
                sex = "男";

            if( textBox1.Text =="" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("请完善信息！");
            else
            {
                string sql = "insert into users(name, sex, tel, idcard, date, password) values('" + textBox1.Text + "','" + sex + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox3.Text + "' )";
                try
                {
                    if (textBox3.Text.Equals(textBox4.Text))
                    {
                        SqlConnection con = DB.Getconn();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        string sql2 = "select id from users where tel ='" + textBox5.Text + "'";
                        SqlCommand cmd2 = new SqlCommand(sql2, con);
                        SqlDataReader sdr = cmd2.ExecuteReader();
                        string new_id = "";

                        if (sdr.Read())
                        {
                            new_id = sdr["id"].ToString();
                        }

                        MessageBox.Show("开户成功！用户ID为：" + new_id + " !");
                        adminForm.adminfrm.reload();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("异常信息：" + ex.ToString());
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }
    }
}
