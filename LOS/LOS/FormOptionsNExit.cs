using System.ComponentModel;
using System.Text;
using System.Diagnostics;
using Timer = System.Windows.Forms.Timer;

namespace LOS
{
    public partial class FormOptionsNExit : Form
    {
        IntPtr handle;
        Bitmap resume, pause;
        bool flip = true;

        FormMainOverlay mainOverlay;
        FormOptions optionsForm;

        WindowsAPI.Rect rect;

        public bool activeOptionsWindow = false;

        Timer tmr;
        bool timerSetActive = false;

        private const int maximizeCode = 3;
        private const int minimizeCode = 6;

        //resolution scaling
        private int currentResolutionHeight;
        Timer checkResolutionTimer = new Timer();

        public FormOptionsNExit()
        {
            InitializeComponent();
            checkResolutionTimer.Interval = GlobalContainer.Main.checkForResolutionChangeInterval;
            checkResolutionTimer.Tick += updateCheckResolutionTimer;
        }
        private void updateCheckResolutionTimer(object sender, EventArgs e)
        {
            WindowsAPI.GetWindowRect(handle, out rect);
            int tempHeight = rect.bottom - rect.top;
            int tempWidth = rect.right - rect.left;
            if (tempHeight != currentResolutionHeight && checkIfResolutionIsSupported(tempHeight, tempWidth))
            {
                checkResolutionTimer.Stop();

                if (flip) mainOverlay.pauseAutoDetectBackgroundWorker(false);
                mainOverlay.Hide();
                this.Hide();
                if (optionsForm != null && activeOptionsWindow) optionsForm.Hide();

                Thread.Sleep(1000); //TODO maybe find work around

                mainOverlay.importNSetNewImageNPositionData(tempHeight, tempWidth);
                currentResolutionHeight = tempHeight;

                timerSetActive = false;
                if (flip) mainOverlay.resumeAutoDetectBackgroundWorker();
                mainOverlay.Show();
                this.Show();
                if (optionsForm != null && activeOptionsWindow) optionsForm.Show();

                checkResolutionTimer.Start();
            }
        }
        private bool checkIfResolutionIsSupported(int height, int width)
        {
            if (width == 1600 && height == 900) return true;
            if (width == 1280 && height == 720) return true;
            if (width == 1024 && height == 576) return true;
            return false;
        }
        private void updateOpacityUpTimer(object sender, EventArgs e)
        {
            this.Opacity += GlobalContainer.Main.loadUpOpacityChangePerInterval;
            if (this.Opacity == 100)
            {
                opacityUpLoadTimer.Stop();
            }
        }

        private void OptionsNExit_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Text = GlobalContainer.Main.thisApplicationName;

            handle = WindowsAPI.FindWindow(null, GlobalContainer.Main.windowName);

            int lolClientActive = 1;
            int tries = 0;
            /* 0 - LoL client is active
             * 1 - retry was requested
             * 2 - shutdown was requested
             */
            BasicData preBasicData = preloadBasicData();
            if (preBasicData == null) preBasicData = getNewLoLStartInformation(preBasicData);
            while (lolClientActive == 1)
            {
                lolClientActive = checkIfLoLIsActive(preBasicData);
                if (lolClientActive == 2)
                {
                    notifyIcon1.Visible = false;
                    Application.Exit();
                    return;
                }
                if (lolClientActive == 0 && tries > 0)
                {
                    notifyIcon1.Visible = false;
                    Application.Restart();
                    Environment.Exit(0);
                    return;
                }
                tries++;
            }

            tmr = new Timer();
            tmr.Interval = 500;
            tmr.Tick += timerTickAction;

            mainOverlay = new FormMainOverlay(this);
            mainOverlay.Show();

