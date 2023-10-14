// Ignore Spelling: Defs

namespace BestChat.IRC.Data.Defs
{
	public interface IMode
	{
		public char ModeChar
		{
			get;
		}

		public LocalizedTextSystem Desc
		{
			get;
		}

		public bool NotAlwaysAvailable
		{
			get;
		}
	}
}