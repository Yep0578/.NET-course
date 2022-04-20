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
    public partial class adminForm : Form
    {
        public static adminForm adminfrm;

        public adminForm()
        {
            InitializeComponent();
            adminfrm = this;
            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    try { textBox1.BeginInvoke(new MethodInvoker(() => textBox1.Text = DateTime.Now.ToString())); }
                    catch { }
                    System.Threading.Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }

        public string adminid;
        private int selid;

        public void reload()
        {
            string sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users";
            DataTable dtMach = DB.getDataSet(sql).Tables[0];
            dataGridView1.DataSource = dtMach;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {   
            try
            {
                string sql = "";
                if (idtext.Text != "")
                {
                    sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users where id=" + Convert.ToInt32(idtext.Text);
                    DataTable dtMach = DB.getDataSet(sql).Tables[0];
                    dataGridView1.DataSource = dtMach;
                }
                else if (teltext.Text != "")
                {
                    sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users where tel='" + teltext.Text + "'";
                    DataTable dtMach = DB.getDataSet(sql).Tables[0];
                    dataGridView1.DataSource = dtMach;
                }
                else if (nametext.Text != "")
                {
                    sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users where name= '" + nametext.Text + "'";
                    DataTable dtMach = DB.getDataSet(sql).Tables[0];
                    dataGridView1.DataSource = dtMach;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息：" + ex.ToString());
            }
        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            txt11.Text = adminid;
            string sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users";
            DataTable dtMach = DB.getDataSet(sql).Tables[0];
            dataGridView1.DataSource = dtMach;
            
        }

        private void adminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                int a = dataGridView1.CurrentRow.Index;

                selid = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value.ToString());
                txt7.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();
                txt9.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
                txt8.Text = dataGridView1.Rows[a].Cells[6].Value.ToString();
                txt10.Text = dataGridView1.Rows[a].Cells[4].Value.ToString();

                if (dataGridView1.Rows[a].Cells[5].Value.ToString().Equals("正常"))
                    checkBox1.Checked = false;
                else
                    checkBox1.Checked = true;

            }
            
        }

        private void changebtn_Click(object sender, EventArgs e)
        {
            string sit = "";
            if (checkBox1.Checked)
                sit = "冻结";
            else
                sit = "正常";

            string sql = "update users set tel='" + txt7.Text + "' ,name='" + txt9.Text + "' ,idcard = '" + txt8.Text + "' ,date='" + textBox1.Text + "' ,situation='" + sit + "' where id=" + selid;
            try
            {
                SqlConnection con = DB.Getconn(); 
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users";
                DataTable dtMach = DB.getDataSet(sql).Tables[0];
                dataGridView1.DataSource = dtMach;
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息：" + ex.ToString());
            }

        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            string sql = "delete from users where id=" + selid;
            try
            {
                SqlConnection con = DB.Getconn();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                sql = "select id, name 姓名, sex 性别, tel 电话号码, money 余额, situation 账户情况, idcard 证件号码, date 上次修改时间 from users";
                DataTable dtMach = DB.getDataSet(sql).Tables[0];
                dataGridView1.DataSource = dtMach;
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常信息：" + ex.ToString());
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            securityForm securityForm = new securityForm();
            securityForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addForm addForm = new addForm();
            addForm.Show();

        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void idtext_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void teltext_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            historyForm historyFrm = new historyForm();
            historyFrm.id = selid;
            historyFrm.Show();
        }
    }
}
