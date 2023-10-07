namespace BestChat.Platform.HttpClientOwner
{
	public interface IHttpClientOwner
	{
		System.Net.Http.HttpClient HttpClient
		{
			get;
		}
	}
}