using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiInterfaceTestConsole
{
	class Program
	{
		private static string url = "http://localhost:5000";

		static void Main(string[] args)
		{
			Console.WriteLine(GetValues());
			Console.WriteLine(GetValueWithId());

			Console.ReadKey();
		}

		private static object GetValues()
		{
			using (var webClient = new CookieAwareWebClient())
			{
				webClient.Headers["Accept-Encoding"] = "UTF-8";
				webClient.Headers["Content-Type"] = "application/json";

				var arr = webClient.DownloadData(url + "/api/values");
				return Encoding.ASCII.GetString(arr);
			}
		}

		private static object GetValueWithId()
		{
			using (var webClient = new CookieAwareWebClient())
			{
				webClient.Headers["Accept-Encoding"] = "UTF-8";
				webClient.Headers["Content-Type"] = "application/json";

				var arr = webClient.DownloadData(url + "/api/values/12");
				return Encoding.ASCII.GetString(arr);
			}
		}
	}
}
