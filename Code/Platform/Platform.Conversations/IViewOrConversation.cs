namespace BestChat.Platform.Conversations
{
	public interface IViewOrConversation
	{
		public string Name
		{
			get;
		}

		public string ProperName
		{
			get;
		}

		public string SafeName
		{
			get;
		}

		public string Path
		{
			get;
		}
	}
}