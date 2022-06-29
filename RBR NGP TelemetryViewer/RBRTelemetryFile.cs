using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RBR_NGP_TelemetryViewer
{
    class RBRTelemetryFile
    {
        public class Parse
        {
            static List<string> columnsname = new List<string>();
            static List<List<double>> telemetrydata = new List<List<double>>();
            public static bool test(string selectfile)
            {

                string rowfile;
                bool isbusy;
                try
                {
                    using (StreamReader filestream = new StreamReader(selectfile))
                    {
                        //StreamReader filestream = new StreamReader(selectfile, false);
                        //Reading Data

                        while (filestream.Peek() != -1)
                        {
                            rowfile = filestream.ReadLine();
                            string[] rowdata = rowfile.Split('\t');
                            if (columnsname.Count == 0)
                            {
                                columnsname.AddRange(rowfile.Split('\t'));
                                telemetrydata.AddRange(from string column in columnsname
                                                       let data = new List<double>()
                                                       select data);
                            }
                            else
                            {
                                for (int i = 0; i < rowdata.Length; i++)
                                {
                                    Double.TryParse(rowdata[i], out double value);
                                    telemetrydata[i].Add(value);
                                }

                            }
                        }
                    }
                    return isbusy = false;
                }
                catch (Exception ex)
                {
                    return isbusy = true;
                }
                //filestream.Dispose();
                //filestream.Close();
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

            public static void ClearData()
            {
                columnsname.Clear();
                telemetrydata.Clear();
            }
        }
    }
}
