//using System;
//using System.IO;
//using Microsoft.VisualBasic.FileIO;

//namespace Assignment1
//{


//    public class DirWalker
//    {
//        int valid_row_counter = 0;
//        int skipped_row_counter = 0;
//        public void walk(String path)
//        {
//            string[] list = Directory.GetDirectories(path);


//            if (list == null) return;

//            foreach (string dirpath in list)
//            {
//                if (Directory.Exists(dirpath))
//                {
//                    walk(dirpath);
//                    Console.WriteLine("Dir:" + dirpath);
//                }
//            }
//            string[] fileList = Directory.GetFiles(path);
//            foreach (string filepath in fileList)
//            {

//                Console.WriteLine("File:" + filepath);
//                TextFieldParser parser = new TextFieldParser(filepath);

//                parser.TextFieldType = FieldType.Delimited;
//                parser.SetDelimiters(",");
//                while (!parser.EndOfData)
//                {
//                    string[] fields = parser.ReadFields();
//                    if (fields.GetValue(0).Equals("First Name"))
//                    {
//                        continue;
//                    }
//                    if ((fields.GetValue(0).Equals("")) && (fields.GetValue(1).Equals("")))
//                    {
//                        skipped_row_counter++;
//                        continue;
//                    }
//                    //Console.WriteLine(string.Join(",", fields));
//                    using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\pandu\\Downloads\\output.csv", true))
//                    {
//                        file.WriteLine(fields);
//                    }

//                }
//            }
//        }

//        public static void Main(String[] args)
//        {

//            string[] csv_header = { "First Name", "Last Name", "Street Number", "Street", "City", "Province", "Postal Code", "Country", "Phone Number", "Email Address" };
//            using (System.IO.StreamWriter file = new System.IO.StreamWriter("C:\\Users\\pandu\\Downloads\\output.csv", false))
//            {
//                file.WriteLine(string.Join(",", csv_header));
//            }
//            DirWalker fw = new DirWalker();
//            fw.walk("C:\\Users\\pandu\\Downloads\\Sample Data\\Sample Data");


//        }

//    }
//}