using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desktop
{
    public partial class mainWindow : Form
    {
        public bool setWindowStayTop = false;
        public List<draggableImage> imageList;

        public mainWindow()
        {
            InitializeComponent();
            imageList = new List<draggableImage>();
        }
        

        private void setWindowTopOrNot_Click(object sender, EventArgs e)
        {
            if(!setWindowStayTop)
            {
                this.TopMost = true;
                setWindowStayTop = true;
                this.windowTopStatus.Text = "取消置顶";
            }
            else
            {
                this.TopMost = false;
                setWindowStayTop = false;
                this.windowTopStatus.Text = "窗口置顶";
            }
        }

        private void dragEnterMW(object sender, DragEventArgs e)
        {
            Array file = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            string fileText = null;
            if (null!=file)
            {
                foreach (object I in file)
                {
                    fileText = I.ToString();
                    if (fileText.EndsWith(".jpg") || fileText.EndsWith(".jpeg") ||
                        fileText.EndsWith(".bmp") || fileText.EndsWith(".png") ||
                        fileText.EndsWith(".gif"))
                    {
                        e.Effect = DragDropEffects.Link;
                        break;
                    }
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void dragDropMW(object sender, DragEventArgs e)
        {
            Array file = (System.Array)e.Data.GetData(DataFormats.FileDrop);
            string fileText = null;
            Point point = this.PointToClient(MousePosition);
            foreach (object I in file)
            {
                fileText = I.ToString();
                if (fileText.EndsWith(".jpg") || fileText.EndsWith(".jpeg") ||
                    fileText.EndsWith(".bmp") || fileText.EndsWith(".png") ||
                    fileText.EndsWith(".gif"))
                {

                    draggableImage picture = new draggableImage();
                    picture.Load(fileText);
                    picture.Location = point;
                    point.X += 5;
                    point.Y += 5;
                    picture.SizeMode = PictureBoxSizeMode.AutoSize;
                    this.Controls.Add(picture);
                    imageList.Add(picture);
                }
            }
        }

        private void clipboardImageBtn_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Bitmap))
            {
                draggableImage image = new draggableImage();
                image.Image = (Bitmap)iData.GetData(DataFormats.Bitmap);
                image.Location = new Point(10,10);
                image.SizeMode = PictureBoxSizeMode.AutoSize;
                this.Controls.Add(image);
                imageList.Add(image);
            }
        }

        private void deleteAllImage_Click(object sender, EventArgs e)
        {
            foreach(draggableImage image in imageList)
            {
                this.Controls.Remove(image);
            }
            imageList.Clear();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
