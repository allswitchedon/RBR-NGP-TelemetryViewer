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
            //static List<int> distance_t0 = new List<int>();
            //static List<int> distance_t1 = new List<int>();
            //static List<int> distance_t2 = new List<int>();
            //static List<int> distance_t3 = new List<int>();
            static List<int> distance_2 = new List<int>();
            static List<double> time = new List<double>();
            //static List<double> time_t0 = new List<double>();
            //static List<double> time_t1 = new List<double>();
            //static List<double> time_t2 = new List<double>();
            //static List<double> time_t3 = new List<double>();
            static List<double> time_2 = new List<double>();
            static List<double> time_dif = new List<double>();
            static List<double> pos_x = new List<double>();
            //static List<double> pos_x_t0 = new List<double>();
            //static List<double> pos_x_t1 = new List<double>();
            //static List<double> pos_x_t2 = new List<double>();
            //static List<double> pos_x_t3 = new List<double>();
            static List<double> pos_y = new List<double>();
            //static List<double> pos_y_t0 = new List<double>();
            //static List<double> pos_y_t1 = new List<double>();
            //static List<double> pos_y_t2 = new List<double>();
            //static List<double> pos_y_t3 = new List<double>();
            static List<double> pos_x2 = new List<double>();
            static List<double> pos_y2 = new List<double>();
            public static async void Convert(List<string> columnsname, List<List<double>> telemetrydata, int run)
            {
                              
                if (run == 1)
                {
                     List<int> distance_t0 = new List<int>();
                     List<int> distance_t1 = new List<int>();
                     List<int> distance_t2 = new List<int>();
                     List<int> distance_t3 = new List<int>();
                     List<double> time_t0 = new List<double>();
                     List<double> time_t1 = new List<double>();
                     List<double> time_t2 = new List<double>();
                     List<double> time_t3 = new List<double>();
                     List<double> pos_x_t0 = new List<double>();
                     List<double> pos_x_t1 = new List<double>();
                     List<double> pos_x_t2 = new List<double>();
                     List<double> pos_x_t3 = new List<double>();
                     List<double> pos_y_t0 = new List<double>();
                     List<double> pos_y_t1 = new List<double>();
                     List<double> pos_y_t2 = new List<double>();
                     List<double> pos_y_t3 = new List<double>();

                    List<int> driveLineLocation_int_list = new List<int>();

                    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
                    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray();
                    var position_x = telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray();
                    var position_y = telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray();
                    //int distance_plus;

                    for (int i = 0; i < driveLineLocation.Length; i++)
                    {
                        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                    }
                    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                    int index = driveLineLocation_int.Max() / 4;
                    int index_t0 = index;
                    int index_t1 = index_t0 + index;
                    int index_t2 = index_t1 + index;
                    int index_t3 = driveLineLocation_int.Max();

                    if (Array.LastIndexOf(driveLineLocation_int, index_t0) == -1 || Array.LastIndexOf(driveLineLocation_int, index_t0 + 1) == -1)
                    {
                        for (int i = index_t0; i < index_t1; i++)
                        {
                            if (Array.LastIndexOf(driveLineLocation_int, i) > -1 && Array.LastIndexOf(driveLineLocation_int, i + 1) > -1)
                            {
                                index_t0 = i;
                                break;
                            }
                            else;
                        }
                    }
                    else;

                    if (Array.LastIndexOf(driveLineLocation_int, index_t1) == -1 || Array.LastIndexOf(driveLineLocation_int, index_t1 + 1) == -1)
                    {
                        for (int i = index_t1; i < index_t2; i++)
                        {
                            if (Array.LastIndexOf(driveLineLocation_int, i) > -1 && Array.LastIndexOf(driveLineLocation_int, i + 1) > -1)
                            {
                                index_t1 = i;
                                break;
                            }
                            else;
                        }
                    }
                    else;

                    if (Array.LastIndexOf(driveLineLocation_int, index_t2) == -1 || Array.LastIndexOf(driveLineLocation_int, index_t2 + 1) == -1)
                    {
                        for (int i = index_t2; i < index_t3; i++)
                        {
                            if (Array.LastIndexOf(driveLineLocation_int, i) > -1 && Array.LastIndexOf(driveLineLocation_int, i + 1) > -1)
                            {
                                index_t2 = i;
                                break;
                            }
                            else;
                        }
                    }
                    else;
                    
                    var task_list = new Task[4];

                    task_list[0] = Task.Run(() =>
                    {
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        // Task Here
                        for (int i = 0; i < index_t0; i++)
                        {
                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t0.Add(driveLineLocation_int[location]);
                                time_t0.Add(raceTime[location]);
                                pos_x_t0.Add(position_x[location]);
                                pos_y_t0.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t0.Add(i);
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
                                    pos_x_t0.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t0.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t0.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t0.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t0.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t0.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t0.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t0.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t0.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t0.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });

                    task_list[1] = Task.Run(() =>
                    {
                        // Task Here
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        
                        for (int i = index_t0; i < index_t1; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t1.Add(driveLineLocation_int[location]);
                                time_t1.Add(raceTime[location]);
                                pos_x_t1.Add(position_x[location]);
                                pos_y_t1.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t1.Add(i);
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
                                    pos_x_t1.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t1.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t1.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t1.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t1.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t1.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t1.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t1.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t1.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t1.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });

                    task_list[2] = Task.Run(() =>
                    {
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        // Task Here
                        for (int i = index_t1; i < index_t2 ; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t2.Add(driveLineLocation_int[location]);
                                time_t2.Add(raceTime[location]);
                                pos_x_t2.Add(position_x[location]);
                                pos_y_t2.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t2.Add(i);
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
                                    pos_x_t2.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t2.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t2.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t2.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t2.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t2.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t2.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t2.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t2.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t2.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });

                    task_list[3] = Task.Run(() =>
                    {
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        // Task Here
                        for (int i = index_t2; i <= index_t3; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t3.Add(driveLineLocation_int[location]);
                                time_t3.Add(raceTime[location]);
                                pos_x_t3.Add(position_x[location]);
                                pos_y_t3.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t3.Add(i);
                                for (int j = i+1; j < driveLineLocation_int.Max() - 2; j++)
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
                                    pos_x_t3.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t3.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t3.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t3.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t3.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t3.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t3.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t3.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t3.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t3.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });



                    Task.WaitAll(task_list.ToArray());


                    distance.AddRange(distance_t0);
                    distance.AddRange(distance_t1);
                    distance.AddRange(distance_t2);
                    distance.AddRange(distance_t3);     
                    

                    pos_x.AddRange(pos_x_t0);
                    pos_x.AddRange(pos_x_t1);
                    pos_x.AddRange(pos_x_t2);
                    pos_x.AddRange(pos_x_t3);

                    pos_y.AddRange(pos_y_t0);
                    pos_y.AddRange(pos_y_t1);
                    pos_y.AddRange(pos_y_t2);
                    pos_y.AddRange(pos_y_t3);

                    time.AddRange(time_t0);
                    time.AddRange(time_t1);
                    time.AddRange(time_t2);
                    time.AddRange(time_t3);

                    //Form1.endparse = DateTime.Now.Ticks;

                    pos_x[0] = position_x[0];
                    pos_y[0] = position_y[0];
                    
                }

                // NEW RUN >= 2 Section

                if (run >= 2)
                {

                    List<int> distance_t0 = new List<int>();
                    List<int> distance_t1 = new List<int>();
                    List<int> distance_t2 = new List<int>();
                    List<int> distance_t3 = new List<int>();
                    List<double> time_t0 = new List<double>();
                    List<double> time_t1 = new List<double>();
                    List<double> time_t2 = new List<double>();
                    List<double> time_t3 = new List<double>();
                    List<double> pos_x_t0 = new List<double>();
                    List<double> pos_x_t1 = new List<double>();
                    List<double> pos_x_t2 = new List<double>();
                    List<double> pos_x_t3 = new List<double>();
                    List<double> pos_y_t0 = new List<double>();
                    List<double> pos_y_t1 = new List<double>();
                    List<double> pos_y_t2 = new List<double>();
                    List<double> pos_y_t3 = new List<double>();

                    distance_2.Clear();
                    time_2.Clear();
                    time_dif.Clear();

                    //distance_t0.Clear();
                    //distance_t1.Clear();
                    //distance_t2.Clear();
                    //distance_t3.Clear();

                    //time_t0.Clear();
                    //time_t1.Clear();
                    //time_t2.Clear();
                    //time_t3.Clear();

                    //pos_x_t0.Clear();
                    //pos_x_t1.Clear();
                    //pos_x_t2.Clear();
                    //pos_x_t3.Clear();

                    //pos_y_t0.Clear();
                    //pos_y_t1.Clear();
                    //pos_y_t2.Clear();
                    //pos_y_t3.Clear();



                    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
                    List<int> driveLineLocation_int_list = new List<int>();
                    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray();
                    var position_x = telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray();
                    var position_y = telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray();
                    //int distance_plus;

                    
                    for (int i = 0; i < driveLineLocation.Length; i++)
                    {
                        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                    }

                    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                    int index = driveLineLocation_int.Max() / 4;
                    int index_t0 = index;
                    int index_t1 = index_t0 + index;
                    int index_t2 = index_t1 + index;
                    int index_t3 = driveLineLocation_int.Max();

                    if (Array.LastIndexOf(driveLineLocation_int, index_t0) == -1 || Array.LastIndexOf(driveLineLocation_int, index_t0 + 1) == -1)
                    {
                        for (int i = index_t0; i < index_t1; i++)
                        {
                            if (Array.LastIndexOf(driveLineLocation_int, i) > -1 && Array.LastIndexOf(driveLineLocation_int, i + 1) > -1)
                            {
                                index_t0 = i;
                                break;
                            }
                            else;
                        }
                    }
                    else;

                    if (Array.LastIndexOf(driveLineLocation_int, index_t1) == -1 || Array.LastIndexOf(driveLineLocation_int, index_t1 + 1) == -1)
                    {
                        for (int i = index_t1; i < index_t2; i++)
                        {
                            if (Array.LastIndexOf(driveLineLocation_int, i) > -1 && Array.LastIndexOf(driveLineLocation_int, i + 1) > -1)
                            {
                                index_t1 = i;
                                break;
                            }
                            else;
                        }
                    }
                    else;

                    if (Array.LastIndexOf(driveLineLocation_int, index_t2) == -1 || Array.LastIndexOf(driveLineLocation_int, index_t2 + 1) == -1)
                    {
                        for (int i = index_t2; i < index_t3; i++)
                        {
                            if (Array.LastIndexOf(driveLineLocation_int, i) > -1 && Array.LastIndexOf(driveLineLocation_int, i + 1) > -1)
                            {
                                index_t2 = i;
                                break;
                            }
                            else;
                        }
                    }
                    else;


                    var task_list = new Task[4];

                    task_list[0] = Task.Run(() =>
                    {
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        // Task Here
                        for (int i = 0; i < index_t0; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t0.Add(driveLineLocation_int[location]);
                                time_t0.Add(raceTime[location]);
                                pos_x_t0.Add(position_x[location]);
                                pos_y_t0.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t0.Add(i);
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
                                    pos_x_t0.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t0.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t0.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t0.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t0.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t0.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t0.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t0.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t0.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t0.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });

                    task_list[1] = Task.Run(() =>
                    {
                        // Task Here
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;

                        for (int i = index_t0; i < index_t1; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t1.Add(driveLineLocation_int[location]);
                                time_t1.Add(raceTime[location]);
                                pos_x_t1.Add(position_x[location]);
                                pos_y_t1.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t1.Add(i);
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
                                    pos_x_t1.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t1.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t1.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t1.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t1.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t1.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t1.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t1.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t1.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t1.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });

                    task_list[2] = Task.Run(() =>
                    {
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        // Task Here
                        for (int i = index_t1; i < index_t2; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t2.Add(driveLineLocation_int[location]);
                                time_t2.Add(raceTime[location]);
                                pos_x_t2.Add(position_x[location]);
                                pos_y_t2.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t2.Add(i);
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
                                    pos_x_t2.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t2.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t2.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t2.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t2.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t2.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t2.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t2.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t2.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t2.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });

                    task_list[3] = Task.Run(() =>
                    {
                        double time_plus = 0;
                        double time_minus = 0;
                        double pos_x_plus = 0;
                        double pos_y_plus = 0;
                        double pos_x_minus = 0;
                        double pos_y_minus = 0;
                        int location_minus = 0;
                        // Task Here
                        for (int i = index_t2; i <= index_t3; i++)
                        {

                            var location = Array.LastIndexOf(driveLineLocation_int, i);

                            if (location > -1)
                            {
                                distance_t3.Add(driveLineLocation_int[location]);
                                time_t3.Add(raceTime[location]);
                                pos_x_t3.Add(position_x[location]);
                                pos_y_t3.Add(position_y[location]);
                                location_minus = location;

                            }
                            else
                            {

                                int notfound = 1;
                                pos_x_minus = position_x[location_minus];
                                pos_y_minus = position_y[location_minus];
                                time_minus = raceTime[location_minus];
                                int miss = 1;
                                distance_t3.Add(i);
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
                                    pos_x_t3.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t3.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t3.Add((time_plus - time_minus) / miss + time_minus);

                                }
                                if (notfound >= 2)
                                {
                                    pos_x_t3.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                                    pos_y_t3.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                                    time_t3.Add((time_plus - time_minus) / miss + time_minus);

                                    for (int k = 2; k <= notfound; k++)
                                    {
                                        pos_x_t3.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus);
                                        pos_y_t3.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus);
                                        time_t3.Add((time_plus - time_minus) / miss * (k) + time_minus);

                                        i++;
                                        distance_t3.Add(i);
                                    }
                                }
                            }
                        }

                        // Task END
                    });



                    Task.WaitAll(task_list.ToArray());

                    var path = System.Windows.Forms.Application.StartupPath.ToString();

                    distance_2.AddRange(distance_t0);
                    distance_2.AddRange(distance_t1);
                    distance_2.AddRange(distance_t2);
                    distance_2.AddRange(distance_t3);


                    pos_x2.AddRange(pos_x_t0);
                    pos_x2.AddRange(pos_x_t1);
                    pos_x2.AddRange(pos_x_t2);
                    pos_x2.AddRange(pos_x_t3);

                    pos_y2.AddRange(pos_y_t0);
                    pos_y2.AddRange(pos_y_t1);
                    pos_y2.AddRange(pos_y_t2);
                    pos_y2.AddRange(pos_y_t3);

                    time_2.AddRange(time_t0);
                    time_2.AddRange(time_t1);
                    time_2.AddRange(time_t2);
                    time_2.AddRange(time_t3);

                    //Form1.endparse = DateTime.Now.Ticks;

                    pos_x2[0] = position_x[0];
                    pos_y2[0] = position_y[0];

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



                // END OF NEW SECTION






                //if (run >= 2)
                //{
                //    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".Equals)].ToArray();
                //    List<int> driveLineLocation_int_list = new List<int>();
                //    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".Equals)].ToArray();
                //    var position_x = telemetrydata[columnsname.FindIndex("position.x".Equals)].ToArray();
                //    var position_y = telemetrydata[columnsname.FindIndex("position.y".Equals)].ToArray();
                //    //int distance_plus;
                //    double time_plus = 0; double time_minus = 0; double pos_x_plus = 0; double pos_y_plus = 0; double pos_x_minus = 0; double pos_y_minus = 0;

                //    Form1.startparse = DateTime.Now.Ticks;
                //    for (int i = 0; i < driveLineLocation.Length; i++)
                //    {
                //        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                //    }

                //    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                //    int location_minus = 0;
                //    for (int i = 0; i <= driveLineLocation_int.Max(); i++)
                //    {

                //        var location = Array.LastIndexOf(driveLineLocation_int, i);
                //        if (location > -1)
                //        {
                //            Task[] task1 = new Task[5];
                //            task1[0] = Task.Run(() => distance_2.Add(driveLineLocation_int[location]));
                //            task1[1] = Task.Run(() => time_2.Add(raceTime[location]));
                //            task1[2] = Task.Run(() => pos_x2.Add(position_x[location]));
                //            task1[3] = Task.Run(() => pos_y2.Add(position_y[location]));
                //            task1[4] = Task.Run(() => location_minus = location);
                //            Task.WaitAll(task1);
                //        }
                //        else
                //        {
                //            int notfound = 1;
                //            int miss = 1;
                //            Task[] task2 = new Task[4];
                //            task2[0] = Task.Run(() =>pos_x_minus = position_x[location_minus]);
                //            task2[1] = Task.Run(() =>pos_y_minus = position_y[location_minus]);
                //            task2[2] = Task.Run(() =>time_minus = raceTime[location_minus]);
                //            task2[3] = Task.Run(() => distance_2.Add(i));
                //            Task.WaitAll(task2);
                //            for (int j = i + 1; j < driveLineLocation_int.Max() - 2; j++)
                //            {
                //                miss++;
                //                var location_plus = Array.LastIndexOf(driveLineLocation_int, j);
                //                if (location_plus > -1)
                //                {
                //                    Task[] task3 = new Task[3];
                //                    task3[0] = Task.Run(() => pos_x_plus = position_x[location_plus]);
                //                    task3[1] = Task.Run(() => pos_y_plus = position_y[location_plus]);
                //                    task3[2] = Task.Run(() => time_plus = raceTime[location_plus]);
                //                    Task.WaitAll(task3);
                //                    break;
                //                }
                //                else
                //                {
                //                    notfound++;
                //                }
                //            }

                //            if (notfound == 1)
                //            {
                //                Task[] task4 = new Task[3];
                //                task4[0] = Task.Run(() => pos_x2.Add((pos_x_plus - pos_x_minus) / miss  + pos_x_minus));
                //                task4[1] = Task.Run(() => pos_y2.Add((pos_y_plus - pos_y_minus) / miss  + pos_y_minus));
                //                task4[2] = Task.Run(() => time_2.Add((time_plus - time_minus) / miss  + time_minus));
                //                Task.WaitAll(task4);
                //            }
                //            if (notfound >= 2)
                //            {
                //                Task[] task5 = new Task[3];
                //                task5[0] = Task.Run(() => pos_x2.Add((pos_x_plus - pos_x_minus) / miss  + pos_x_minus));
                //                task5[1] = Task.Run(() => pos_y2.Add((pos_y_plus - pos_y_minus) / miss  + pos_y_minus));
                //                task5[2] = Task.Run(() => time_2.Add((time_plus - time_minus) / miss  + time_minus));
                //                Task.WaitAll(task5);
                //                for (int k = 2; k <= notfound; k++)
                //                {
                //                    Task[] task6 = new Task[3];
                //                    task6[0] = Task.Run(() => pos_x2.Add((pos_x_plus - pos_x_minus) / miss * (k) + pos_x_minus));
                //                    task6[1] = Task.Run(() => pos_y2.Add((pos_y_plus - pos_y_minus) / miss * (k) + pos_y_minus));
                //                    task6[2] = Task.Run(() => time_2.Add((time_plus - time_minus) / miss * (k) + time_minus));
                //                    Task.WaitAll(task6);
                //                    i++;
                //                    distance_2.Add(i);
                //                }
                //            }
                //        }
                //        Form1.endparse = DateTime.Now.Ticks;
                //        pos_x2[0] = position_x[0];
                //        pos_y2[0] = position_y[0];
                //    }

                //    if (distance_2.Count > distance.Count)
                //    {
                //        for (int i = 0; i < distance.Count; i++)
                //        {
                //            time_dif.Add(time[i] - time_2[i]);
                //        }
                //    }
                //    if (distance_2.Count < distance.Count)
                //    {
                //        for (int i = 0; i < distance_2.Count; i++)
                //        {
                //            time_dif.Add(time[i] - time_2[i]);
                //        }
                //    }
                //    if (distance_2.Count == distance.Count)
                //    {
                //        for (int i = 0; i < distance.Count; i++)
                //        {
                //            time_dif.Add(time[i] - time_2[i]);
                //        }
                //    }

                //}


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
            public static List<double> Position_x_dist(int run)
            {
                if (run == 1)
                {
                    return pos_x;
                }
                else
                {
                                    
                if (distance.Count <= distance_2.Count)
                    return pos_x;
                else return pos_x2;
                }
            }
            public static List<double> Position_y_dist(int run)
            {
                if (run == 1)
                {
                    return pos_y;
                }
                else
                {
                    if (distance.Count <= distance_2.Count)
                        return pos_y;
                    else return pos_y2;
                }
            }

            public static List<double> left_x()
            {
                return pos_x;
            }
            public static List<double> left_y()
            {
                return pos_y;
            }
            public static List<double> right_x()
            {
                return pos_x2;
            }
            public static List<double> right_y()
            {
                return pos_y2;
            }
        }
    }
}
