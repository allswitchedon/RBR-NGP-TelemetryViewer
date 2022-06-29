using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBR_NGP_TelemetryViewer
{
    public partial class Form1 : Form
    {
        public static List<string> columnsname_form2 = new List<string>();
        public static List<string> user_workspace = new List<string>();
        List<string> columnsname = new List<string>();
        List<List<double>> telemetrydata = new List<List<double>>();
        List<double> time_diff = new List<double>();
        List<double> distance = new List<double>();
        List<double> position_x_dist = new List<double>();
        List<double> position_y_dist = new List<double>();
        int run = 1;
        DataTable testvalues = new DataTable();
        double max_speed;
        double max_rpm;
        double racetime;
        int trackleght;
        string stagemapfolder = Application.StartupPath.ToString() + "\\stagemap\\";
        string stage_id;
        double start_x=0;
        double start_y=0;
        double start_x2 = 0;
        double start_y2 = 0;
        double stage_leght=0;
        double stage_id_run1 = 0;
        double stage_id_run2 = 0;
        public static long startparse;
        public static long endparse;
        long starttime = 0;

        PlotModel Speed_Model = new PlotModel { PlotMargins = new OxyThickness(40,0,0,0) };
        Legend Speed_Legend = new Legend();
        PlotModel GForces_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend GForces_Legend = new Legend();
        PlotModel TimeDiff_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend TimeDiff_Legend = new Legend();
        PlotModel Engine_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend Engine_Legend = new Legend();
        PlotModel RaceTrack_Model = new PlotModel { PlotMargins = new OxyThickness(0, 0, 0, 0) };
        Legend RaceTrack_Legend = new Legend();

        PlotModel TyrePressureLF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyrePressureRF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyrePressureLB_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyrePressureRB_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend TyrePressureLF_Legend = new Legend();
        Legend TyrePressureRF_Legend = new Legend();
        Legend TyrePressureLB_Legend = new Legend();
        Legend TyrePressureRB_Legend = new Legend();

        PlotModel TyrePressureLF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyrePressureRF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyrePressureLB_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyrePressureRB_Histogram_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend TyrePressureLF_Histogram_Legend = new Legend();
        Legend TyrePressureRF_Histogram_Legend = new Legend();
        Legend TyrePressureLB_Histogram_Legend = new Legend();
        Legend TyrePressureRB_Histogram_Legend = new Legend();

        PlotModel TyreTempsLF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyreTempsRF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyreTempsLB_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyreTempsRB_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend TyreTempsLF_Legend = new Legend();
        Legend TyreTempsRF_Legend = new Legend();
        Legend TyreTempsLB_Legend = new Legend();
        Legend TyreTempsRB_Legend = new Legend();

        PlotModel TyreTempsLF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyreTempsRF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyreTempsLB_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel TyreTempsRB_Histogram_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend TyreTempsLF_Histogram_Legend = new Legend();
        Legend TyreTempsRF_Histogram_Legend = new Legend();
        Legend TyreTempsLB_Histogram_Legend = new Legend();
        Legend TyreTempsRB_Histogram_Legend = new Legend();

        PlotModel SuspensionLF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel SuspensionRF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel SuspensionLB_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel SuspensionRB_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend SuspensionLF_Legend = new Legend();
        Legend SuspensionRF_Legend = new Legend();
        Legend SuspensionLB_Legend = new Legend();
        Legend SuspensionRB_Legend = new Legend();

        PlotModel SuspensionLF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel SuspensionRF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel SuspensionLB_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel SuspensionRB_Histogram_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend SuspensionLF_Histogram_Legend = new Legend();
        Legend SuspensionRF_Histogram_Legend = new Legend();
        Legend SuspensionLB_Histogram_Legend = new Legend();
        Legend SuspensionRB_Histogram_Legend = new Legend();

        PlotModel DamperLF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel DamperRF_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel DamperLB_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel DamperRB_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend DamperLF_Legend = new Legend();
        Legend DamperRF_Legend = new Legend();
        Legend DamperLB_Legend = new Legend();
        Legend DamperRB_Legend = new Legend();

        PlotModel DamperLF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel DamperRF_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel DamperLB_Histogram_Model = new PlotModel{ PlotMargins = new OxyThickness(40, 0, 0, 0) };
        PlotModel DamperRB_Histogram_Model = new PlotModel { PlotMargins = new OxyThickness(40, 0, 0, 0) };
        Legend DamperLF_Histogram_Legend = new Legend();
        Legend DamperRF_Histogram_Legend = new Legend();
        Legend DamperLB_Histogram_Legend = new Legend();
        Legend DamperRB_Histogram_Legend = new Legend();

        List<OxyPlot.PlotModel> PlotModels = new List<OxyPlot.PlotModel>();
        List<OxyPlot.PlotModel> HistogramModels = new List<OxyPlot.PlotModel>();
        List<OxyPlot.WindowsForms.PlotView> plotViews = new List<OxyPlot.WindowsForms.PlotView>();

        List<OxyPlot.Series.LineSeries> WS_Series = new List<OxyPlot.Series.LineSeries>();

        //Vertical Line Annotation for Damper Histogram
        LineAnnotation RF_HS_Plus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = -30 };
        LineAnnotation RF_HS_Minus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = 30 };
        LineAnnotation LB_HS_Plus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = -30 };
        LineAnnotation LB_HS_Minus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = 30 };
        LineAnnotation RB_HS_Plus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = -30 };
        LineAnnotation RB_HS_Minus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = 30 };
        LineAnnotation LF_HS_Plus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = -30 };
        LineAnnotation LF_HS_Minus = new LineAnnotation { Type = LineAnnotationType.Vertical, X = 30 };


        [Obsolete]
        public Form1()
        {
            InitializeComponent();
            Application.CurrentCulture = new CultureInfo("en-US");
            testvalues.Columns.Add(" ");
            testvalues.Rows.Add("Reaction Time");
            testvalues.Rows.Add("Maximum Speed");
            testvalues.Rows.Add("Distance");
            testvalues.Rows.Add("Maximum RPM");
            testvalues.Rows.Add("Open Time");
            testvalues.Rows.Add("Track Leght");
            testvalues.Rows.Add("Parse Time");
            saveToolStripMenuItem.Enabled = false;
            if (Directory.Exists(stagemapfolder));
            else Directory.CreateDirectory(stagemapfolder);

            


            // List of Plot Models
            PlotModels.Add(Speed_Model);
            PlotModels.Add(GForces_Model);
            PlotModels.Add(TimeDiff_Model);
            PlotModels.Add(Engine_Model);
            PlotModels.Add(RaceTrack_Model);

            PlotModels.Add(TyrePressureLF_Model);
            PlotModels.Add(TyrePressureRF_Model);
            PlotModels.Add(TyrePressureLB_Model);
            PlotModels.Add(TyrePressureRB_Model);

            PlotModels.Add(TyrePressureLF_Histogram_Model);
            PlotModels.Add(TyrePressureRF_Histogram_Model);
            PlotModels.Add(TyrePressureLB_Histogram_Model);
            PlotModels.Add(TyrePressureRB_Histogram_Model);

            PlotModels.Add(TyreTempsLF_Model);
            PlotModels.Add(TyreTempsRF_Model);
            PlotModels.Add(TyreTempsLB_Model);
            PlotModels.Add(TyreTempsRB_Model);

            HistogramModels.Add(TyreTempsLF_Histogram_Model);
            HistogramModels.Add(TyreTempsRF_Histogram_Model);
            HistogramModels.Add(TyreTempsLB_Histogram_Model);
            HistogramModels.Add(TyreTempsRB_Histogram_Model);

            PlotModels.Add(SuspensionLF_Model);
            PlotModels.Add(SuspensionRF_Model);
            PlotModels.Add(SuspensionLB_Model);
            PlotModels.Add(SuspensionRB_Model);

            HistogramModels.Add(SuspensionLF_Histogram_Model);
            HistogramModels.Add(SuspensionRF_Histogram_Model);
            HistogramModels.Add(SuspensionLB_Histogram_Model);
            HistogramModels.Add(SuspensionRB_Histogram_Model);

            PlotModels.Add(DamperLF_Model);
            PlotModels.Add(DamperRF_Model);
            PlotModels.Add(DamperLB_Model);
            PlotModels.Add(DamperRB_Model);

            HistogramModels.Add(DamperLF_Histogram_Model);
            HistogramModels.Add(DamperRF_Histogram_Model);
            HistogramModels.Add(DamperLB_Histogram_Model);
            HistogramModels.Add(DamperRB_Histogram_Model);

            //List of PlotViews
            plotViews.Add(Speed_Plot);
            plotViews.Add(GForces_Plot);
            plotViews.Add(TimeDiff_Plot);
            plotViews.Add(Engine_Plot);
            plotViews.Add(RaceTrack_OP);

            plotViews.Add(TyrePressureLF_OP);
            plotViews.Add(TyrePressureRF_OP);
            plotViews.Add(TyrePressureLB_OP);
            plotViews.Add(TyrePressureRB_OP);

            plotViews.Add(TyreTempsLF_OP);
            plotViews.Add(TyreTempsRF_OP);
            plotViews.Add(TyreTempsLB_OP);
            plotViews.Add(TyreTempsRB_OP);

            plotViews.Add(SuspensionLF_OP);
            plotViews.Add(SuspensionRF_OP);
            plotViews.Add(SuspensionLB_OP);
            plotViews.Add(SuspensionRB_OP);

            plotViews.Add(DamperLF_OP);
            plotViews.Add(DamperRF_OP);
            plotViews.Add(DamperLB_OP);
            plotViews.Add(DamperRB_OP);




            //Graph
            Speed_Model.Legends.Add(Speed_Legend);
            Speed_Plot.Model = Speed_Model;
            GForces_Model.Legends.Add(GForces_Legend);
            GForces_Plot.Model = GForces_Model;
            Engine_Model.Legends.Add(Engine_Legend);
            Engine_Plot.Model = Engine_Model;
            TimeDiff_Model.Legends.Add(TimeDiff_Legend);
            TimeDiff_Plot.Model = TimeDiff_Model;
            RaceTrack_Model.Legends.Add(RaceTrack_Legend);
            RaceTrack_OP.Model = RaceTrack_Model;


            //Tyre Pressure
            TyrePressureLF_Model.Legends.Add(TyrePressureLF_Legend);
            TyrePressureRF_Model.Legends.Add(TyrePressureRF_Legend); 
            TyrePressureLB_Model.Legends.Add(TyrePressureLB_Legend);
            TyrePressureRB_Model.Legends.Add(TyrePressureRB_Legend);

            TyrePressureLF_Histogram_Model.Legends.Add(TyrePressureLF_Histogram_Legend);
            TyrePressureRF_Histogram_Model.Legends.Add(TyrePressureRF_Histogram_Legend);
            TyrePressureLB_Histogram_Model.Legends.Add(TyrePressureLB_Histogram_Legend);
            TyrePressureRB_Histogram_Model.Legends.Add(TyrePressureRB_Histogram_Legend);

            TyrePressureLF_OP.Model = TyrePressureLF_Model;
            TyrePressureRF_OP.Model = TyrePressureRF_Model;
            TyrePressureLB_OP.Model = TyrePressureLB_Model;
            TyrePressureRB_OP.Model = TyrePressureRB_Model;

            //Tyre Temps
            TyreTempsLF_Model.Legends.Add(TyreTempsLF_Legend);
            TyreTempsRF_Model.Legends.Add(TyreTempsRF_Legend);
            TyreTempsLB_Model.Legends.Add(TyreTempsLB_Legend);
            TyreTempsRB_Model.Legends.Add(TyreTempsRB_Legend);

            TyreTempsLF_OP.Model = TyreTempsLF_Model;
            TyreTempsRF_OP.Model = TyreTempsRF_Model;
            TyreTempsLB_OP.Model = TyreTempsLB_Model;
            TyreTempsRB_OP.Model = TyreTempsRB_Model;

            TyreTempsLF_Histogram_Model.Legends.Add(TyreTempsLF_Histogram_Legend);
            TyreTempsRF_Histogram_Model.Legends.Add(TyreTempsRF_Histogram_Legend);
            TyreTempsLB_Histogram_Model.Legends.Add(TyreTempsLB_Histogram_Legend);
            TyreTempsRB_Histogram_Model.Legends.Add(TyreTempsRB_Histogram_Legend);

            //Suspension

            SuspensionLF_Model.Legends.Add(SuspensionLF_Legend);
            SuspensionRF_Model.Legends.Add(SuspensionRF_Legend);
            SuspensionLB_Model.Legends.Add(SuspensionLB_Legend);
            SuspensionRB_Model.Legends.Add(SuspensionRB_Legend);

            SuspensionLF_Histogram_Model.Legends.Add(SuspensionLF_Histogram_Legend);
            SuspensionRF_Histogram_Model.Legends.Add(SuspensionRF_Histogram_Legend);
            SuspensionLB_Histogram_Model.Legends.Add(SuspensionLB_Histogram_Legend);
            SuspensionRB_Histogram_Model.Legends.Add(SuspensionRB_Histogram_Legend);

            //Dampers

            DamperLF_Model.Legends.Add(DamperLF_Legend);
            DamperRF_Model.Legends.Add(DamperRF_Legend);
            DamperLB_Model.Legends.Add(DamperLB_Legend);
            DamperRB_Model.Legends.Add(DamperRB_Legend);

            DamperLF_Histogram_Model.Legends.Add(DamperLF_Histogram_Legend);
            DamperRF_Histogram_Model.Legends.Add(DamperRF_Histogram_Legend);
            DamperLB_Histogram_Model.Legends.Add(DamperLB_Histogram_Legend);
            DamperRB_Histogram_Model.Legends.Add(DamperRB_Histogram_Legend);


            lineToolStripMenuItem_Click(true, EventArgs.Empty);
            lineToolStripMenuItem1_Click(true, EventArgs.Empty);
            Suspension_Lines_Menu__Click(true, EventArgs.Empty);
            Dampers_Histrogram_Menu_Click(true, EventArgs.Empty);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RBRTelemetryFile.Parse.ClearData();
            TyreWear.Clear();
            openFileToolStripMenuItem.Enabled = false;
            columnsname.Clear();
            telemetrydata.Clear();
            columnsname_form2.Clear();
            //List<string> columnsname = new List<string>();
            //List<List<double>> telemetrydata = new List<List<double>>();
            OpenFileDialog selectfile = new OpenFileDialog { Filter = "RBR NGP Telemetry|*.tsv" };
            selectfile.ShowDialog();
            if (File.Exists(selectfile.FileName))
            {
                starttime = DateTime.Now.Ticks;
                //var read_task = new Task(() =>
                //{
                //    RBRTelemetryFile.Parse.test(selectfile.FileName);
                //});
                //read_task.Start();
                //read_task.Wait();
                bool isbusy = RBRTelemetryFile.Parse.test(selectfile.FileName);
                if (isbusy == false)
                {
                    columnsname = RBRTelemetryFile.Parse.test1();
                    columnsname_form2.AddRange(columnsname);
                    telemetrydata = RBRTelemetryFile.Parse.test2();
                    ToDistance.Get.Convert(columnsname, telemetrydata, run);
                    distance = ToDistance.Get.distance_int();
                    position_x_dist = ToDistance.Get.Position_x_dist(run);
                    position_y_dist = ToDistance.Get.Position_y_dist(run);
                    time_diff = ToDistance.Get.time_difference();
                }
                else goto End;

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

            double[] LF_deflectionVelocity = ConvertRawData.Damper(telemetrydata[columnsname.FindIndex("LF.deflectionVelocity".Equals)]);
            double[] RF_deflectionVelocity = ConvertRawData.Damper(telemetrydata[columnsname.FindIndex("RF.deflectionVelocity".Equals)]);
            double[] LB_deflectionVelocity = ConvertRawData.Damper(telemetrydata[columnsname.FindIndex("LB.deflectionVelocity".Equals)]);
            double[] RB_deflectionVelocity = ConvertRawData.Damper(telemetrydata[columnsname.FindIndex("RB.deflectionVelocity".Equals)]);

            double[] LF_deflection = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("LF.deflection".Equals)]);
            double[] RF_deflection = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("RF.deflection".Equals)]);
            double[] LB_deflection = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("LB.deflection".Equals)]);
            double[] RB_deflection = ConvertRawData.Suspension(telemetrydata[columnsname.FindIndex("RB.deflection".Equals)]);

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

            List<double[]> acc_1st_gear = new List<double[]>();
            List<double[]> acc_2st_gear = new List<double[]>();
            List<double[]> acc_3st_gear = new List<double[]>();
            List<double[]> acc_4st_gear = new List<double[]>();
            List<double[]> acc_5st_gear = new List<double[]>();
            List<double[]> acc_6st_gear = new List<double[]>();
            for (int i2 = 0; i2 < GForce_Y.Length; i2++)
            {
                if (GForce_Y[i2] < 0)
                {
                    double speed_double = speed[i2];
                    double G_Force_Y_double = -GForce_Y[i2];
                    double[] test = new double[2];
                    test[0] = speed_double;
                    test[1] = G_Force_Y_double;

                    if (Gear[i2] == 1)
                        acc_1st_gear.Add(test);
                    if (Gear[i2] == 2)
                        acc_2st_gear.Add(test);
                    if (Gear[i2] == 3)
                        acc_3st_gear.Add(test);
                    if (Gear[i2] == 4)
                        acc_4st_gear.Add(test);
                    if (Gear[i2] == 5)
                        acc_5st_gear.Add(test);
                    if (Gear[i2] == 6)
                        acc_6st_gear.Add(test);
                }
            }


                var Stage_time = RaceTime.ToString(raceTime.Max());

            for (int i = 0; i < driveLineLocation.Length; i++)
            {
                Speed_XYZ2[i] = Math.Sqrt(Math.Pow(Speed_X[i], 2) + Math.Pow(Speed_Y[i], 2) + Math.Pow(Speed_Z[i], 2)) * 3.6;
            }
            max_speed = Speed_XYZ2.Max();

            startparse = DateTime.Now.Ticks;
            if (run >= 2)
            {
                    start_x2 = (int)(position_x[0] * 100);
                    start_y2 = (int)(position_y[0] * 100);
                    stage_id_run2 = telemetrydata[columnsname.FindIndex("stage".Equals)][0];
                if (stage_id_run1 == stage_id_run2 && start_x == start_x2 && start_y2 == start_y2)
                {
                    Task.Run(() =>
                    {

                        var timediff = new OxyPlot.Series.LineSeries { Title = Stage_time } ;
                        for (int i = 0; i < distance.Count; i++)
                            timediff.Points.Add(new OxyPlot.DataPoint(distance[i], time_diff[i]));
                        TimeDiff_Model.Series.Add(timediff);
                    });
                }
                else
                {
                    //Speed_Model.Series.Clear();
                    //GForces_Model.Series.Clear();
                    //Engine_Model.Series.Clear();
                    //TimeDiff_Model.Series.Clear();
                    //RaceTrack_Model.Series.Clear();
                    //переделать на foreach
                    foreach (OxyPlot.PlotModel pm in PlotModels)
                    {
                        pm.Series.Clear();
                        pm.Annotations.Clear();
                    }
                    foreach (OxyPlot.PlotModel pm in HistogramModels)
                    {
                        pm.Series.Clear();
                        pm.Annotations.Clear();
                    }

                    //DamperLF_Histogram_Model.Annotations.Clear();
                    //DamperRF_Histogram_Model.Annotations.Clear();
                    //DamperLB_Histogram_Model.Annotations.Clear();
                    //DamperRF_Histogram_Model.Annotations.Clear();

                    for (int i = 1; i < run; i++)
                    {
                        testvalues.Columns.RemoveAt(1);
                    }
                    run = 1;
                }
            }


            if (run == 1)
            {
                start_x = (int)(position_x[0]*100);
                start_y = (int)(position_y[0]*100);
                stage_id_run1 = telemetrydata[columnsname.FindIndex("stage".Equals)][0];
                Task.Run(() =>
                {
                    var trl = new OxyPlot.Series.LineSeries();
                    for (int i = 0; i < driveLineLocation.Length; i++)
                        trl.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], position_z[i]));
                    var trlM = new OxyPlot.PlotModel{ PlotMargins = new OxyThickness(40, 0, 10, 20) };
                    //trlM.Series.Add(trl);
                    var areaSeries1 = new AreaSeries();
                    for (int i = 0; i < driveLineLocation.Length; i++)
                        areaSeries1.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], position_z[i]));
                    areaSeries1.ConstantY2 = position_z.Min();
                    trlM.Series.Add(areaSeries1);
                    TrackLeght_OP.Model = trlM;
                });
                var path = stagemapfolder + stage_id_run1 + "_" + start_x.ToString() + "_" + start_y.ToString() + ".tsv";
                if (File.Exists(path))
                {
                    StreamReader stagemap = new StreamReader(path);
                    double[] left_x = (from string coordinate in stagemap.ReadLine().Split('\t')
                                       let data = Double.Parse(coordinate)
                                       select data).ToArray();
                    double[] left_y = (from string coordinate in stagemap.ReadLine().Split('\t')
                                       let data = Double.Parse(coordinate)
                                       select data).ToArray();
                    double[] right_x = (from string coordinate in stagemap.ReadLine().Split('\t')
                                        let data = Double.Parse(coordinate)
                                        select data).ToArray();
                    double[] right_y = (from string coordinate in stagemap.ReadLine().Split('\t')
                                        let data = Double.Parse(coordinate)
                                        select data).ToArray();
                    var left = new OxyPlot.Series.LineSeries { Color = OxyPlot.OxyColors.Gray, StrokeThickness = 1, LineStyle = OxyPlot.LineStyle.LongDash };
                    var right = new OxyPlot.Series.LineSeries { Color = OxyPlot.OxyColors.Gray, StrokeThickness = 1 , LineStyle = OxyPlot.LineStyle.LongDash };
                    for (int i = 0; i < left_x.Length; i++)
                        left.Points.Add(new OxyPlot.DataPoint(left_x[i], left_y[i]));
                    for (int i = 0; i < right_x.Length; i++)
                        right.Points.Add(new OxyPlot.DataPoint(right_x[i], right_y[i]));
                    RaceTrack_Model.Series.Add(left);
                    RaceTrack_Model.Series.Add(right);
                }
                //Dampers Annotation
                DamperLF_Histogram_Model.Annotations.Add(LF_HS_Plus);
                DamperLF_Histogram_Model.Annotations.Add(LF_HS_Minus);
                DamperRB_Histogram_Model.Annotations.Add(RB_HS_Plus);
                DamperRB_Histogram_Model.Annotations.Add(RB_HS_Minus);
                DamperLB_Histogram_Model.Annotations.Add(LB_HS_Plus);
                DamperLB_Histogram_Model.Annotations.Add(LB_HS_Minus);
                DamperRF_Histogram_Model.Annotations.Add(RF_HS_Plus);
                DamperRF_Histogram_Model.Annotations.Add(RF_HS_Minus);
            }

            foreach (OxyPlot.PlotModel pm in PlotModels)
            {
                pm.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, IsAxisVisible = false });
                pm.PlotAreaBorderThickness = new OxyThickness(1, 0, 0, 0);
            }
            RaceTrack_Model.Axes.Add(new LinearAxis { Position = AxisPosition.Left, IsAxisVisible = false });
            RaceTrack_Model.PlotAreaBorderThickness = new OxyThickness(0, 0, 0, 0);

            Task[] Graph_Draw = new Task[12];

            Graph_Draw[0] =
            //Speed Model
            Task.Run(() =>
            {
                var speed_line = new OxyPlot.Series.LineSeries { Title = Stage_time };
                for (int i = 0; i < driveLineLocation.Length; i++)
                    speed_line.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], Speed_XYZ2[i]));
                Speed_Model.Series.Add(speed_line);
                var wheel_speed = new OxyPlot.Series.LineSeries { Title = "Wheel Speed", IsVisible = false };
                for (int i = 0; i < driveLineLocation.Length; i++)
                    wheel_speed.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], speed[i]));
                WS_Series.Add(wheel_speed);
                Speed_Model.Series.Add(WS_Series[WS_Series.Count -1]);
                Speed_Legend.ShowInvisibleSeries = false;

                //var geat1st_line = new OxyPlot.Series.ScatterSeries { Title = "1st" , MarkerType = MarkerType.Circle, MarkerSize = 3};
                //for (int i = 0; i < acc_1st_gear.Count; i++)
                //    geat1st_line.Points.Add(new OxyPlot.Series.ScatterPoint(acc_1st_gear[i][0], acc_1st_gear[i][1]));
                //Speed_Model.Series.Add(geat1st_line);
                //var geat2st_line = new OxyPlot.Series.ScatterSeries { Title = "2st", MarkerType = MarkerType.Circle, MarkerSize = 3 };
                //for (int i = 0; i < acc_2st_gear.Count; i++)
                //    geat2st_line.Points.Add(new OxyPlot.Series.ScatterPoint(acc_2st_gear[i][0], acc_2st_gear[i][1]));
                //Speed_Model.Series.Add(geat2st_line);
                //var geat3st_line = new OxyPlot.Series.ScatterSeries { Title = "3st", MarkerType = MarkerType.Circle, MarkerSize = 3 };
                //for (int i = 0; i < acc_3st_gear.Count; i++)
                //    geat3st_line.Points.Add(new OxyPlot.Series.ScatterPoint(acc_3st_gear[i][0], acc_3st_gear[i][1]));
                //Speed_Model.Series.Add(geat3st_line);
                //var geat4st_line = new OxyPlot.Series.ScatterSeries { Title = "4st", MarkerType = MarkerType.Circle, MarkerSize = 3 };
                //for (int i = 0; i < acc_4st_gear.Count; i++)
                //    geat4st_line.Points.Add(new OxyPlot.Series.ScatterPoint(acc_4st_gear[i][0], acc_4st_gear[i][1]));
                //Speed_Model.Series.Add(geat4st_line);
                //var geat5st_line = new OxyPlot.Series.ScatterSeries { Title = "5st", MarkerType = MarkerType.Circle, MarkerSize = 3 };
                //for (int i = 0; i < acc_5st_gear.Count; i++)
                //    geat5st_line.Points.Add(new OxyPlot.Series.ScatterPoint(acc_5st_gear[i][0], acc_5st_gear[i][1]));
                //Speed_Model.Series.Add(geat5st_line);
                //var geat6st_line = new OxyPlot.Series.ScatterSeries { Title = "6st", MarkerType = MarkerType.Circle, MarkerSize = 3 };
                //for (int i = 0; i < acc_6st_gear.Count; i++)
                //    geat6st_line.Points.Add(new OxyPlot.Series.ScatterPoint(acc_6st_gear[i][0], acc_6st_gear[i][1]));
                //Speed_Model.Series.Add(geat6st_line);
            });

            Graph_Draw[1] =
            //GForces Model
            Task.Run(() =>
            {
                var GForce_x = new OxyPlot.Series.LineSeries { Title = Stage_time +" | X" };
                var GForce_y = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Y" };
                for (int i = 0; i < driveLineLocation.Length; i++)
                {
                    GForce_x.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], GForce_X[i]));
                    GForce_y.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], GForce_Y[i]));
                }
                GForces_Model.Series.Add(GForce_x);
                GForces_Model.Series.Add(GForce_y);
            });

            Graph_Draw[2] =
            //Engine Model
            Task.Run(() =>
            {
                const string keyAxisY_Gear = "axisY_Gear";
                const string keyAxisY_RPM = "axisY_RPM";
                var RPMs = new OxyPlot.Series.LineSeries { Title = Stage_time + " | RPM", YAxisKey = keyAxisY_RPM };
                var Gears = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Gear", YAxisKey = keyAxisY_Gear};
               
                for (int i = 0; i < driveLineLocation.Length; i++)
                {
                    RPMs.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], engineRotation[i]));
                    Gears.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], Gear[i]));
                }
                Engine_Model.Series.Add(RPMs);
                Engine_Model.Series.Add(Gears);
                if (run == 1)
                {
                    LinearAxis AxisY_Gear = null;
                    AxisY_Gear = new LinearAxis()
                    {
                        //Title = "Gear",
                        Position = AxisPosition.Left,
                        MajorGridlineStyle = OxyPlot.LineStyle.None,
                        PositionTier = 1,
                        Key = keyAxisY_Gear,
                        IsAxisVisible = false,
                        Maximum = 6,
                        Minimum = 0
                    };
                    LinearAxis AxisY_RPM = null;
                    AxisY_RPM = new LinearAxis()
                    {
                        //Title = "RPM",
                        Position = AxisPosition.Left,
                        MajorGridlineStyle = OxyPlot.LineStyle.None,
                        PositionTier = 0,
                        Key = keyAxisY_RPM,
                        IsAxisVisible = true,
                    };
                    Engine_Model.Axes.Add(AxisY_Gear);
                    Engine_Model.Axes.Add(AxisY_RPM);
                }
                
            });

            Graph_Draw[3] =
            // RaceTrack Model
            Task.Run(() =>
            {
                var stage_map = new OxyPlot.Series.LineSeries { Title = Stage_time, };//StrokeThickness = 1 };

                for (int i = 0; i < position_x_dist.Count; i++)
                {
                    stage_map.Points.Add(new OxyPlot.DataPoint(position_x_dist[i], position_y_dist[i]));
                }
                RaceTrack_Model.Series.Add(stage_map);
            });

            //TyrePressure
            Graph_Draw[4] =
            Task.Run(() =>
            {
                var TyrePressure_LF = new OxyPlot.Series.LineSeries { Title = Stage_time };
                for (int i = 0; i < driveLineLocation.Length; i++)
                {
                    TyrePressure_LF.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LF_pressure[i]));
                }
                TyrePressureLF_Model.Series.Add(TyrePressure_LF);

            });
            Graph_Draw[5] =
            Task.Run(() =>
            {
                var TyrePressure_RF = new OxyPlot.Series.LineSeries { Title = Stage_time };
                for (int i = 0; i < driveLineLocation.Length; i++)
                {
                    TyrePressure_RF.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RF_pressure[i]));
                }
                TyrePressureRF_Model.Series.Add(TyrePressure_RF);
            });
            Graph_Draw[6] =
            Task.Run(() =>
            {
                var TyrePressure_LB = new OxyPlot.Series.LineSeries { Title = Stage_time };
                for (int i = 0; i < driveLineLocation.Length; i++)
                {
                    TyrePressure_LB.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LB_pressure[i]));
                }
                TyrePressureLB_Model.Series.Add(TyrePressure_LB);
            }); 
            Graph_Draw[7] =
             Task.Run(() =>
             {
                 var TyrePressure_RB = new OxyPlot.Series.LineSeries { Title = Stage_time };
                 for (int i = 0; i < driveLineLocation.Length; i++)
                 {
                     TyrePressure_RB.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RB_pressure[i]));
                 }
                 TyrePressureRB_Model.Series.Add(TyrePressure_RB);
             });

            //TyreTemps
            Graph_Draw[8] =
             Task.Run(() =>
             {
                 var TyreTemps_LF_air = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Air" };
                 var TyreTemps_LF_tyre = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Tyre" };
                 var TyreTemps_LF_thread = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Thread" };
                 for (int i = 0; i < driveLineLocation.Length; i++)
                 {
                     TyreTemps_LF_air.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LF_temperature[i]));
                     TyreTemps_LF_tyre.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LF_tyreTemperature[i]));
                     TyreTemps_LF_thread.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LF_treadTemperature[i]));
                 }
                 TyreTempsLF_Model.Series.Add(TyreTemps_LF_air);
                 TyreTempsLF_Model.Series.Add(TyreTemps_LF_tyre);
                 TyreTempsLF_Model.Series.Add(TyreTemps_LF_thread);
             });
            Graph_Draw[9] =
             Task.Run(() =>
             {
                 var TyreTemps_RF_air = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Air" };
                 var TyreTemps_RF_tyre = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Tyre" };
                 var TyreTemps_RF_thread = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Thread" };
                 for (int i = 0; i < driveLineLocation.Length; i++)
                 {
                     TyreTemps_RF_air.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RF_temperature[i]));
                     TyreTemps_RF_tyre.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RF_tyreTemperature[i]));
                     TyreTemps_RF_thread.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RF_treadTemperature[i]));
                 }
                 TyreTempsRF_Model.Series.Add(TyreTemps_RF_air);
                 TyreTempsRF_Model.Series.Add(TyreTemps_RF_tyre);
                 TyreTempsRF_Model.Series.Add(TyreTemps_RF_thread);
             });
            Graph_Draw[10] =
             Task.Run(() =>
             {
                 var TyreTemps_LB_air = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Air" };
                 var TyreTemps_LB_tyre = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Tyre" };
                 var TyreTemps_LB_thread = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Thread" };
                 for (int i = 0; i < driveLineLocation.Length; i++)
                 {
                     TyreTemps_LB_air.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LB_temperature[i]));
                     TyreTemps_LB_tyre.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LB_tyreTemperature[i]));
                     TyreTemps_LB_thread.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], LB_treadTemperature[i]));
                 }
                 TyreTempsLB_Model.Series.Add(TyreTemps_LB_air);
                 TyreTempsLB_Model.Series.Add(TyreTemps_LB_tyre);
                 TyreTempsLB_Model.Series.Add(TyreTemps_LB_thread);
             });
            Graph_Draw[11] =
             Task.Run(() =>
             {
                 var TyreTemps_RB_air = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Air" };
                 var TyreTemps_RB_tyre = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Tyre" };
                 var TyreTemps_RB_thread = new OxyPlot.Series.LineSeries { Title = Stage_time + " | Thread" };
                 for (int i = 0; i < driveLineLocation.Length; i++)
                 {
                     TyreTemps_RB_air.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RB_temperature[i]));
                     TyreTemps_RB_tyre.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RB_tyreTemperature[i]));
                     TyreTemps_RB_thread.Points.Add(new OxyPlot.DataPoint(driveLineLocation[i], RB_treadTemperature[i]));
                 }
                 TyreTempsRB_Model.Series.Add(TyreTemps_RB_air);
                 TyreTempsRB_Model.Series.Add(TyreTemps_RB_tyre);
                 TyreTempsRB_Model.Series.Add(TyreTemps_RB_thread);
             });


            Task.WaitAll(Graph_Draw);

            //TyrePressureLF_OP.Model = DrawModels.Line(TyreTempsLF_Model, "driveLineLocation", "LF_pressure", columnsname, telemetrydata);
            //TyrePressureLF_OP.Model = DrawModels.Line(TyrePressureLF_OP.Model, driveLineLocation, LF_pressure, Stage_time);

            //HistogramADD
            TyrePressureLF_Histogram_Model = DrawModels.Histogram(TyrePressureLF_Histogram_Model, LF_pressure.ToList(), Stage_time);
            TyrePressureRF_Histogram_Model = DrawModels.Histogram(TyrePressureRF_Histogram_Model, RF_pressure.ToList(), Stage_time);
            TyrePressureLB_Histogram_Model = DrawModels.Histogram(TyrePressureLB_Histogram_Model, LB_pressure.ToList(), Stage_time);
            TyrePressureRB_Histogram_Model = DrawModels.Histogram(TyrePressureRB_Histogram_Model, RB_pressure.ToList(), Stage_time);

            TyreTempsLF_Histogram_Model = DrawModels.Histogram(TyreTempsLF_Histogram_Model, LF_tyreTemperature.ToList(), Stage_time);
            TyreTempsRF_Histogram_Model = DrawModels.Histogram(TyreTempsRF_Histogram_Model, RF_tyreTemperature.ToList(), Stage_time);
            TyreTempsLB_Histogram_Model = DrawModels.Histogram(TyreTempsLB_Histogram_Model, LB_tyreTemperature.ToList(), Stage_time);
            TyreTempsRB_Histogram_Model = DrawModels.Histogram(TyreTempsRB_Histogram_Model, RB_tyreTemperature.ToList(), Stage_time);

            //Suspension
            SuspensionLF_Model = DrawModels.Line(SuspensionLF_Model, "driveLineLocation", "LF.deflection", columnsname, telemetrydata, Stage_time);
            SuspensionRF_Model = DrawModels.Line(SuspensionRF_Model, "driveLineLocation", "RF.deflection", columnsname, telemetrydata, Stage_time);
            SuspensionLB_Model = DrawModels.Line(SuspensionLB_Model, "driveLineLocation", "LB.deflection", columnsname, telemetrydata, Stage_time);
            SuspensionRB_Model = DrawModels.Line(SuspensionRB_Model, "driveLineLocation", "RB.deflection", columnsname, telemetrydata, Stage_time);

            SuspensionLF_Histogram_Model = DrawModels.Histogram(SuspensionLF_Histogram_Model, LF_deflection.ToList(), Stage_time);
            SuspensionRF_Histogram_Model = DrawModels.Histogram(SuspensionRF_Histogram_Model, RF_deflection.ToList(), Stage_time);
            SuspensionLB_Histogram_Model = DrawModels.Histogram(SuspensionLB_Histogram_Model, LB_deflection.ToList(), Stage_time);
            SuspensionRB_Histogram_Model = DrawModels.Histogram(SuspensionRB_Histogram_Model, RB_deflection.ToList(), Stage_time);

            //Dampers
            DamperLF_Model = DrawModels.Line(DamperLF_Model, "driveLineLocation", "LF.deflectionVelocity", columnsname, telemetrydata, Stage_time);
            DamperRF_Model = DrawModels.Line(DamperRF_Model, "driveLineLocation", "RF.deflectionVelocity", columnsname, telemetrydata, Stage_time);
            DamperLB_Model = DrawModels.Line(DamperLB_Model, "driveLineLocation", "LB.deflectionVelocity", columnsname, telemetrydata, Stage_time);
            DamperRB_Model = DrawModels.Line(DamperRB_Model, "driveLineLocation", "RB.deflectionVelocity", columnsname, telemetrydata, Stage_time);


            var firs_index = Array.LastIndexOf(driveLineLocation, driveLineLocation[1]);
            var last_index = Array.IndexOf(raceTime, raceTime.Last());
            List<double> Remove_start_stop (double[] values)
            {
                List<double> Test = new List<double>();
                Test.AddRange(values);
                Test.RemoveRange(last_index, Test.Count - last_index);
                Test.RemoveRange(0, firs_index);
                return Test;
            }

            
            DamperRF_Histogram_Model = DrawModels.Histogram(DamperRF_Histogram_Model, Remove_start_stop(RF_deflectionVelocity), 300, Stage_time);
            DamperLB_Histogram_Model = DrawModels.Histogram(DamperLB_Histogram_Model, Remove_start_stop(LB_deflectionVelocity),300, Stage_time);
            DamperRB_Histogram_Model = DrawModels.Histogram(DamperRB_Histogram_Model, Remove_start_stop(RB_deflectionVelocity).ToList(),300, Stage_time);
            DamperLF_Histogram_Model = DrawModels.Histogram(DamperLF_Histogram_Model, Remove_start_stop(LF_deflectionVelocity).ToList(),300, Stage_time);
            





            max_rpm = engineRotation.Max();
            racetime = raceTime.Max();
            var racetime_index = Array.IndexOf(raceTime, racetime);
            

            endparse = DateTime.Now.Ticks;
            var endTime = DateTime.Now.Ticks;
            var test12345 = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
            var startposition = test12345[1];
            trackleght = (int)((driveLineLocation[racetime_index]) - startposition);
            var lastindex = Array.LastIndexOf(test12345, startposition);
            //var racestart = telemetrydata[columnsname.FindIndex("raceTime".Equals)][lastindex];
            var racestart = ReactionTime.GetTime(telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray(), telemetrydata[columnsname.FindIndex("speed".Equals)].ToArray());
            double endtime2 = (double)(endTime);
            double starttime2 = (double)(starttime);
            double timerun = (endtime2 - starttime2) / 10000000;
            double parserun = ((double)endparse - (double)startparse) / 10000000;

            

            testvalues.Columns.Add(RaceTime.ToString(raceTime.Max()));
            testvalues.Rows[0][run] = racestart;
            testvalues.Rows[1][run] = max_speed.ToString("0.0");
            testvalues.Rows[2][run] = test12345.Max();
            testvalues.Rows[3][run] = max_rpm;
            testvalues.Rows[4][run] = timerun;
            testvalues.Rows[5][run] = trackleght;
            //testvalues.Rows[5][run] = Application.CurrentCulture.Name.ToString();
            bool test1234 = true;
            testvalues.Rows[6][run] = parserun;
            dataGridView1.DataSource = testvalues;
            stage_id = telemetrydata[columnsname.FindIndex("stage".Equals)][0].ToString();

            
            if (run == 2 && start_x == start_x2 && start_y == start_y2 && stage_id_run1 == stage_id_run2)
                saveToolStripMenuItem.Enabled = true;
            else saveToolStripMenuItem.Enabled = false;

            

            //RBRTelemetryFile.Parse.ClearData();
            TyreWear.Clear();

            //Graph Update
            //Speed_Plot.OnModelChanged();
            //GForces_Plot.OnModelChanged();
            //Engine_Plot.OnModelChanged();
            //TimeDiff_Plot.OnModelChanged();
            //RaceTrack_OP.OnModelChanged();

            //TyrePressureLF_OP.OnModelChanged();
            //TyrePressureRF_OP.OnModelChanged();
            //TyrePressureLB_OP.OnModelChanged();
            //TyrePressureRB_OP.OnModelChanged();

            //TyreTempsLF_OP.OnModelChanged();
            //TyreTempsRF_OP.OnModelChanged();
            //TyreTempsLB_OP.OnModelChanged();
            //TyreTempsRB_OP.OnModelChanged();

            foreach (OxyPlot.WindowsForms.PlotView pv in plotViews)
                pv.OnModelChanged();


            run++;
            
        End: openFileToolStripMenuItem.Enabled = true ;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void saveLeftSideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = stagemapfolder + stage_id + "_left.tsv";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(String.Join("\t", position_x_dist));
            sw.WriteLine(String.Join("\t", position_y_dist));
            sw.Dispose();
            sw.Close();
        }

        private void saveRightSideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var path = stagemapfolder + stage_id + "_right.tsv";
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(String.Join("\t", position_x_dist));
            sw.WriteLine(String.Join("\t", position_y_dist));
            sw.Dispose();
            sw.Close();            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (run == 3 && start_x == start_x2 && start_y == start_y2)
            //{
                var path = stagemapfolder + stage_id + "_" + start_x.ToString() + "_" + start_y.ToString() + ".tsv";
                StreamWriter sw = new StreamWriter(path);
                //sw.WriteLine(stage_id.ToString() + "\t" + start_x.ToString() + "\t" + start_y.ToString() + "\t" + trackleght.ToString());
                sw.WriteLine(String.Join("\t", ToDistance.Get.left_x()));
                sw.WriteLine(String.Join("\t", ToDistance.Get.left_y()));
                sw.WriteLine(String.Join("\t", ToDistance.Get.right_x()));
                sw.WriteLine(String.Join("\t", ToDistance.Get.right_y()));
                sw.Dispose();
                sw.Close();
            //}
            //else
            //{
            //    MessageBox.Show("dolboeb");
            //}
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TyrePressureLF_OP.Location = new Point(0, 0);
            TyrePressureLF_OP.Size = new Size(1200, 150);
            TyrePressureLF_OP.Model = TyrePressureLF_Model;
            TyrePressureRF_OP.Location = new Point(0, 150);
            TyrePressureRF_OP.Size = new Size(1200, 150);
            TyrePressureRF_OP.Model = TyrePressureRF_Model;
            TyrePressureLB_OP.Location = new Point(0, 300);
            TyrePressureLB_OP.Size = new Size(1200, 150);
            TyrePressureLB_OP.Model = TyrePressureLB_Model;
            TyrePressureRB_OP.Location = new Point(0, 450);
            TyrePressureRB_OP.Size = new Size(1200, 150);
            TyrePressureRB_OP.Model = TyrePressureRB_Model;

            lineToolStripMenuItem.Checked = true;
            histogramToolStripMenuItem.Checked = false;

        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TyrePressureLF_OP.Location = new Point(0, 0);
            TyrePressureLF_OP.Size = new Size(600, 300);
            TyrePressureLF_OP.Model = TyrePressureLF_Histogram_Model;
            TyrePressureRF_OP.Location = new Point(600, 0);
            TyrePressureRF_OP.Size = new Size(600, 300);
            TyrePressureRF_OP.Model = TyrePressureRF_Histogram_Model;
            TyrePressureLB_OP.Location = new Point(0, 300);
            TyrePressureLB_OP.Size = new Size(600, 300);
            TyrePressureLB_OP.Model = TyrePressureLB_Histogram_Model;
            TyrePressureRB_OP.Location = new Point(600, 300);
            TyrePressureRB_OP.Size = new Size(600, 300);
            TyrePressureRB_OP.Model = TyrePressureRB_Histogram_Model;

            lineToolStripMenuItem.Checked = false;
                histogramToolStripMenuItem.Checked = true;
        }

        private void lineToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            TyreTempsLF_OP.Location = new Point(0, 0);
            TyreTempsLF_OP.Size = new Size(1200, 150);
            TyreTempsLF_OP.Model = TyreTempsLF_Model;
            TyreTempsRF_OP.Location = new Point(0, 150);
            TyreTempsRF_OP.Size = new Size(1200, 150);
            TyreTempsRF_OP.Model = TyreTempsRF_Model;
            TyreTempsLB_OP.Location = new Point(0, 300);
            TyreTempsLB_OP.Size = new Size(1200, 150);
            TyreTempsLB_OP.Model = TyreTempsLB_Model;
            TyreTempsRB_OP.Location = new Point(0, 450);
            TyreTempsRB_OP.Size = new Size(1200, 150);
            TyreTempsRB_OP.Model = TyreTempsRB_Model;

            lineToolStripMenuItem1.Checked = true;
            histogramToolStripMenuItem1.Checked = false;
        }

        private void histogramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TyreTempsLF_OP.Location = new Point(0, 0);
            TyreTempsLF_OP.Size = new Size(600, 300);
            TyreTempsLF_OP.Model = TyreTempsLF_Histogram_Model;
            TyreTempsRF_OP.Location = new Point(600, 0);
            TyreTempsRF_OP.Size = new Size(600, 300);
            TyreTempsRF_OP.Model = TyreTempsRF_Histogram_Model;
            TyreTempsLB_OP.Location = new Point(0, 300);
            TyreTempsLB_OP.Size = new Size(600, 300);
            TyreTempsLB_OP.Model = TyreTempsLB_Histogram_Model;
            TyreTempsRB_OP.Location = new Point(600, 300);
            TyreTempsRB_OP.Size = new Size(600, 300);
            TyreTempsRB_OP.Model = TyreTempsRB_Histogram_Model;

            lineToolStripMenuItem1.Checked = false;
            histogramToolStripMenuItem1.Checked = true;
        }

        private void addWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string tabname = " ";
            tabControl1.TabPages.Add(tabname);
            var tabnumber = tabControl1.TabPages.Count;
            var tabid = tabnumber - 2;
            var newtab = tabControl1.TabPages[tabnumber-1];
            newtab.Location = new System.Drawing.Point(4, 25);
            newtab.Name = "tabPage" + tabnumber.ToString();
            newtab.Size = new System.Drawing.Size(1200, 597);
            newtab.TabIndex = tabnumber - 1;
            newtab.Text = "tabPage" + tabnumber.ToString();
            newtab.UseVisualStyleBackColor = true;
            var test_op_1 = new OxyPlot.WindowsForms.PlotView();
            var test_op_2 = new OxyPlot.WindowsForms.PlotView();
            var test_op_3 = new OxyPlot.WindowsForms.PlotView();
            var test_op_4 = new OxyPlot.WindowsForms.PlotView();

            newtab.Controls.Add(test_op_1);
            newtab.Controls.Add(test_op_2);
            newtab.Controls.Add(test_op_3);
            newtab.Controls.Add(test_op_4);

            // TyreTempsLF_OP
            // 
            test_op_1.Location = new System.Drawing.Point(0, 0);
            test_op_1.Name = "test_op_1";
            test_op_1.PanCursor = System.Windows.Forms.Cursors.Hand;
            test_op_1.Size = new System.Drawing.Size(1200, 150);
            //test_op_1.TabIndex = 8;
            test_op_1.Text = "test_op_1";
            test_op_1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            test_op_1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            test_op_1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;

            // TyreTempsRF_OP
            // 
            test_op_2.Location = new System.Drawing.Point(0, 150);
            test_op_2.Name = "test_op_2";
            test_op_2.PanCursor = System.Windows.Forms.Cursors.Hand;
            test_op_2.Size = new System.Drawing.Size(1200, 150);
            //test_op_2.TabIndex = 9;
            test_op_2.Text = "test_op_2";
            test_op_2.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            test_op_2.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            test_op_2.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 

            // TyreTempsLB_OP
            // 
            test_op_3.Location = new System.Drawing.Point(0, 300);
            test_op_3.Name = "test_op_3";
            test_op_3.PanCursor = System.Windows.Forms.Cursors.Hand;
            test_op_3.Size = new System.Drawing.Size(1200, 150);
            //test_op_3.TabIndex = 10;
            test_op_3.Text = "test_op_3";
            test_op_3.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            test_op_3.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            test_op_3.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 


            // 
            // TyreTempsRB_OP
            // 
            test_op_4.Location = new System.Drawing.Point(0, 450);
            test_op_4.Name = "test_op_4";
            test_op_4.PanCursor = System.Windows.Forms.Cursors.Hand;
            test_op_4.Size = new System.Drawing.Size(1200, 150);
            test_op_4.TabIndex = 11;
            test_op_4.Text = "test_op_4";
            test_op_4.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            test_op_4.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            test_op_4.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 

            PlotModel test_op_1_Model = new PlotModel();
            PlotModel test_op_2_Model = new PlotModel();
            PlotModel test_op_3_Model = new PlotModel();
            PlotModel test_op_4_Model = new PlotModel();

            new Form2().ShowDialog();

            //Task.Run(() =>
            //{
            //    var test_op1_graph = new OxyPlot.Series.LineSeries();
            //    for (int i = 0; i < telemetrydata[columnsname.FindIndex(user_workspace[0].Equals)].Count; i++)
            //    {
            //        test_op1_graph.Points.Add(new OxyPlot.DataPoint(telemetrydata[columnsname.FindIndex(user_workspace[0].Equals)][i], telemetrydata[columnsname.FindIndex(user_workspace[1].Equals)][i]));
            //    }
            //    test_op_1_Model.Series.Add(test_op1_graph);
            //});

            //Task.Run(() =>
            //{
            //    var test_op2_graph = new OxyPlot.Series.LineSeries();
            //    for (int i = 0; i < telemetrydata[columnsname.FindIndex(user_workspace[0].Equals)].Count; i++)
            //    {
            //        test_op2_graph.Points.Add(new OxyPlot.DataPoint(telemetrydata[columnsname.FindIndex(user_workspace[2].Equals)][i], telemetrydata[columnsname.FindIndex(user_workspace[3].Equals)][i]));
            //    }
            //    test_op_2_Model.Series.Add(test_op2_graph);
            //});
            //Task.Run(() =>
            //{
            //    var test_op3_graph = new OxyPlot.Series.LineSeries();
            //    for (int i = 0; i < telemetrydata[columnsname.FindIndex(user_workspace[0].Equals)].Count; i++)
            //    {
            //        test_op3_graph.Points.Add(new OxyPlot.DataPoint(telemetrydata[columnsname.FindIndex(user_workspace[4].Equals)][i], telemetrydata[columnsname.FindIndex(user_workspace[5].Equals)][i]));
            //    }
            //    test_op_3_Model.Series.Add(test_op3_graph);
            //});
            //Task.Run(() =>
            //{
            //    var test_op4_graph = new OxyPlot.Series.LineSeries();
            //    for (int i = 0; i < telemetrydata[columnsname.FindIndex(user_workspace[0].Equals)].Count; i++)
            //    {
            //        test_op4_graph.Points.Add(new OxyPlot.DataPoint(telemetrydata[columnsname.FindIndex(user_workspace[6].Equals)][i], telemetrydata[columnsname.FindIndex(user_workspace[7].Equals)][i]));
            //    }
            //    test_op_4_Model.Series.Add(test_op4_graph);
            //});


           test_op_1.Model = DrawModels.Line(test_op_1.Model, user_workspace[0], user_workspace[1], columnsname, telemetrydata);
           test_op_2.Model = DrawModels.Line(test_op_2.Model, user_workspace[2], user_workspace[3], columnsname, telemetrydata);
           test_op_3.Model = DrawModels.Line(test_op_3.Model, user_workspace[4], user_workspace[5], columnsname, telemetrydata);
           test_op_4.Model = DrawModels.Line(test_op_4.Model, user_workspace[6], user_workspace[7], columnsname, telemetrydata);

        }

        private void Suspension_Lines_Menu__Click(object sender, EventArgs e)
        {
            SuspensionLF_OP.Location = new Point(0, 0);
            SuspensionRF_OP.Location = new Point(0, 150);
            SuspensionLB_OP.Location = new Point(0, 300);
            SuspensionRB_OP.Location = new Point(0, 450);
            SuspensionLF_OP.Size = new Size(1200, 150);
            SuspensionRF_OP.Size = new Size(1200, 150);
            SuspensionLB_OP.Size = new Size(1200, 150);
            SuspensionRB_OP.Size = new Size(1200, 150);
            SuspensionLF_OP.Model = SuspensionLF_Model;
            SuspensionRF_OP.Model = SuspensionRF_Model;
            SuspensionLB_OP.Model = SuspensionLB_Model;
            SuspensionRB_OP.Model = SuspensionRB_Model;

            Suspension_Lines_Menu.Checked = true;
            Suspension_Histogram_Menu.Checked = false;
        }

        private void Suspension_Histogram_Menu_Click(object sender, EventArgs e)
        {
            SuspensionLF_OP.Location = new Point(0, 0);
            SuspensionRF_OP.Location = new Point(600, 0);
            SuspensionLB_OP.Location = new Point(0, 300);
            SuspensionRB_OP.Location = new Point(600, 300);
            SuspensionLF_OP.Size = new Size(600, 300);
            SuspensionRF_OP.Size = new Size(600, 300);
            SuspensionLB_OP.Size = new Size(600, 300);
            SuspensionRB_OP.Size = new Size(600, 300);
            SuspensionLF_OP.Model = SuspensionLF_Histogram_Model;
            SuspensionRF_OP.Model = SuspensionRF_Histogram_Model;
            SuspensionLB_OP.Model = SuspensionLB_Histogram_Model;
            SuspensionRB_OP.Model = SuspensionRB_Histogram_Model;

            Suspension_Lines_Menu.Checked = false;
            Suspension_Histogram_Menu.Checked = true;
        }

        private void Dampers_Lines_Menu_Click(object sender, EventArgs e)
        {
            DamperLF_OP.Location = new Point(0, 0);
            DamperRF_OP.Location = new Point(0, 150);
            DamperLB_OP.Location = new Point(0, 300);
            DamperRB_OP.Location = new Point(0, 450);
            DamperLF_OP.Size = new Size(1200, 150);
            DamperRF_OP.Size = new Size(1200, 150);
            DamperLB_OP.Size = new Size(1200, 150);
            DamperRB_OP.Size = new Size(1200, 150);
            DamperLF_OP.Model = DamperLF_Model;
            DamperRF_OP.Model = DamperRF_Model;
            DamperLB_OP.Model = DamperLB_Model;
            DamperRB_OP.Model = DamperRB_Model;

            Dampers_Lines_Menu.Checked = true;
            Dampers_Histogram_Menu.Checked = false;
        }

        private void Dampers_Histrogram_Menu_Click(object sender, EventArgs e)
        {
            DamperLF_OP.Location = new Point(0, 0);
            DamperRF_OP.Location = new Point(600, 0);
            DamperLB_OP.Location = new Point(0, 300);
            DamperRB_OP.Location = new Point(600, 300);
            DamperLF_OP.Size = new Size(600, 300);
            DamperRF_OP.Size = new Size(600, 300);
            DamperLB_OP.Size = new Size(600, 300);
            DamperRB_OP.Size = new Size(600, 300);
            DamperLF_OP.Model = DamperLF_Histogram_Model;
            DamperRF_OP.Model = DamperRF_Histogram_Model;
            DamperLB_OP.Model = DamperLB_Histogram_Model;
            DamperRB_OP.Model = DamperRB_Histogram_Model;

            Dampers_Lines_Menu.Checked = false;
            Dampers_Histogram_Menu.Checked = true;
        }

        private void Show_WheelSpeed_Menu_Click(object sender, EventArgs e)
        {
            if (Show_WheelSpeed_Menu.Checked != true)
            {
                Show_WheelSpeed_Menu.Checked = true;
                foreach (OxyPlot.Series.LineSeries ws_ls in WS_Series)
                    ws_ls.IsVisible = true;
                Speed_Legend.ShowInvisibleSeries = true;                
                Speed_Plot.OnModelChanged();
            }
            else
            {
                Show_WheelSpeed_Menu.Checked = false;
                foreach (OxyPlot.Series.LineSeries ws_ls in WS_Series)
                    ws_ls.IsVisible = false;
                Speed_Legend.ShowInvisibleSeries = false;
                Speed_Plot.OnModelChanged();
            }
        }

        private void Front_Bump_Treshold_TextChanged(object sender, EventArgs e)
        {
            int bump_threshold;
            Int32.TryParse(Front_Bump_Treshold.Text, out bump_threshold);
                RF_HS_Minus.X = -bump_threshold;
                RF_HS_Plus.X = bump_threshold;
                LF_HS_Minus.X = -bump_threshold;
                LF_HS_Plus.X = bump_threshold;
            if (bump_threshold == 0)
            {
                DamperLF_Histogram_Model.Annotations.Clear();
                DamperRF_Histogram_Model.Annotations.Clear();
            }
            if(DamperLF_Histogram_Model.Annotations.Count == 0 && bump_threshold != 0)
            { 
                DamperLF_Histogram_Model.Annotations.Add(LF_HS_Minus);
                DamperLF_Histogram_Model.Annotations.Add(LF_HS_Plus);
            }
            if (DamperRF_Histogram_Model.Annotations.Count == 0 && bump_threshold != 0)
            {
                DamperRF_Histogram_Model.Annotations.Add(RF_HS_Minus);
                DamperRF_Histogram_Model.Annotations.Add(RF_HS_Plus);
            }

            DamperRF_OP.OnModelChanged();
            DamperLF_OP.OnModelChanged();
        }

        private void Rear_Bump_Treshold_TextChanged(object sender, EventArgs e)
        {
            int bump_threshold;
            Int32.TryParse(Rear_Bump_Treshold.Text, out bump_threshold);
            RB_HS_Minus.X = -bump_threshold;
            RB_HS_Plus.X = bump_threshold;
            LB_HS_Minus.X = -bump_threshold;
            LB_HS_Plus.X = bump_threshold;

            if (bump_threshold == 0)
            {
                DamperLB_Histogram_Model.Annotations.Clear();
                DamperRB_Histogram_Model.Annotations.Clear();
            }
            if (DamperLB_Histogram_Model.Annotations.Count == 0 && bump_threshold != 0)
            {
                DamperLB_Histogram_Model.Annotations.Add(LB_HS_Minus);
                DamperLB_Histogram_Model.Annotations.Add(LB_HS_Plus);
            }
            if (DamperRB_Histogram_Model.Annotations.Count == 0 && bump_threshold != 0)
            {
                DamperRB_Histogram_Model.Annotations.Add(RB_HS_Minus);
                DamperRB_Histogram_Model.Annotations.Add(RB_HS_Plus);
            }

            DamperRB_OP.OnModelChanged();
            DamperLB_OP.OnModelChanged();
        }


        private void TrackLeght_OP_Zoom_Changed(object sender, EventArgs e)
        {
            if (TrackLeght_OP.Model != null)// && TrackLeght_OP.Model.Series != null)
            {
                int yyyy;
                Int32.TryParse(label1.Text, out yyyy);
                yyyy++;
                label1.Text = yyyy.ToString();

                var min = TrackLeght_OP.Model.Axes[0].ActualMinimum;
                var max = TrackLeght_OP.Model.Axes[0].ActualMaximum;
                var center = (int)(max + min) / 2;
                var delta = (int)(max - min) / 4;
                
                label1.Text = (position_x_dist[center] - delta).ToString() + " | " + (position_x_dist[center] + delta).ToString() + "\n " + (position_y_dist[center] - delta).ToString() + " | " + (position_y_dist[center] + delta).ToString() 
                    + "\n" + RaceTrack_OP.Model.Axes[0].ActualMinimum.ToString() + " | " + RaceTrack_OP.Model.Axes[0].ActualMaximum.ToString() + " \n " + RaceTrack_OP.Model.Axes[1].ActualMinimum.ToString() + " | " + RaceTrack_OP.Model.Axes[1].ActualMaximum.ToString() + " | "
                    ;
                foreach (OxyPlot.PlotModel pm in PlotModels)
                {
                    //Task.Run(() => pm.Axes[0].Zoom(min, max));
                    pm.Axes[0].Zoom(min, max);
                }
                RaceTrack_OP.Model.Axes[0].Zoom(position_x_dist[center] - delta, position_x_dist[center] + delta);
                RaceTrack_OP.Model.Axes[1].Zoom(position_y_dist[center] - delta, position_y_dist[center] + delta);
                foreach (OxyPlot.WindowsForms.PlotView pv in plotViews)
                {
                    Task.Run(() => pv.OnModelChanged());
                    //pv.OnModelChanged();
                }
            }
        }
    }

    }
