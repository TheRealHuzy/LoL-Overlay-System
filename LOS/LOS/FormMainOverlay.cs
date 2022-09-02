using Emgu.CV;
using Emgu.CV.Structure;
using IronOcr;
using RiotSharp;
using ScreenShotDemo;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using Timer = System.Windows.Forms.Timer;

namespace LOS
{
    public partial class FormMainOverlay : Form
    {
        string tempLolVersion = null;
        bool apiErrorOccurence = false;
        bool errorOccured = false;
        bool changedVersion = false;

        List<ImageData> imageData;
        List<ChampionData> championData;
        List<PictureBoxData> pictureBoxes = new List<PictureBoxData>();

        //overlay
        IntPtr handle;
        WindowsAPI.Rect rect;
        List<Bitmap> numbers = new List<Bitmap>();
        Bitmap chestImage;

        //capture
        ScreenCapture sc = new ScreenCapture();
        Image img;
        List<Bitmap> pics = new List<Bitmap>(new Bitmap[15]);

        //imagecomparison
        List<string> foundChampionNames = new List<string>(new string[15]);

        //pausing overlay worker
        ManualResetEvent MRESuspendEvent = new ManualResetEvent(true);
        ManualResetEvent MRESuspendEventManual = new ManualResetEvent(true);
        public bool backgroundWorkerPaused;

        //get basic data information
        BasicData basicData;
        public RiotApi api;

        //show options after loading
        FormOptionsNExit optionsNExit;

        //for findling lol client
        Process process;

        //crashProof
        public bool inSetup = true;
        bool foundAPIError = false;
        AuxFormLoading loadingForm;

        //optimize find image
        ImageDataPool imageDataPool = new ImageDataPool();

        //fixing stuck images after pause
        Timer cleanerTimer = new Timer();

        //resolution scaling
        /* 1600x900 >> 0
         * 1280x720 >> 1
         * 1024x576 >> 2
         */
        private int resIndex;
        List<PositionData> positionData = new List<PositionData>();
        public bool critical = false;

        public FormMainOverlay(FormOptionsNExit optionsNExit)
        {
            InitializeComponent();
            this.optionsNExit = optionsNExit;
            cleanerTimer.Interval = 500;
            cleanerTimer.Tick += clearPictureBoxes;
        }
        int numOfTimes = 0;
        private void clearPictureBoxes(object sender, EventArgs e)
        {
            foreach (var obj in pictureBoxes)
            {
                obj.numberPictureBox.Image = null;
                obj.chestPictureBox.Image = null;
            }
            numOfTimes++;
            if (numOfTimes > 4)
            {
                numOfTimes = 0;
                cleanerTimer.Stop();
            }
            if (!paused)
            {
                numOfTimes = 0;
                cleanerTimer.Stop();
            }
        }

        private void MainOverlay_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Text = GlobalContainer.Main.thisApplicationName;
            this.BackColor = Color.AliceBlue;
            this.TransparencyKey = Color.AliceBlue;

            loadingForm = new AuxFormLoading();
            Task.Run(threadStartLoadingForm);

            handle = WindowsAPI.FindWindow(null, GlobalContainer.Main.windowName);

            importNumbersNChestPictures();

            api = null;
            Serializer serializer = new Serializer();

            basicData = (BasicData)serializer.DeserializeJSON(GlobalContainer.NamesNPaths.FullNames.baseData);
            if (basicData == null)
            {
                basicData = new BasicData();
                basicData.apiKey = getApiKey("");
            }
            if (basicData.apiKey == null) setupTerminateApplication();

            api = createRiotSharpAPIInstance();
            
            getVersion(api, basicData); //version does not require a valid api key so thats why it works with invalid one
            if (errorOccured)
            {
                AuxFormInfoMessageBox imb = new AuxFormInfoMessageBox(GlobalContainer.Messages.riotAPIBasicError);
                imb.ShowDialog();
                imb.Dispose();
                setupTerminateApplication();
                return;
            }

