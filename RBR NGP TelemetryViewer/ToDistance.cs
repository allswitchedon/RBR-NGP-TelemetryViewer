using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    class ToDistance
    {
        public class Get
        {

            static List<int> distance = new List<int>();
            static List<int> distance_2 = new List<int>();
            static List<double> time = new List<double>();
            static List<double> time_2 = new List<double>();
            static List<double> time_dif = new List<double>();
            static List<double> pos_x = new List<double>();
            static List<double> pos_y = new List<double>();
            static List<double> pos_x2 = new List<double>();
            static List<double> pos_y2 = new List<double>();
            public static void Convert(List<string> columnsname, List<List<double>> telemetrydata, int run)
            {
                distance_2.Clear();
                time_2.Clear();
                time_dif.Clear();

                if (run == 1)
                {
                    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
                    List<int> driveLineLocation_int_list = new List<int>();
                    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray();
                    var position_x = telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray();
                    var position_y = telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray();
                    int distance_plus;
                    double time_plus = 0; double time_minus = 0; double pos_x_plus = 0; double pos_y_plus = 0; double pos_x_minus = 0; double pos_y_minus = 0;

                    for (int i = 0; i < driveLineLocation.Length; i++)
                    {
                        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                    }

                    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                    int location_minus = 0;
                    for (int i = 0; i <= driveLineLocation_int.Max(); i++)
                    {

                        var location = Array.LastIndexOf(driveLineLocation_int, i);

                        if (location > -1)
                        {
                            distance.Add(driveLineLocation_int[location]);
                            time.Add(raceTime[location]);
                            pos_x.Add(position_x[location]);
                            pos_y.Add(position_y[location]);
                            location_minus = location;
                        }
                        // if
                        else
                        {
                            int notfound = 1;
                            pos_x_minus = position_x[location_minus];
                            pos_y_minus = position_y[location_minus];
                            time_minus = raceTime[location_minus];
                            int miss = 1;
                            distance.Add(i);
                            for (int j = i +1; j < driveLineLocation_int.Max()-2;j++)
                            {                                
                                miss++;
                                var location_plus = Array.LastIndexOf(driveLineLocation_int, j);
                                if (location_plus > -1)
                                {
                                    pos_x_plus = position_x[location_plus];
                                    pos_y_plus = position_y[location_plus];
                                    time_plus = raceTime[location_plus];
                                    break;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }

                            if (notfound == 1)
                            {
                                pos_x.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                pos_y.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                time.Add((time_plus - time_minus) / miss + time_minus);
                            }
                            if (notfound >= 2)
                            {
                                pos_x.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                pos_y.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                time.Add((time_plus - time_minus) / miss + time_minus);
                                for (int k = 2; k <= notfound; k++)
                                {
                                    pos_x.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                    pos_y.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                    time.Add((time_plus - time_minus) / miss * (k) + time_minus);
                                    i++;
                                    distance.Add(i);
                                }
                            }
                            else;
                        }
                        //end
                    }
                    pos_x[0] = position_x[0];
                    pos_y[0] = position_y[0];

                }

                if (run >= 2)
                {
                    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
                    List<int> driveLineLocation_int_list = new List<int>();
                    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray();
                    var position_x = telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray();
                    var position_y = telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray();
                    int distance_plus;
                    double time_plus = 0; double time_minus = 0; double pos_x_plus = 0; double pos_y_plus = 0; double pos_x_minus = 0; double pos_y_minus = 0;


                    for (int i = 0; i < driveLineLocation.Length; i++)
                    {
                        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                    }

                    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                    int location_minus = 0;
                    for (int i = 0; i <= driveLineLocation_int.Max(); i++)
                    {

                        var location = Array.LastIndexOf(driveLineLocation_int, i);
                        if (location > -1)
                        {
                            distance_2.Add(driveLineLocation_int[location]);
                            time_2.Add(raceTime[location]);
                            pos_x2.Add(position_x[location]);
                            pos_y2.Add(position_y[location]);
                            location_minus = location;
                        }
                        else
                        {
                            int notfound = 1;
                            pos_x_minus = position_x[location_minus];
                            pos_y_minus = position_y[location_minus];
                            time_minus = raceTime[location_minus];
                            int miss = 1;
                            distance_2.Add(i);
                            for (int j = i + 1; j < driveLineLocation_int.Max() - 2; j++)
                            {
                                miss++;
                                var location_plus = Array.LastIndexOf(driveLineLocation_int, j);
                                if (location_plus > -1)
                                {
                                    pos_x_plus = position_x[location_plus];
                                    pos_y_plus = position_y[location_plus];
                                    time_plus = raceTime[location_plus];
                                    break;
                                }
                                else
                                {
                                    notfound++;
                                }
                            }

                            if (notfound == 1)
                            {
                                pos_x2.Add((pos_x_plus - pos_x_minus) / miss  + pos_x_minus);
                                pos_y2.Add((pos_y_plus - pos_y_minus) / miss  + pos_y_minus);
                                time_2.Add((time_plus - time_minus) / miss  + time_minus);
                            }
                            if (notfound >= 2)
                            {
                                pos_x2.Add((pos_x_plus - pos_x_minus) / miss  + pos_x_minus);
                                pos_y2.Add((pos_y_plus - pos_y_minus) / miss  + pos_y_minus);
                                time_2.Add((time_plus - time_minus) / miss  + time_minus);
                                for (int k = 2; k <= notfound; k++)
                                {
                                    pos_x2.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                    pos_y2.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                    time_2.Add((time_plus - time_minus) / miss * (k) + time_minus);
                                    i++;
                                    distance_2.Add(i);
                                }
                            }
                            else;
                        }
                        pos_x2[0] = position_x[0];
                        pos_y2[0] = position_y[0];
                    }

                    if (distance_2.Count > distance.Count)
                    {
                        for (int i = 0; i < distance.Count; i++)
                        {
                            time_dif.Add(time[i] - time_2[i]);
                        }
                    }
                    if (distance_2.Count < distance.Count)
                    {
                        for (int i = 0; i < distance_2.Count; i++)
                        {
                            time_dif.Add(time[i] - time_2[i]);
                        }
                    }
                    if (distance_2.Count == distance.Count)
                    {
                        for (int i = 0; i < distance.Count; i++)
                        {
                            time_dif.Add(time[i] - time_2[i]);
                        }
                    }

                }


            }

            public static List<double> time_difference()
            { 
                return time_dif;
            }
            public static List<double> distance_int()
            {
                if (distance.Count > distance_2.Count && distance_2.Count !=0)
                {
                    List<double> distance_double = new List<double>();
                    for (int i = 0;i< distance_2.Count;i++)
                    {
                        distance_double.Add((double)distance_2[i]);
                    }
                    return distance_double; 
                }
                if (distance.Count < distance_2.Count)
                {
                    List<double> distance_double = new List<double>();
                    for (int i = 0; i < distance.Count; i++)
                    {
                        distance_double.Add((double)distance[i]);
                    }
                    return distance_double;
                }
                else
                {
                    List<double> distance_double = new List<double>();
                    for (int i = 0; i < distance.Count; i++)
                    {
                        distance_double.Add((double)distance[i]);
                    }
                    return distance_double;
                }
            }
            public static List<double> position_x_dist()
            {
                if (distance.Count <= distance_2.Count)
                    return pos_x;
                else return pos_x2;
            }
            public static List<double> position_y_dist()
            {
                if (distance.Count <= distance_2.Count)
                    return pos_y;
                else return pos_y2;
            }

        }
    }
}
