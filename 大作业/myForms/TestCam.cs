using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 引用AForge的命名空间
using AForge.Video;
using AForge.Video.DirectShow;



namespace 大作业.myForms
{
    public partial class TestCam : Form
    {
        // 定义摄像头设备变量
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        public TestCam()
        {
            InitializeComponent();
                    // 获取所有视频输入设备
        videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        }

        private void TestCam_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (videoDevices.Count == 0)
                return;

            // 创建视频源
            videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoDevice.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoDevice.Start();
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // 获取新帧并显示
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            // Invoke方法用于在拥有控件的基础窗口句柄的线程上执行指定的委托
            panel1.Invoke(new MethodInvoker(delegate ()
            {
                // 在panel1上绘制图像
                Graphics g = panel1.CreateGraphics();
                g.DrawImage(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
                g.Dispose();
            }));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