            optionsForm = new FormOptions(handle, this, mainOverlay);

            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;
            this.TopMost = true;
            CheckForIllegalCrossThreadCalls = false;
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, GlobalContainer.NamesNPaths.Paths.graphicDataPath));
            resume = new Bitmap(newPath + GlobalContainer.NamesNPaths.FullNames.picResume);
            pause = new Bitmap(newPath + GlobalContainer.NamesNPaths.FullNames.picPause);

            setSpawnPlaceSetup();

            opacityUpLoadTimer.Start();
            mainOverlay.opacityUpLoadTimer.Start();

            backgroundWorker1.RunWorkerAsync();

            checkResolutionTimer.Start();
        }
        public BasicData preloadBasicData()
        {
            Serializer serializer = new Serializer();
            BasicData basicData = (BasicData)serializer.DeserializeJSON(GlobalContainer.NamesNPaths.FullNames.baseData);
            if (basicData == null) basicData = loadBasicDataFromTemp(basicData);
            if (basicData != null) File.Delete(GlobalContainer.NamesNPaths.FullNames.tempBaseData);
            return basicData;
        }
        public BasicData loadBasicDataFromTemp(BasicData bd)
        {
            Serializer serializer = new Serializer();
            return (BasicData)serializer.DeserializeJSON(GlobalContainer.NamesNPaths.FullNames.tempBaseData);
        }

        private BasicData getNewLoLStartInformation(BasicData basicData)
        {
            basicData = new BasicData();
            basicData.lolClientLocation = getNewLolClientLocation();

            Serializer serializer = new Serializer();
            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.tempBaseData);

            return basicData;
        }
        private string getNewLolClientLocation()
        {
            AuxFormLoading loadingForm = new AuxFormLoading();
            loadingForm.Show();

            SetupFormEnterLoLClientLocation enterLoLClientLocation = new SetupFormEnterLoLClientLocation();
            enterLoLClientLocation.ShowDialog();

            loadingForm.Close();
            return enterLoLClientLocation.returnValue;
        }
        /* 0 - LoL client is active
         * 1 - retry was requested
         * 2 - shutdown was requested
         */
        private int checkIfLoLIsActive(BasicData bd)
        {
            int result;
            Process[] processes = Process.GetProcessesByName(GlobalContainer.Main.processName);
            if (processes.Length > 0)
            {
                //WindowsAPI.ShowWindow(this.handle, SW_MAXIMIZE);
                WindowsAPI.SetForegroundWindow(this.handle);
                return 0;
            }
            string lolLocation = bd.lolClientLocation;
            if (lolLocation != null)
            {
                if (lolLocation.CompareTo("") != 0)
                {
                    try
                    {
                        var p = new Process();
                        p.StartInfo.FileName = lolLocation;
                        p.Start();
                        result = runMessageBoxWaitForClient();
                    }
                    catch (Exception e)
                    {
                        result = runMessageBoxRunClient();
                    }
                }
                else result = runMessageBoxRunClient();
            }
            else result = runMessageBoxRunClient();
            return result;
        }
        public int runMessageBoxRunClient()
        {
            AuxFormWarningMessageBox runClientWarning = new AuxFormWarningMessageBox("Please start your LoL Client, wait for it to load and the press OK.");
            runClientWarning.ShowDialog();
            return runClientWarning.returnValue;
        }
        public int runMessageBoxWaitForClient()
        {
            AuxFormWarningMessageBox waitForClientWarning = new AuxFormWarningMessageBox("Please wait for your LoL Client to load then press OK.");
            waitForClientWarning.ShowDialog();
            return waitForClientWarning.returnValue;
        }

        public void startTimer()
        {
            tmr.Start();
        }
        private void timerTickAction(object sender, EventArgs e)
        {
            string title = ActiveWindowTitle();
            if ((title == GlobalContainer.Main.windowName || title == GlobalContainer.Main.thisApplicationName) && timerSetActive)
            {
                timerSetActive = false;
                if (flip) mainOverlay.resumeAutoDetectBackgroundWorker();
                mainOverlay.Show();
                this.Show();
                if (optionsForm != null && activeOptionsWindow) optionsForm.Show();
            }
            else if (title != GlobalContainer.Main.windowName && title != GlobalContainer.Main.thisApplicationName && !timerSetActive)
            {
                timerSetActive = true;
                if (flip) mainOverlay.pauseAutoDetectBackgroundWorker(false);
                mainOverlay.Hide();
                this.Hide();
                if (optionsForm != null && activeOptionsWindow) optionsForm.Hide();
            }
        }
        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (flip)
            {
                flip = false; timerSetActive = false;
                btnPauseResume.BackgroundImage = resume;
                mainOverlay.pauseAutoDetectBackgroundWorker(true);
            }
            else
            {
                flip = true; timerSetActive = true;
                btnPauseResume.BackgroundImage = pause;
                mainOverlay.resumeAutoDetectBackgroundWorker();
            }
        }
        private string ActiveWindowTitle()
        {
            const int nChar = 256;
            StringBuilder ss = new StringBuilder(nChar);
            IntPtr handle = IntPtr.Zero;
            handle = WindowsAPI.GetForegroundWindow();
            if (WindowsAPI.GetWindowText(handle, ss, nChar) > 0) return ss.ToString();
            else return "";
        }
        private void setSpawnPlaceSetup()
        {
            WindowsAPI.GetWindowRect(handle, out rect);
            this.Top = rect.bottom - 28;
            this.Left = rect.left + 78;
            currentResolutionHeight = rect.bottom - rect.top;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                setSpawnPlace();
                Thread.Sleep(1);
            }
        }
        private void setSpawnPlace()
        {
            WindowsAPI.GetWindowRect(handle, out rect);
            this.Top = rect.bottom - GlobalContainer.Main.optionsNExitPointDistanceFromBottom;
            this.Left = rect.left + GlobalContainer.Main.optionsNExitPointDistanceFromLeft;
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if (!activeOptionsWindow)
            {
                activeOptionsWindow = true;
                optionsForm.setSpawnPlace();
                optionsForm.resumeBackgroundWorker();
                optionsForm.Show();
                optionsForm.startShowHideTimer();
            }
        }
        public void allowOptionsWindow()
        {
            activeOptionsWindow = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            if (mainOverlay != null)
            {
                BasicData basicData = mainOverlay.getThisBasicData();
                if (mainOverlay.inSetup && basicData.summonerData.Count < 1)
                {
                    if (File.Exists(GlobalContainer.NamesNPaths.FullNames.baseData)) File.Delete(GlobalContainer.NamesNPaths.FullNames.baseData);
                }
            }
            if (File.Exists(GlobalContainer.NamesNPaths.FullNames.tempBaseData)) File.Delete(GlobalContainer.NamesNPaths.FullNames.tempBaseData);
            Application.Restart();
            Environment.Exit(0);
            return;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            if (mainOverlay != null)
            {
                BasicData basicData = mainOverlay.getThisBasicData();
                if (mainOverlay.inSetup && basicData.summonerData.Count < 1)
                {
                    if (File.Exists(GlobalContainer.NamesNPaths.FullNames.baseData)) File.Delete(GlobalContainer.NamesNPaths.FullNames.baseData);
                }
            }
            if (File.Exists(GlobalContainer.NamesNPaths.FullNames.tempBaseData)) File.Delete(GlobalContainer.NamesNPaths.FullNames.tempBaseData);
            Application.Exit();
            return;
        }

        private void btnOptions_MouseEnter(object sender, EventArgs e) { btnOptions.BackColor = Color.Black; }
        private void btnOptions_MouseHover(object sender, EventArgs e) { btnOptions.BackColor = Color.Black; }
        private void btnOptions_MouseLeave(object sender, EventArgs e) { btnOptions.BackColor = Color.Transparent; }
        private void btnPauseResume_MouseEnter(object sender, EventArgs e) { btnPauseResume.BackColor = Color.Black; }
        private void btnPauseResume_MouseHover(object sender, EventArgs e) { btnPauseResume.BackColor = Color.Black; }
        private void btnPauseResume_MouseLeave(object sender, EventArgs e) { btnPauseResume.BackColor = Color.Transparent; }
        private void btnExit_MouseEnter(object sender, EventArgs e) { btnExit.BackColor = Color.Black; }
        private void btnExit_MouseHover(object sender, EventArgs e) { btnExit.BackColor = Color.Black; }
        private void btnExit_MouseLeave(object sender, EventArgs e) { btnExit.BackColor = Color.Transparent; }

        private void toolStripMenuItemMouseOnChanges(ToolStripMenuItem item) { item.BackColor = Color.BlanchedAlmond; }
        private void toolStripMenuItemMouseOffChanges(ToolStripMenuItem item) { item.BackColor = Color.Black; }

        private void restartToolStripMenuItem_MouseEnter(object sender, EventArgs e) { toolStripMenuItemMouseOnChanges(restartToolStripMenuItem); }
        private void restartToolStripMenuItem_MouseHover(object sender, EventArgs e) { toolStripMenuItemMouseOnChanges(restartToolStripMenuItem); }
        private void restartToolStripMenuItem_MouseLeave(object sender, EventArgs e) { toolStripMenuItemMouseOffChanges(restartToolStripMenuItem); }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e) { toolStripMenuItemMouseOnChanges(exitToolStripMenuItem); }
        private void exitToolStripMenuItem_MouseHover(object sender, EventArgs e) { toolStripMenuItemMouseOnChanges(exitToolStripMenuItem); }
        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e) { toolStripMenuItemMouseOffChanges(exitToolStripMenuItem); }
    }
}
