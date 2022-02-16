using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    internal class RaceTime
    {
        

        public static string ToString(double time)
        {
            int minute;
            int second;
            int milisecond;
            string Time;
            minute = (int)(time/60);
            second = (int)(time - 60 * minute);
            milisecond = (int)((time - (int)(time))*100);
            Time = minute.ToString();
            if (second < 10)
                Time += ":" + "0" + second.ToString();
            else Time = minute.ToString() + ":" + second.ToString();
            if (milisecond <10)
                Time += ":"+"0" + milisecond.ToString();
            else Time +=  ":" + milisecond.ToString();
            return Time;
        }

    }
}
