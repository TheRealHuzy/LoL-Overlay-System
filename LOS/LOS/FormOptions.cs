using System.ComponentModel;
using ScreenShotDemo;
using IronOcr;
using Timer = System.Windows.Forms.Timer;

namespace LOS
{
    public partial class FormOptions : Form
    {
        IntPtr handle;
        FormOptionsNExit optionsNExit;
        BasicData basicData;
        FormMainOverlay mainOverlay;

        ScreenCapture sc = new ScreenCapture();

        WindowsAPI.Rect rect;
        ManualResetEvent MRESuspendEvent = new ManualResetEvent(true);

        List<string> summoners = new List<string>();
        bool dataSourceLoaded = false;

        Timer messageTimer = new Timer();
        bool formShown = false;

        public FormOptions(IntPtr handle, FormOptionsNExit optionsNExit, FormMainOverlay mainOverlay)
        {
            InitializeComponent();
            this.handle = handle;
            this.optionsNExit = optionsNExit;
            this.basicData = mainOverlay.getThisBasicData();
            this.mainOverlay = mainOverlay;
            
            messageTimer.Interval = GlobalContainer.Main.updateMessageDuration;
            messageTimer.Tick += updateMessageTimer;
        }
        public void updateMessageTimer(object sender, EventArgs e)
        {
            lblOptionsMessage.Text = "";
            messageTimer.Stop();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.Width = 0;
            this.Text = GlobalContainer.Main.thisApplicationName;
            List<string> summoners = loadSummonersForComboBox();

            cbxSummonerNames.DataSource = summoners;
            dataSourceLoaded = true;
            cbxSummonerNames.DisplayMember = "Name";

            cbxSummonerNames.SelectedIndex = cbxSummonerNames.FindStringExact(basicData.defaultSummoner);
                        
            setSpawnPlace();
            this.Show();
            backgroundWorker1.RunWorkerAsync();
        }
        public List<string> loadSummonersForComboBox()
        {
            summoners.Clear();
            foreach (var summoner in basicData.summonerData)
            {
                summoners.Add(summoner.summonerName);
            }
            return summoners;
        }
        public void setSpawnPlace()
        {
            WindowsAPI.GetWindowRect(handle, out rect);
            this.Top = rect.bottom - GlobalContainer.Main.optionsSpawnPointDistanceFromBottom;
            this.Left = rect.left + GlobalContainer.Main.optionsSpawnPointDistanceFromLeft;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                MRESuspendEvent.WaitOne(Timeout.Infinite);
                setSpawnPlace();
                Thread.Sleep(1);
            }
        }
        private void pauseBackgroundWorker()
        {
            MRESuspendEvent.Reset();
        }
        public void resumeBackgroundWorker()
        {
            MRESuspendEvent.Set();
        }

