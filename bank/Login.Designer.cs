namespace bank
{
    partial class Login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_log = new System.Windows.Forms.Button();
            this.yh = new System.Windows.Forms.RadioButton();
            this.gly = new System.Windows.Forms.RadioButton();
            this.password = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(225, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "银行储蓄系统";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_log);
            this.groupBox1.Controls.Add(this.yh);
            this.groupBox1.Controls.Add(this.gly);
            this.groupBox1.Controls.Add(this.password);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(182, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 236);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入用户名密码登录";
            // 
            // button_log
            // 
            this.button_log.Location = new System.Drawing.Point(154, 191);
            this.button_log.Name = "button_log";
            this.button_log.Size = new System.Drawing.Size(124, 25);
            this.button_log.TabIndex = 8;
            this.button_log.Text = "登录";
            this.button_log.UseVisualStyleBackColor = true;
            this.button_log.Click += new System.EventHandler(this.button_log_Click);
            // 
            // yh
            // 
            this.yh.AutoSize = true;
            this.yh.Location = new System.Drawing.Point(137, 157);
            this.yh.Name = "yh";
            this.yh.Size = new System.Drawing.Size(47, 16);
            this.yh.TabIndex = 7;
            this.yh.TabStop = true;
            this.yh.Text = "用户";
            this.yh.UseVisualStyleBackColor = true;
            // 
            // gly
            // 
            this.gly.AutoSize = true;
            this.gly.Location = new System.Drawing.Point(232, 157);
            this.gly.Name = "gly";
            this.gly.Size = new System.Drawing.Size(59, 16);
            this.gly.TabIndex = 6;
            this.gly.TabStop = true;
            this.gly.Text = "管理员";
            this.gly.UseVisualStyleBackColor = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(117, 119);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(217, 21);
            this.password.TabIndex = 3;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(117, 69);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(217, 21);
            this.id.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(39, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "密  码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(39, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户ID：";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "登录";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_log;
        private System.Windows.Forms.RadioButton yh;
        private System.Windows.Forms.RadioButton gly;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

