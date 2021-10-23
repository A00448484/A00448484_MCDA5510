using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

public class Class1
{
    public static void Main(String[] args)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Logger.WriteLog("Starting....");
        int valid_row_counter = 0;
        int skipped_row_counter = 0;
        string csvfile = "C:\\Users\\pandu\\source\\repos\\A00448484_MCDA5510\\Assignment1\\Output\\output.csv";

        string[] csv_header = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Postal Code", "Country", "Phone Number", "Email Address", "Date" };

        try
        {
            using (System.IO.StreamWriter outputfile = new System.IO.StreamWriter(csvfile, false))
            {
                outputfile.WriteLine(string.Join(",", csv_header));
            }

            List<string> files = DirReader.getFileNames();
            using (System.IO.StreamWriter outputfile = new System.IO.StreamWriter(csvfile, true))
            {
                foreach (string file in files)
                {
                    TextFieldParser parser = new TextFieldParser(file);

                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields.GetValue(0).Equals("First Name"))
                        {
                            continue;
                        }

                        if ((fields.GetValue(0).Equals("")) && (fields.GetValue(1).Equals("")))
                        {
                            skipped_row_counter++;
                            Logger.WriteLog($"Skipping record of the file {file}");
                            continue;
                        }

                        valid_row_counter++;
                        string record = string.Join(",", fields);
                        string date = getDate(file);
                        record += date;
                        outputfile.WriteLine(record);
                    }
                }
            }
        }
        catch(Exception e) {
            Logger.WriteLog(e.Message);
        }
    
        //Console.WriteLine("Total number of valid records: {0}", valid_row_counter.ToString());
        //Console.WriteLine("Total number of invalid records: {0}", skipped_row_counter.ToString());
        Logger.WriteLog($"Total number of valid records: {valid_row_counter.ToString()}");
        Logger.WriteLog($"Total number of invalid/skipped records: {skipped_row_counter.ToString()}");
        watch.Stop();

        var elapsedms = watch.ElapsedMilliseconds;
        //Console.WriteLine("Total execution time in milliseconds: {0}", elapsedms);
        Logger.WriteLog($"Total execution time in milliseconds: {elapsedms}");
        Logger.WriteLog("Finished.");
    }

    public static string getDate(string filepath) {

        string[] folders = filepath.Split("\\");
        string year = folders.GetValue(6).ToString();
        string month = folders.GetValue(7).ToString();
        string day = folders.GetValue(8).ToString();
        string date = "," + year + "/" + month + "/" + day;
        return date;
    }
}
