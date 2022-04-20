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
    public partial class usersForm : Form
    {
        public static usersForm usersfrm;
        private decimal mon;
        public int id;

        public usersForm()
        {
            InitializeComponent();
            usersfrm = this;
            new System.Threading.Thread(() =>
            {
                while (true)
                {
                    try { label3.BeginInvoke(new MethodInvoker(() => label3.Text = DateTime.Now.ToString())); }
                    catch { }
                    System.Threading.Thread.Sleep(1000);
                }
            })
            { IsBackground = true }.Start();
        }
        
        public void reload()
        {
            SqlConnection conn = DB.Getconn();
            string sql = "select name, sex, money from users where id=" + id.ToString();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string name = sdr["name"].ToString();
                name = name.Replace(" ", "");
                label1.Text = "尊敬的" + name;
                if (sdr["sex"].ToString().Equals("男"))
                    label1.Text += "先生:";
                else
                    label1.Text += "女士:";

                textBox1.Text = sdr["money"].ToString();
                mon = Convert.ToDecimal(textBox1.Text);
            }
        }

        private void usersForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DB.Getconn();
            string sql = "select name, sex, money from users where id=" + id.ToString();
            SqlCommand cmd = new SqlCommand(sql,conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string name = sdr["name"].ToString();
                name = name.Replace(" ", "");
                label1.Text = "尊敬的" + name;
                if (sdr["sex"].ToString().Equals("男"))
                    label1.Text += "先生:";
                else
                    label1.Text += "女士:";

                textBox1.Text = sdr["money"].ToString();
                mon = Convert.ToDecimal(textBox1.Text);
            }
            sdr.Close();
        }

        private void usersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            securityForm securityForm = new securityForm();
            securityForm.id = id;
            securityForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moneyFrom moneyFrm = new moneyFrom();
            moneyFrm.id = id;
            moneyFrm.mon = mon;
            moneyFrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            historyForm historyFrm = new historyForm();
            historyFrm.id = id;
            historyFrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giveForm giveFrm = new giveForm();
            giveFrm.id = id;
            giveFrm.mon = mon;
            giveFrm.Show();
        }
    }
}
