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
using System.Threading;

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
        Thread gifThread;
        bool processingFramesDone = false;
        public main_window()
        {
            InitializeComponent();
        }

        private void processFrames()
        {
            foreach (Image img in frame_list) {
                gifCreator.AddFrame(img, delay: -1, quality: GIFQuality.Bit8);
                progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.PerformStep(); }));
            }
            // when thread finishes, reshow button
            gifCreator.Dispose();

            progressBar1.Invoke(new MethodInvoker(delegate { progressBar1.Visible = false; }));
            button1.Invoke(new MethodInvoker(delegate { button1.Visible = true; button1.BringToFront(); button1.Text = "Start Recording"; button1.BackColor = System.Drawing.Color.SeaGreen; })); 
            /*
            button1.Invoke(new MethodInvoker(delegate { button1.BringToFront(); }));

            button1.Invoke(new MethodInvoker(delegate { button1.Text = "Start Recording"; }));
            button1.Invoke(new MethodInvoker(delegate { button1.BackColor = System.Drawing.Color.SeaGreen; }));
            */
            recording = false;
            processingFramesDone = true;
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
                processingFramesDone = false;
            }
            else
            {
                if (!processingFramesDone)
                {
                    // change button to show a progress bar
                    button1.Visible = false;
                    button1.SendToBack();
                    progressBar1.Visible = true;
                    progressBar1.Maximum = frame_list.Count;
                    progressBar1.Minimum = 1;
                    progressBar1.Value = 1;
                    progressBar1.Step = 1;
                    timer1.Stop();

                    // create new thread to process frames so program doesn't stall
                    gifThread = new Thread(processFrames);
                    gifThread.Start();
                }
            }
        }

        private void main_window_Load(object sender, EventArgs e)
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = FPS;
            timer1.Tick += timer1_Tick;
            progressBar1.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // code to take screenshots
            img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            g = Graphics.FromImage(img);
            g.CopyFromScreen(0, 0, 0, 0, img.Size);
            pictureBox1.Image = img;
            frame_list.Add(img);
        }
    }
}
