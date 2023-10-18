namespace BestChat.Platform.Conversations
{
	public interface IGroup : IGroupViewOrConversation, System.Collections.Specialized
		.INotifyCollectionChanged, TreeData.VisualTreeData.IChildOwner
	{
		public System.Collections.Generic.IReadOnlyDictionary<string, IGroupViewOrConversation> ChildrenByName
		{
			get;
		}

		public System.Collections.Generic.IEnumerable<IGroupViewOrConversation> UnsortedChildren
		{
			get;
		}
	}
}