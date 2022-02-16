using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
     class delete
    {
        

        public class Get
        {
            List<int> distance = new List<int>();
            List<int> distance_2 = new List<int>();
            List<double> time = new List<double>();
            List<double> time_2 = new List<double>();
            List<double> time_dif = new List<double>();
            List<double> pos_x = new List<double>();
            List<double> pos_y = new List<double>();
            public  void Convert(List<string> columnsname, List<List<double>> telemetrydata, int run)
            {
                if (run == 1)
                {
                    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".StartsWith)].ToArray();
                    List<int> driveLineLocation_int_list = new List<int>();
                    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".StartsWith)].ToArray();
                    var position_x = telemetrydata[columnsname.FindIndex("position.x".StartsWith)].ToArray();
                    var position_y = telemetrydata[columnsname.FindIndex("position.y".StartsWith)].ToArray();
                    //firsttime = time.Max();
                    //List<int> ilist = new List<int>();
                    int distance_plus;
                    double time_plus = 0; double pos_x_plus = 0; double pos_y_plus = 0;

                    for (int i = 0; i < driveLineLocation.Length; i++)
                    {
                        //lineList.Add((int)(linedouble[i]));
                        //var test = Math.Round(linedouble[i], MidpointRounding.AwayFromZero);
                        //lineList.Add(test);
                        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                    }

                    //var line = lineList.ToArray();
                    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                    for (int i = 0; i <= driveLineLocation_int.Max(); i++)
                    {

                        var location = Array.LastIndexOf(driveLineLocation_int, i);
                        if (location > -1)
                        {
                            //test1.Add(line[icount]);
                            //test2.Add(time[icount]);
                            //testX.Add(posx[icount]);
                            //testY.Add(posy[icount]);
                            //ilist.Add(i);
                            distance.Add(driveLineLocation_int[location]);
                            time.Add(raceTime[location]);
                            pos_x.Add(position_x[location]);
                            pos_y.Add(position_y[location]);


                        }
                        if (location == -1 && i > 0)
                        {
                            var distance_minus = driveLineLocation_int[location - 1];
                            var time_minus = raceTime[location - 1];
                            var pos_x_minus = position_x[location - 1];
                            var pos_y_minus = position_y[location - 1];
                            //int distance_plus;
                            //double time_plus, pos_x_plus, pos_y_plus;
                            int miss = 1;
                            //for (int i_plus= location+1; i_plus <= driveLineLocation_int.Max(); i_plus++)
                            for (int i_plus = location; Array.LastIndexOf(driveLineLocation_int, i_plus) != -1;)
                            {
                                i_plus++;
                                miss++;
                                var location_plus = Array.LastIndexOf(driveLineLocation_int, i_plus);
                                if (Array.LastIndexOf(driveLineLocation_int, i_plus) != -1)
                                {
                                    distance_plus = driveLineLocation_int[i_plus];
                                    time_plus = raceTime[i_plus];
                                    pos_x_plus = position_x[i_plus];
                                    pos_y_plus = position_y[i_plus];
                                }
                                else
                                {
                                    time_plus = 0;
                                    pos_x_plus = 0;
                                    pos_y_plus = 0;
                                }

                            }
                            distance.Add(distance_minus + 1);
                            time.Add((time_plus - time_minus) / miss + time_minus);
                            pos_x.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                            pos_y.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                        }
                    }
                    //testvalues.Columns.Add(RaceTime.ToString(time.Max()));
                    ////testvalues.Rows.Add;
                    //dataGridView1.DataSource = testvalues;
                    ////testX.AddRange( telemetrydata[columnsname.FindIndex("position.x".StartsWith)].ToArray());
                    ////testY.AddRange(telemetrydata[columnsname.FindIndex("position.y".StartsWith)].ToArray());
                    //DataTable testXY_dist = new DataTable();
                    //testXY_dist.Columns.Add("X");
                    //testXY_dist.Columns.Add("Y");
                    //testXY_dist.Columns.Add("i");
                    //testXY_dist.Columns.Add("iList");
                    //for (int i = 0; i < testX.Count(); i++)
                    //{
                    //    testXY_dist.Rows.Add(testX[i], testY[i], i);
                    //}
                    //dataGridView2.DataSource = testXY_dist;


                }

                if (run >= 2)
                {
                    var driveLineLocation = telemetrydata[columnsname.FindIndex("driveLineLocation".StartsWith)].ToArray();
                    List<int> driveLineLocation_int_list = new List<int>();
                    var raceTime = telemetrydata[columnsname.FindIndex("raceTime".StartsWith)].ToArray();
                    var position_x = telemetrydata[columnsname.FindIndex("position.x".StartsWith)].ToArray();
                    var position_y = telemetrydata[columnsname.FindIndex("position.y".StartsWith)].ToArray();
                    int distance_plus;
                    double time_plus = 0; double pos_x_plus = 0; double pos_y_plus = 0;
                    //firsttime = time.Max();
                    //List<int> ilist = new List<int>();

                    for (int i = 0; i < driveLineLocation.Length; i++)
                    {
                        //lineList.Add((int)(linedouble[i]));
                        //var test = Math.Round(linedouble[i], MidpointRounding.AwayFromZero);
                        //lineList.Add(test);
                        driveLineLocation_int_list.Add((int)Math.Round(driveLineLocation[i], MidpointRounding.AwayFromZero));
                    }

                    //var line = lineList.ToArray();
                    var driveLineLocation_int = driveLineLocation_int_list.ToArray();
                    for (int i = 0; i <= driveLineLocation_int.Max(); i++)
                    {

                        var location = Array.LastIndexOf(driveLineLocation_int, i);
                        if (location > -1)
                        {
                            //test1.Add(line[icount]);
                            //test2.Add(time[icount]);
                            //testX.Add(posx[icount]);
                            //testY.Add(posy[icount]);
                            //ilist.Add(i);
                            distance_2.Add(driveLineLocation_int[location]);
                            time_2.Add(raceTime[location]);
                            pos_x.Add(position_x[location]);
                            pos_y.Add(position_y[location]);


                        }
                        if (location == -1 && i > 0)
                        {
                            var distance_minus = driveLineLocation_int[location - 1];
                            var time_minus = raceTime[location - 1];
                            var pos_x_minus = position_x[location - 1];
                            var pos_y_minus = position_y[location - 1];
                            //int distance_plus;
                            //double time_plus, pos_x_plus, pos_y_plus;
                            int miss = 1;
                            //for (int i_plus= location+1; i_plus <= driveLineLocation_int.Max(); i_plus++)
                            for (int i_plus = location; Array.LastIndexOf(driveLineLocation_int, i_plus) != -1;)
                            {
                                i_plus++;
                                miss++;
                                var location_plus = Array.LastIndexOf(driveLineLocation_int, i_plus);
                                if (Array.LastIndexOf(driveLineLocation_int, i_plus) != -1)
                                {
                                    distance_plus = driveLineLocation_int[i_plus];
                                    time_plus = raceTime[i_plus];
                                    pos_x_plus = position_x[i_plus];
                                    pos_y_plus = position_y[i_plus];
                                }
                                else
                                {
                                    time_plus = pos_x_plus = pos_y_plus = 0;
                                }

                            }
                            distance_2.Add(distance_minus + 1);
                            time_2.Add((time_plus - time_minus) / miss + time_minus);
                            pos_x.Add((pos_x_plus - pos_x_minus) / miss + pos_x_minus);
                            pos_y.Add((pos_y_plus - pos_y_minus) / miss + pos_y_minus);
                        }

                    }
                    //testvalues.Columns.Add(RaceTime.ToString(time.Max()));
                    ////testvalues.Rows.Add;
                    //dataGridView1.DataSource = testvalues;
                    ////testX.AddRange( telemetrydata[columnsname.FindIndex("position.x".StartsWith)].ToArray());
                    ////testY.AddRange(telemetrydata[columnsname.FindIndex("position.y".StartsWith)].ToArray());
                    //DataTable testXY_dist = new DataTable();
                    //testXY_dist.Columns.Add("X");
                    //testXY_dist.Columns.Add("Y");
                    //testXY_dist.Columns.Add("i");
                    //testXY_dist.Columns.Add("iList");
                    //for (int i = 0; i < testX.Count(); i++)
                    //{
                    //    testXY_dist.Rows.Add(testX[i], testY[i], i);
                    //}
                    //dataGridView2.DataSource = testXY_dist;
                    if (distance_2.Count > distance.Count)
                    {
                        for (int i = 0; i <= distance.Count; i++)
                        {
                            time_dif.Add(time[i] - time_2[i]);
                        }
                    }
                    if (distance_2.Count < distance.Count)
                    {
                        for (int i = 0; i <= distance_2.Count; i++)
                        {
                            time_dif.Add(time[i] - time_2[i]);
                        }
                    }
                    if (distance_2.Count == distance.Count)
                    {
                        for (int i = 0; i <= distance.Count; i++)
                        {
                            time_dif.Add(time[i] - time_2[i]);
                        }
                    }

                }

                List<double> time_difference()
                {
                    return time_dif;
                }
                List<double> position_x_dist()
                {
                    return pos_x;
                }
                List<double> position_y_dist()
                {
                    return pos_y;
                }
                List<int> distance_int()
                {
                    return distance;
                }


            }
            //if (run >= 2)
            //{
            //    var linedouble = telemetrydata[columnsname.FindIndex("driveLineLocation".StartsWith)].ToArray();
            //    List<int> lineList = new List<int>();
            //    var time = telemetrydata[columnsname.FindIndex("raceTime".StartsWith)].ToArray();
            //    secondtime = time.Max();
            //    testvalues.Columns.Add(RaceTime.ToString(time.Max()));
            //    for (int i = 0; i < linedouble.Length; i++)
            //    {
            //        lineList.Add((int)(linedouble[i]));
            //    }
            //    var line = lineList.ToArray();
            //    for (int i = 0; i < line.Max(); i++)
            //    {
            //        var icount = Array.LastIndexOf(line, i);
            //        if (icount > -1)
            //        {
            //            test1_1.Add(line[icount]);
            //            test2_1.Add(time[icount]);
            //        }
            //    }

            //    if (test2.Count > test2_1.Count)
            //    {
            //        for (int i = 0; i < test1_1.Count; i++)
            //        {
            //            test2_2.Add(test2[i] - test2_1[i]);
            //        }
            //        TimeDiffirenceChart.Plot.AddScatterLines(test1_1.ToArray(), test2_2.ToArray());

            //        //TimeDiffirenceChart.Plot.AddScatterLines(test1.ToArray(), test2.ToArray());
            //        //TimeDiffirenceChart.Plot.AddScatterLines(test1_1.ToArray(), test2_1.ToArray());
            //        var TimeDiffOPLine = new OxyPlot.Series.LineSeries();
            //        for (int i = 0; i < test1_1.Count; i++)
            //        {
            //            TimeDiffOPLine.Points.Add(new OxyPlot.DataPoint(test1[i], test2_2[i]));
            //        }
            //        TimeDiffOPModel.Series.Add(TimeDiffOPLine);
            //    }

            //    if (test2.Count < test2_1.Count)
            //    {
            //        for (int i = 0; i < test2.Count; i++)
            //        {
            //            test2_2.Add(test2[i] - test2_1[i]);
            //        }
            //        TimeDiffirenceChart.Plot.AddScatterLines(test1.ToArray(), test2_2.ToArray());
            //        //TimeDiffirenceChart.Plot.AddScatterLines(test1.ToArray(), test2.ToArray());
            //        //TimeDiffirenceChart.Plot.AddScatterLines(test1_1.ToArray(), test2_1.ToArray());
            //        var TimeDiffOPLine = new OxyPlot.Series.LineSeries();
            //        for (int i = 0; i < test1.Count; i++)
            //        {
            //            TimeDiffOPLine.Points.Add(new OxyPlot.DataPoint(test1_1[i], test2_2[i]));
            //        }
            //        TimeDiffOPModel.Series.Add(TimeDiffOPLine);
            //    }
            //    TimeDiffirenceChart.Plot.AddHorizontalLine(0, color: Color.Black);
            //    test1_1.Clear();
            //    test2_1.Clear();
            //    test2_2.Clear();
            //}

        }
    }
}
