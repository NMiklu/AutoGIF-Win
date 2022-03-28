using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GifMotion;
using System.IO;

namespace AutoGif_windows
{
    public partial class main_window : Form
    {
        int FPS = 10;
        bool recording = false;
        Bitmap img;
        Graphics g;
        String path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        GifCreator gifCreator;
        List<Image> frame_list;
        public main_window()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                frame_list = new List<Image>();
                gifCreator = AnimatedGif.Create(path + "/test.gif", 33);
                timer1.Start();


                button1.Text = "Stop Recording";
                button1.BackColor = System.Drawing.Color.Red;
                recording = true;
            }
            else
            {
                timer1.Stop();
                gifCreator.Dispose();

                button1.Text = "Start Recording";
                button1.BackColor = System.Drawing.Color.SeaGreen;
                recording = false;
            }

        }

        private void main_window_Load(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = FPS;
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // code to take screenshots
            img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            g = Graphics.FromImage(img);
            g.CopyFromScreen(0, 0, 0, 0, img.Size);
            pictureBox1.Image = img;
            frame_list.Add(img);
            gifCreator.AddFrame(img, delay: -1, quality: GIFQuality.Bit8);
        }
    }
}
