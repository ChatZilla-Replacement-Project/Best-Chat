namespace BestChat.Platform.Conversations
{
	public interface IGroupViewOrConversation : TreeData.VisualTreeData.IItemInfo
	{
		string Name
		{
			get;
		}

		string ProperName
		{
			get;
		}

		string SafeName
		{
			get;
		}

		string LongDesc
		{
			get;
		}

		string Path
		{
			get;
		}
	}
}