using Emgu.CV;
using Emgu.CV.Structure;

namespace LOS
{
    [Serializable]
    internal class ImageData
    {
        public string champtionName;
        public Image<Bgr, byte> emguImage;
        public Image<Bgr, byte> emguImageSmall;

        public ImageData(string champtionName, Image<Bgr, byte> emguImage, Image<Bgr, byte> emguImageSmall)
        {
            this.champtionName = champtionName;
            this.emguImage = emguImage;
            this.emguImageSmall = emguImageSmall;
        }
    }
}
