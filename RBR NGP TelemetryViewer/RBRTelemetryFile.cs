using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RBR_NGP_TelemetryViewer
{
    class RBRTelemetryFile
    {
        public class Parse
        {

            static List<string> columnsname = new List<string>();
            static List<List<double>> telemetrydata = new List<List<double>>();
            public static void test(string selectfile)
            {
                string rowfile;
                double value;

                StreamReader filestream = new StreamReader(selectfile, false);
                //Reading Data
                while (filestream.Peek() != -1)
                {
                    rowfile = filestream.ReadLine();
                    string[] rowdata = rowfile.Split('\t');
                    if (columnsname.Count == 0)
                    {
                        columnsname.AddRange(rowfile.Split('\t'));
                        foreach (string column in columnsname)
                        {
                            List<double> data = new List<double>();
                            telemetrydata.Add(data);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < rowdata.Length; i++)
                        {
                            Double.TryParse(rowdata[i], out value);
                            telemetrydata[i].Add(value);
                            //telemetrydata[i].Add(Convert.ToDouble(rowdata[i]));
                        }
                    }
                }
                filestream.Dispose();
                filestream.Close();
            }

            public static List<string> test1()
            {
                return columnsname;
            }
            public static  List<List<double>> test2()
            {
                var first5 = telemetrydata[0].IndexOf(5);
                var last5 = telemetrydata[0].LastIndexOf(5);
                if (first5 != last5)
                {
                    for (int i = 0; i < columnsname.Count; i++)
                    {
                        telemetrydata[i].RemoveRange(0, last5);
                    } 
                }
                return telemetrydata;
            }

            public static void removetest(int column, int index)
            {
                if (index < 12500)
                {
                    telemetrydata[column-1].RemoveRange(0, 12400);
                }
            }

            public static void ClearData()
            {
                columnsname.Clear();
                telemetrydata.Clear();
            }
        }
    }
}