            string summonerName = "";
            string summonerId = "";
            bool summonerExists = false;
            if (basicData.summonerData.Count == 0)
            {
                basicData.defaultSummoner = getSummonerName("");
                summonerName = basicData.defaultSummoner;
            }
            else
            {
                summonerName = basicData.defaultSummoner;
                foreach (SummonerData sd in basicData.summonerData)
                {
                    if (sd.summonerName == summonerName)
                    {
                        summonerExists = true;
                        summonerId = sd.summonerId;
                        break;
                    }
                }
            }
            if (!summonerExists)
            {
                if (getEncryptedId(api, summonerName))
                {
                    summonerId = basicData.summonerData[basicData.summonerData.Count - 1].summonerId;
                }
                else { setupTerminateApplication(); return; }
            }

            championData = (List<ChampionData>)serializer.DeserializeBin(GlobalContainer.NamesNPaths.PartialNames.championData + summonerName + GlobalContainer.NamesNPaths.Extentions.myFiles);
            if (changedVersion || championData == null)
            {
                try {
                    championData = getChampionData(api, basicData.version);
                } catch
                {
                    AuxFormInfoMessageBox imb = new AuxFormInfoMessageBox(GlobalContainer.Messages.riotAPIBasicError);
                    imb.ShowDialog();
                    imb.Dispose();
                    setupTerminateApplication();
                    return;
                }
            }

            WindowsAPI.GetWindowRect(handle, out rect);
            int setupOverlayWidth = rect.right - rect.left;
            int setupOverlayHeight = rect.bottom - rect.top;

            setResolutionIndex(setupOverlayHeight);

            imageData = (List<ImageData>)serializer.DeserializeBin(GlobalContainer.NamesNPaths.PartialNames.imageData + setupOverlayHeight + GlobalContainer.NamesNPaths.Extentions.myFiles);
            if (changedVersion || imageData == null)
            {
                try
                {
                    SetupFormLoadingBar loadingBar = new SetupFormLoadingBar(championData.Count);
                    loadingBar.Show();

                    ImageDataCluster imageCluster = getImagesFromNet(championData, loadingBar);

                    loadingBar.Close();

                    switch (resIndex)
                    {
                        case 0: imageData = imageCluster.imageData900; break;
                        case 1: imageData = imageCluster.imageData720; break;
                        case 2: imageData = imageCluster.imageData576; break;
                    }
                    serializer.SerializeBin(imageCluster.imageData900, GlobalContainer.NamesNPaths.FullNames.SetupSerilizeImageData.res900);
                    serializer.SerializeBin(imageCluster.imageData720, GlobalContainer.NamesNPaths.FullNames.SetupSerilizeImageData.res720);
                    serializer.SerializeBin(imageCluster.imageData576, GlobalContainer.NamesNPaths.FullNames.SetupSerilizeImageData.res576);
                }
                catch
                {
                    AuxFormInfoMessageBox imb = new AuxFormInfoMessageBox(GlobalContainer.Messages.communityDragonError);
                    imb.ShowDialog();
                    imb.Dispose();
                    setupTerminateApplication();
                    return;
                }
            }
            // Position data generation based on 1600x900 location data
            /* 
            PositionDataScript pds = new PositionDataScript();
            positionData = pds.RunScript();
            serializer.SerializeBin(positionData, "positionData.hz");
            positionData = (List<PositionData>) serializer.DeserializeBin("positionData.hz");
            */

            addPictureBoxesToList();

            positionData = (List<PositionData>)serializer.DeserializeBin(GlobalContainer.NamesNPaths.FullNames.positionData);
            setPictureBoxesPositionNSize();
            setOverlayMessagePosition();

            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.baseData);
            
            if (getMasteryNChestInfo(api, basicData, championData, summonerId))
            {
                serializer.SerializeBin(championData, GlobalContainer.NamesNPaths.PartialNames.championData + summonerName + GlobalContainer.NamesNPaths.Extentions.myFiles);
            }
            else { if (basicData.summonerData.Count < 1) setupTerminateApplication(); return; }
            
