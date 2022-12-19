using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace MergeImageApp
{
    public partial class Form1 : Form
    {
        string saveLocationTest = @"X:\1LolSplash\img\champion\mergeAppSaves\";
        string saveLocation = @"X:\1LolSplash\img\champion\mergeAppSaves\pic\";
        string saveLocationM = @"X:\1LolSplash\img\champion\mergeAppSaves\picM\";
        string saveLocationS = @"X:\1LolSplash\img\champion\mergeAppSaves\picS\";
        string importAllImagesLocation = @"X:\1LolSplash\img\champion\";
        string importAllImagesLocationM = @"X:\1LolSplash\img\champion\MChampion\";
        string importAllImagesLocationS = @"X:\1LolSplash\img\champion\SChampion\";
        string image1Name;
        int image1Resolution;

        Bitmap bitmap1 = null;
        Bitmap bitmap2 = null;
        Bitmap bitmap2Initial = null;

        Bitmap merged = null;
        Graphics g = null;

        int x = 0;
        int y = 0;

        int maxResolution = 0;
        int currentResolution = 0;
        bool retainScaleOffset = true;
        bool allowQualityLoss = false;
        bool temp;

        int resizeBigStep = 10;
        int resizeSmallStep = 1;

        float opacity = 1;
        float opacityBigStep;
        float opacitySmallStep;

        EventArgs args;
        List<Button> buttonBoard;
        bool boardEnabled = false;

        List<ImageClass> pictureList;

        public Form1()
        {
            InitializeComponent();
            pb1stPic.SizeMode = PictureBoxSizeMode.Zoom;
            pbFinalPic.SizeMode = PictureBoxSizeMode.Zoom;
            pb2ndPic.SizeMode = PictureBoxSizeMode.Zoom;

            opacityBigStep = (float)Math.Round(0.1, 2);
            opacitySmallStep = (float)Math.Round(0.01, 2);

            args = new EventArgs();
            buttonBoard = new List<Button>();
            createBoard();
            changeControlBoardAccess(false);
        }

        private void btnSetDefault_Click(object sender, EventArgs e)
        {
            //opacity, x, y, resolution in px
            resetAllImage2Stats();
            callDraw();
            setDefaultValues(0.62, 7, 7, 72);
        }
        private void btnSetDefaultM_Click(object sender, EventArgs e)
        {
            resetAllImage2Stats();
            callDraw();
            setDefaultValues(0.58, 6, 6, 58);
        }
        private void btnSetDefaultS_Click(object sender, EventArgs e)
        {
            resetAllImage2Stats();
            callDraw();
            setDefaultValues(0.60, 4, 4, 48);
        }

        private void setDefaultValues(double opacity, int x, int y, int resolution)
        {
            this.opacity = (float)Math.Round(opacity, 2);
            this.x = x;
            this.y = y;
            currentResolution = resolution;

            bitmap2 = rescaleImage(bitmap2, currentResolution);
            bitmap2 = changeOpacity(bitmap2, this.opacity);
            updateSizeStats();
            updateOpacityStats();
            updatePositionStats();

            callDraw();
        }

        private void btnBrowseTop_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                bitmap1 = new Bitmap(open.FileName);
                pb1stPic.Image = bitmap1;

                image1Name = Path.GetFileNameWithoutExtension(open.FileName);
                image1Resolution = bitmap1.Width;

                tbxBackImage.Text = Path.GetFileName(open.FileName);
            }

            merged = new Bitmap(bitmap1.Width, bitmap1.Height, PixelFormat.Format32bppArgb);
            g = Graphics.FromImage(merged);
            g.CompositingMode = CompositingMode.SourceOver;
            
            if (bitmap2 != null) btnMerge_Click(this, args);
        }

        private void btnBrowseBot_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                bitmap2 = new Bitmap(open.FileName);
                pb2ndPic.Image = bitmap2;

                tbxFrontImage.Text = Path.GetFileName(open.FileName);
            }

            int maxTemp = maxResolution;
            maxResolution = bitmap2.Height;
            if (currentResolution == 0) currentResolution = maxResolution;
            else if (retainScaleOffset) currentResolution = maxResolution * currentResolution / maxTemp;
            bitmap2Initial = bitmap2;

            if (bitmap1 != null) btnMerge_Click(this, args);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (bitmap1 == null || bitmap2 == null) return;

            if (!boardEnabled)
            {
                boardEnabled = true;
                changeControlBoardAccess(true);
                resetAllImage2Stats();
            } else
            {
                bitmap2 = rescaleImage(bitmap2, currentResolution);
                bitmap2 = changeOpacity(bitmap2, opacity);
                updateSizeStats();
                updateOpacityStats();
            }
            callDraw();
        }

        private void resetAllImage2Stats()
        {
            x = 0;
            y = 0;
            opacity = 1;
            bitmap2 = rescaleImage(bitmap2Initial, maxResolution);
            currentResolution = maxResolution;
            updatePositionStats();
            updateSizeStats();
            updateOpacityStats();
        }

        private void callDraw()
        {
            g.DrawImage(bitmap1, 0, 0);
            g.DrawImage(bitmap2, x, y);
            pbFinalPic.Image = merged;
        }

        private void btnMoveRight_Click(object sender, EventArgs e) { x++; moveFuntionCall(); }
        private void btnMoveLeft_Click(object sender, EventArgs e) { x--; moveFuntionCall(); }
        private void btnMoveUp_Click(object sender, EventArgs e) { y--; moveFuntionCall(); }
        private void btnMoveDown_Click(object sender, EventArgs e) { y++; moveFuntionCall(); }
        private void moveFuntionCall()
        {
            updatePositionStats();
            callDraw();
        }

        private Bitmap rescaleImage(Image image, int resolution)
        {
            var rect = new Rectangle(0, 0, resolution, resolution);
            var output = new Bitmap(resolution, resolution);
            output.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var gr = Graphics.FromImage(output))
            {
                gr.CompositingMode = CompositingMode.SourceCopy;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    gr.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
                }
            }
            return output;
        }

        private void btnResizeUp_Click(object sender, EventArgs e) { if (resizeCheckHigh(resizeSmallStep)) resizeFunctionCall(resizeSmallStep, true); }
        private void btnResizeDown_Click(object sender, EventArgs e) { if (resizeCheckLow(resizeSmallStep)) resizeFunctionCall(resizeSmallStep, false); }
        private void btnResizeUpMuch_Click(object sender, EventArgs e) { if (resizeCheckHigh(resizeBigStep)) resizeFunctionCall(resizeBigStep, true); }
        private void btnResizeDownMuch_Click(object sender, EventArgs e) { if (resizeCheckLow(resizeBigStep)) resizeFunctionCall(resizeBigStep, false); }
        private bool resizeCheckHigh(int step)
        {
            temp = true;
            if (!allowQualityLoss) temp = currentResolution + step <= maxResolution;
            return temp; 
        }
        private bool resizeCheckLow(int step) { return (currentResolution - step >= 2); }

        private void resizeFunctionCall(int amount, bool enlarge)
        {
            if (enlarge) currentResolution += amount;
            else currentResolution -= amount;
            bitmap2 = rescaleImage(bitmap2Initial, currentResolution);
            bitmap2 = changeOpacity(bitmap2, opacity);
            updateSizeStats();
            callDraw();
        }

        private void updateSizeStats()
        {
            lblSizeDeviation.Text = ((maxResolution-currentResolution)*-1).ToString();
        }
        private void updatePositionStats()
        {
            lblXPositionDeviation.Text = (0 + x).ToString() + " px";
            lblYPositionDeviation.Text = (0 - y).ToString() + " px";
        }
        private void updateOpacityStats()
        {
            lblOpacityPercentage.Text = Math.Round(opacity*100,2).ToString() + "%";
        }

        public Bitmap changeOpacity(Image image, float opacity)
        {
            try
            {
                var rect = new Rectangle(0, 0, image.Width, image.Height);
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                using (Graphics gr = Graphics.FromImage(bmp))
                {
                    ColorMatrix matrix = new ColorMatrix();
                    matrix.Matrix33 = opacity;
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap); 
                    gr.DrawImage(image, rect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void btnOpacityUp_Click(object sender, EventArgs e) { if (opacityCheckHigh(opacityBigStep)) opacityChangeFunctionCall(opacityBigStep, true); }
        private void btnOpacityDown_Click(object sender, EventArgs e) { if (opacityCheckLow(opacityBigStep)) opacityChangeFunctionCall(opacityBigStep, false); }
        private void btnOpacityUpLittle_Click(object sender, EventArgs e) { if (opacityCheckHigh(opacitySmallStep)) opacityChangeFunctionCall(opacitySmallStep, true); }
        private void btnOpacityDownLittle_Click(object sender, EventArgs e) { if (opacityCheckLow(opacitySmallStep)) opacityChangeFunctionCall(opacitySmallStep, false); }

        private bool opacityCheckHigh(float step)
        {
            float midstep = (float)Math.Round(opacity + step,2);
            return (midstep <= 1); 
        }
        private bool opacityCheckLow(float step)
        {
            float midstep = (float)Math.Round(opacity - step, 2);
            return (midstep >= 0);
        }
        private void opacityChangeFunctionCall(float opacityForwarded, bool increase)
        {
            if (increase) opacity = (float)Math.Round(opacity + opacityForwarded, 2);
            else opacity = (float)Math.Round(opacity - opacityForwarded, 2); ;
            bitmap2 = changeOpacity(bitmap2Initial, opacity);
            bitmap2 = rescaleImage(bitmap2, currentResolution);
            updateOpacityStats();
            callDraw();
        }

        private void changeControlBoardAccess(bool enable)
        {
            if (enable) foreach (var item in buttonBoard) item.Enabled = true;
            else foreach (var item in buttonBoard) item.Enabled = false;
        }

        private void createBoard()
        {
            buttonBoard.AddRange(new List<Button> {
                btnMoveDown, btnMoveLeft, btnMoveRight, btnMoveUp,
                btnResizeDown, btnResizeUp, btnResizeDownMuch, btnResizeUpMuch,
                btnOpacityDown, btnOpacityDownLittle, btnOpacityUp, btnOpacityUpLittle,
                btnReset, btnSetDefault, btnSetDefaultM, btnSetDefaultS,
                btnSave, btnSaveAll, btnSaveAllM, btnSaveAllS, btnSaveAllResolutions
            });
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetAllImage2Stats();
            callDraw();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Bitmap saveImage = (Bitmap)pbFinalPic.Image;
            string name = image1Name;
            string resolution = "0X0"; //unrecognized
            string opacity = (Math.Round(this.opacity, 2)*100).ToString();
            string s = ";"; //separator

            switch (image1Resolution)
            {
                case 86: resolution = "900"; break;
                case 70: resolution = "720"; break;
                case 56: resolution = "576"; break;
            }

            saveImage.Save(saveLocationTest + name + "-"
                + resolution + s
                + opacity + "op" + s
                + currentResolution + "px" + s
                + x + "x" + s
                + y*-1 + "y"
                + ".png");
        }

        private void cbxRetainScaleOffset_CheckStateChanged(object sender, EventArgs e)
        {
            if (retainScaleOffset)
            {
                cbxRetainScaleOffset.Checked = false;
                retainScaleOffset = false;
            }
            else
            {
                cbxRetainScaleOffset.Checked = true;
                retainScaleOffset = true;
            }
        }

        private void cbxAllowQualityLoss_CheckStateChanged(object sender, EventArgs e)
        {
            if (allowQualityLoss)
            {
                cbxAllowQualityLoss.Checked = false;
                allowQualityLoss = false;
            }
            else
            {
                cbxAllowQualityLoss.Checked = true;
                allowQualityLoss = true;
            }
        }
        private void btnSaveAll_Click(object sender, EventArgs e) { saveAllWithCurrentSetup(importAllImagesLocation, saveLocation); }
        private void btnSaveAllM_Click(object sender, EventArgs e) { saveAllWithCurrentSetup(importAllImagesLocationM, saveLocationM); }
        private void btnSaveAllS_Click(object sender, EventArgs e) { saveAllWithCurrentSetup(importAllImagesLocationS, saveLocationS); }

        private void btnSaveAllResolutions_Click(object sender, EventArgs e)
        {
            btnSetDefault_Click(sender, e);
            btnSaveAllM_Click(sender, e);
            btnSetDefaultM_Click(sender, e);
            btnSaveAllM_Click(sender, e);
            btnSetDefaultS_Click(sender, e);
            btnSaveAllS_Click(sender, e);
        }
        private void saveAllWithCurrentSetup(string importLocation, string saveLocation)
        {
            pictureList = getAllImagesInsideAFile(importLocation);

            foreach (var item in pictureList)
            {
                merged = new Bitmap(item.picture.Width, item.picture.Height, PixelFormat.Format32bppArgb);
                g = Graphics.FromImage(merged);
                g.CompositingMode = CompositingMode.SourceOver;
                g.DrawImage(item.picture, 0, 0);
                g.DrawImage(bitmap2, x, y);
                item.picture = merged;
                pbFinalPic.Image = merged;
            }

            foreach (var item in pictureList) item.picture.Save(saveLocation + item.fileName + ".png");
        }

        private List<ImageClass> getAllImagesInsideAFile(string filePath)
        {
            List<ImageClass> imageList = new List<ImageClass>();
            string[] filePaths = Directory.GetFiles(filePath, "*.png");

            foreach (string st in filePaths)
            {
                string nameToList = Path.GetFileName(st);
                Bitmap imageToList = new Bitmap(st);
                ImageClass imageClass = new ImageClass(nameToList, imageToList);
                imageList.Add(imageClass);
            }
            return imageList;
        }
    }
}
