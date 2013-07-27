using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Data;
using DotNetWikiBot;

namespace afcbot
{
	public class Task4
	{
		public static Thread thread;
		public static void Init()
		{
			MainClass.DebugLog("Task 4");
			thread = new Thread(exec);
			thread.Start();
			MainClass.Log("Task 4 initialized");
		}

		public static void exec()
		{
			string[] line = System.IO.File.ReadAllLines("list");
			List<string> ignorelist = new List<string>();
			if (System.IO.File.Exists("resultsig"))
			{
				ignorelist.AddRange (System.IO.File.ReadAllLines("resultsig"));
			}
			if (System.IO.File.Exists("results"))
			{
				ignorelist.AddRange (System.IO.File.ReadAllLines("results"));
			}
			foreach (string c in line)
			{
				if (ignorelist.Contains(c))
				{
					continue;
				}
				try
				{
					Page afc = new Page(MainClass.en, "Wikipedia talk:" + c);
					afc.Load();
					if (afc.text.Contains("REDIRECT") || afc.text.Contains("{{AFC"))
					{
						MainClass.DebugLog("OK:" + c);
						System.IO.File.AppendAllText("resultsig", c + "\n");
					}
					else
					{
						MainClass.DebugLog("Template missing:"  + c);
						System.IO.File.AppendAllText("results", c + "\n");
					}
				}
				catch (Exception fail)
				{
					Console.WriteLine(fail.ToString());
					System.IO.File.AppendAllText("errors", c + "." + Environment.NewLine);
				}
		    }
			MainClass.Log("end");
		}
	}
}

