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
    public partial class giveForm : Form
    {
        public giveForm()
        {
            InitializeComponent();
            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    try { textBox4.BeginInvoke(new MethodInvoker(() => textBox4.Text = DateTime.Now.ToString())); }
                    catch { }
                    System.Threading.Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }

        public int id;
        public decimal mon;

        private void giveForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal money = Convert.ToDecimal(textBox2.Text);
            int flag = 0;
            try
            {
                SqlConnection con = DB.Getconn();
                SqlCommand cmd1 = new SqlCommand("select count(*) from users where id=" + id.ToString() + " and password='" + textBox3.Text + "'", con);
                int i = Convert.ToInt32(cmd1.ExecuteScalar());

                string ssql = "select situation from users where id=" + id.ToString();
                SqlCommand ccmd = new SqlCommand(ssql, con);
                SqlDataReader sdr = ccmd.ExecuteReader();

                if (sdr.Read())
                {
                    string situation = sdr[0].ToString();
                    if (situation.Equals("冻结"))
                        flag = 1;
                }

                sdr.Close();

                string ssql2 = "select situation from users where id=" + textBox5.Text;
                SqlCommand ccmd2 = new SqlCommand(ssql2, con);
                SqlDataReader sdr2 = ccmd2.ExecuteReader();

                if (sdr2.Read())
                {
                    string situation = sdr2[0].ToString();
                    if (situation.Equals("冻结"))
                        flag = 2;
                }
                sdr2.Close();

                string ssql3 = "select count(*) from users where id=" + textBox5.Text;
                SqlCommand ccmd3 = new SqlCommand(ssql3, con);
                int j = Convert.ToInt32(ccmd3.ExecuteScalar());

               

                if (i > 0 && mon >= money && flag == 0 && j > 0)
                {
                    string sql = "update users set money = money - " + money.ToString() + "where id=" + id.ToString();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    string sql2 = "insert into history values(" + id + ", '-" + money.ToString() + "', '" + textBox4.Text + "', '转账给ID:" + textBox5.Text + "')";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();

                    string sql3 = "update users set money = money + " + money.ToString() + "where id=" + textBox5.Text;
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.ExecuteNonQuery();

                    string sql4 = "insert into history values(" + Convert.ToInt32(textBox5.Text) + ", '+" + money.ToString() + "', '" + textBox4.Text + "', '来自ID：" + id.ToString() + "的转账')";
                    SqlCommand cmd4 = new SqlCommand(sql4, con);
                    cmd4.ExecuteNonQuery();

                    MessageBox.Show("转账成功！");
                    usersForm.usersfrm.reload();
                    this.Hide();
                }
                else if (mon < money)
                {
                    MessageBox.Show("对不起，余额不足！");
                }
                else if (flag == 1)
                {
                    MessageBox.Show("对不起，该账户已被冻结！");
                }
                else if (flag == 2)
                {
                    MessageBox.Show("对不起，收款账户已被冻结！");
                }
                else if (j <= 0)
                {
                    MessageBox.Show("对不起，收款账户不存在！");
                }
                else
                {
                    MessageBox.Show("对不起，密码错误！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息：" + ex.ToString());
            }
        }
    }
}
