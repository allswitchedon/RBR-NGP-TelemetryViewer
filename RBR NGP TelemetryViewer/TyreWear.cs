using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    internal class TyreWear
    {
        static List<List<double>> LFTireWear = new List<List<double>>();
        static List<List<double>> RFTireWear = new List<List<double>>();
        static List<List<double>> LBTireWear = new List<List<double>>();
        static List<List<double>> RBTireWear = new List<List<double>>();

        static public List<double> LFAverageWear = new List<double>();
        static public List<double> RFAverageWear = new List<double>();
        static public List<double> LBAverageWear = new List<double>();
        static public List<double> RBAverageWear = new List<double>();
         
        static public List<double> LFSegmentWear = new List<double>();
        static public List<double> RFSegmentWear = new List<double>();
        static public List<double> LBSegmentWear = new List<double>();
        static public List<double> RBSegmentWear = new List<double>();

        static List<double> LF_currentTyreSegment = new List<double>();
        static List<double> RF_currentTyreSegment = new List<double>();
        static List<double> LB_currentTyreSegment = new List<double>();
        static List<double> RB_currentTyreSegment = new List<double>();

        public static void Calculate(List<List<double>> telemetrydata, List<string> columnsname)
        {
            Task[] find_task = new Task[4];
            find_task[0] = Task.Run(() =>
            {
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[0]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[1]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[2]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[3]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[4]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[5]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[6]".Equals)]);
                LFTireWear.Add(telemetrydata[columnsname.FindIndex("LF.wear[7]".Equals)]);
                LF_currentTyreSegment = telemetrydata[columnsname.FindIndex("LF.currentTyreSegment".Equals)];
            });
            find_task[1] = Task.Run(() =>
            {
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[0]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[1]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[2]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[3]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[4]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[5]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[6]".Equals)]);
                RFTireWear.Add(telemetrydata[columnsname.FindIndex("RF.wear[7]".Equals)]);
                RF_currentTyreSegment = telemetrydata[columnsname.FindIndex("LF.currentTyreSegment".Equals)];
            });

            find_task[2] = Task.Run(() =>
            {
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[0]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[1]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[2]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[3]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[4]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[5]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[6]".Equals)]);
                LBTireWear.Add(telemetrydata[columnsname.FindIndex("LB.wear[7]".Equals)]);
                LB_currentTyreSegment = telemetrydata[columnsname.FindIndex("LF.currentTyreSegment".Equals)];
            });

            find_task[3] = Task.Run(() =>
            {
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[0]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[1]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[2]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[3]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[4]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[5]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[6]".Equals)]);
                RBTireWear.Add(telemetrydata[columnsname.FindIndex("RB.wear[7]".Equals)]);
                RB_currentTyreSegment = telemetrydata[columnsname.FindIndex("LF.currentTyreSegment".Equals)];
            });

            Task.WaitAll(find_task);

            Task[] calc_task = new Task[4];
            calc_task[0] = Task.Run(() =>
            {
                for (int i = 0; i < LF_currentTyreSegment.Count(); i++)
                {
                    double LFWearSum = 0;
                    for (int lf = 0; lf <= 7; lf++)
                    {
                        LFWearSum += LFTireWear[lf][i];
                    }
                    LFAverageWear.Add(LFWearSum / 8 * 100);
                    LFSegmentWear.Add(LFTireWear[(int)LF_currentTyreSegment[i]][i] * 100);
                }
            });
            calc_task[1] = Task.Run(() =>
            {
                for (int i = 0; i < RF_currentTyreSegment.Count(); i++)
                {
                    double RFWearSum = 0;
                    for (int rf = 0; rf <= 7; rf++)
                    {
                        RFWearSum += LFTireWear[rf][i];
                    }
                    RFAverageWear.Add(RFWearSum / 8 * 100);
                    RFSegmentWear.Add(RFTireWear[(int)RF_currentTyreSegment[i]][i] * 100);
                }
            });
            calc_task[2] = Task.Run(() =>
            {
                for (int i = 0; i < LB_currentTyreSegment.Count(); i++)
                {
                    double LBWearSum = 0;
                    for (int lb = 0; lb <= 7; lb++)
                    {
                        LBWearSum += LBTireWear[lb][i];
                    }
                    LBAverageWear.Add(LBWearSum / 8 * 100);
                    LBSegmentWear.Add(LBTireWear[(int)LB_currentTyreSegment[i]][i] * 100);
                }
            });
            calc_task[3] = Task.Run(() =>
            {
                for (int i = 0; i < RB_currentTyreSegment.Count(); i++)
                {
                    double RBWearSum = 0;
                    for (int rb = 0; rb <= 7; rb++)
                    {
                        RBWearSum += LBTireWear[rb][i];
                    }
                    RBAverageWear.Add(RBWearSum / 8 * 100);
                    RBSegmentWear.Add(RBTireWear[(int)RB_currentTyreSegment[i]][i] * 100);
                }
            });

            Task.WaitAll(calc_task);
            

        }

        public static void Clear()
        {
            LFTireWear.Clear();
            RFTireWear.Clear();
            LBTireWear.Clear();
            RBTireWear.Clear();

            LFAverageWear.Clear();
            RFAverageWear.Clear();
            LBAverageWear.Clear();
            RBAverageWear.Clear();

            LFSegmentWear.Clear();
            RFSegmentWear.Clear();
            LBSegmentWear.Clear();
            RBSegmentWear.Clear();

        }
    }
}
