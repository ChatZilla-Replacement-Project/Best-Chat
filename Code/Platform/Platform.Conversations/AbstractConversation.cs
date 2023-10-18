namespace BestChat.Platform.Conversations
{
	public abstract class AbstractConversation : IViewOrConversation, System.ComponentModel
		.INotifyPropertyChanged
	{
		#region Constructors & Deconstructors
			public AbstractConversation(in string strName, in string strLongDesc)
			{
				Name = strName;
				LongDesc = strLongDesc;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
			public abstract event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;

			public abstract event Common.IDieable.OnDieing? evtDieing;
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
			public string Name
			{
				get;

				private init;
			}

			public abstract string ProperName
			{
				get;
			}

			public abstract string SafeName
			{
				get;
			}

			public abstract string LocalizedName
			{
				get;
			}

			public string LongDesc
			{
				get;

				private init;
			}

			public string LocalizedLongDesc
			{
				get;
			}

			public abstract string Path
			{
				get;
			}

			public abstract IViewOrConversation.Types Type
			{
				get;
			}

			public System.Collections.Generic.IReadOnlyDictionary<System.DateTime, IEventInfo>
				AllEventsByWhenTheyHappened => mapEventsByTime;

			public System.Collections.Generic.IReadOnlyList<IEventInfo> UnsortedEvents => ocEvents;

			public abstract string Icon
			{
				get;
			}
		#endregion

		#region Methods
			protected abstract void FirePropChanged(string strPropName);
		#endregion

		#region Event Handlers
		#endregion
	}
}