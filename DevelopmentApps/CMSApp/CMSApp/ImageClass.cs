using Emgu.CV;
using Emgu.CV.Structure;

namespace CMSApp
{
    internal class ImageClass
    {
        public string fileName;
        public Image<Bgr, byte> EmguCVInfo;

        public ImageClass(string fileName, Image<Bgr, byte> EmguCVInfo)
        {
            this.fileName = fileName;
            this.EmguCVInfo = EmguCVInfo;
        }
    }
}
