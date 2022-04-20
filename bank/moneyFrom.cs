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
    public partial class moneyFrom : Form
    {
        public int id;
        public decimal mon;

        public moneyFrom()
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

        private void moneyFrom_Load(object sender, EventArgs e)
        {
            textBox1.Text = id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
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

                    if (i > 0 && flag == 0)
                    {
                        string sql = "update users set money = money + " + money.ToString() + "where id=" + id.ToString();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        string sql2 = "insert into history values(" + id + ", '+" + money.ToString()+ "', '" + textBox4.Text + "', '存款')";
                        SqlCommand cmd2 = new SqlCommand(sql2, con);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("存款成功！");
                        usersForm.usersfrm.reload();
                        this.Hide();
                    }
                    else if(flag == 1)
                    {
                        MessageBox.Show("对不起，该账户已被冻结！");
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
            else if(radioButton2.Checked == true)
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

                    if (i > 0 && mon >= money && flag == 0 )
                    {
                        string sql = "update users set money = money - " + money.ToString() + "where id=" + id.ToString();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        string sql2 = "insert into history values(" + id + ", '-" + money.ToString() + "', '" + textBox4.Text + "', '取款')";
                        SqlCommand cmd2 = new SqlCommand(sql2, con);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("取款成功！");
                        usersForm.usersfrm.reload();
                        this.Hide();
                    }
                    else if(mon < money)
                    {
                        MessageBox.Show("对不起，余额不足！");
                    }
                    else if (flag == 1)
                    {
                        MessageBox.Show("对不起，该账户已被冻结！");
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
}
