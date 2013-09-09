using System.Net;
using System;

namespace afcbot
{
	class MainClass
	{
		public static DotNetWikiBot.Site en = null;

		public static void Log(string text)
		{
			Console.WriteLine (DateTime.Now.ToString () + ": " + text);
		}

		public static void DebugLog(string text)
		{
			Log ("DEBUG: " + text);
		}

		public static void Main (string[] args)
		{
			Log ("Afc bot v. 2.0.0");
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
			Configuration.Read();
			Log ("Connecting to wiki");
			en = new DotNetWikiBot.Site("en.wikipedia.org", Configuration.UserName, Configuration.Password);
			Log ("Initializing all tasks");
			Task1.exec();
		}
	}
}
