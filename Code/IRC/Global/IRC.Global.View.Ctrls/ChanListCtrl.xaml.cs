// Ignore Spelling: Ctrl Chans

using System.Linq;

namespace BestChat.IRC.Global.View.Ctrls
{
	/// <summary>
	/// Interaction logic for ChanListCtrl.xaml
	/// </summary>
	public partial class ChanListCtrl : System.Windows.Controls.UserControl
	{
		#region Constructors & Deconstructors
			public ChanListCtrl() => InitializeComponent();
		#endregion

		#region Delegates
		#endregion

		#region Events
			public event System.Windows.RoutedEventHandler evtSelChanged
			{
				add => AddHandler(evtSelChangedEvent, value);

				remove => RemoveHandler(evtSelChangedEvent, value);
			}
		#endregion

		#region Constants
			#region Dependency Properties
				public static readonly System.Windows.DependencyProperty SelProperty = System.Windows
					.DependencyProperty.Register(nameof(Sel), typeof(string), typeof(ChanListCtrl), new
					System.Windows.UIPropertyMetadata(null, OnSelPropChanged, null,
					true));

				public static readonly System.Windows.DependencyProperty OwnerOfChansProperty = System.Windows
					.DependencyProperty.Register(nameof(OwnerOfChans), typeof(Data.ActiveNetwork),
					typeof(ChanListCtrl), new(OnOwnerOfChansPropChanged));
			#endregion

			#region Routed Events
				public static readonly System.Windows.RoutedEvent evtSelChangedEvent = System.Windows.EventManager
					.RegisterRoutedEvent(nameof(evtSelChanged), System.Windows.RoutingStrategy.Bubble, typeof(System
					.Windows.RoutedEventHandler), typeof(ChanListCtrl));
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private bool bChangingSelProp = false;
		#endregion

		#region Properties
			public string? Sel
			{
				get => (string?)GetValue(SelProperty);

				set => SetValue(SelProperty, value);
			}

			public Data.ActiveNetwork OwnerOfChans
			{
				get => (Data.ActiveNetwork)GetValue(OwnerOfChansProperty);

				set => SetValue(OwnerOfChansProperty, value);
			}
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
			private static void OnSelPropChanged(System.Windows.DependencyObject doSender, System.Windows
				.DependencyPropertyChangedEventArgs e)
			{
				if(doSender is ChanListCtrl ctrlSender && !ctrlSender.bChangingSelProp)
				{
					ctrlSender.RaiseEvent(new(evtSelChangedEvent, ctrlSender));

					ctrlSender.bChangingSelProp = true;

					if(ctrlSender.Sel == null)
						ctrlSender.cbChannel.SelectedIndex = -1;
					else
						ctrlSender.cbChannel.SelectedItem = ctrlSender.Sel.Remove(0, 1);

					ctrlSender.bChangingSelProp = false;
				}
			}

			private static void OnOwnerOfChansPropChanged(System.Windows.DependencyObject doSender, System
				.Windows.DependencyPropertyChangedEventArgs e)
			{
				if(doSender is ChanListCtrl ctrlSender)
				{
					Data.ActiveNetwork anetOwnerOfChans = ctrlSender.OwnerOfChans;

					foreach(Data.Chan chanCur in anetOwnerOfChans.ChildrenByName.Values.Where((Platform
							.Conversations.IGroupViewOrConversation gvc) => gvc is Data.Chan).Cast<Data.Chan>())
						ctrlSender.cbChannel.Items.Add(chanCur.ProperName.Remove(0, 1));
				}
			}

			private void OnCbSelChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
			{
				if(!bChangingSelProp)
				{
					bChangingSelProp = true;

					Sel = cbChannel.SelectedIndex > 0 ? cbChannel.SelectedItem + "#" : null;

					bChangingSelProp = false;
				}
			}
		#endregion
	}
}
