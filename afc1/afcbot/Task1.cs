using System;
using System.Collections.Generic;
using DotNetWikiBot;
using System.Threading;

namespace afcbot
{
	public class Task1
	{
			public static Thread thread;
			public static void Init()
			{
				MainClass.DebugLog("Task 1");
				thread = new Thread(exec);
				thread.Start();
				MainClass.Log("Task 1 initialized");
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
			int processed = 1;
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
					if ( afc.text == null ||
					    afc.text.Contains("REDIRECT") ||
					    afc.text.Contains("{{AFC") ||
					    afc.text.Contains("{{WPAFC") ||
					                  afc.text == "" ||
					    afc.text.Contains("[[Category:AfC_submissions_with_missing_AfC_template]]")
					                 )
					{
						MainClass.DebugLog("OK:" + c);
						System.IO.File.AppendAllText("resultsig", c + "\n");
					}
					else
					{
						MainClass.DebugLog("Category missing:"  + c);
						afc.text = afc.text + "\n[[Category:AfC_submissions_with_missing_AfC_template]]";
						afc.Save(afc.text, "Bot: inserting [[Category:AfC_submissions_with_missing_AfC_template]]", false);
						processed++;
						System.IO.File.AppendAllText("results", c + "\n");
						if (processed > 100)
						{
							MainClass.DebugLog("Finished for today");
							return;
						}
					}
				}
				catch (Exception fail)
				{
					Console.WriteLine(fail.ToString());
					System.IO.File.AppendAllText("errors", c + Environment.NewLine);
				}
			}
			MainClass.Log("end");
		}
	}
}

