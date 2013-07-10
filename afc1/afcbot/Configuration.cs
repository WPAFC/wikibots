using System;

namespace afcbot
{
	public class Configuration
	{
		public static string UserName = "ArticlesForCreationBot";
		public static string Password = "";

		public static void Read()
		{
			if (!System.IO.File.Exists ("system.cfg"))
			{
				MainClass.Log ("Unable to find the config file!");
				Environment.Exit (2);
			}
			string[] f = System.IO.File.ReadAllLines ("system.cfg");
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

