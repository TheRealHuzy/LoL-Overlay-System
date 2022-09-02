using System.Runtime.InteropServices;
using ScreenShotDemo;
using IronOcr;

namespace CCW
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public const string windowName = "League of Legends";
        ScreenCapture sc = new ScreenCapture();
        List<Image> pics = new List<Image>(new Image[15]);
        Image img;

        private const int bigResolutionCaptureWidth = 25;
        private const int bigResolutionCaptureHeight = 50;
        private const int bigResolutionCaptureTopWidth = 55;
        private const int bigResolutionCaptureTopHeight = 55;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            /*IntPtr handle = FindWindow(null, windowName);
            Image img = sc.CaptureWindow(handle);
            img = cropImageRec((Bitmap)img, 1410, 35, 3);
            var Ocr = new IronTesseract();
            var Result = Ocr.Read(img);
            System.Diagnostics.Debug.WriteLine(">>> " + Result.Text);*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Bitmap bitmap = null;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IntPtr handle = FindWindow(null, windowName);
            
            while (true)
            {
                img = sc.CaptureWindow(handle);
                bitmap = (Bitmap)img;

                pics[0] = cropImageRec(bitmap, 55, 91, 7);
                pics[1] = cropImageRec(bitmap, 55, 156, 7);
                pics[2] = cropImageRec(bitmap, 55, 219, 7);
                pics[3] = cropImageRec(bitmap, 55, 284, 7);
                pics[4] = cropImageRec(bitmap, 55, 347, 7);
                pics[5] = cropImageRec(bitmap, 284, 11, 8);
                pics[6] = cropImageRec(bitmap, 331, 11, 8);
                pics[7] = cropImageRec(bitmap, 378, 11, 8);
                pics[8] = cropImageRec(bitmap, 425, 11, 8);
                pics[9] = cropImageRec(bitmap, 472, 11, 8);
                pics[10] = cropImageRec(bitmap, 518, 11, 8);
                pics[11] = cropImageRec(bitmap, 566, 11, 8);
                pics[12] = cropImageRec(bitmap, 613, 11, 8);
                pics[13] = cropImageRec(bitmap, 659, 11, 8);
                pics[14] = cropImageRec(bitmap, 706, 11, 8);

                this.Invoke(drawImages);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(1);
            }
        }

        /*
         * 1600x900 resolution
                pics[0] = cropImageRec(bitmap, 88, 150, 1);
                pics[1] = cropImageRec(bitmap, 88, 250, 1);
                pics[2] = cropImageRec(bitmap, 88, 350, 1);
                pics[3] = cropImageRec(bitmap, 88, 450, 1);
                pics[4] = cropImageRec(bitmap, 88, 550, 1);
                pics[5] = cropImageRec(bitmap, 442, 16, 2);
                pics[6] = cropImageRec(bitmap, 515, 16, 2);
                pics[7] = cropImageRec(bitmap, 588, 16, 2);
                pics[8] = cropImageRec(bitmap, 662, 16, 2);
                pics[9] = cropImageRec(bitmap, 736, 16, 2);
                pics[10] = cropImageRec(bitmap, 809, 16, 2);
                pics[11] = cropImageRec(bitmap, 884, 16, 2);
                pics[12] = cropImageRec(bitmap, 956, 16, 2);
                pics[13] = cropImageRec(bitmap, 1030, 16, 2);
                pics[14] = cropImageRec(bitmap, 1104, 16, 2);
         * 
         */
        /*
         * 1280x720 resolution
                pics[0] = cropImageRec(bitmap, 70, 113, 5);
                pics[1] = cropImageRec(bitmap, 70, 193, 5);
                pics[2] = cropImageRec(bitmap, 70, 273, 5);
                pics[3] = cropImageRec(bitmap, 70, 354, 5);
                pics[4] = cropImageRec(bitmap, 70, 434, 5);
                pics[5] = cropImageRec(bitmap, 355, 13, 6);
                pics[6] = cropImageRec(bitmap, 413, 13, 6);
                pics[7] = cropImageRec(bitmap, 472, 13, 6);
                pics[8] = cropImageRec(bitmap, 530, 13, 6);
                pics[9] = cropImageRec(bitmap, 589, 13, 6);
                pics[10] = cropImageRec(bitmap, 648, 13, 6);
                pics[11] = cropImageRec(bitmap, 706, 13, 6);
                pics[12] = cropImageRec(bitmap, 765, 13, 6);
                pics[13] = cropImageRec(bitmap, 824, 13, 6);
                pics[14] = cropImageRec(bitmap, 882, 13, 6);
         * 
         */

        private void drawImages()
        {
            pictureBox1.Image = bitmap;
            pictureBox2.Image = pics[0];
            pictureBox3.Image = pics[1];
            pictureBox4.Image = pics[2];
            pictureBox5.Image = pics[3];
            pictureBox6.Image = pics[4];
            pictureBox7.Image = pics[5];
            pictureBox8.Image = pics[6];
            pictureBox9.Image = pics[7];
            pictureBox10.Image = pics[8];
            pictureBox11.Image = pics[9];
            pictureBox12.Image = pics[10];
            pictureBox13.Image = pics[11];
            pictureBox14.Image = pics[12];
            pictureBox15.Image = pics[13];
            pictureBox16.Image = pics[14];
        }

        private Image cropImage(Image img, int leftRight, int topBottom)
        {   
            int newWidth = 35;
            int newHeight = 50;
            Rectangle cropArea = new Rectangle(leftRight, topBottom, newWidth, newHeight);
            var bmp = (Bitmap) img;
            Bitmap bmpCrop = bmp.Clone(cropArea, img.PixelFormat);
            return bmpCrop;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 1;
            foreach (Image img in pics)
            {
                img.Save(@"X:\1LolSplash\img\champion\screenshots\E" + i + "-576.png");
                i++;
            }
            pictureBox2.Image = pics[0];
            pictureBox3.Image = pics[1];
            pictureBox4.Image = pics[2];
            pictureBox5.Image = pics[3];
            pictureBox6.Image = pics[4];
        }

        /* capture index description
         * 1 - side picture 1600x900
         * 2 - top picture 1600x900
         * 3 - name tag top right
         * 4 - play/party top left
         * 5 - side picture 1280x720
         * 6 - top picture 1280x720
         * 7 - side picture 1024x576
         * 8 - top picture 1024x576
         */
        private static Bitmap cropImageRec(Bitmap b, int pointX, int pointY, int captureIndex)
        {
            int width, height;
            switch (captureIndex)
            {
                case 1: { width = bigResolutionCaptureWidth; height = bigResolutionCaptureHeight; } break;
                case 2: { width = bigResolutionCaptureTopWidth; height = bigResolutionCaptureTopHeight; } break;
                case 3: { width = 185; height = 25; } break;
                case 4: { width = 100; height = 30; } break;
                case 5: { width = 18; height = 42; } break;
                case 6: { width = 44; height = 44; } break;
                case 7: { width = 15; height = 33; } break;
                case 8: { width = 34; height = 34; } break;
                default: { width = bigResolutionCaptureWidth; height = bigResolutionCaptureHeight; } break;
            }
            Bitmap bmpCrop = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmpCrop))
            {
                g.DrawImage(b, -pointX, -pointY);
                return bmpCrop;
            }
        }
    }
}