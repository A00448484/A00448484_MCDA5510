using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
public class DirReader
{
	public static List<string> getFileNames()
	{
        List<string> filenames = new List<string>();

        // Initial path to start collecting the file names.
        string mainDir = "C:\\Users\\pandu\\Downloads\\Sample Data\\Sample Data";
        try
        {
            foreach (string firstlevel in Directory.GetDirectories(mainDir))
            {
                // Subfolder (Year)

                foreach (string secondlevel in Directory.GetDirectories(firstlevel))
                {
                    // Subfolder (Month)

                    foreach (string thirdlevel in Directory.GetDirectories(secondlevel))
                    {
                           // Subfolder (Date)

                        foreach (string file in Directory.GetFiles(thirdlevel))
                        {
                            filenames.Add(file);
                        }
                    }
                }
            }
        }
        catch(Exception e) {
            Logger.WriteLog($"ERROR - {e.Message}");
        }
        // Return all the filnames in a list.
        return filenames;
    }
}
