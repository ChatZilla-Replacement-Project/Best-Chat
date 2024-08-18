namespace BestChat.ProtocolDef
{
	public interface IProtocolDef
	{
		string Name
		{
			get;
		}

		string Publisher
		{
			get;
		}

		System.Uri Homepage
		{
			get;
		}

		System.Uri PublisherHomepage
		{
			get;
		}
	}
}