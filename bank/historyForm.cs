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
    public partial class historyForm : Form
    {
        public historyForm()
        {
            InitializeComponent();
        }

        public int id;
                
        private void historyForm_Load(object sender, EventArgs e)
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

            }

            string sql1 = "select id 用户ID, flow 资金明细, way 方式, date 操作时间 from history where id= " + id.ToString();
            DataTable dtMach = DB.getDataSet(sql1).Tables[0];
            dataGridView1.DataSource = dtMach;

        }
    }
}
