// Ignore Spelling: IRC

namespace BestChat.IRC.ModuleInterfaces
{
	public interface INetwork
	{
		string Name
		{
			get;
		}

		System.Uri? Homepage
		{
			get;
		}

		System.Collections.Generic.IEnumerable<string> EnabledServerDomainsInSearchOrder
		{
			get;
		}
	}
}