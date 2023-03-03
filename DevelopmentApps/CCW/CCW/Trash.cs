using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOS
{
    internal class Trash
    {
        // first oldCrop
        private Image cropImage(Image img, int leftRight, int topBottom)
        {
            int newWidth = 35;
            int newHeight = 50;
            Rectangle cropArea = new Rectangle(leftRight, topBottom, newWidth, newHeight);
            var bmp = (Bitmap)img;
            Bitmap bmpCrop = bmp.Clone(cropArea, img.PixelFormat);
            return bmpCrop;
        }

        //old relevant data capture info (in case OCR is needed/implemented)

        /* capture index description
         ...
         * 3 - name tag top right
         * 4 - play/party top left
         ...
         */

        /*
        private static Bitmap cropImageRec(Bitmap b, int pointX, int pointY, int captureIndex)
        {
            int width, height;
            switch (captureIndex)
            {
                case 3: { width = 185; height = 25; } break;
                case 4: { width = 100; height = 30; } break;
            }
            Bitmap bmpCrop = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmpCrop))
            {
                g.DrawImage(b, -pointX, -pointY);
                return bmpCrop;
            }
        }*/
    }
}
