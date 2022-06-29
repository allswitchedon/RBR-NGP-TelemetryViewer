using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    internal class DrawModels
    {
        public static OxyPlot.PlotModel Line(OxyPlot.PlotModel model, string x,string y, List<string> columnsname, List<List<double>> telemetrydata)
        {
            var line_model = new OxyPlot.PlotModel();
            if (model != null)
            line_model = model;
            var line_series = new OxyPlot.Series.LineSeries(); 
            for (int i = 0; i < telemetrydata[columnsname.FindIndex(x.Equals)].Count; i++)
            {
                line_series.Points.Add(new OxyPlot.DataPoint(telemetrydata[columnsname.FindIndex(x.Equals)][i], telemetrydata[columnsname.FindIndex(y.Equals)][i]));
            }

            line_model.Series.Add(line_series);
            return line_model;
        }

        public static OxyPlot.PlotModel Line(OxyPlot.PlotModel model, string x, string y, List<string> columnsname, List<List<double>> telemetrydata, string title)
        {
            var line_model = new OxyPlot.PlotModel();
            if (model != null)
                line_model = model;
            var line_series = new OxyPlot.Series.LineSeries { Title = title };
            for (int i = 0; i < telemetrydata[columnsname.FindIndex(x.Equals)].Count; i++)
            {
                line_series.Points.Add(new OxyPlot.DataPoint(telemetrydata[columnsname.FindIndex(x.Equals)][i], telemetrydata[columnsname.FindIndex(y.Equals)][i]));
            }

            line_model.Series.Add(line_series);
            return line_model;
        }

        public static OxyPlot.PlotModel Line(OxyPlot.PlotModel model, double[] X_axis, double[] Y_axis, string title)
        {
            var line_model = new OxyPlot.PlotModel();
            if (model != null)
                line_model = model;
            var line_series = new OxyPlot.Series.LineSeries { Title = title };
            for (int i = 0; i < X_axis.Length; i++)
            {
                line_series.Points.Add(new OxyPlot.DataPoint(X_axis[i], Y_axis[i]));
            }

            line_model.Series.Add(line_series);
            return line_model;
        }

        public static OxyPlot.PlotModel Histogram(OxyPlot.PlotModel model, List<double> samples, string title)
        {
            var histogram_model = new PlotModel();
            if (model != null)
                histogram_model = model;

            var histogram = new OxyPlot.Series.HistogramSeries { Title = title };
            var test = samples.Max() - samples.Min();
            if (test < 1)
                test = 1;
            var bins = HistogramHelpers.CreateUniformBins(samples.Min(), samples.Max(), (int)test);
            var binningOptions = new BinningOptions(BinningOutlierMode.RejectOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues);
            var bars = HistogramHelpers.Collect(samples, bins, binningOptions);
            histogram.Items.AddRange(bars);
            histogram_model.Series.Add(histogram);
            return histogram_model;
        }

        public static OxyPlot.PlotModel Histogram(OxyPlot.PlotModel model, List<double> samples, int binsize, string title)
        {
            var histogram_model = new PlotModel();
            if (model != null)
                histogram_model = model;

            var histogram = new OxyPlot.Series.HistogramSeries { Title = title };
            var bins = HistogramHelpers.CreateUniformBins(samples.Min(), samples.Max(), binsize);
            var binningOptions = new BinningOptions(BinningOutlierMode.RejectOutliers, BinningIntervalType.InclusiveLowerBound, BinningExtremeValueMode.IncludeExtremeValues);
            var bars = HistogramHelpers.Collect(samples, bins, binningOptions);
            histogram.Items.AddRange(bars);
            histogram_model.Series.Add(histogram);
            return histogram_model;
        }
    }
}
