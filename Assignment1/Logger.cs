using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;


	public static class Logger
	{
		public static void WriteLog(string logMessage)
		{
			string filepath = "C:\\Users\\pandu\\source\\repos\\A00448484_MCDA5510\\Assignment1\\logs\\logs.txt";
			using (StreamWriter logwriter = new StreamWriter(filepath, true))
			{
				logwriter.WriteLine($"{DateTime.Now} : {logMessage}");
			}
		}
	}

