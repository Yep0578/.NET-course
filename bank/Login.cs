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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button_log_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || password.Text == "")
            {
                MessageBox.Show("请输入用户名或密码", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    SqlConnection con = DB.Getconn();   //验证开始
                    if (yh.Checked == true)
                    {
                        SqlCommand cmd = new SqlCommand("select count(*) from users where id=" + Convert.ToInt32(id.Text) + " and password='" + password.Text + "'", con);
                        int i = Convert.ToInt32(cmd.ExecuteScalar());
                        if (i > 0)
                        {
                            cmd = new SqlCommand("select * from users where id=" + Convert.ToInt32(id.Text), con);
                            SqlDataReader sdr = cmd.ExecuteReader();
                            sdr.Read();
                            con.Close();
                            usersForm user = new usersForm();
                            user.id = Convert.ToInt32(id.Text);
                            user.Show();
                            this.Hide();
                        }
                        else
                        { MessageBox.Show("对不起，用户名或密码错误！"); }
                    }
                    else if (gly.Checked == true)
                    {
                        SqlCommand cmd = new SqlCommand("select count(*) from admin where id='" + id.Text + "' and password='" + password.Text + "'", con);
                        int i = Convert.ToInt32(cmd.ExecuteScalar());

                        if (i > 0)
                        {
                            cmd = new SqlCommand("select * from admin where id='" + id.Text + "'", con);
                            SqlDataReader sdr = cmd.ExecuteReader();
                            sdr.Read();
                            con.Close();
                            adminForm admin = new adminForm();
                            admin.adminid = id.Text;
                            admin.Show();
                            this.Hide();
                        }
                        else
                        { MessageBox.Show("对不起，用户名或密码错误！"); }
                    }
                        
                    else
                        MessageBox.Show("请选择身份！");

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("异常信息：" + ex.ToString());
                }
            }
        }
    }
}
