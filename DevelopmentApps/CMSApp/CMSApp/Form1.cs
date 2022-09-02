using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using RiotSharp;

namespace CMSApp
{
    public partial class Form1 : Form
    {
        Bitmap bitmap1 = null;
        Bitmap bitmap2 = null;
        Image<Bgr, byte> ImageMain = null;
        Image<Bgr, byte> ImageSearch = null;
        Image<Bgr, byte> NewMainImage = null;
        Image<Bgr, byte> ImageTemp = null;
        List<ImageClass> imageList = new List<ImageClass>();
        List<ImageClass> imageListTop = new List<ImageClass>();
        List<ImageClass> imageListM = new List<ImageClass>();
        List<ImageClass> imageListTopM = new List<ImageClass>();
        List<ImageClass> imageListS = new List<ImageClass>();
        List<ImageClass> imageListTopS = new List<ImageClass>();
        Point[] maxLocationsGlobal;

        public Form1()
        {
            InitializeComponent();

            var apikey = "APIKey goes here";
            var api = RiotApi.GetDevelopmentInstance(apikey);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            imageList = getAllImagesInsideAFile(@"X:\1LolSplash\img\champion\");
            imageListTop = getAllImagesInsideAFile(@"X:\1LolSplash\img\champion\championTop\");
            imageListM = getAllImagesInsideAFile(@"X:\1LolSplash\img\champion\MChampion\");
            imageListTopM = getAllImagesInsideAFile(@"X:\1LolSplash\img\champion\MChampionTop\");
            imageListS = getAllImagesInsideAFile(@"X:\1LolSplash\img\champion\SChampion\");
            imageListTopS = getAllImagesInsideAFile(@"X:\1LolSplash\img\champion\SChampionTop\");
        }

        private List<ImageClass> getAllImagesInsideAFile(string filePath)
        {
            List<ImageClass> imageList = new List<ImageClass>();
            string[] filePaths = Directory.GetFiles(filePath, "*.png");

            foreach (string st in filePaths)
            {
                string nameToList = Path.GetFileName(st);
                Image<Bgr, Byte> imageToList = new Image<Bgr, byte>(st);
                ImageClass imageClass = new ImageClass(nameToList, imageToList);
                imageList.Add(imageClass);
            }
            return imageList;
        }

        private int getRBGPercetage()
        {
            int imageInfo2 = getImageRGBInfo(bitmap1);
            int imageInfo1 = getImageRGBInfo(bitmap2);
            txtbxPic1.Text = imageInfo1.ToString();
            txtbxPic2.Text = imageInfo2.ToString();
            return imageInfo1;
        }

        private int getImageRGBInfo(Bitmap bitmap)
        {
            int imageInfo = 0;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int pixel = bitmap.GetPixel(i, j).ToArgb();
                    imageInfo = +pixel;
                }
            }
            return imageInfo;
        }

        private void btnBrowsePic1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                bitmap1 = new Bitmap(open.FileName);
                ImageMain = new Image<Bgr, byte>(open.FileName);
                NewMainImage = ImageMain.Copy();
                pictureBox1.Image = bitmap1;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnBrowsePic2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                bitmap2 = new Bitmap(open.FileName);
                ImageSearch = new Image<Bgr, byte>(open.FileName);
                pictureBox2.Image = bitmap2;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnShowSimilarity_Click(object sender, EventArgs e)
        {
            if (ImageMain == null || ImageSearch == null) MessageBox.Show("Select two images!");
            else {
                getRBGPercetage();
                double retur = findImageInImage();
                drawFoundImage(retur);
            }
        }

        private double findImageInImage()
        {
            double retur = 0;
            using (Image<Gray, float> result = ImageMain.MatchTemplate(ImageSearch, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                retur = maxValues[0];
                maxLocationsGlobal = maxLocations;

                txtbxCertainty.Text = (maxValues[0] * 100).ToString().Substring(0, 5) + " %";
            }

            float Threshold = 0.5f;
            Image<Gray, float> Matches = ImageMain.MatchTemplate(ImageSearch, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
            double sum = 0;
            int numOf = 0;
            for (int y = 0; y < Matches.Data.GetLength(0); y++)
            {
                for (int x = 0; x < Matches.Data.GetLength(1); x++)
                {
                    if (Matches.Data[y, x, 0] >= Threshold)
                    {
                        sum =+ Matches.Data[y, x, 0];
                        numOf++;
                    }
                }
            }
            if (sum == 0) txtbxSimilarity.Text = "";
            else txtbxSimilarity.Text = (sum/numOf*100).ToString().Substring(0,5) + " %";

            return retur;
        }

        private void drawFoundImage(double retur)
        {
            Bitmap BitmapShow = NewMainImage.ToBitmap();
            pictureBox3.Image = BitmapShow;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            if (retur > 0.1)
            {
                Rectangle match = new Rectangle(maxLocationsGlobal[0], ImageSearch.Size);
                NewMainImage.Draw(match, new Bgr(Color.Red), 1);
            }
        }

        private void btnSwitchPic_Click(object sender, EventArgs e)
        {
            if (ImageSearch == null && ImageMain == null) MessageBox.Show("Select images to swap!");
            else
            {
                Bitmap temp;
                if (ImageMain == null)
                {
                    bitmap1 = bitmap2;
                    bitmap2 = null;
                }
                else if (ImageSearch == null)
                {
                    bitmap2 = bitmap1;
                    bitmap1 = null;
                }
                else
                {
                    temp = new Bitmap(bitmap2);
                    bitmap2 = bitmap1;
                    bitmap1 = temp;
                }
                ImageTemp = ImageMain;
                ImageMain = ImageSearch;
                ImageSearch = ImageTemp;

                pictureBox1.Image = bitmap1;
                pictureBox2.Image = bitmap2;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btxRemovePoints_Click(object sender, EventArgs e)
        {
            NewMainImage = ImageMain.Copy();
            Bitmap BitmapShow = NewMainImage.ToBitmap();
            pictureBox3.Image = BitmapShow;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnFindMatch_Click(object sender, EventArgs e)
        {
            standardButtonSearchOperation(imageList);
        }
        private void btnFindMatchTop_Click(object sender, EventArgs e)
        {
            standardButtonSearchOperation(imageListTop);
        }

        private void btnFindMatchM_Click(object sender, EventArgs e)
        {
            standardButtonSearchOperation(imageListM);
        }
        private void btnFindMatchTopM_Click(object sender, EventArgs e)
        {
            standardButtonSearchOperation(imageListTopM);
        }

        private void btnFindMatchS_Click(object sender, EventArgs e)
        {
            standardButtonSearchOperation(imageListS);
        }
        private void btnFindMatchTopS_Click(object sender, EventArgs e)
        {
            standardButtonSearchOperation(imageListTopS);
        }

        private void standardButtonSearchOperation(List<ImageClass> imageList)
        {
            if (ImageSearch == null) MessageBox.Show("Select second image!");
            else
            {
                double match = 0;
                double result;
                Image<Bgr, byte> image = null;
                foreach (ImageClass ic in imageList)
                {
                    ImageMain = ic.EmguCVInfo;
                    result = findImageInImage();
                    if (result > match)
                    {
                        match = result;
                        image = ImageMain;
                    }
                }
                if (image != null)
                {
                    ImageMain = image;
                    NewMainImage = image.Copy();
                    Bitmap BitmapShow = image.ToBitmap();
                    bitmap1 = BitmapShow;
                    pictureBox1.Image = BitmapShow;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    txtbxCertainty.Text = (match * 100).ToString().Substring(0, 5) + " %";
                }
            }
        }
    }
}