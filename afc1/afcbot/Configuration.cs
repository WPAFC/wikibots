using System;

namespace afcbot
{
	public class Configuration
	{
		public static string File = "system.cfg";
		public static string UserName = "ArticlesForCreationBot";
		public static string Password = "";

		public static void Read()
		{
			MainClass.DebugLog("Reading " + File);
			if (!System.IO.File.Exists (File))
			{
				MainClass.Log ("Unable to find the config file " + File);
				Environment.Exit (2);
			}
			string[] f = System.IO.File.ReadAllLines (File);
			foreach (string line in f)
			{
				if (line.StartsWith ("username="))
				{
					UserName = line.Substring ("username=".Length);
					continue;
				}

				if (line.StartsWith ("password="))
				{
					Password = line.Substring("username=".Length);
					continue;
				}
			}
		}
	}
}

