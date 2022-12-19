using System.Drawing;

namespace MergeImageApp
{
    internal class ImageClass
    {
        public string fileName;
        public Bitmap picture;

        public ImageClass(string fileName, Bitmap picture)
        {
            this.fileName = fileName;
            this.picture = picture;
        }
    }
}
