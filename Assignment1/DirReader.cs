using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
public class DirReader
{
	public static List<string> getFileNames()
	{
        List<string> filenames = new List<string>();

        string mainDir = "C:\\Users\\pandu\\Downloads\\Sample Data\\Sample Data";
        try
        {
            foreach (string firstlevel in Directory.GetDirectories(mainDir))
            {

                foreach (string secondlevel in Directory.GetDirectories(firstlevel))
                {


                    foreach (string thirdlevel in Directory.GetDirectories(secondlevel))
                    {

                        foreach (string file in Directory.GetFiles(thirdlevel))
                        {
                            filenames.Add(file);
                        }
                    }
                }
            }
        }
        catch(Exception e) {
            Logger.WriteLog(e.Message);
        }
        return filenames;
    }
}
