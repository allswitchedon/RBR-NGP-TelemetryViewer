using OxyPlot.Axes;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBR_NGP_TelemetryViewer
{
    public partial class Form1 : Form
    {
        List<double> time_diff = new List<double>();
        List<double> distance = new List<double>();
        List<double> position_x_dist = new List<double>();
        List<double> position_y_dist = new List<double>();
        int run = 1;
        double firsttime, secondtime;
        DataTable testvalues = new DataTable();
        double max_speed;
        double max_rpm;
        double racetime;
        int trackleght;

        public FormsPlot[] FormsPlots { get; }

        public Form1()
        {
            InitializeComponent();
            testvalues.Columns.Add(" ");
            testvalues.Rows.Add("Reaction Time");
            testvalues.Rows.Add("Maximum Speed");
            testvalues.Rows.Add("Distance");
            testvalues.Rows.Add("Maximum RPM");
            testvalues.Rows.Add("Open Time");
            testvalues.Rows.Add("Track Leght");
            testvalues.Rows.Add("Visible");
            FormsPlots = new FormsPlot[] { SpeedChart, EngineDataChart, GForcesChart, TimeDiffirenceChart };
            foreach (var fp in FormsPlots)
            {
                fp.AxesChanged += OnAxesChanged;
                fp.Plot.YAxis.SetSizeLimit(min: 35, max: 35);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var starttime = DateTime.Now.Ticks;
            List<string> columnsname = new List<string>();
            List<List<double>> telemetrydata = new List<List<double>>();
            OpenFileDialog selectfile = new OpenFileDialog();
            selectfile.ShowDialog();
            if (File.Exists(selectfile.FileName))
            {
                RBRTelemetryFile.Parse.test(selectfile.FileName);
                columnsname = RBRTelemetryFile.Parse.test1();
                telemetrydata = RBRTelemetryFile.Parse.test2();

                ToDistance.Get.Convert(columnsname, telemetrydata, run);
                distance = ToDistance.Get.distance_int();
                position_x_dist = ToDistance.Get.position_x_dist();
                position_y_dist = ToDistance.Get.position_y_dist();
                time_diff = ToDistance.Get.time_difference();
            }
            else goto End;

            double[] speed = ConvertRawData.Speed(telemetrydata[columnsname.FindIndex("speed".Equals)]);
            double[] driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
            double[] raceTime = telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray();
            double[] engineRotation = telemetrydata[columnsname.FindIndex("engineRotation".Equals)].ToArray();
            double[] position_x = telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray();
            double[] position_y = telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray();
            double[] position_z = telemetrydata[columnsname.FindIndex("position.z".Equals)].ToArray();
            double[] GForce_X = ConvertRawData.Gforces(telemetrydata[columnsname.FindIndex("vecAvgLinearAccelerationCar.x".Equals)]);
            double[] GForce_Y = ConvertRawData.Gforces(telemetrydata[columnsname.FindIndex("vecAvgLinearAccelerationCar.y".Equals)]);
            double[] Speed_X = telemetrydata[columnsname.FindIndex("vecLinearVelocityCar.x".Equals)].ToArray();
            double[] Speed_Y = telemetrydata[columnsname.FindIndex("vecLinearVelocityCar.y".Equals)].ToArray();
            double[] Speed_Z = telemetrydata[columnsname.FindIndex("vecLinearVelocityCar.z".Equals)].ToArray();
            double[] SpeedAdditional_X = telemetrydata[columnsname.FindIndex("vecAngularVelocityCar.x".Equals)].ToArray();
            double[] SpeedAdditional_Y = telemetrydata[columnsname.FindIndex("vecAngularVelocityCar.x".Equals)].ToArray();
            double[] SpeedAdditional_Z = telemetrydata[columnsname.FindIndex("vecAngularVelocityCar.x".Equals)].ToArray();
            double[] Speed_XYZ = new double[driveLineLocation.Length];
            double[] Speed_XYZ2 = new double[driveLineLocation.Length];
            double[] LF_deflectionVelocity = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("LF.deflectionVelocity".Equals)]);
            double[] RF_deflectionVelocity = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("RF.deflectionVelocity".Equals)]);
            double[] LB_deflectionVelocity = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("LB.deflectionVelocity".Equals)]);
            double[] RB_deflectionVelocity = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("RB.deflectionVelocity".Equals)]);

            double[] LF_brakeDiskLayerTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("LF.brakeDiskLayerTemp".Equals)]);
            double[] RF_brakeDiskLayerTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("RF.brakeDiskLayerTemp".Equals)]);
            double[] LB_brakeDiskLayerTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("LB.brakeDiskLayerTemp".Equals)]);
            double[] RB_brakeDiskLayerTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("RB.brakeDiskLayerTemp".Equals)]);

            double[] LF_brakeDiskTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("LF.brakeDiskTemp".Equals)]);
            double[] RF_brakeDiskTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("RF.brakeDiskTemp".Equals)]);
            double[] LB_brakeDiskTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("LB.brakeDiskTemp".Equals)]);
            double[] RB_brakeDiskTemp = ConvertRawData.BrakeTemp(telemetrydata[columnsname.FindIndex("RB.brakeDiskTemp".Equals)]);

            double[] LF_tyreTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("LF.tyreTemperature".Equals)]);
            double[] RF_tyreTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("RF.tyreTemperature".Equals)]);
            double[] LB_tyreTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("LB.tyreTemperature".Equals)]);
            double[] RB_tyreTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("RB.tyreTemperature".Equals)]);

            double[] LF_treadTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("LF.treadTemperature".Equals)]);
            double[] RF_treadTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("RF.treadTemperature".Equals)]);
            double[] LB_treadTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("LB.treadTemperature".Equals)]);
            double[] RB_treadTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("RB.treadTemperature".Equals)]);

            double[] LF_temperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("LF.temperature".Equals)]);
            double[] RF_temperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("RF.temperature".Equals)]);
            double[] LB_temperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("LB.temperature".Equals)]);
            double[] RB_temperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("RB.temperature".Equals)]);

            double[] LF_pressure = ConvertRawData.Pressure(telemetrydata[columnsname.FindIndex("LF.pressure".Equals)]);
            double[] RF_pressure = ConvertRawData.Pressure(telemetrydata[columnsname.FindIndex("RF.pressure".Equals)]);
            double[] LB_pressure = ConvertRawData.Pressure(telemetrydata[columnsname.FindIndex("LB.pressure".Equals)]);
            double[] RB_pressure = ConvertRawData.Pressure(telemetrydata[columnsname.FindIndex("RB.pressure".Equals)]);

            double[] Gear = ConvertRawData.Gear(telemetrydata[columnsname.FindIndex("gear".Equals)]);

            double[] radiatorCoolantHeatState_temperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("radiatorCoolantHeatState.temperature".Equals)]);
            double[] engineCoolantHeatState_temperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("engineCoolantHeatState.temperature".Equals)]);
            double[] engineTemperature = ConvertRawData.Temps(telemetrydata[columnsname.FindIndex("engineTemperature".Equals)]);

            TyreWear.Calculate(telemetrydata, columnsname);

            double[] LFAverageWear = TyreWear.LFAverageWear.ToArray();
            double[] RFAverageWear = TyreWear.RFAverageWear.ToArray();
            double[] LBAverageWear = TyreWear.LBAverageWear.ToArray();
            double[] RBAverageWear = TyreWear.RBAverageWear.ToArray();

            double[] LFSegmentWear = TyreWear.LFSegmentWear.ToArray();
            double[] RFSegmentWear = TyreWear.RFSegmentWear.ToArray();
            double[] LBSegmentWear = TyreWear.LBSegmentWear.ToArray();
            double[] RBSegmentWear = TyreWear.RBSegmentWear.ToArray();

            double[] LF_brakeWear = ConvertRawData.BrakeWear(telemetrydata[columnsname.FindIndex("LF.brakeWear".Equals)]);
            double[] RF_brakeWear = ConvertRawData.BrakeWear(telemetrydata[columnsname.FindIndex("RF.brakeWear".Equals)]);
            double[] LB_brakeWear = ConvertRawData.BrakeWear(telemetrydata[columnsname.FindIndex("LB.brakeWear".Equals)]);
            double[] RB_brakeWear = ConvertRawData.BrakeWear(telemetrydata[columnsname.FindIndex("RB.brakeWear".Equals)]);

            double[] LF_rollbarForce = telemetrydata[columnsname.FindIndex("LF.rollbarForce".Equals)].ToArray();
            double[] RF_rollbarForce = telemetrydata[columnsname.FindIndex("RF.rollbarForce".Equals)].ToArray();
            double[] LB_rollbarForce = telemetrydata[columnsname.FindIndex("LB.rollbarForce".Equals)].ToArray();
            double[] RB_rollbarForce = telemetrydata[columnsname.FindIndex("RB.rollbarForce".Equals)].ToArray();

            double[] LF_springForce = telemetrydata[columnsname.FindIndex("LF.springForce".Equals)].ToArray();
            double[] RF_springForce = telemetrydata[columnsname.FindIndex("RF.springForce".Equals)].ToArray();
            double[] LB_springForce = telemetrydata[columnsname.FindIndex("LB.springForce".Equals)].ToArray();
            double[] RB_springForce = telemetrydata[columnsname.FindIndex("RB.springForce".Equals)].ToArray();

            double[] LF_strutForce = telemetrydata[columnsname.FindIndex("LF.strutForce".Equals)].ToArray();
            double[] RF_strutForce = telemetrydata[columnsname.FindIndex("RF.strutForce".Equals)].ToArray();
            double[] LB_strutForce = telemetrydata[columnsname.FindIndex("LB.strutForce".Equals)].ToArray();
            double[] RB_strutForce = telemetrydata[columnsname.FindIndex("RB.strutForce".Equals)].ToArray();

            double[] LF_helperSpringActive = telemetrydata[columnsname.FindIndex("LF.helperSpringActive".Equals)].ToArray();
            double[] RF_helperSpringActive = telemetrydata[columnsname.FindIndex("RF.helperSpringActive".Equals)].ToArray();
            double[] LB_helperSpringActive = telemetrydata[columnsname.FindIndex("LB.helperSpringActive".Equals)].ToArray();
            double[] RB_helperSpringActive = telemetrydata[columnsname.FindIndex("RB.helperSpringActive".Equals)].ToArray();

            max_rpm = engineRotation.Max();
            racetime = raceTime.Max();
            var racetime_index = Array.IndexOf(raceTime, racetime);
            trackleght = (int)(driveLineLocation[racetime_index]);

            for (int i = 0; i < driveLineLocation.Length; i++)
            {
                Speed_XYZ2[i] = Math.Sqrt(Math.Pow(Speed_X[i], 2) + Math.Pow(Speed_Y[i], 2) + Math.Pow(Speed_Z[i], 2)) * 3.6;

                //Speed_XYZ2[i] = Math.Sqrt(Math.Pow(telemetrydata[columnsname.FindIndex("vecLinearVelocityCar.x".Equals)][i], 2) + Math.Pow(telemetrydata[columnsname.FindIndex("vecLinearVelocityCar.y".Equals)][i], 2) + Math.Pow(telemetrydata[columnsname.FindIndex("vecLinearVelocityCar.z".Equals)][i], 2) + Math.Pow(telemetrydata[columnsname.FindIndex("vecAngularVelocityCar.x".Equals)][i], 2) + Math.Pow(telemetrydata[columnsname.FindIndex("vecAngularVelocityCar.x".Equals)][i], 2) + Math.Pow(telemetrydata[columnsname.FindIndex("vecAngularVelocityCar.x".Equals)][i], 2)) * 3.6;
            }
            max_speed = Speed_XYZ2.Max();
            //ScottPlot
            //SpeedChart.Plot.AddScatterLines(telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray(), speed, label: "WheelSpeed");            
            SpeedChart.Plot.AddScatterLines(driveLineLocation, Speed_XYZ2, label: "Lineran Speed");
            SpeedChart.Plot.SetOuterViewLimits(driveLineLocation.Min() - 5, driveLineLocation.Max() + 10, Speed_XYZ2.Min()-10, Speed_XYZ2.Max()+5);
            EngineDataChart.Plot.AddScatterLines(telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("engineRotation".Equals)].ToArray(), label: "RPM");
            RaceTrack.Plot.AddScatterLines(telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray());
            GForcesChart.Plot.AddScatterLines(telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("vecAvgLinearAccelerationCar.y".Equals)].ToArray(), label: "Brake");
            GForcesChart.Plot.AddScatterLines(telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("vecAvgLinearAccelerationCar.x".Equals)].ToArray(), label: "Corner");

            SpeedChart.Plot.Legend();
            EngineDataChart.Plot.Legend();
            GForcesChart.Plot.Legend();

            //var test = new ScottPlot.Plottable.ScatterPlotList();
            //for (int v = 1; v < position_x.Count(); v++)
            //{

            //    double x1 = position_x[v-1];
            //    double y1 = position_y[v-1];
            //    double x2 = position_x[v];
            //    double y2 = position_y[v];
            //    var xx = new double[]{ x1, x2 };
            //    var yy = new double[]{ y1, y2};
            //    double colorFraction = ((speed[v]-speed[v-1])/2 + speed[v])/200;
            //    System.Drawing.Color c = ScottPlot.Drawing.Colormap.Jet.GetColor(colorFraction);
            //    //test.Add(x, y);
            //    test.Color = c;
            //    RaceTrack.Plot.AddScatterLines(xx, yy, c,2);
            //}

            //suspension test
            SuspensionLFPlot.Plot.AddScatterLines(driveLineLocation, telemetrydata[columnsname.FindIndex("LF.deflection".Equals)].ToArray(), label: "LF.deflection");
            SuspensionRFPlot.Plot.AddScatterLines(driveLineLocation, telemetrydata[columnsname.FindIndex("RF.deflection".Equals)].ToArray(), label: "RF.deflection");
            SuspensionLBPlot.Plot.AddScatterLines(driveLineLocation, telemetrydata[columnsname.FindIndex("LB.deflection".Equals)].ToArray(), label: "LB.deflection");
            SuspensionRBPlot.Plot.AddScatterLines(driveLineLocation, telemetrydata[columnsname.FindIndex("RB.deflection".Equals)].ToArray(), label: "RB.deflection");

            SuspensionLFPlot.Refresh();
            SuspensionRFPlot.Refresh();
            SuspensionLBPlot.Refresh();
            SuspensionRBPlot.Refresh();


            BrakeTempLFPlot.Plot.AddScatterLines(driveLineLocation, LF_brakeDiskTemp, label: "brakeDiskTemp");
            BrakeTempRFPlot.Plot.AddScatterLines(driveLineLocation, RF_brakeDiskTemp, label: "brakeDiskTemp");
            BrakeTempLBPlot.Plot.AddScatterLines(driveLineLocation, LB_brakeDiskTemp, label: "brakeDiskTemp");
            BrakeTempRBPlot.Plot.AddScatterLines(driveLineLocation, RB_brakeDiskTemp, label: "brakeDiskTemp");

            BrakeTempLFPlot.Plot.AddScatterLines(driveLineLocation, LF_brakeDiskLayerTemp, label: "brakeDiskLayerTemp");
            BrakeTempRFPlot.Plot.AddScatterLines(driveLineLocation, RF_brakeDiskLayerTemp, label: "brakeDiskLayerTemp");
            BrakeTempLBPlot.Plot.AddScatterLines(driveLineLocation, LB_brakeDiskLayerTemp, label: "brakeDiskLayerTemp");
            BrakeTempRBPlot.Plot.AddScatterLines(driveLineLocation, RB_brakeDiskLayerTemp, label: "brakeDiskLayerTemp");

            BrakeTempLFPlot.Plot.Legend();
            BrakeTempRFPlot.Plot.Legend();
            BrakeTempLBPlot.Plot.Legend();
            BrakeTempRBPlot.Plot.Legend();

            BrakeTempLFPlot.Refresh();
            BrakeTempRFPlot.Refresh();
            BrakeTempLBPlot.Refresh();
            BrakeTempRBPlot.Refresh();


            TyreTempsLFPlot.Plot.AddScatterLines(driveLineLocation, LF_treadTemperature, label: "treadTemperature");
            TyreTempsRFPlot.Plot.AddScatterLines(driveLineLocation, RF_treadTemperature, label: "treadTemperature");
            TyreTempsLBPlot.Plot.AddScatterLines(driveLineLocation, LB_treadTemperature, label: "treadTemperature");
            TyreTempsRBPlot.Plot.AddScatterLines(driveLineLocation, RB_treadTemperature, label: "treadTemperature");

            TyreTempsLFPlot.Plot.AddScatterLines(driveLineLocation, LF_tyreTemperature, label: "tyreTemperature");
            TyreTempsRFPlot.Plot.AddScatterLines(driveLineLocation, RF_tyreTemperature, label: "tyreTemperature");
            TyreTempsLBPlot.Plot.AddScatterLines(driveLineLocation, LB_tyreTemperature, label: "tyreTemperature");
            TyreTempsRBPlot.Plot.AddScatterLines(driveLineLocation, RB_tyreTemperature, label: "tyreTemperature");

            TyreTempsLFPlot.Plot.AddScatterLines(driveLineLocation, LF_temperature, label: "temperature");
            TyreTempsRFPlot.Plot.AddScatterLines(driveLineLocation, RF_temperature, label: "temperature");
            TyreTempsLBPlot.Plot.AddScatterLines(driveLineLocation, LB_temperature, label: "temperature");
            TyreTempsRBPlot.Plot.AddScatterLines(driveLineLocation, RB_temperature, label: "temperature");

            TyreTempsLFPlot.Plot.Legend();
            TyreTempsRFPlot.Plot.Legend();
            TyreTempsLBPlot.Plot.Legend();
            TyreTempsRBPlot.Plot.Legend();

            TyreTempsLFPlot.Refresh();
            TyreTempsRFPlot.Refresh();
            TyreTempsLBPlot.Refresh();
            TyreTempsRBPlot.Refresh();

            TyrePressureLFPlot.Plot.AddScatterLines(driveLineLocation, LF_pressure, label: "pressure");
            TyrePressureRFPlot.Plot.AddScatterLines(driveLineLocation, RF_pressure, label: "pressure");
            TyrePressureLBPlot.Plot.AddScatterLines(driveLineLocation, LB_pressure, label: "pressure");
            TyrePressureRBPlot.Plot.AddScatterLines(driveLineLocation, RB_pressure, label: "pressure");

            TyrePressureLFPlot.Refresh();
            TyrePressureRFPlot.Refresh();
            TyrePressureLBPlot.Refresh();
            TyrePressureRBPlot.Refresh();

            GearPlot.Plot.AddScatterLines(driveLineLocation, Gear);
            GearPlot.Refresh();

            WheelSpeedPlot.Plot.AddScatterLines(driveLineLocation, speed);
            WheelSpeedPlot.Refresh();

            EngineTempsPlot.Plot.AddScatterLines(driveLineLocation, radiatorCoolantHeatState_temperature, label: "radiatorCoolantHeatState_temperature");
            EngineTempsPlot.Plot.AddScatterLines(driveLineLocation, engineCoolantHeatState_temperature, label: "engineCoolantHeatState_temperature");
            EngineTempsPlot.Plot.AddScatterLines(driveLineLocation, engineTemperature, label: "engineTemperature");
            EngineTempsPlot.Plot.Legend();
            EngineTempsPlot.Refresh();

            
            WheelWearsLFPlot.Plot.AddScatterLines(driveLineLocation, LFAverageWear, label: "LFAverageWear");
            WheelWearsRFPlot.Plot.AddScatterLines(driveLineLocation, RFAverageWear, label: "RFAverageWear");
            WheelWearsLBPlot.Plot.AddScatterLines(driveLineLocation, LBAverageWear, label: "LBAverageWear");
            WheelWearsRBPlot.Plot.AddScatterLines(driveLineLocation, RBAverageWear, label: "RBAverageWear");
         
            WheelWearsLFPlot.Plot.AddScatterLines(driveLineLocation, LFSegmentWear, label: "LFSegmentWear");
            WheelWearsRFPlot.Plot.AddScatterLines(driveLineLocation, RFSegmentWear, label: "RFSegmentWear");
            WheelWearsLBPlot.Plot.AddScatterLines(driveLineLocation, LBSegmentWear, label: "LBSegmentWear");
            WheelWearsRBPlot.Plot.AddScatterLines(driveLineLocation, RBSegmentWear, label: "RBSegmentWear");
           
            WheelWearsLFPlot.Plot.AddScatterLines(driveLineLocation, LF_brakeWear, label: "LF_brakeWear");
            WheelWearsRFPlot.Plot.AddScatterLines(driveLineLocation, RF_brakeWear, label: "RF_brakeWear");
            WheelWearsLBPlot.Plot.AddScatterLines(driveLineLocation, LB_brakeWear, label: "LB_brakeWear");
            WheelWearsRBPlot.Plot.AddScatterLines(driveLineLocation, RB_brakeWear, label: "RB_brakeWear");
   
            WheelWearsLFPlot.Plot.Legend();
            WheelWearsRFPlot.Plot.Legend();
            WheelWearsLBPlot.Plot.Legend();
            WheelWearsRBPlot.Plot.Legend();

            WheelWearsLFPlot.Refresh();
            WheelWearsRFPlot.Refresh();
            WheelWearsLBPlot.Refresh();
            WheelWearsRBPlot.Refresh();

            //end

            //suspension forecs
            SuspensionForcesLFPlot.Plot.AddScatterLines(driveLineLocation, LF_rollbarForce, label: "LF_rollbarForce");
            SuspensionForcesRFPlot.Plot.AddScatterLines(driveLineLocation, RF_rollbarForce, label: "RF_rollbarForce");
            SuspensionForcesLBPlot.Plot.AddScatterLines(driveLineLocation, LB_rollbarForce, label: "LB_rollbarForce");
            SuspensionForcesRBPlot.Plot.AddScatterLines(driveLineLocation, RB_rollbarForce, label: "RB_rollbarForce");
            
            SuspensionForcesLFPlot.Plot.AddScatterLines(driveLineLocation, LF_springForce, label: "LF_springForce");
            SuspensionForcesRFPlot.Plot.AddScatterLines(driveLineLocation, RF_springForce, label: "RF_springForce");
            SuspensionForcesLBPlot.Plot.AddScatterLines(driveLineLocation, LB_springForce, label: "LB_springForce");
            SuspensionForcesRBPlot.Plot.AddScatterLines(driveLineLocation, RB_springForce, label: "RB_springForce");
       
            SuspensionForcesLFPlot.Plot.AddScatterLines(driveLineLocation, LF_strutForce, label: "LF_strutForce");
            SuspensionForcesRFPlot.Plot.AddScatterLines(driveLineLocation, RF_strutForce, label: "RF_strutForce");
            SuspensionForcesLBPlot.Plot.AddScatterLines(driveLineLocation, LB_strutForce, label: "LB_strutForce");
            SuspensionForcesRBPlot.Plot.AddScatterLines(driveLineLocation, RB_strutForce, label: "RB_strutForce");

            SuspensionForcesLFPlot.Plot.Legend();
            SuspensionForcesRFPlot.Plot.Legend();
            SuspensionForcesLBPlot.Plot.Legend();
            SuspensionForcesRBPlot.Plot.Legend();
 
            SuspensionForcesLFPlot.Refresh();
            SuspensionForcesRFPlot.Refresh();
            SuspensionForcesLBPlot.Refresh();
            SuspensionForcesRBPlot.Refresh();
            //end

            HelperSpringPlot.Plot.AddScatterLines(driveLineLocation, LF_helperSpringActive, label: "LF_helperSpringActive");
            HelperSpringPlot.Plot.AddScatterLines(driveLineLocation, RF_helperSpringActive, label: "RF_helperSpringActive");
            HelperSpringPlot.Plot.AddScatterLines(driveLineLocation, LB_helperSpringActive, label: "LB_helperSpringActive");
            HelperSpringPlot.Plot.AddScatterLines(driveLineLocation, RB_helperSpringActive, label: "RB_helperSpringActive");

            HelperSpringPlot.Plot.Legend();

            HelperSpringPlot.Refresh();


            SpeedChart.Plot.Frameless();
            GForcesChart.Plot.Frameless();
            EngineDataChart.Plot.Frameless();
            
            SpeedChart.Plot.YAxis.Hide(false);
            GForcesChart.Plot.YAxis.Hide(false);
            EngineDataChart.Plot.XAxis.Hide(false);
            EngineDataChart.Plot.YAxis.Hide(false);
            RaceTrack.Plot.AxisAuto();
            RaceTrack.Plot.Frameless();            
            SpeedChart.Refresh();
            EngineDataChart.Refresh();
            RaceTrack.Refresh();
            GForcesChart.Refresh();

            //ScottPlotEND

            //Accel/RPM
            {
                //
                //    var accell_before = telemetrydata[columnsname.FindIndex("vecLinearAccelerationCar.y".Equals)];
                //    var rpm_before = telemetrydata[columnsname.FindIndex("engineRotation".Equals)];
                //    var gear_before = telemetrydata[columnsname.FindIndex("gear".Equals)];
                //    List<double> accell_after = new List<double>();
                //    List<double> rpm_after = new List<double>();
                //    List<double> gear_afte = new List<double>();
                //    for (int p = 0; p < accell_before.Count(); p++)
                //    {
                //        if (accell_before[p] < 0)
                //        {
                //            accell_after.Add(accell_before[p] * -1);
                //            rpm_after.Add(rpm_before[p]);
                //            gear_afte.Add(gear_before[p]);

                //        }
                //    }
                //    var gm = gear_afte.Max();
                //    for (int u = 0; u < rpm_after.Count(); u++)
                //    {
                //        double x = rpm_after[u];
                //        double y = accell_after[u];
                //        double colorFraction = gear_afte[u];
                //        System.Drawing.Color c = ScottPlot.Drawing.Colormap.Jet.GetColor(colorFraction / gm);
                //        formsPlot9.Plot.AddPoint(x, y, c);
                //    }
                //    formsPlot9.Refresh();
                //
            }
            //end


            //histogramm
            double FindBinSize (string what)
            {
                List<double> vs = new List<double> ();
                var lf = "LF." + what;
                vs.Add((telemetrydata[columnsname.FindIndex(lf.Equals)]).Max()- (telemetrydata[columnsname.FindIndex(lf.Equals)]).Min()) ;
                var rf = "RF." + what;
                vs.Add((telemetrydata[columnsname.FindIndex(rf.Equals)]).Max() - (telemetrydata[columnsname.FindIndex(rf.Equals)]).Min());
                var lb = "LB." + what;
                vs.Add((telemetrydata[columnsname.FindIndex(lb.Equals)]).Max() - (telemetrydata[columnsname.FindIndex(lb.Equals)]).Min());
                var rb = "RB." + what;
                vs.Add((telemetrydata[columnsname.FindIndex(rb.Equals)]).Max() - (telemetrydata[columnsname.FindIndex(rb.Equals)]).Min());
                return vs.Max()/50;
            }
            double TTbarwidth = FindBinSize("tyreTemperature");
            var RFT = Histogram.TyresTemps(RF_tyreTemperature, TTbarwidth);
            TyreTempRFPlotH.Plot.AddBar(values: RFT[0], positions: RFT[1]).BarWidth = TTbarwidth;
            TyreTempRFPlotH.Refresh();
            var LFT = Histogram.TyresTemps(LF_tyreTemperature, TTbarwidth);
            TyreTempLFPlotH.Plot.AddBar(values: LFT[0], positions: LFT[1]).BarWidth = TTbarwidth;
            TyreTempLFPlotH.Refresh();
            var RBT = Histogram.TyresTemps(RB_tyreTemperature, TTbarwidth);
            TyreTempRBPlotH.Plot.AddBar(values: RBT[0], positions: RBT[1]).BarWidth = TTbarwidth;
            TyreTempRBPlotH.Refresh();
            var LBT = Histogram.TyresTemps(LB_tyreTemperature, TTbarwidth);
            TyreTempLBPlotH.Plot.AddBar(values: LBT[0], positions: LBT[1]).BarWidth = TTbarwidth;
            TyreTempLBPlotH.Refresh();

            double TPbarwidth = FindBinSize("pressure");
            var RFP = Histogram.TyresPressure(RF_pressure, TPbarwidth);
            TyrePressureRFPlotH.Plot.AddBar(values: RFP[0], positions: RFP[1]).BarWidth = TPbarwidth;
            TyrePressureRFPlotH.Refresh();
            var LFP = Histogram.TyresPressure(LF_pressure, TPbarwidth);
            TyrePressureLFPlotH.Plot.AddBar(values: LFP[0], positions: LFP[1]).BarWidth = TPbarwidth;
            TyrePressureLFPlotH.Refresh();
            var RBP = Histogram.TyresPressure(RB_pressure, TPbarwidth);
            TyrePressureRBPlotH.Plot.AddBar(values: RBP[0], positions: RBP[1]).BarWidth = TPbarwidth;
            TyrePressureRBPlotH.Refresh();
            var LBP = Histogram.TyresPressure(LB_pressure, TPbarwidth);
            TyrePressureLBPlotH.Plot.AddBar(values: LBP[0], positions: LBP[1]).BarWidth = TPbarwidth;
            TyrePressureLBPlotH.Refresh();

            //double Sbarwidth = FindBinSize("deflectionVelocity");
            var test = 1.25 * 2 / 100;
            double Sbarwidth = test;
            var RFS = Histogram.Suspension(RF_deflectionVelocity, raceTime, Sbarwidth);
            SuspensionRFPlotH.Plot.AddBar(values: RFS[0], positions: RFS[1]).BarWidth = Sbarwidth;
            SuspensionRFPlotH.Plot.SetAxisLimitsX(-1.25, 1.25);
            SuspensionRFPlotH.Refresh();
            var LFS = Histogram.Suspension(LF_deflectionVelocity, raceTime, Sbarwidth);
            SuspensionLFPlotH.Plot.AddBar(values: LFS[0], positions: LFS[1]).BarWidth = Sbarwidth;
            SuspensionLFPlotH.Plot.SetAxisLimitsX(-1.25, 1.25);
            SuspensionLFPlotH.Refresh();
            var RBS = Histogram.Suspension(RB_deflectionVelocity, raceTime, Sbarwidth);
            SuspensionRBPlotH.Plot.AddBar(values: RBS[0], positions: RBS[1]).BarWidth = Sbarwidth;
            SuspensionRBPlotH.Plot.SetAxisLimitsX(-1.25, 1.25);
            SuspensionRBPlotH.Refresh();
            var LBS = Histogram.Suspension(LB_deflectionVelocity, raceTime, Sbarwidth);
            SuspensionLBPlotH.Plot.AddBar(values: LBS[0], positions: LBS[1]).BarWidth = Sbarwidth;
            SuspensionLBPlotH.Plot.SetAxisLimitsX(-1.25, 1.25);
            SuspensionLBPlotH.Refresh();
            //histogramm end


            if (run >= 2)
            {
                TimeDiffirenceChart.Plot.AddScatterLines(distance.ToArray(), time_diff.ToArray());
                TimeDiffirenceChart.Plot.Frameless();
                TimeDiffirenceChart.Plot.YAxis.Hide(false);
                TimeDiffirenceChart.Plot.AxisAuto();
                TimeDiffirenceChart.Refresh();
            }



            var endTime = DateTime.Now.Ticks;
            var test12345 = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
            var startposition = test12345[1];
            var lastindex = Array.LastIndexOf(test12345, startposition);
            //var racestart = telemetrydata[columnsname.FindIndex("raceTime".Equals)][lastindex];
            var racestart = ReactionTime.GetTime(telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("speed".Equals)].ToArray());
            double endtime2 = (double)(endTime);
            double starttime2 = (double)(starttime);
            double timerun = (endtime2 - starttime2) / 10000000;
            
            testvalues.Columns.Add(RaceTime.ToString(raceTime.Max()));
            testvalues.Rows[0][run] = racestart;
            testvalues.Rows[1][run] = max_speed.ToString("0.0");
            testvalues.Rows[2][run] = test12345.Max();
            testvalues.Rows[3][run] = max_rpm;
            testvalues.Rows[4][run] = timerun;
            testvalues.Rows[5][run] = trackleght;
            bool test1234 = true;
            testvalues.Rows[6][run] = test1234;
            dataGridView1.DataSource = testvalues;
            RBRTelemetryFile.Parse.ClearData();
            TyreWear.Clear();
            run++;
        End: ;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void OnAxesChanged(object sender, EventArgs e)
        {
            FormsPlot changedPlot = (FormsPlot)sender;
            //var newAxisLimits = changedPlot.Plot.GetAxisLimits();
            var test = changedPlot.Plot.GetAxisLimits();
            var delta = (test.XMax - test.XMin)/4;
            var center = (test.XMax - test.XMin) / 2 + test.XMin ;

            //label1.Text = "Center: " + Convert.ToString((int)(center)) + " | "+ position_x_dist[(int)center].ToString() + "\n" + "Delta: " + Convert.ToString((int)delta) + " | " + position_y_dist[(int)center].ToString();

            //changedPlot.Plot.AxisAutoY();
            RaceTrack.Configuration.AxesChangedEventEnabled = false;
            if (center >=0 && center <= position_x_dist.Count)
            {
                var rtxmin = position_x_dist[(int)center] - delta;
                var rtxmax = position_x_dist[(int)center] + delta;
                var rtymin = position_y_dist[(int)center] - delta;
                var rtymax = position_y_dist[(int)center] +delta;
                RaceTrack.Plot.SetAxisLimitsX(rtxmin, rtxmax);
                RaceTrack.Plot.SetAxisLimitsY(rtymin,rtymax);
                RaceTrack.Render();
            }
            else
            {
                RaceTrack.Plot.AxisAuto();
            }
            RaceTrack.Configuration.AxesChangedEventEnabled = true;


            foreach (var fp in FormsPlots)
            {
                if (fp == changedPlot)
                    continue;
                // disable events briefly to avoid an infinite loop
                fp.Configuration.AxesChangedEventEnabled = false;
                fp.Plot.SetAxisLimitsX(test.XMin, test.XMax);
                fp.Plot.AxisAutoY();
                fp.Refresh();
                fp.Configuration.AxesChangedEventEnabled = true;
                
            }
        }
    }

    }
