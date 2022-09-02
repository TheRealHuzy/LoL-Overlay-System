namespace LOS
{
    internal class ImageDataPool
    {
        private int maxNumber = 15;
        private int currentNumber = 0;
        public List<ImageDataPoolInstance> imageQueue;

        public ImageDataPool()
        {
            imageQueue = new List<ImageDataPoolInstance>();
        }

        public void addToPool(ImageDataPoolInstance idpi)
        {
            if (currentNumber >= maxNumber) removeFirstEnterance();
            imageQueue.Add(idpi);
            currentNumber++;
        }

        public void removeFirstEnterance()
        {
            imageQueue.RemoveAt(0);
            currentNumber--;
        }
        public void customClear()
        {
            imageQueue.Clear();
            currentNumber = 0;
        }
    }
}
