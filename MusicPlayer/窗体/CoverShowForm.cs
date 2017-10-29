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
    public partial class CoverShowForm : Form
    {
        Point MouseOff;//鼠标移动位置变量

        bool bIsLeftFlag;//左键按下标志

        public CoverShowForm(Image img)
        {
            InitializeComponent();

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000; toolTip1.InitialDelay = 500; toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.pic_CoverShow, "双击 或者按 ESC 关闭");

            pic_CoverShow.Image = img;
        }

        private void pic_CoverShow_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void CoverShowForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void pic_CoverShow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseOff = new Point(-e.X, -e.Y); //得到变量的值
                bIsLeftFlag = true;                  //点击左键按下时标注为true;
            }
        }

        private void pic_CoverShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (bIsLeftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(MouseOff.X, MouseOff.Y);  //设置移动后的位置
                Location = mouseSet;
            }
        }

        private void pic_CoverShow_MouseUp(object sender, MouseEventArgs e)
        {
            if (bIsLeftFlag)
            {
                bIsLeftFlag = false;//释放鼠标后标注为false;
            }
        }

        private void pic_CoverShow_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CoverShowForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
