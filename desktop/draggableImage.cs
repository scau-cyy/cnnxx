using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace desktop
{
    public partial class draggableImage : PictureBox
    {
        public bool mouseleft = false;
        public bool mouseright = false;
        public bool mousedown = false;
        public int mousedownX = 0;
        public int mousedownY = 0;
        private ContextMenuStrip menu;

        public draggableImage()
        {
            InitializeComponent();
            initMyParm();
        }

        public draggableImage(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            initMyParm();
        }
        public void initMyParm()
        {
            menu = new ContextMenuStrip();
            menu.Items.Add("删除");
            menu.Items.Add("置顶");
            menu.Items[0].Click += menu_deleteImage;
            menu.Items[1].Click += menu_setTop;
            this.ContextMenuStrip = menu;
        }
        

        private void mouseDownDI(object sender, MouseEventArgs e)
        {
            mousedown = true;
            mousedownX = e.X;
            mousedownY = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                this.BorderStyle = BorderStyle.FixedSingle;
                mouseleft = true;
                this.BringToFront();
            }
            else if (e.Button == MouseButtons.Right)
            {
                mouseright = true;
            }
        }

        private void mouseUpDI(object sender, MouseEventArgs e)
        {
            mousedown = false;
            mouseleft = false;
            mouseright = false;
            mousedownX = 0;
            mousedownY = 0;
            this.BorderStyle = BorderStyle.None;
        }

        private void mouseMoveDI(object sender, MouseEventArgs e)
        {
            if(mousedown && mouseleft)
            {
                Point point = new Point(this.Location.X + e.X - mousedownX, this.Location.Y + e.Y - mousedownY);
                this.Location = point;
            }
        }
        

        private void menu_deleteImage(object sender, EventArgs e)
        {
            //MessageBox.Show("删除{0}", "哈哈");
            //int delete = MessageBox.Show("确定删除", "删除图片", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            DialogResult dr =MessageBox.Show("确定删除", "删除图片", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.OK)
            {
                this.Dispose();
            }
        }
        private void menu_setTop(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
