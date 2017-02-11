using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace ApiInterfaceTestConsole
{
	public class CookieAwareWebClient : WebClient
	{
		public CookieContainer CookieContainer { get; set; }

		public CookieAwareWebClient()
		{
			CookieContainer = new CookieContainer();
		}

		public void SaveCookies(string filename)
		{
			var stream = File.Open(filename, FileMode.Create);
			var formatter = new BinaryFormatter();

			formatter.Serialize(stream, CookieContainer);
			stream.Close();
		}

		public void LoadCookies(string filename)
		{
			var stream = File.Open(filename, FileMode.Open);
			var formatter = new BinaryFormatter();

			CookieContainer = (CookieContainer)formatter.Deserialize(stream);
			stream.Close();
		}

		protected override WebRequest GetWebRequest(Uri address)
		{
			var request = base.GetWebRequest(address);

			var webRequest = request as HttpWebRequest;
			if (webRequest != null)
			{
				webRequest.CookieContainer = CookieContainer;
			}

			return request;
		}
	}
}
