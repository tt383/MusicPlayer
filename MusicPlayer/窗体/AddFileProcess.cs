using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class ADDFILEPROCESSFORM : Form
    {
        public int PbValue { set { this.pb_AddFlieProcess.Value = value; }}
        public string CurAddFileName { set { this.lbl_CurAddFileName.Text = value; }}
        public int PbMaximum { set { this.pb_AddFlieProcess.Maximum = value; } }
        public Action ThisFormClosedCallBack;

        public ADDFILEPROCESSFORM(int pbvalue, Action ac)
        {
            InitializeComponent();
            pb_AddFlieProcess.Maximum = pbvalue;

            ThisFormClosedCallBack = ac;

        }

        private void btn_CancelAddProcess_Click(object sender, EventArgs e)
        {
            //通知主窗口关掉添加文件进程
            ThisFormClosedCallBack();
            this.Dispose();
        }

        private void ADDFILEPROCESSFORM_FormClosed(object sender, FormClosedEventArgs e)
        {
            //通知主窗口关掉添加文件进程
            ThisFormClosedCallBack();
            this.Dispose();
        }
    }
}
