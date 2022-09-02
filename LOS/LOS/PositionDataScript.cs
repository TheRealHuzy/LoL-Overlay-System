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

            var pdc900S = positionData[0].cuttingPosition.side;

            pdc900S.width = 25;
            pdc900S.height = 50;

            pdc900S.permanentCoordinate = 88;
            pdc900S.dynamicCoordinates.Add(150);
            pdc900S.dynamicCoordinates.Add(250);
            pdc900S.dynamicCoordinates.Add(350);
            pdc900S.dynamicCoordinates.Add(450);
            pdc900S.dynamicCoordinates.Add(550);

            var pdc900T = positionData[0].cuttingPosition.top;

            pdc900T.heightNWidth = 55;

            pdc900T.permanentCoordinate = 16;
            pdc900T.dynamicCoordinates.Add(442);
            pdc900T.dynamicCoordinates.Add(515);
            pdc900T.dynamicCoordinates.Add(588);
            pdc900T.dynamicCoordinates.Add(662);
            pdc900T.dynamicCoordinates.Add(736);

            pdc900T.dynamicCoordinates.Add(809);
            pdc900T.dynamicCoordinates.Add(884);
            pdc900T.dynamicCoordinates.Add(956);
            pdc900T.dynamicCoordinates.Add(1030);
            pdc900T.dynamicCoordinates.Add(1104);

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdc720S = positionData[1].cuttingPosition.side;

            pdc720S.width = 18;
            pdc720S.height = 42;

            pdc720S.permanentCoordinate = 70;
            pdc720S.dynamicCoordinates.Add(113);
            pdc720S.dynamicCoordinates.Add(193);
            pdc720S.dynamicCoordinates.Add(273);
            pdc720S.dynamicCoordinates.Add(354);
            pdc720S.dynamicCoordinates.Add(434);

            var pdc720T = positionData[1].cuttingPosition.top;

            pdc720T.heightNWidth = 44;

            pdc720T.permanentCoordinate = 13;
            pdc720T.dynamicCoordinates.Add(355);
            pdc720T.dynamicCoordinates.Add(413);
            pdc720T.dynamicCoordinates.Add(472);
            pdc720T.dynamicCoordinates.Add(530);
            pdc720T.dynamicCoordinates.Add(589);

            pdc720T.dynamicCoordinates.Add(648);
            pdc720T.dynamicCoordinates.Add(706);
            pdc720T.dynamicCoordinates.Add(765);
            pdc720T.dynamicCoordinates.Add(824);
            pdc720T.dynamicCoordinates.Add(882);

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdc576S = positionData[2].cuttingPosition.side;

            pdc576S.width = 15;
            pdc576S.height = 33;

            pdc576S.permanentCoordinate = 55;
            pdc576S.dynamicCoordinates.Add(91);
            pdc576S.dynamicCoordinates.Add(156);
            pdc576S.dynamicCoordinates.Add(219);
            pdc576S.dynamicCoordinates.Add(284);
            pdc576S.dynamicCoordinates.Add(347);

            var pdc576T = positionData[2].cuttingPosition.top;

            pdc576T.heightNWidth = 34;

            pdc576T.permanentCoordinate = 11;
            pdc576T.dynamicCoordinates.Add(284);
            pdc576T.dynamicCoordinates.Add(331);
            pdc576T.dynamicCoordinates.Add(378);
            pdc576T.dynamicCoordinates.Add(425);
            pdc576T.dynamicCoordinates.Add(472);

            pdc576T.dynamicCoordinates.Add(518);
            pdc576T.dynamicCoordinates.Add(566);
            pdc576T.dynamicCoordinates.Add(613);
            pdc576T.dynamicCoordinates.Add(659);
            pdc576T.dynamicCoordinates.Add(706);

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdd900Sn = positionData[0].drawingPosition.side.numberDrawInfo;

            pdd900Sn.heightNWidth = 40;

            pdd900Sn.permanentCoordinate = 124;
            pdd900Sn.dynamicCoordinates.Add(164);
            pdd900Sn.dynamicCoordinates.Add(263);
            pdd900Sn.dynamicCoordinates.Add(362);
            pdd900Sn.dynamicCoordinates.Add(461);
            pdd900Sn.dynamicCoordinates.Add(560);

            var pdd900Sc = positionData[0].drawingPosition.side.chestDrawInfo;

            pdd900Sc.heightNWidth = 25;

            pdd900Sc.permanentCoordinate = 61;
            pdd900Sc.dynamicCoordinates.Add(127);
            pdd900Sc.dynamicCoordinates.Add(226);
            pdd900Sc.dynamicCoordinates.Add(326);
            pdd900Sc.dynamicCoordinates.Add(426);
            pdd900Sc.dynamicCoordinates.Add(526);

            var pdd900Tn = positionData[0].drawingPosition.top.numberDrawInfo;

            pdd900Tn.heightNWidth = 30;

            pdd900Tn.permanentCoordinate = 56;
            pdd900Tn.dynamicCoordinates.Add(476);
            pdd900Tn.dynamicCoordinates.Add(550);
            pdd900Tn.dynamicCoordinates.Add(624);
            pdd900Tn.dynamicCoordinates.Add(698);
            pdd900Tn.dynamicCoordinates.Add(774);

            pdd900Tn.dynamicCoordinates.Add(849);
            pdd900Tn.dynamicCoordinates.Add(921);
            pdd900Tn.dynamicCoordinates.Add(998);
            pdd900Tn.dynamicCoordinates.Add(1074);
            pdd900Tn.dynamicCoordinates.Add(1147);

            var pdd900Tc = positionData[0].drawingPosition.top.chestDrawInfo;

            pdd900Tc.heightNWidth = 25;

            pdd900Tc.permanentCoordinate = 6;
            pdd900Tc.dynamicCoordinates.Add(431);
            pdd900Tc.dynamicCoordinates.Add(507);
            pdd900Tc.dynamicCoordinates.Add(580);
            pdd900Tc.dynamicCoordinates.Add(654);
            pdd900Tc.dynamicCoordinates.Add(727);

            pdd900Tc.dynamicCoordinates.Add(801);
            pdd900Tc.dynamicCoordinates.Add(880);
            pdd900Tc.dynamicCoordinates.Add(953);
            pdd900Tc.dynamicCoordinates.Add(1029);
            pdd900Tc.dynamicCoordinates.Add(1104);

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdd720Sn = positionData[1].drawingPosition.side.numberDrawInfo;
             
            pdd720Sn.heightNWidth = get720ApproximationFrom900(40);

            pdd720Sn.permanentCoordinate = get720ApproximationFrom900(124);
            pdd720Sn.dynamicCoordinates.Add(get720ApproximationFrom900(164));
            pdd720Sn.dynamicCoordinates.Add(get720ApproximationFrom900(263));
            pdd720Sn.dynamicCoordinates.Add(get720ApproximationFrom900(362));
            pdd720Sn.dynamicCoordinates.Add(get720ApproximationFrom900(461));
            pdd720Sn.dynamicCoordinates.Add(get720ApproximationFrom900(560));

            var pdd720Sc = positionData[1].drawingPosition.side.chestDrawInfo;

            pdd720Sc.heightNWidth = get720ApproximationFrom900(25);

            pdd720Sc.permanentCoordinate = get720ApproximationFrom900(61);
            pdd720Sc.dynamicCoordinates.Add(get720ApproximationFrom900(127));
            pdd720Sc.dynamicCoordinates.Add(get720ApproximationFrom900(226));
            pdd720Sc.dynamicCoordinates.Add(get720ApproximationFrom900(326));
            pdd720Sc.dynamicCoordinates.Add(get720ApproximationFrom900(426));
            pdd720Sc.dynamicCoordinates.Add(get720ApproximationFrom900(526));

            var pdd720Tn = positionData[1].drawingPosition.top.numberDrawInfo;

            pdd720Tn.heightNWidth = get720ApproximationFrom900(30);

            pdd720Tn.permanentCoordinate = get720ApproximationFrom900(56);
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(476));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(550));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(624));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(698));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(774));

            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(849));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(921));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(998));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(1074));
            pdd720Tn.dynamicCoordinates.Add(get720ApproximationFrom900(1147));

            var pdd720Tc = positionData[1].drawingPosition.top.chestDrawInfo;

            pdd720Tc.heightNWidth = get720ApproximationFrom900(25);

            pdd720Tc.permanentCoordinate = get720ApproximationFrom900(6);
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(431));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(507));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(580));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(654));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(727));

            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(801));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(880));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(953));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(1029));
            pdd720Tc.dynamicCoordinates.Add(get720ApproximationFrom900(1104));

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            var pdd576Sn = positionData[2].drawingPosition.side.numberDrawInfo;

            pdd576Sn.heightNWidth = get576ApproximationFrom900(40);

            pdd576Sn.permanentCoordinate = get576ApproximationFrom900(124);
            pdd576Sn.dynamicCoordinates.Add(get576ApproximationFrom900(164));
            pdd576Sn.dynamicCoordinates.Add(get576ApproximationFrom900(263));
            pdd576Sn.dynamicCoordinates.Add(get576ApproximationFrom900(362));
            pdd576Sn.dynamicCoordinates.Add(get576ApproximationFrom900(461));
            pdd576Sn.dynamicCoordinates.Add(get576ApproximationFrom900(560));

            var pdd576Sc = positionData[2].drawingPosition.side.chestDrawInfo;

            pdd576Sc.heightNWidth = get576ApproximationFrom900(25);

            pdd576Sc.permanentCoordinate = get576ApproximationFrom900(61);
            pdd576Sc.dynamicCoordinates.Add(get576ApproximationFrom900(127));
            pdd576Sc.dynamicCoordinates.Add(get576ApproximationFrom900(226));
            pdd576Sc.dynamicCoordinates.Add(get576ApproximationFrom900(326));
            pdd576Sc.dynamicCoordinates.Add(get576ApproximationFrom900(426));
            pdd576Sc.dynamicCoordinates.Add(get576ApproximationFrom900(526));

            var pdd576Tn = positionData[2].drawingPosition.top.numberDrawInfo;

            pdd576Tn.heightNWidth = get576ApproximationFrom900(30);

            pdd576Tn.permanentCoordinate = get576ApproximationFrom900(56);
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(476));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(550));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(624));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(698));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(774));

            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(849));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(921));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(998));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(1074));
            pdd576Tn.dynamicCoordinates.Add(get576ApproximationFrom900(1147));

            var pdd576Tc = positionData[2].drawingPosition.top.chestDrawInfo;

            pdd576Tc.heightNWidth = get576ApproximationFrom900(25);

            pdd576Tc.permanentCoordinate = get576ApproximationFrom900(6);
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(431));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(507));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(580));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(654));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(727));

            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(801));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(880));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(953));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(1029));
            pdd576Tc.dynamicCoordinates.Add(get576ApproximationFrom900(1104));

            //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

            //Serializer serializer = new Serializer();
            //serializer.SerializeBin(positionData, "positionData.hz");
            //List<PositionData> testDeserializePositionData = (List<PositionData>) serializer.DeserializeBin("positionData.hz");

            return positionData;
            
        }

        //1600 : 40 = 1280 : X
        public int get720ApproximationFrom900(int numToAprox) { return Convert.ToInt32(Math.Round((decimal)numToAprox * 4 / 5)); }
        //1600 : 40 = 1024 : X
        public int get576ApproximationFrom900(int numToAprox) { return Convert.ToInt32(Math.Round((decimal)numToAprox * 16 / 25)); }
    }
}