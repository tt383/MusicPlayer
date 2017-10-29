namespace MusicPlayer
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tc_Setting = new System.Windows.Forms.TabControl();
            this.tp_PlayerSetting = new System.Windows.Forms.TabPage();
            this.tp_LibSetting = new System.Windows.Forms.TabPage();
            this.tp_LrcSetting = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.listbox_LocalLrcSearchOrder = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btn_Local = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button6 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tc_Setting.SuspendLayout();
            this.tp_PlayerSetting.SuspendLayout();
            this.tp_LrcSetting.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tc_Setting, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(422, 290);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tc_Setting
            // 
            this.tc_Setting.Controls.Add(this.tp_PlayerSetting);
            this.tc_Setting.Controls.Add(this.tp_LibSetting);
            this.tc_Setting.Controls.Add(this.tp_LrcSetting);
            this.tc_Setting.Controls.Add(this.tabPage1);
            this.tc_Setting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Setting.Location = new System.Drawing.Point(3, 3);
            this.tc_Setting.Multiline = true;
            this.tc_Setting.Name = "tc_Setting";
            this.tc_Setting.SelectedIndex = 0;
            this.tc_Setting.Size = new System.Drawing.Size(416, 239);
            this.tc_Setting.TabIndex = 0;
            // 
            // tp_PlayerSetting
            // 
            this.tp_PlayerSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tp_PlayerSetting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tp_PlayerSetting.Controls.Add(this.checkBox3);
            this.tp_PlayerSetting.Controls.Add(this.checkBox2);
            this.tp_PlayerSetting.Controls.Add(this.checkBox1);
            this.tp_PlayerSetting.Location = new System.Drawing.Point(4, 22);
            this.tp_PlayerSetting.Name = "tp_PlayerSetting";
            this.tp_PlayerSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tp_PlayerSetting.Size = new System.Drawing.Size(385, 213);
            this.tp_PlayerSetting.TabIndex = 0;
            this.tp_PlayerSetting.Text = "播放";
            // 
            // tp_LibSetting
            // 
            this.tp_LibSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tp_LibSetting.Location = new System.Drawing.Point(4, 22);
            this.tp_LibSetting.Name = "tp_LibSetting";
            this.tp_LibSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tp_LibSetting.Size = new System.Drawing.Size(385, 213);
            this.tp_LibSetting.TabIndex = 2;
            this.tp_LibSetting.Text = "音乐库";
            // 
            // tp_LrcSetting
            // 
            this.tp_LrcSetting.BackColor = System.Drawing.SystemColors.Control;
            this.tp_LrcSetting.Controls.Add(this.button8);
            this.tp_LrcSetting.Controls.Add(this.button7);
            this.tp_LrcSetting.Controls.Add(this.btn_Local);
            this.tp_LrcSetting.Controls.Add(this.button5);
            this.tp_LrcSetting.Controls.Add(this.label1);
            this.tp_LrcSetting.Controls.Add(this.listbox_LocalLrcSearchOrder);
            this.tp_LrcSetting.Location = new System.Drawing.Point(4, 22);
            this.tp_LrcSetting.Name = "tp_LrcSetting";
            this.tp_LrcSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tp_LrcSetting.Size = new System.Drawing.Size(408, 213);
            this.tp_LrcSetting.TabIndex = 1;
            this.tp_LrcSetting.Text = "歌词";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 248);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(416, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.button2, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.button3, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(410, 33);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(233, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 27);
            this.button1.TabIndex = 0;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(293, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(54, 27);
            this.button2.TabIndex = 1;
            this.button2.Text = "应用";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(353, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 27);
            this.button3.TabIndex = 2;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 27);
            this.button4.TabIndex = 3;
            this.button4.Text = "恢复默认";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 50);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 28);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(78, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 6);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(78, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // listbox_LocalLrcSearchOrder
            // 
            this.listbox_LocalLrcSearchOrder.FormattingEnabled = true;
            this.listbox_LocalLrcSearchOrder.ItemHeight = 12;
            this.listbox_LocalLrcSearchOrder.Items.AddRange(new object[] {
            "歌曲所在目录",
            "F:\\Music\\Lrc"});
            this.listbox_LocalLrcSearchOrder.Location = new System.Drawing.Point(6, 28);
            this.listbox_LocalLrcSearchOrder.Name = "listbox_LocalLrcSearchOrder";
            this.listbox_LocalLrcSearchOrder.Size = new System.Drawing.Size(167, 136);
            this.listbox_LocalLrcSearchOrder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "本地歌词搜索目录";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(179, 57);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "删除";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btn_Local
            // 
            this.btn_Local.Location = new System.Drawing.Point(179, 28);
            this.btn_Local.Name = "btn_Local";
            this.btn_Local.Size = new System.Drawing.Size(50, 23);
            this.btn_Local.TabIndex = 3;
            this.btn_Local.Text = "添加";
            this.btn_Local.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(179, 112);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(50, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "上移";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(179, 141);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 23);
            this.button8.TabIndex = 5;
            this.button8.Text = "下移";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(408, 213);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "专辑封面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(179, 140);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "下移";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(179, 111);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(50, 23);
            this.button9.TabIndex = 10;
            this.button9.Text = "上移";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(179, 27);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(50, 23);
            this.button10.TabIndex = 9;
            this.button10.Text = "添加";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(179, 56);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(50, 23);
            this.button11.TabIndex = 8;
            this.button11.Text = "删除";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "本地专辑封面搜索目录";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "歌曲所在目录",
            "F:\\Music\\Lrc"});
            this.listBox1.Location = new System.Drawing.Point(6, 27);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(167, 136);
            this.listBox1.TabIndex = 6;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 290);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SettingForm";
            this.Text = "设置";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tc_Setting.ResumeLayout(false);
            this.tp_PlayerSetting.ResumeLayout(false);
            this.tp_PlayerSetting.PerformLayout();
            this.tp_LrcSetting.ResumeLayout(false);
            this.tp_LrcSetting.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tc_Setting;
        private System.Windows.Forms.TabPage tp_PlayerSetting;
        private System.Windows.Forms.TabPage tp_LrcSetting;
        private System.Windows.Forms.TabPage tp_LibSetting;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btn_Local;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listbox_LocalLrcSearchOrder;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
    }
}