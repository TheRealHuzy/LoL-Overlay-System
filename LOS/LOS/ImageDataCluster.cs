namespace LOS
{
    internal class ImageDataCluster
    {
        public List<ImageData> imageData900;
        public List<ImageData> imageData720;
        public List<ImageData> imageData576;

        public ImageDataCluster()
        {
            imageData900 = new List<ImageData>();
            imageData720 = new List<ImageData>();
            imageData576 = new List<ImageData>();
        }
    }
}
