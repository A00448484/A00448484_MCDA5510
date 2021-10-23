using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;

public class Class1
{
    public static void Main(String[] args)
    {
        // Starting timer for the program execution time.
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // Logging start of the program.
        Logger.WriteLog("Starting....");

        // Initializing the counters.
        int valid_row_counter = 0;
        int skipped_row_counter = 0;

        // Filepath for the output file.
        string csvfile = "C:\\Users\\pandu\\source\\repos\\A00448484_MCDA5510\\Assignment1\\Output\\output.csv";

        // Header for the output file.
        string[] csv_header = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Postal Code", "Country", "Phone Number", "Email Address", "Date" };

        try
        {
            // Initiating writer to write header.
            // Setting up header for the output file.
            using (System.IO.StreamWriter outputfile = new System.IO.StreamWriter(csvfile, false))
            {
                outputfile.WriteLine(string.Join(",", csv_header));
            }

            // Getting all the file names present in the given directory path.
            List<string> files = DirReader.getFileNames();

            // Setting the writer to write records in the output file.
            using (System.IO.StreamWriter outputfile = new System.IO.StreamWriter(csvfile, true))
            {
                foreach (string file in files)
                {
                    // Setting the parser to reach each line present in the file with proper delimiter.
                    TextFieldParser parser = new TextFieldParser(file);
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    // Generating the date using the folder structure.
                    string date = getDate(file);

                    // Reading lines until end of the file.
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        // Checking first value of record to differentiate it with header of each file.
                        if (fields.GetValue(0).Equals("First Name"))
                        {
                            continue;
                        }

                        // Condition to check the invalid record.
                        if ((fields.GetValue(0).Equals("")) && (fields.GetValue(1).Equals("")))
                        {
                            // Increment invalid record counter and log it.
                            skipped_row_counter++;
                            Logger.WriteLog($"Skipping record of the file {file}");
                            continue;
                        }

                        // Some of the records contain unwanted text in 4th field. For ex "Alm../../Php?"
                        // Condition to count such records as invalid.
                        if (fields.Length >= 4)
                        {
                            string field_4 = fields.GetValue(3).ToString();
                            if (field_4.Contains("/"))
                            {
                                skipped_row_counter++;
                                Logger.WriteLog($"Skipping record of the file {file}");
                                continue;
                            }
                        }
                        // Increment valid record coounter.
                        valid_row_counter++;

                        // Concatenate the fields to make one record.
                        string record = string.Join(",", fields);
                        
                        // Add date as a last field in the record.
                        record += date;

                        //Insert record in the output file.
                        outputfile.WriteLine(record);
                    }
                }
            }
        }
        catch(Exception e) {
            Logger.WriteLog(e.Message);
        }
        
        // Log the counts of valid and invalid records in the log file.
        Logger.WriteLog($"Total number of valid records: {valid_row_counter.ToString()}");
        Logger.WriteLog($"Total number of invalid/skipped records: {skipped_row_counter.ToString()}");

        // Stop timer for program execution time.
        watch.Stop();

        // Get the total execution time.
        var elapsedms = watch.ElapsedMilliseconds;

        // Log total execution time in the log file.
        Logger.WriteLog($"Total execution time in milliseconds: {elapsedms}");
        Logger.WriteLog("Finished.");
    }

    // Method to extract date from the givem file path
    public static string getDate(string filepath) {

        // Split the file path to get hierarchy of folders.
        string[] folders = filepath.Split("\\");

        // Get the required folder names.
        string year = folders.GetValue(6).ToString();
        string month = folders.GetValue(7).ToString();
        string day = folders.GetValue(8).ToString();

        // Make the final string in proper date format.
        string date = "," + year + "/" + month + "/" + day;
        return date;
    }
}
