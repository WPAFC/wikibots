using System;

namespace afcbot
{
	class MainClass
	{
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
			Configuration.Read();
		}
	}
}
