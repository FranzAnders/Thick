using System;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thick
{
	public class Communication
	{
		RestClient client;
		public Communication ()
		{
			client = new RestClient ("https://monchiz.com/api/user/order_detail/?order_id=3878");
			client.AddHandler ("application/json", new RestSharpJsonNetDeserializer ());
		}

		public async Task<JsonResponse> loadData() {
			RestRequest request = new RestRequest (HttpMethod.Get);
			var response = await client.Execute<JsonResponse> (request).ConfigureAwait (false);
			return response.Data;
		}
	}
}

