//using System;
//using System.IO;
//using Microsoft.VisualBasic.FileIO;

//class Program
//{
//    static void Main()
//    {
//        var watch = System.Diagnostics.Stopwatch.StartNew();

//        //using 
//        int valid_row_counter = 0;
//        int skipped_row_counter = 0;
//        TextFieldParser parser = new TextFieldParser("C:\\Users\\pandu\\Downloads\\Sample Data\\Sample Data\\2017\\11\\8\\CustomerData13.csv");
//        string[] csv_header = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Postal Code", "Country", "Phone Number", "Email Address" };
//        using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\pandu\\Downloads\\output.csv", false))
//        {
//            file.WriteLine(string.Join(",", csv_header));
//        }
//        //{
//        parser.TextFieldType = FieldType.Delimited;
//        parser.SetDelimiters(",");
//        string[] list = Directory.GetDirectories("C:\\Users\\pandu\\Downloads\\Sample Data\\Sample Data");
//        Console.WriteLine(string.Join(",", list));
//        while (!parser.EndOfData)
//        {
//            string[] fields = parser.ReadFields();
//            if (fields.GetValue(0).Equals("First Name"))
//            {
//                continue;
//            }
//            if ((fields.GetValue(0).Equals("")) && (fields.GetValue(1).Equals("")))
//            {
//                skipped_row_counter++;
//                continue;
//            }
//            Console.WriteLine(string.Join(",", fields));
//            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\pandu\\Downloads\\output.csv", true))
//            {
//                valid_row_counter++;
                
//                file.WriteLine(string.Join(",", fields));
//            }

//        }
//        Console.WriteLine("Total valid rows: {0}", valid_row_counter.ToString());
//        Console.WriteLine("Total valid rows: {0}", skipped_row_counter.ToString());
//        watch.Stop();

//        var elapsedms = watch.ElapsedMilliseconds;
//        Console.WriteLine("Total execution time in milliseconds: {0}", elapsedms);
//    }
//}
