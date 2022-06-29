using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    internal class Histogram
    {


        public static List<double[]> TyresTemps(double[] values, double binsize)
        {
            //for (int i = 0; i < values.Count(); i++)
            //{
            //    values[i] = values[i] - 273.15;
            //}
            //double[] values = telemetrydata[columnsname.FindIndex("LF.pressure".Equals)].ToArray();
            //for (int b = 0; b < values.Count(); b++)
            //{
            //    values[b] = values[b]/1000;
            //}
            // create a histogram
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(values, min: values.Min(), max: values.Max(), binSize: binsize, density: true);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // display the histogram counts as a bar plot
            //var bar = TireTempFLPlotH.Plot.AddBar(values: counts, positions: leftEdges);

            var bar = new List<double[]>
            {
                counts,
                leftEdges
            };
            return bar;
        }
        public static List<double[]> TyresPressure(double[] values, double binsize)
        {
            //for (int i = 0; i < values.Count(); i++)
            //{
            //    values[i] = values[i]/1000;
            //}
            //double[] values = telemetrydata[columnsname.FindIndex("LF.pressure".Equals)].ToArray();
            //for (int b = 0; b < values.Count(); b++)
            //{
            //    values[b] = values[b]/1000;
            //}
            // create a histogram
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(values, min: values.Min(), max: values.Max(), binSize: binsize, density: true);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // display the histogram counts as a bar plot
            //var bar = TireTempFLPlotH.Plot.AddBar(values: counts, positions: leftEdges);

            var bar = new List<double[]>
            {
                counts,
                leftEdges
            };
            return bar;
        }
        public static List<double[]> Suspension(double[] value, double[] raceTime, double binsize)
        {
            //for (int i = 0; i < values.Count(); i++)
            //{
            //    values[i] = values[i] / 1000;
            //}
            //double[] values = telemetrydata[columnsname.FindIndex("LF.pressure".Equals)].ToArray();
            //for (int b = 0; b < values.Count(); b++)
            //{
            //    values[b] = values[b]/1000;
            //}
            // create a histogram

            var val = new List<double> ();
            val.AddRange(value);
            var start = Array.LastIndexOf(raceTime, 0);
            var finish = Array.IndexOf(raceTime, raceTime.Max());
            val.RemoveRange(finish, val.Count() - finish);
            val.RemoveRange(0, start);
            //val.RemoveAll(x => x > 1.5);
            //val.RemoveAll(x => x < -1.5);
            var values = val.ToArray();
            (double[] counts, double[] binEdges) = ScottPlot.Statistics.Common.Histogram(values, min: values.Min(), max: values.Max(), binSize: binsize, density: true);
            double[] leftEdges = binEdges.Take(binEdges.Length - 1).ToArray();

            // display the histogram counts as a bar plot
            //var bar = TireTempFLPlotH.Plot.AddBar(values: counts, positions: leftEdges);

            var bar = new List<double[]>
            {
                counts,
                leftEdges
            };
            return bar;
        }

    }
}
