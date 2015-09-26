using System;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using System.Net.Http;
using System.Threading.Tasks;

namespace Thick
{
	class RequestObj{
		public string phone {get;set;}
	}
	public class Communication
	{
		RestClient client;

		public Communication ()
		{
			client = new RestClient ("http://default-environment-p2xuz7zxhf.elasticbeanstalk.com/");
			client.AddHandler ("application/json", new RestSharpJsonNetDeserializer ());
		}

		public async Task<JsonResponse> SendPhoneNumber(string phoneNumber) {
			RestRequest request = new RestRequest ("users/authenticate", HttpMethod.Post);
			request.AddParameter ("phone", phoneNumber);
			var response = await client.Execute<JsonResponse> (request).ConfigureAwait (false);
			return response.Data;
		}

		public async Task<JsonResponse> VerifyPhoneNumber(string phoneNumber, string verificationCode) {
			RestRequest request = new RestRequest ("users/verify", HttpMethod.Post);
			request.AddParameter ("phone", phoneNumber);
			request.AddParameter ("code", verificationCode);
			var response = await client.Execute<JsonResponse> (request).ConfigureAwait (false);
			return response.Data;
		}

		public async Task<JsonResponse> SaveName(string phoneNumber, string firstName, string lastName) {
			RestRequest request = new RestRequest ("users/saveName", HttpMethod.Post);
			request.AddParameter ("phone", phoneNumber);
			request.AddParameter ("fname", firstName);
			request.AddParameter ("lname", lastName);
			var response = await client.Execute<JsonResponse> (request).ConfigureAwait (false);
			return response.Data;
		}

		public async Task<JsonResponse> SaveGender(string phoneNumber, string gender) {
			RestRequest request = new RestRequest ("users/saveGender", HttpMethod.Post);
			request.AddParameter ("phone", phoneNumber);
			request.AddParameter ("gender", gender);
			var response = await client.Execute<JsonResponse> (request).ConfigureAwait (false);
			return response.Data;
		}
	}
}