            CheckForIllegalCrossThreadCalls = false;
            int initialStyle = WindowsAPI.GetWindowLong(this.Handle, -20);
            WindowsAPI.SetWindowLong(this.Handle, -20, initialStyle | 0x8000 | 0x20);

            this.Size = new Size(setupOverlayWidth, setupOverlayHeight);

            inSetup = false;

            threadExitLoadingForm();
            optionsNExit.startTimer();

            backgroundWorker1.RunWorkerAsync(); //placement follows league client
            backgroundWorker2.RunWorkerAsync(); //finding data with images
            //backgroundWorker3.RunWorkerAsync(); //viewing if the champion select is displayed
            backgroundWorker4.RunWorkerAsync(); //closing if league client is closed
        }

        private void threadStartLoadingForm()
        {
            loadingForm.ShowDialog();
        }
        private void threadExitLoadingForm()
        {
            loadingForm.Close();
        }
        private void importNumbersNChestPictures()
        {
            Bitmap bitmap;
            string path = Directory.GetCurrentDirectory();
            string newPath = Path.GetFullPath(Path.Combine(path, GlobalContainer.NamesNPaths.Paths.graphicDataPath));
            for (int i = 0; i < 10; i++)
            {
                bitmap = new Bitmap(newPath + i + GlobalContainer.NamesNPaths.Extentions.numberPic);
                numbers.Add(bitmap);
            }
            chestImage = new Bitmap(newPath + GlobalContainer.NamesNPaths.FullNames.picChest);
        }

        private string getApiKey(string api)
        {
            SetupFormEnterApiKey enterApiKey = new SetupFormEnterApiKey(api);
            enterApiKey.ShowDialog();
            enterApiKey.Dispose();
            return enterApiKey.returnValue;
        }
        public RiotApi createRiotSharpAPIInstance()
        {
            return RiotApi.GetDevelopmentInstance(basicData.apiKey);
        }
        private void getVersion(RiotApi api, BasicData basicData)
        {
            if (tempLolVersion == null) tempLolVersion = getLolVersion(api);
            if (tempLolVersion.Contains("."))
            {
                if (basicData.version != tempLolVersion)
                {
                    basicData.version = tempLolVersion;
                    changedVersion = true;
                }
            }
            else
            {
                int errorCode = Int32.Parse(tempLolVersion);
                switch (errorCode)
                {
                    case 403:
                        {
                            if (!apiErrorOccurence)
                            {
                                apiErrorOccurence = true;
                                basicData.apiKey = getApiKey("");
                                getVersion(api, basicData);
                            }
                            else { errorOccured = true; return; }
                            break;
                        }
                    default:
                        errorOccured = true;
                        return;
                }
            }
        }
        private string getLolVersion(RiotApi api)
        {
            try
            {
                return api.StaticData.Versions.GetAllAsync().Result[0];
            }
            catch (RiotSharpException ex)
            {
                return ex.HttpStatusCode.ToString();
            }
        }

        private List<ChampionData> getChampionData(RiotApi api, string version)
        {
            List<ChampionData> championData = new List<ChampionData>();
            try
            {
                var champions = api.StaticData.Champions.GetAllAsync(version).Result;
                foreach (var champion in champions.Champions)
                {
                    championData.Add(new ChampionData(champion.Value.Id, champion.Value.Name));
                }
            }
            catch (RiotSharpException ex)
            {
            }
            return championData;
        }

        private ImageDataCluster getImagesFromNet(List<ChampionData> championData, SetupFormLoadingBar loadingBar)
        {
            string netPath4Icons = GlobalContainer.Main.communityDragonPicturesWebAddress;
            ImageDataCluster imageCluster = new ImageDataCluster();

            for (int i = 0; i < championData.Count; i++)
            {
                WebRequest request = WebRequest.Create(netPath4Icons + championData[i].id + ".png");
                using (var response = request.GetResponse())
                {
                    using (var str = response.GetResponseStream())
                    {
                        Image image = (Bitmap)Bitmap.FromStream(str);

                        Image<Bgr, byte> newImageSide900 = downscaleImage(image, GlobalContainer.Measures.DownScale.sideImage900);
                        Image<Bgr, byte> newImageTop900 = downscaleImage(image, GlobalContainer.Measures.DownScale.topImage900);
                        Image<Bgr, byte> newImageSide720 = downscaleImage(image, GlobalContainer.Measures.DownScale.sideImage720);
                        Image<Bgr, byte> newImageTop720 = downscaleImage(image, GlobalContainer.Measures.DownScale.topImage720);
                        Image<Bgr, byte> newImageSide579 = downscaleImage(image, GlobalContainer.Measures.DownScale.sideImage576);
                        Image<Bgr, byte> newImageTop579 = downscaleImage(image, GlobalContainer.Measures.DownScale.topImage576);

                        imageCluster.imageData900.Add(new ImageData(championData[i].name, newImageSide900, newImageTop900));
                        imageCluster.imageData720.Add(new ImageData(championData[i].name, newImageSide720, newImageTop720));
                        imageCluster.imageData576.Add(new ImageData(championData[i].name, newImageSide579, newImageTop579));
                        
                        image.Dispose();
                    }
                }
                loadingBar.incrementProgressBar();
            }
            return imageCluster;
        }
        private Image<Bgr, byte> downscaleImage(Image image, int resolution)
        {
            var rect = new Rectangle(0, 0, resolution, resolution);
            var output = new Bitmap(resolution, resolution);
            output.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var gr = Graphics.FromImage(output))
            {
                gr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    gr.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return output.ToImage<Bgr, byte>();
        }

        private string getSummonerName(string name)
        {
            string summonerName;
            string OCRResult = OCRSummonerName();
            if (OCRResult.CompareTo("") != 0)
            {
                summonerName = OCRResult;
            } else
            {
                SetupFormEnterSummonerName enterSummonerName = new SetupFormEnterSummonerName(name);
                enterSummonerName.ShowDialog();
                summonerName = enterSummonerName.returnValue;
            }
            return summonerName;
        }
        private string OCRSummonerName()
        {
            try
            {
                Image img = sc.CaptureWindow(handle);
                img = cropImageRec((Bitmap)img, 1410, 35, 3);
                return new IronTesseract().Read(img).Text;
            } catch (Exception e)
            {
                return "";
            }
        }

        private bool getEncryptedId(RiotApi api, string summonerName)
        {
            try
            {
                var summoner = api.Summoner.GetSummonerByNameAsync(RiotSharp.Misc.Region.Eune, summonerName).Result;
                basicData.summonerData.Add(new SummonerData(summoner.Id, summoner.Name));
            }
            catch (Exception e)
            {
                int result = runInfoNoSummonerFound();
                switch (result)
                {
                    case 1: getEncryptedId(api, summonerName); break;
                    case 2: if (inSetup) return false;
                        else foundAPIError = true; break;
                    case 3: basicData.defaultSummoner = getSummonerName(basicData.defaultSummoner);
                        getEncryptedId(api, basicData.defaultSummoner);
                        break;
                    case 4: basicData.apiKey = getApiKey(basicData.apiKey);
                        this.api = createRiotSharpAPIInstance();
                        getEncryptedId(this.api, summonerName);
                        break;
                }
            }
            return true;
        }
        /* 1 - retry
         * 2 - exit
         * 3 - enter summoner name
         * 4 - enter api key
         */
        private int runInfoNoSummonerFound()
        {
            AuxFormInfoNoSummonerFound infoNoSummonerFound = new AuxFormInfoNoSummonerFound(basicData.defaultSummoner, basicData.apiKey);
            infoNoSummonerFound.ShowDialog();
            return infoNoSummonerFound.returnValue;
        }

        private bool getMasteryNChestInfo(RiotApi api, BasicData basicData, List<ChampionData> championData, string summonerId)
        {
            try
            {
                var championMasteryInfo = api.ChampionMastery.GetChampionMasteriesAsync(RiotSharp.Misc.Region.Eune, summonerId).Result;
                foreach (var item in championMasteryInfo)
                {
                    foreach (var cData in championData)
                    {
                        if (cData.id == item.ChampionId)
                        {
                            cData.level = item.ChampionLevel;
                            cData.chestAquired = item.ChestGranted;
                            break;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                if (inSetup)
                {
                    AuxFormWarningMessageBox apiCouldBeInvalid = new AuxFormWarningMessageBox(GlobalContainer.Warnings.invalidAPIError, "Yes", "No");
                    apiCouldBeInvalid.ShowDialog();
                    if (apiCouldBeInvalid.returnValue == 1)
                    {
                        SetupFormEnterApiKey enterApiKey = new SetupFormEnterApiKey(GlobalContainer.PlaceholderMessages.invalidAPI, true);
                        enterApiKey.ShowDialog();
                        this.basicData.apiKey = enterApiKey.returnValue;
                        enterApiKey.Dispose();
                        this.api = createRiotSharpAPIInstance();
                        serilizeBasicData();
                        return getMasteryNChestInfo(this.api, basicData, championData, summonerId);
                    } else
                    {
                        APIErrorMessage();
                        return false;
                    }
                    apiCouldBeInvalid.Dispose();
                }
                else
                {
                    APIErrorMessage();
                    return false;
                }
            }
        }
        public void serilizeBasicData()
        {
            Serializer serializer = new Serializer();
            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.baseData);
        }
        private void APIErrorMessage()
        {
            AuxFormInfoMessageBox imb = new AuxFormInfoMessageBox(GlobalContainer.Messages.riotAPIchampionMasteryError);
            imb.ShowDialog();
            imb.Dispose();
        }

        private void addPictureBoxesToList()
        {
            pictureBoxes.AddRange(new List<PictureBoxData>
            {
                new PictureBoxData(pictureBox1, pbxChest1),
                new PictureBoxData(pictureBox2, pbxChest2),
                new PictureBoxData(pictureBox3, pbxChest3),
                new PictureBoxData(pictureBox4, pbxChest4),
                new PictureBoxData(pictureBox5, pbxChest5),
                new PictureBoxData(pictureBox6, pbxChest6),
                new PictureBoxData(pictureBox7, pbxChest7),
                new PictureBoxData(pictureBox8, pbxChest8),
                new PictureBoxData(pictureBox9, pbxChest9),
                new PictureBoxData(pictureBox10, pbxChest10),
                new PictureBoxData(pictureBox11, pbxChest11),
                new PictureBoxData(pictureBox12, pbxChest12),
                new PictureBoxData(pictureBox13, pbxChest13),
                new PictureBoxData(pictureBox14, pbxChest14),
                new PictureBoxData(pictureBox15, pbxChest15)
            });
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

        private void setPictureBoxesPositionNSize()
        {
            int i = 0;
            ChestNumberContainer container;

            foreach (var pb in pictureBoxes)
            {
                if (i < 5)
                {
                    container = positionData[resIndex].drawingPosition.side;
                    pb.numberPictureBox.Location = new Point(container.numberDrawInfo.permanentCoordinate, container.numberDrawInfo.getNextDynamicCoordinate());
                    pb.chestPictureBox.Location = new Point(container.chestDrawInfo.permanentCoordinate, container.chestDrawInfo.getNextDynamicCoordinate());
                }
                else
                {
                    container = positionData[resIndex].drawingPosition.top;
                    pb.numberPictureBox.Location = new Point(container.numberDrawInfo.getNextDynamicCoordinate(), container.numberDrawInfo.permanentCoordinate);
                    pb.chestPictureBox.Location = new Point(container.chestDrawInfo.getNextDynamicCoordinate(), container.chestDrawInfo.permanentCoordinate);
                }

                pb.numberPictureBox.Width = container.numberDrawInfo.heightNWidth;
                pb.numberPictureBox.Height = container.numberDrawInfo.heightNWidth;

                pb.chestPictureBox.Width = container.chestDrawInfo.heightNWidth;
                pb.chestPictureBox.Height = container.chestDrawInfo.heightNWidth;

                i++;
            }
        }
        private void setOverlayMessagePosition()
        {
            WindowsAPI.GetWindowRect(handle, out rect);
            int currentResolutionHeight = rect.bottom - rect.top;
            lblOverlayStatus.Location = new Point(8, currentResolutionHeight - 23);
        }

        private void setupTerminateApplication()
        {
            loadingForm.Close();
            if (basicData.summonerData.Count < 1)
            {
                if (File.Exists(GlobalContainer.NamesNPaths.FullNames.baseData)) File.Delete(GlobalContainer.NamesNPaths.FullNames.baseData);
                if (File.Exists(GlobalContainer.NamesNPaths.FullNames.tempBaseData)) File.Delete(GlobalContainer.NamesNPaths.FullNames.tempBaseData);
            }
            Application.Exit();
            return;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                WindowsAPI.GetWindowRect(handle, out rect);
                this.Size = new Size(rect.right - rect.left, rect.bottom - rect.top);
                this.Top = rect.top;
                this.Left = rect.left;
                Thread.Sleep(1);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap bitmap = null;
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

                findMatches();
                this.Invoke(drawOverlay);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(1);
            }
        }
        /* capture index description
         * 1 - side picture
         * 2 - top picture
         * 3 - name tag top right
         * 4 - play/party top left / champions available
         */
        private Bitmap cropImageRec(Bitmap b, int pointX, int pointY, int captureIndex)
        {
            int width, height;
            
            switch (captureIndex)
            {
                case 1: { width = positionData[resIndex].cuttingPosition.side.width; height = positionData[resIndex].cuttingPosition.side.height; } break;
                case 2: { width = positionData[resIndex].cuttingPosition.top.heightNWidth; height = positionData[resIndex].cuttingPosition.top.heightNWidth; } break;
                case 3: { width = 185; height = 25; } break;    //must be changed for other resolutions if OCRbg works
                case 4: { width = 100; height = 30; } break;
                default: { width = GlobalContainer.Measures.Capture.cropWSideImage576; height = GlobalContainer.Measures.Capture.cropHSideImage576; } break;
            }
            Bitmap bmpCrop = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmpCrop))
            {
                g.DrawImage(b, -pointX, -pointY);
                return bmpCrop;
            }
        }
        double defaultMatch = GlobalContainer.Main.pictureMatchMinimumPercentageValue;
        private void findMatches()
        {
            foundChampionNames.Clear();
            int i = 0;
            foreach (Bitmap b in pics)
            {
                if (i > 5 && foundChampionNames[i - 1] == "None")
                {
                    foundChampionNames = addTheRestNONEToList(foundChampionNames);
                    return;
                }

                Image<Bgr, byte> emguImage = b.ToImage<Bgr, byte>();
                double match = defaultMatch, result = 0;
                string championName = "None";

                ImageDataPoolInstance foundChampion;

                if (imageDataPool.imageQueue.Count > 0)
                {
                    foundChampion = null;
                    for (int j = imageDataPool.imageQueue.Count - 1; j >= 0; j--)
                    {
                        if (imageDataPool.imageQueue[j].position == i) {
                            foundChampion = imageDataPool.imageQueue[j]; break;
                        }
                    }
                    if (foundChampion != null)
                    {
                        if (i < 5) result = findImageInImage(foundChampion.imageData.emguImage, emguImage);
                        else result = findImageInImage(foundChampion.imageData.emguImageSmall, emguImage);
                        if (result > match)
                        {
                            championName = foundChampion.imageData.champtionName;
                        }
                    }
                    if (championName == "None") {
                        foreach (var item in imageDataPool.imageQueue)
                        {
                            if (i < 5) result = findImageInImage(item.imageData.emguImage, emguImage);
                            else result = findImageInImage(item.imageData.emguImageSmall, emguImage);
                            if (result > match)
                            {
                                match = result;
                                championName = item.imageData.champtionName;
                                item.position = i;
                            }
                        }
                        match = defaultMatch;
                    }
                }
                if (championName == "None")
                {
                    ImageData imageDataToAdd = null;
                    foreach (ImageData id in imageData)
                    {
                        if (i < 5) result = findImageInImage(id.emguImage, emguImage);
                        else result = findImageInImage(id.emguImageSmall, emguImage);
                        if (result > match)
                        {
                            match = result;
                            championName = id.champtionName;
                            imageDataToAdd = id;
                        }
                    }
                    if (imageDataToAdd != null) imageDataPool.addToPool(new ImageDataPoolInstance(i, imageDataToAdd));
                }
                i++;
                foundChampionNames.Add(championName);
            }
        }
        private double findImageInImage(Image<Bgr, byte> imageMain, Image<Bgr, byte> imageSearch)
        {
            double retur = 0;
            using (Image<Gray, float> result = imageMain.MatchTemplate(imageSearch, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                retur = maxValues[0];
            }
            return retur;
        }
        private List<string> addTheRestNONEToList(List<string> championNameList)
        {
            while (championNameList.Count != 15)
            {
                championNameList.Add("None");
            }
            return championNameList;
        }
        private void drawOverlay()
        {
            int i = 0;
            foreach (string name in foundChampionNames)
            {
                bool noneMissing = false;
                if (name == "None") {
                    pictureBoxes[i].numberPictureBox.Image = null;
                    pictureBoxes[i].chestPictureBox.Image = null;
                    i++;
                    continue;
                }
                noneMissing = true;
                foreach (ChampionData cd in championData)
                {
                    if (name == cd.name)
                    {
                        pictureBoxes[i].numberPictureBox.Image = numbers[Convert.ToInt32(cd.level)];
                        if (cd.chestAquired == false) pictureBoxes[i].chestPictureBox.Image = chestImage;
                        else pictureBoxes[i].chestPictureBox.Image = null;
                        break;
                    }
                }
                if (noneMissing) i++;
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorkerPaused = false;
            while (true)
            {
                MRESuspendEventManual.WaitOne(Timeout.Infinite);

                Image img = sc.CaptureWindow(handle);
                img = cropImageRec((Bitmap)img, 300, 20, 4);    //needs change for all resolution support
                //img = cropImageRec((Bitmap)img, 105, 35, 4);  //play/pause data
                string result = "";
                try { result = new IronTesseract().Read(img).Text; }
                catch { }

                img.Dispose();
                if (result.CompareTo(GlobalContainer.OCR.ARAMGameMode) == 0)
                {
                    if (backgroundWorkerPaused) { backgroundWorkerPaused = false; resumeOverlayBackgroundWorker(); }
                }
                else
                {
                    if (!backgroundWorkerPaused) { backgroundWorkerPaused = true; pauseOverlayBackgroundWorker(false); }
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                Thread.Sleep(500);
            }
        }
        bool paused = false;
        public void pauseOverlayBackgroundWorker(bool calledManually)
        {
            MRESuspendEvent.Reset();
            lblOverlayStatus.Text = GlobalContainer.OverlayStatus.STANDBY;
            paused = true;
            if (calledManually) cleanerTimer.Start();
        }
        public void resumeOverlayBackgroundWorker()
        {
            lblOverlayStatus.Text = GlobalContainer.OverlayStatus.ON;
            MRESuspendEvent.Set();
            paused = false;
        }
        public void pauseAutoDetectBackgroundWorker(bool calledManually)
        {
            MRESuspendEventManual.Reset();
            pauseOverlayBackgroundWorker(calledManually);
            backgroundWorkerPaused = true;
            lblOverlayStatus.Text = GlobalContainer.OverlayStatus.OFF;
        }
        public void resumeAutoDetectBackgroundWorker()
        {
            imageDataPool.customClear();
            MRESuspendEventManual.Set();
            lblOverlayStatus.Text = GlobalContainer.OverlayStatus.STANDBY;
            backgroundWorkerPaused = false;
            resumeOverlayBackgroundWorker();
        }


        public void setThisBasicData(BasicData basicData)
        {
            this.basicData = basicData;
        }
        public BasicData getThisBasicData()
        {
            return basicData;
        }

        public bool getNewSummonerInfo(string summonerName)
        {
            Serializer serializer = new Serializer();
            string summonerId = "";
            getEncryptedId(api, summonerName);
            if (foundAPIError)
            {
                foundAPIError = false;
                return false;
            }
            summonerId = basicData.summonerData[basicData.summonerData.Count - 1].summonerId;

            basicData.defaultSummoner = summonerName;
            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.baseData);

            foreach (var champion in championData)
            {
                champion.level = 0;
                champion.chestAquired = false;
            }
            if (getMasteryNChestInfo(api, basicData, championData, summonerId))
            {
                serializer.SerializeBin(championData, GlobalContainer.NamesNPaths.PartialNames.championData + summonerName + GlobalContainer.NamesNPaths.Extentions.myFiles);
                return true;
            }
            return false;
        }

        public bool checkIfSummonerMasteryDataExists(string summonerName)
        {
            foreach (SummonerData sd in basicData.summonerData)
            {
                if (sd.summonerName == summonerName)
                {
                    return true;
                }
            }
            return false;
        }

        public void loadChampionData(string summonerName)
        {
            Serializer serializer = new Serializer();
            basicData.defaultSummoner = summonerName;
            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.baseData);
            championData = (List<ChampionData>)serializer.DeserializeBin(GlobalContainer.NamesNPaths.PartialNames.championData + summonerName + GlobalContainer.NamesNPaths.Extentions.myFiles);
        }

        public bool callGetMasteryUpdated()
        {
            Serializer serializer = new Serializer();
            string summonerName = basicData.defaultSummoner;
            string summonerId = "";
            foreach (var summoner in basicData.summonerData)
            {
                if (summoner.summonerName == summonerName)
                {
                    summonerId = summoner.summonerId;
                    break;
                }
            }
            if (summonerId.CompareTo("") != 0)
                if (getMasteryNChestInfo(api, basicData, championData, summonerId))
                {
                    serializer.SerializeBin(championData, GlobalContainer.NamesNPaths.PartialNames.championData + summonerName + GlobalContainer.NamesNPaths.Extentions.myFiles);
                    return true;
                }
            return false;
        }

        public void callDeleteActiveSummonerData(string summonerName)
        {
            Serializer serializer = new Serializer();
            foreach (var item in basicData.summonerData) if (item.summonerName == summonerName) { basicData.summonerData.Remove(item); break; }
            if (basicData.summonerData.Count > 0)
            {
                string newDefaultSummoner = basicData.summonerData[0].summonerName;
                basicData.defaultSummoner = newDefaultSummoner;
                championData = (List<ChampionData>)serializer.DeserializeBin(GlobalContainer.NamesNPaths.PartialNames.championData + newDefaultSummoner + GlobalContainer.NamesNPaths.Extentions.myFiles);
            }
            else championData.Clear();
            serializer.SerializeJSON(basicData, GlobalContainer.NamesNPaths.FullNames.baseData);
            File.Delete(GlobalContainer.NamesNPaths.PartialNames.championData + summonerName + GlobalContainer.NamesNPaths.Extentions.myFiles);
        }

        public void updateOpacityUpTimer(object sender, EventArgs e)
        {
            this.Opacity += GlobalContainer.Main.loadUpOpacityChangePerInterval;
            if (this.Opacity == 100)
            {
                opacityUpLoadTimer.Stop();
            }
        }

        public void importNSetNewImageNPositionData(int newHeight, int newWidth)
        {
            Serializer serializer = new Serializer();
            imageData = (List<ImageData>) serializer.DeserializeBin(GlobalContainer.NamesNPaths.PartialNames.imageData + newHeight + GlobalContainer.NamesNPaths.Extentions.myFiles);
            setResolutionIndex(newHeight);
            setOverlayMessagePosition();
            setPictureBoxesPositionNSize();
        }
        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName(GlobalContainer.Main.processName);
            if (processes.Length > 0)
            {
                process = processes[0];
                process.WaitForExit();
                Application.Exit();
            }
            return;
        }
    }
}