        private void btnSetNewSummoner_Click(object sender, EventArgs e)
        {
            if (changeSummonerData(tbxSummonerName.Text))
            {
                updateOptionsMessage(GlobalContainer.UpdateStatus.summonerExistsSucc);
            }
            else updateOptionsMessage(GlobalContainer.UpdateStatus.summonerExistsFail);

            tbxSummonerName.Text = "";
        }
        private void cbxSummonerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSummonerNames.DataSource != null && dataSourceLoaded)
            {
                changeSummonerData(cbxSummonerNames.Text);
                updateOptionsMessage(GlobalContainer.UpdateStatus.summonerExistsSucc);
            }
        }
        private bool changeSummonerData(string summonerName)
        {
            bool noAPIError = true;
            bool summonerAlreadyExists = false;
            if (mainOverlay.checkIfSummonerMasteryDataExists(summonerName))
            {
                mainOverlay.loadChampionData(summonerName);
                summonerAlreadyExists = true;
            }
            else
            {
                noAPIError = mainOverlay.getNewSummonerInfo(summonerName);
                cbxSummonerNames.DataSource = null;
            }
            if (noAPIError)
            {
                mainOverlay.setThisBasicData(basicData);
                summoners = loadSummonersForComboBox();
                cbxSummonerNames.DataSource = summoners;
                cbxSummonerNames.SelectedIndex = cbxSummonerNames.FindStringExact(summonerName);
            }
            return summonerAlreadyExists;
        }

        private void btnScanSummonerName_Click(object sender, EventArgs e)
        {
            string OCRFoundString = OCRSummonerName();
            if (OCRFoundString.CompareTo("") != 0)
            {
                tbxSummonerName.Text = OCRFoundString;
                updateOptionsMessage(GlobalContainer.UpdateStatus.scanSucc);
            }
            else
            {
                tbxSummonerName.PlaceholderText = GlobalContainer.PlaceholderMessages.summonerNameOCRFail;
                updateOptionsMessage(GlobalContainer.UpdateStatus.scanFail);
            }
        }
        private string OCRSummonerName()
        {
            Image img = sc.CaptureWindow(handle);
            img = cropImageRec((Bitmap)img, 1410, 35);      //TODO needs to be changed if OCR works
            string result;
            try { result = new IronTesseract().Read(img).Text; }
            catch { result = ""; }
            return result;
        }
        private static Bitmap cropImageRec(Bitmap b, int pointX, int pointY)
        {
            int width = 185, height = 25;                   //TODO needs to be changed if OCR works
            Bitmap bmpCrop = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmpCrop))
            {
                g.DrawImage(b, -pointX, -pointY);
                return bmpCrop;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (mainOverlay.callGetMasteryUpdated()) updateOptionsMessage(GlobalContainer.UpdateStatus.summonerUpdateSucc);
            else updateOptionsMessage(GlobalContainer.UpdateStatus.summonerUpdateFail);
        }
        private void btnDeleteActiveSummonerData_Click(object sender, EventArgs e)
        {
            if (basicData.summonerData.Count == 1)
            {
                AuxFormInfoMessageBox infoMessageBox = new AuxFormInfoMessageBox(GlobalContainer.Messages.deletingTheOnlySummonerEntry + basicData.summonerData[0].summonerName + " !");
                infoMessageBox.ShowDialog();
                updateOptionsMessage(GlobalContainer.UpdateStatus.summonerDeleteFail);
                return;
            }
            mainOverlay.callDeleteActiveSummonerData(cbxSummonerNames.GetItemText(cbxSummonerNames.SelectedItem));
            summoners = loadSummonersForComboBox();

            dataSourceLoaded = false;
            cbxSummonerNames.DataSource = null;
            cbxSummonerNames.DataSource = summoners;
            dataSourceLoaded = true;
            if (basicData.summonerData.Count > 0) cbxSummonerNames.SelectedIndex = cbxSummonerNames.FindStringExact(basicData.summonerData[0].summonerName);
            updateOptionsMessage(GlobalContainer.UpdateStatus.summonerDeleteSucc);
        }
        private void btnSetApiKey_Click(object sender, EventArgs e)
        {
            if (tbxApiKey.Text.CompareTo("") == 0)
            {
                tbxApiKey.PlaceholderText = GlobalContainer.PlaceholderMessages.APIKeyNullOnSet;
                return;
            }
            basicData.apiKey = tbxApiKey.Text;
            mainOverlay.api = mainOverlay.createRiotSharpAPIInstance();
            mainOverlay.serilizeBasicData();
            tbxApiKey.Text = "";
            updateOptionsMessage(GlobalContainer.UpdateStatus.APISetSucc);
        }
        private void btnSetLoLCleintL_Click(object sender, EventArgs e)
        {
            basicData.lolClientLocation = tbxLoLClientL.Text;
            Serializer serializer = new Serializer();
            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.baseData);
            tbxLoLClientL.Text = "";
            updateOptionsMessage(GlobalContainer.UpdateStatus.LoLClientLocSetSucc);
        }
        private void btnCloseOptions_Click(object sender, EventArgs e)
        {
            pauseBackgroundWorker();
            startShowHideTimer();

            tbxSummonerName.PlaceholderText = GlobalContainer.PlaceholderMessages.summonerNameDefault;
            tbxApiKey.PlaceholderText = GlobalContainer.PlaceholderMessages.APIKeyDefault;
        }
        public void startShowHideTimer()
        {
            showHideTimer.Start();
        }
        public void updateShowHideTimer(object sender, EventArgs e)
        {
            if (formShown)
            {
                this.Width -= GlobalContainer.Main.optionsShowHideAnimationSpeed;
                if (this.Width <= this.MinimumSize.Width)
                {
                    formShown = false;
                    showHideTimer.Stop();
                    optionsNExit.allowOptionsWindow();
                    Hide();
                }
            }
            else
            {
                this.Width += GlobalContainer.Main.optionsShowHideAnimationSpeed;
                if (this.Width >= this.MaximumSize.Width)
                {
                    formShown = true;
                    showHideTimer.Stop();
                }
            }
        }

        public void updateOptionsMessage(string message)
        {
            if (messageTimer.Enabled) { messageTimer.Stop(); lblOptionsMessage.Text = ""; }
            lblOptionsMessage.Text = message;
            messageTimer.Start();
        }

        private void buttonMouseOnChanges(Button button) { button.FlatAppearance.BorderColor = Color.CornflowerBlue; }
        private void buttonMouseOffChanges(Button button) { button.FlatAppearance.BorderColor = Color.White; }

        private void buttonCloseMouseOnChanges(Button button) { button.FlatAppearance.BorderColor = Color.White; button.FlatAppearance.BorderSize = 1; }
        private void buttonCloseMouseOffChanges(Button button) { button.FlatAppearance.BorderSize = 0; }

        private void btnDeleteActiveSummonerData_MouseEnter(object sender, EventArgs e) { buttonMouseOnChanges(btnDeleteActiveSummonerData); }
        private void btnDeleteActiveSummonerData_MouseHover(object sender, EventArgs e) { buttonMouseOnChanges(btnDeleteActiveSummonerData); }
        private void btnDeleteActiveSummonerData_MouseLeave(object sender, EventArgs e) { buttonMouseOffChanges(btnDeleteActiveSummonerData); }

        private void btnUpdate_MouseEnter(object sender, EventArgs e) { buttonMouseOnChanges(btnUpdate); }
        private void btnUpdate_MouseHover(object sender, EventArgs e) { buttonMouseOnChanges(btnUpdate); }
        private void btnUpdate_MouseLeave(object sender, EventArgs e) { buttonMouseOffChanges(btnUpdate); }

        private void btnScanSummonerName_MouseEnter(object sender, EventArgs e) { buttonMouseOnChanges(btnScanSummonerName); }
        private void btnScanSummonerName_MouseHover(object sender, EventArgs e) { buttonMouseOnChanges(btnScanSummonerName); }
        private void btnScanSummonerName_MouseLeave(object sender, EventArgs e) { buttonMouseOffChanges(btnScanSummonerName); }

        private void btnSetNewSummoner_MouseEnter(object sender, EventArgs e) { buttonMouseOnChanges(btnSetNewSummoner); }
        private void btnSetNewSummoner_MouseHover(object sender, EventArgs e) { buttonMouseOnChanges(btnSetNewSummoner); }
        private void btnSetNewSummoner_MouseLeave(object sender, EventArgs e) { buttonMouseOffChanges(btnSetNewSummoner); }

        private void btnSetApiKey_MouseEnter(object sender, EventArgs e) { buttonMouseOnChanges(btnSetApiKey); }
        private void btnSetApiKey_MouseHover(object sender, EventArgs e) { buttonMouseOnChanges(btnSetApiKey); }
        private void btnSetApiKey_MouseLeave(object sender, EventArgs e) { buttonMouseOffChanges(btnSetApiKey); }

        private void btnSetLoLCleintL_MouseEnter(object sender, EventArgs e) { buttonMouseOnChanges(btnSetLoLCleintL); }
        private void btnSetLoLCleintL_MouseHover(object sender, EventArgs e) { buttonMouseOnChanges(btnSetLoLCleintL); }
        private void btnSetLoLCleintL_MouseLeave(object sender, EventArgs e) { buttonMouseOffChanges(btnSetLoLCleintL); }

        private void btnCloseOptions_MouseEnter(object sender, EventArgs e) { buttonCloseMouseOnChanges(btnCloseOptions); }
        private void btnCloseOptions_MouseHover(object sender, EventArgs e) { buttonCloseMouseOnChanges(btnCloseOptions); }
        private void btnCloseOptions_MouseLeave(object sender, EventArgs e) { buttonCloseMouseOffChanges(btnCloseOptions); }
    }
}
