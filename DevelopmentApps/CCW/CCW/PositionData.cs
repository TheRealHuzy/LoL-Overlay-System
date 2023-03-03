namespace LOS
{
    [Serializable]
    internal class PositionData
    {
        public CuttingPositionData cuttingPosition;
        public DrawingPositionData drawingPosition;
        public BasicDrawTopSideContainer progressBarPosition;
        public PositionData()
        {
            cuttingPosition = new CuttingPositionData();
            drawingPosition = new DrawingPositionData();
            progressBarPosition = new BasicDrawTopSideContainer();
        }
    }
    [Serializable]
    internal class CuttingPositionData
    {
        public LocDataContainer side;
        public LocSameHWDataContainer top;
        public CuttingPositionData()
        {
            side = new LocDataContainer();
            top = new LocSameHWDataContainer();
        }
    }
    [Serializable]
    internal class DrawingPositionData
    {
        public ChestNumberContainer side;
        public ChestNumberContainer top;
        public DrawingPositionData()
        {
            side = new ChestNumberContainer();
            top = new ChestNumberContainer();
        }
    }
    [Serializable]
    internal class ChestNumberContainer
    {
        public LocSameHWDataContainer chestDrawInfo;
        public LocSameHWDataContainer numberDrawInfo;
        public ChestNumberContainer()
        {
            chestDrawInfo = new LocSameHWDataContainer();
            numberDrawInfo = new LocSameHWDataContainer();
        }
    }

    [Serializable]
    internal class BasicDrawTopSideContainer
    {
        public LocDataContainer side;
        public LocDataContainer top;
        public BasicDrawTopSideContainer()
        {
            side = new LocDataContainer();
            top = new LocDataContainer();
        }
    }

    /* side location : permanent X : dynamic Y
     *  top location : permanent Y : dynamic X
     */
    [Serializable]
    internal class LocDataContainer
    {
        public int height;
        public int width;
        public int permanentCoordinate;
        public List<int> dynamicCoordinates;
        private int i = 0;

        public LocDataContainer()
        {
            dynamicCoordinates = new List<int>();
        }

        public int getNextDynamicCoordinate()
        {
            if (i == dynamicCoordinates.Count) i = 0;
            int temp = i;
            i++;
            return dynamicCoordinates[temp];
        }
    }
    [Serializable]
    internal class LocSameHWDataContainer
    {
        public int heightNWidth;
        public int permanentCoordinate;
        public List<int> dynamicCoordinates;
        private int i = 0;

        public LocSameHWDataContainer()
        {
            dynamicCoordinates = new List<int>();
        }
        public int getNextDynamicCoordinate()
        {
            if (i == dynamicCoordinates.Count) i = 0;
            int temp = i;
            i++;
            return dynamicCoordinates[temp];
        }
    }
}
