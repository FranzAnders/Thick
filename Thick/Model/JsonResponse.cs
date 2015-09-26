using System;

namespace Thick
{
	public class JsonResponse
	{
		public string Status{ get; set;}
		public string Code { get; set; }
		public string Message { get; set;}
		public UserData Data { get; set;}
		public JsonResponse ()
		{
		}
	}
}

