// Ignore Spelling: Ctrl Ctrls Ctnts

namespace BestChat.GUI.Ctrls
{
	public abstract class AbstractVisualTabCtrl : System.Windows.Controls.TabItem
	{
		#region Constructors & Deconstructors
			public AbstractVisualTabCtrl(in string strLocalizedShortName, in string strLocalizedLongDesc)
			{
				Header = LocalizedShortName = strLocalizedShortName;
				LocalizedLongDesc = strLocalizedLongDesc;

				Content = svCtnts;
			}
		#endregion

		#region Delegates
		#endregion

		#region Events
		#endregion

		#region Constants
			#region Dependency Properties
				public static readonly System.Windows.DependencyProperty CtntsProperty = System.Windows
					.DependencyProperty.Register(nameof(Ctnts), typeof(System.Windows.Controls.Control),
					typeof(AbstractVisualTabCtrl), new System.Windows.UIPropertyMetadata(null,
					OnCtntsPropChanged, null, true));
			#endregion

			#region Routed Events
			#endregion
		#endregion

		#region Helper Types
		#endregion

		#region Members
			private readonly System.Windows.Controls.ScrollViewer svCtnts = new();
		#endregion

		#region Properties
			public string LocalizedShortName
			{
				get;

				private init;
			}

			public string LocalizedLongDesc
			{
				get;

				private init;
			}

			public System.Windows.Controls.Control? Ctnts
			{
				get => (System.Windows.Controls.Control?)GetValue(CtntsProperty);

				set => SetValue(CtntsProperty, value);
			}
		#endregion

		#region Methods
		#endregion

		#region Event Handlers
			private static void OnCtntsPropChanged(System.Windows.DependencyObject doSender, System.Windows
				.DependencyPropertyChangedEventArgs ea)
			{
				if(doSender is AbstractVisualTabCtrl avtcSender && avtcSender.svCtnts.Content != avtcSender
						.Content)
					avtcSender.svCtnts.Content = avtcSender.Content;
			}
		#endregion
	}
}