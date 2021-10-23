using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;


	public static class Logger
	{
		// Method to write log messages in the text file.
		public static void WriteLog(string logMessage)
		{
			// Path of the text file.
			string filepath = "C:\\Users\\pandu\\source\\repos\\A00448484_MCDA5510\\Assignment1\\logs\\logs.txt";

			//Creating a stream writer to write into the file.
			using (StreamWriter logwriter = new StreamWriter(filepath, true))
			{
				// Writing the log message along with current system time.
				logwriter.WriteLine($"{DateTime.Now} : {logMessage}");
			}
		}
	}

