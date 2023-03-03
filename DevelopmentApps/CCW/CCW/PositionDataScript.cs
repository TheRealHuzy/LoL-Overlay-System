using System.Drawing;
namespace LOS
{
    internal class PositionDataScript
    {
        public List<PositionData> RunScript()
        {
            List<PositionData> positionData = new List<PositionData>();
            positionData.Add(new PositionData());
            positionData.Add(new PositionData());
            positionData.Add(new PositionData());

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            /*  pdc - position data cut
             *  pdd - position data draw
             *  pdp - position data progressbar
             *  900/720/576 - resolution height
             *  S - sideItem
             *  T - topItem
             *  Sn - sideNumber
             *  Sc - sideChest
             *  
             *  # Cutting has been carefully and thoroughly checked and tested
             *  # !DO NOT! make changes without a backup
             */
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>CUTTING>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdc900S = positionData[0].cuttingPosition.side;
            // height and width are separated because they were not the same in the 1st version
            pdc900S.width = 27; //pdc900S.width = 49; //start 25
            pdc900S.height = 49;
            pdc900S.permanentCoordinate = 82;

            int pdc900SStartPoint = 144;
            int pdc900SDynDistance = 100;
            pdc900S.dynamicCoordinates = addToListFromStartNIntervalTimes(pdc900S.dynamicCoordinates, pdc900SStartPoint, pdc900SDynDistance, 5);

            var pdc900T = positionData[0].cuttingPosition.top;

            pdc900T.heightNWidth = 52; //old 55
            pdc900T.permanentCoordinate = 16;

            int pdc900TStartPoint = 442;
            int pdc900TDynDistance = 74; //start 73
            pdc900T.dynamicCoordinates = addSPECIALToListFromSINT(pdc900T.dynamicCoordinates, pdc900TStartPoint, pdc900TDynDistance, 10);

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdc720S = positionData[1].cuttingPosition.side;

            pdc720S.width = get720ApproximationFrom900(pdc900S.width);
            pdc720S.height = get720ApproximationFrom900(pdc900S.height);
            pdc720S.permanentCoordinate = get720ApproximationFrom900(pdc900S.permanentCoordinate);

            foreach (var item in pdc900S.dynamicCoordinates)
            {
                pdc720S.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            var pdc720T = positionData[1].cuttingPosition.top;

            pdc720T.heightNWidth = get720ApproximationFrom900(pdc900T.heightNWidth);
            pdc720T.permanentCoordinate = get720ApproximationFrom900(pdc900T.permanentCoordinate);

            foreach (var item in pdc900T.dynamicCoordinates)
            {
                pdc720T.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdc576S = positionData[2].cuttingPosition.side;

            pdc576S.width = get576ApproximationFrom900(pdc900S.width);
            pdc576S.height = get576ApproximationFrom900(pdc900S.height);
            pdc576S.permanentCoordinate = get576ApproximationFrom900(pdc900S.permanentCoordinate);

            foreach (var item in pdc900S.dynamicCoordinates)
            {
                pdc576S.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            var pdc576T = positionData[2].cuttingPosition.top;

            pdc576T.heightNWidth = get576ApproximationFrom900(pdc900T.heightNWidth);
            pdc576T.permanentCoordinate = get576ApproximationFrom900(pdc900T.permanentCoordinate);

            foreach (var item in pdc900T.dynamicCoordinates)
            {
                pdc576T.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>DRAWING>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdd900Sn = positionData[0].drawingPosition.side.numberDrawInfo;

            pdd900Sn.heightNWidth = 40;
            pdd900Sn.permanentCoordinate = 124;
            int pdd900SnStartPoint = 164;
            int pddSDynDistance = 100;
            pdd900Sn.dynamicCoordinates = addToListFromStartNIntervalTimes(pdd900Sn.dynamicCoordinates, pdd900SnStartPoint, pddSDynDistance, 5);

            var pdd900Sc = positionData[0].drawingPosition.side.chestDrawInfo;

            pdd900Sc.heightNWidth = 25;
            pdd900Sc.permanentCoordinate = 61;
            int pdd900ScStartPoint = 127;
            pdd900Sc.dynamicCoordinates = addToListFromStartNIntervalTimes(pdd900Sc.dynamicCoordinates, pdd900ScStartPoint, pddSDynDistance, 5);

            var pdd900Tn = positionData[0].drawingPosition.top.numberDrawInfo;

            pdd900Tn.heightNWidth = 30;
            pdd900Tn.permanentCoordinate = 56;
            int pdd900TnStartPoint = 476;
            int pddTDynDistance = 73;
            pdd900Tn.dynamicCoordinates = addSPECIALToListFromSINT(pdd900Tn.dynamicCoordinates, pdd900TnStartPoint, pddTDynDistance, 10);

            var pdd900Tc = positionData[0].drawingPosition.top.chestDrawInfo;

            pdd900Tc.heightNWidth = 25;
            pdd900Tc.permanentCoordinate = 6;
            int pdd900TcStartPoint = 431;
            pdd900Tc.dynamicCoordinates = addSPECIALToListFromSINT(pdd900Tc.dynamicCoordinates, pdd900TcStartPoint, pddTDynDistance, 10);

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdd720Sn = positionData[1].drawingPosition.side.numberDrawInfo;
             
            pdd720Sn.heightNWidth = get720ApproximationFrom900(pdd900Sn.heightNWidth);
            pdd720Sn.permanentCoordinate = get720ApproximationFrom900(pdd900Sn.permanentCoordinate);

            foreach (var item in pdd900Sn.dynamicCoordinates)
            {
                pdd720Sn.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            var pdd720Sc = positionData[1].drawingPosition.side.chestDrawInfo;

            pdd720Sc.heightNWidth = get720ApproximationFrom900(pdd900Sc.heightNWidth);
            pdd720Sc.permanentCoordinate = get720ApproximationFrom900(pdd900Sc.permanentCoordinate);

            foreach (var item in pdd900Sc.dynamicCoordinates)
            {
                pdd720Sc.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            var pdd720Tn = positionData[1].drawingPosition.top.numberDrawInfo;

            pdd720Tn.heightNWidth = get720ApproximationFrom900(30);
            pdd720Tn.permanentCoordinate = get720ApproximationFrom900(56);

            foreach (var item in pdd900Tn.dynamicCoordinates)
            {
                pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            var pdd720Tc = positionData[1].drawingPosition.top.chestDrawInfo;

            pdd720Tc.heightNWidth = get720ApproximationFrom900(25);
            pdd720Tc.permanentCoordinate = get720ApproximationFrom900(6);

            foreach (var item in pdd900Tc.dynamicCoordinates)
            {
                pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdd576Sn = positionData[2].drawingPosition.side.numberDrawInfo;

            pdd576Sn.heightNWidth = get576ApproximationFrom900(pdd900Sn.heightNWidth);
            pdd576Sn.permanentCoordinate = get576ApproximationFrom900(pdd900Sn.permanentCoordinate);

            foreach (var item in pdd900Sn.dynamicCoordinates)
            {
                pdd576Sn.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            var pdd576Sc = positionData[2].drawingPosition.side.chestDrawInfo;

            pdd576Sc.heightNWidth = get576ApproximationFrom900(pdd900Sc.heightNWidth);
            pdd576Sc.permanentCoordinate = get576ApproximationFrom900(pdd900Sc.permanentCoordinate);

            foreach (var item in pdd900Sc.dynamicCoordinates)
            {
                pdd576Sc.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            var pdd576Tn = positionData[2].drawingPosition.top.numberDrawInfo;

            pdd576Tn.heightNWidth = get576ApproximationFrom900(pdd900Tn.heightNWidth);
            pdd576Tn.permanentCoordinate = get576ApproximationFrom900(pdd900Tn.permanentCoordinate);

            foreach (var item in pdd900Tn.dynamicCoordinates)
            {
                pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            var pdd576Tc = positionData[2].drawingPosition.top.chestDrawInfo;

            pdd576Tc.heightNWidth = get576ApproximationFrom900(pdd900Tc.heightNWidth);
            pdd576Tc.permanentCoordinate = get576ApproximationFrom900(pdd900Tc.permanentCoordinate);

            foreach (var item in pdd900Tc.dynamicCoordinates)
            {
                pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>PROGRESS BAR>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>SIDE>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdp900S = positionData[0].progressBarPosition.side;

            pdp900S.width = 90;
            pdp900S.height = 4;

            pdp900S.permanentCoordinate = 64;

            pdp900S.dynamicCoordinates = addToListFromStartNIntervalTimes(pdp900S.dynamicCoordinates, 211, pddSDynDistance, 5);

            var pdp720S = positionData[1].progressBarPosition.side;

            pdp720S.width = get720ApproximationFrom900(pdp900S.width);
            pdp720S.height = get720ApproximationFrom900(pdp900S.height);
            pdp720S.permanentCoordinate = get720ApproximationFrom900(pdp900S.permanentCoordinate);

            foreach (var item in pdp900S.dynamicCoordinates)
            {
                pdp720S.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            var pdp576S = positionData[2].progressBarPosition.side;

            pdp576S.width = get576ApproximationFrom900(pdp900S.width);
            pdp576S.height = get576ApproximationFrom900(pdp900S.height);
            pdp576S.permanentCoordinate = get576ApproximationFrom900(pdp900S.permanentCoordinate);

            foreach (var item in pdp900S.dynamicCoordinates)
            {
                pdp576S.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>TOP>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdp900T = positionData[0].progressBarPosition.top;

            pdp900T.width = 65;
            pdp900T.height = 3;

            pdp900T.permanentCoordinate = 90;

            pdp900T.dynamicCoordinates = addSPECIALToListFromSINT(pdp900T.dynamicCoordinates, 438, pddTDynDistance, 10);

            var pdp720T = positionData[1].progressBarPosition.top;

            pdp720T.width = get720ApproximationFrom900(pdp900T.width);
            pdp720T.height = get720ApproximationFrom900(pdp900T.height);
            pdp720T.permanentCoordinate = get720ApproximationFrom900(pdp900T.permanentCoordinate);

            foreach (var item in pdp900T.dynamicCoordinates)
            {
                pdp720T.dynamicCoordinates.Add(get720ApproximationFrom900(item));
            }

            var pdp576T = positionData[2].progressBarPosition.top;

            pdp576T.width = get576ApproximationFrom900(pdp900T.width);
            pdp576T.height = get576ApproximationFrom900(pdp900T.height);
            pdp576T.permanentCoordinate = get576ApproximationFrom900(pdp900T.permanentCoordinate);

            foreach (var item in pdp900T.dynamicCoordinates)
            {
                pdp576T.dynamicCoordinates.Add(get576ApproximationFrom900(item));
            }

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            Serializer serializer = new Serializer();
            serializer.SerializeBin(positionData, "positionData.hz");

            return positionData;
            
        }

        private List<int> addToListFromStartNIntervalTimes(List<int> list, int first, int interval, int times)
        {
            for (int i = 0; i < times; i++) list.Add(first + interval * i);
            return list;
        }

        /*  top pictures in lol client are not same sized
         *  size below is for resolution 1600x900  
         *  size of pictures >> 3 2 3 3 2  3 3 2 3 3  >> +60px
         *  size of gaps     >>  1 1 0 1  1 0 1 1 0   >> +10px
         *  together         >> 74 73 73 74 73 73 74 73 73 63 << last one excludes gap because of the end
        */
        private List<int> addSPECIALToListFromSINT(List<int> list, int first, int interval, int times)
        {
            for (int i = 0; i < times; i++)
            {
                if ((i+1)%3 == 0) list.Add(first + interval * i + 1);
                else list.Add(first + interval * i);
            }
            return list;
        }

        //1600 -> 1280 (X?)
        private int get720ApproximationFrom900(int numToAprox) { return Convert.ToInt32(Math.Round((decimal)numToAprox * 4 / 5)); }
        //1600 -> 1024 (X?)
        private int get576ApproximationFrom900(int numToAprox) { return Convert.ToInt32(Math.Round((decimal)numToAprox * 16 / 25)); }
    }
}


/* before LoL version 12.23.1 ; release date 7.12.2022.
*
    pdc900S
    width = 25;height = 50;
    permanentCoordinate = 88;
    dynamicCoordinates = [150, 250, 350, 450, 550];

    pdc900T
    heightNWidth = 55;
    permanentCoordinate = 16;
    dynamicCoordinates = [442, 515, 588, 662, 736, 809, 884, 956, 1030, 1104];

    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    pdc720S
    width = 18;height = 42;
    permanentCoordinate = 70;
    dynamicCoordinates = [113, 193, 273, 354, 434];

    pdc720T
    heightNWidth = 44;
    permanentCoordinate = 13;
    dynamicCoordinates = [355, 413, 472, 530, 589, 648, 706, 765, 824, 882];

    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

    pdc576S
    width = 15;
    height = 33;
    permanentCoordinate = 55;
    dynamicCoordinates = [91, 156, 219, 284, 347];

    pdc576T
    heightNWidth = 34;
    permanentCoordinate = 11;
    dynamicCoordinates = [284, 331, 378, 425, 472, 518, 566, 613, 659, 706];
*   
*/

/* before LoL version 13.4 ; release date 23.02.2023.

    pdc900S
    width = 49;
    height = 49;
    permanentCoordinate = 82;
    dynamicCoordinateStartPoint = 144;
    dynamicDistance = 100;

    pdc900T
    heightNWidth = 55;
    permanentCoordinate = 16;
    dynamicCoordinateStartPoint = 442;
    dynamicCoordinates = 73

    >> the rest is generated from this information

 */