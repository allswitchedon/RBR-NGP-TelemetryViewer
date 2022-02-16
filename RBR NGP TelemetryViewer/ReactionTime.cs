using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    internal class ReactionTime
    {
        public static string GetTime(double[] raceTime, double[] driveLineLocation, double[] speed)
        {
            var startposition = driveLineLocation[Array.LastIndexOf(raceTime, 0)];
            var index = Array.LastIndexOf(driveLineLocation, startposition);
            var reactiontime = raceTime[index];
            string r = "";
            if (reactiontime ==0)
            {
                r = "You're Alien";
            }
            else
            {
                if (reactiontime >= 10)
                {
                    r = "False Start";
                }
                else
                {
                    if (reactiontime > 0 && reactiontime < 10 && speed[index] > 1)
                    {
                        r = reactiontime.ToString();
                    }
                    else
                    {
                        r = raceTime[index + 1].ToString();
                    }
                }
            }
            
            return r;
        }
    }

    

}
