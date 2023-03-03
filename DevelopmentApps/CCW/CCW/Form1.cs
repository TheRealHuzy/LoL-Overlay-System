using ScreenShotDemo;
using Timer = System.Windows.Forms.Timer;

namespace LOS
{
    public partial class Form1 : Form
    {
        bool runScript = true; // true if changing position data
        bool saveTopImages = true; // true if all 15 images are to be captured
        string prefix = "A"; // prefix for bundle of images
        string saveLocation = @"C:\Your\save\address\example\";

        const string windowName = "League of Legends";
        ScreenCapture sc = new ScreenCapture();
        List<Image> pics = new List<Image>(new Image[15]);
        Image img;
        ManualResetEvent MRESuspendEvent = new ManualResetEvent(true);

        //auto-adjust resolution position data
        Timer checkResolutionTimer = new Timer();
        IntPtr handle = WindowsAPI.FindWindow(null, windowName);
        WindowsAPI.Rect rect;
        private int currentResolutionHeight;
        private int resIndex;
        List<PositionData> positionData = new List<PositionData>();


        public Form1()
        {
            InitializeComponent();
            checkResolutionTimer.Interval = 1000;
            checkResolutionTimer.Tick += updateCheckResolutionTimer;
        }

        //>>>>>>>>>>>>>MAIN CROPPING<<<<<<<<<<<<<<<<<<<<<<<

        private void Form1_Load(object sender, EventArgs e)
        {
            if (runScript)
            {
                PositionDataScript positionDataScript = new PositionDataScript();
                positionDataScript.RunScript();
            }

            Serializer serializer = new Serializer();
            positionData = (List<PositionData>)serializer.DeserializeBin("positionData.hz");

            checkResolutionTimer.Start();

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.RunWorkerAsync();

            //read summoner name
            /*IntPtr handle = WindowsAPI.FindWindow(null, windowName);
            Image img = sc.CaptureWindow(handle);
            img = cropImageRec((Bitmap)img, 1410, 35, 3);
            var Ocr = new IronTesseract();
            var Result = Ocr.Read(img);
            System.Diagnostics.Debug.WriteLine(">>> " + Result.Text);*/
        }

        Bitmap bitmap = null;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            IntPtr handle = WindowsAPI.FindWindow(null, windowName);
            
            while (true)
            {
                MRESuspendEvent.WaitOne(Timeout.Infinite);

                img = sc.CaptureWindow(handle);
                bitmap = (Bitmap)img;

                for (int i = 0; i < pics.Count; i++)
                {
                    if (i < 5) pics[i] = cropImageRec(bitmap, positionData[resIndex].cuttingPosition.side.permanentCoordinate, positionData[resIndex].cuttingPosition.side.getNextDynamicCoordinate(), 1);
                    else pics[i] = cropImageRec(bitmap, positionData[resIndex].cuttingPosition.top.getNextDynamicCoordinate(), positionData[resIndex].cuttingPosition.top.permanentCoordinate, 2);
                }

                this.Invoke(drawImages);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(1);
            }
        }

        private Bitmap cropImageRec(Bitmap b, int pointX, int pointY, int captureIndex)
        {
            int width = 1, height = 1;

            switch (captureIndex)
            {
                case 1: { width = positionData[resIndex].cuttingPosition.side.width; height = positionData[resIndex].cuttingPosition.side.height; } break;
                case 2: { width = positionData[resIndex].cuttingPosition.top.heightNWidth; height = positionData[resIndex].cuttingPosition.top.heightNWidth; } break;
            }
            Bitmap bmpCrop = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmpCrop))
            {
                g.DrawImage(b, -pointX, -pointY);
                return bmpCrop;
            }
        }
        private void drawImages()
        {
            pictureBox1.Image = bitmap;
            pictureBox2.Image = pics[0]; pictureBox3.Image = pics[1]; pictureBox4.Image = pics[2];
            pictureBox5.Image = pics[3]; pictureBox6.Image = pics[4]; pictureBox7.Image = pics[5];
            pictureBox8.Image = pics[6]; pictureBox9.Image = pics[7]; pictureBox10.Image = pics[8];
            pictureBox11.Image = pics[9]; pictureBox12.Image = pics[10]; pictureBox13.Image = pics[11];
            pictureBox14.Image = pics[12]; pictureBox15.Image = pics[13]; pictureBox16.Image = pics[14];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync(); //fixes pics in use when saving
            Thread.Sleep(1000);

            string resolutionInfo = "";
            switch (resIndex)
            {
                case 0: resolutionInfo = "900"; break;
                case 1: resolutionInfo = "720"; break;
                case 2: resolutionInfo = "576"; break;
            }
            int i = 1;

            if (saveTopImages)
            {
                foreach (Image img in pics)
                {
                    callSave(img, i, resolutionInfo);
                    i++;
                }
            } else
            {
                foreach (Image img in pics)
                {
                    if (i >= 6) break;
                    callSave(img, i, resolutionInfo);
                    i++;
                }
            }


        }

        private void callSave(Image img, int i, string resolutionInfo)
        {
            img.Save(saveLocation + prefix + i + "-" + resolutionInfo + ".png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //>>>>>>>>>>>>>Auto Update Resolution<<<<<<<<<<<<<<<<<<<<<<<

        private void updateCheckResolutionTimer(object sender, EventArgs e)
        {
            WindowsAPI.GetWindowRect(handle, out rect);
            int tempHeight = rect.bottom - rect.top;
            int tempWidth = rect.right - rect.left;
            if (tempHeight != currentResolutionHeight && checkIfResolutionIsSupported(tempHeight, tempWidth))
            {
                checkResolutionTimer.Stop();
                MRESuspendEvent.Reset();
                Thread.Sleep(1000);

                setResolutionIndex(tempHeight);
                currentResolutionHeight = tempHeight;

                checkResolutionTimer.Start();
                MRESuspendEvent.Set();
            }
            Thread.Sleep(1);
        }

        private bool checkIfResolutionIsSupported(int height, int width)
        {
            if (width == 1600 && height == 900) return true;
            if (width == 1280 && height == 720) return true;
            if (width == 1024 && height == 576) return true;
            return false;
        }

        private void setResolutionIndex(int height)
        {
            switch (height)
            {
                case 900: resIndex = 0; break;
                case 720: resIndex = 1; break;
                case 576: resIndex = 2; break;
            }
        }
    }
}