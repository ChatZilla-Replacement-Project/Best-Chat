namespace BestChat.Platform.Conversations
{
	public interface IGroup
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

		public System.Collections.Generic.IEnumerable<IViewOrConversation> Children
		{
			get;
		}
	}
}