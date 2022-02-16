using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    internal class ConvertRawData
    {
        public static double[] Suspension (List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = -data[i];
            }
            return data.ToArray();
        }
        public static double[] BrakeTemp(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = (data[i]/1e6) -273.15;
            }
            return data.ToArray();
        }

        public static double[] Temps(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i] - 273.15;
            }
            return data.ToArray();
        }

        public static double[] Pressure(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i]/1000;
            }
            return data.ToArray();
        }
        public static double[] Speed(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] < 0)
                    data[i] = data[i] * -1;
            }
            return data.ToArray();
        }
        public static double[] Gear(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                    data[i] = data[i] -1;
            }
            return data.ToArray();
        }

        public static double[] BrakeWear(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i]/1e7;
            }
            return data.ToArray();
        }

        public static double[] Gforces(List<double> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = data[i] / 9.806652048217348;
            }
            return data.ToArray();
        }
    }
}
