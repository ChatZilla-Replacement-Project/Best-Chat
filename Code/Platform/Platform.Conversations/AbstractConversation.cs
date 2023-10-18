namespace BestChat.Platform.Conversations
{
	public abstract class AbstractConversation : IViewOrConversation, System.ComponentModel
		.INotifyPropertyChanged
	{
		#region Constructors & Deconstructors
			public AbstractConversation()
			{
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public abstract event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
		#endregion

		#region Constants
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private readonly System.Collections.Generic.SortedDictionary<System.DateTime, IEventInfo>
				mapEventsByTime = new();

			private readonly System.Collections.ObjectModel.ObservableCollection<IEventInfo> ocEvents = new
				();
		#endregion

		#region Properties
			public abstract string Name
			{
				get;
			}

			public abstract string ProperName
			{
				get;
			}

			public abstract string SafeName
			{
				get;
			}

			public abstract string Path
			{
				get;
			}

			public System.Collections.Generic.IReadOnlyDictionary<System.DateTime, IEventInfo>
				AllEventsByWhenTheyHappened => mapEventsByTime;

			public System.Collections.Generic.IReadOnlyList<IEventInfo> UnsortedEvents => ocEvents;
		#endregion

		#region Methods
			protected abstract void FirePropChanged(string strPropName);
		#endregion

		#region Event Handlers
		#endregion
	}
}