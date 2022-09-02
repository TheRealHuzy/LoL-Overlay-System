namespace LOS
{
    internal class ImageDataPoolInstance
    {
        public int position;
        public ImageData imageData;

        public ImageDataPoolInstance(int position, ImageData imageData)
        {
            this.imageData = imageData;
            this.position = position;
        }
    }
}
